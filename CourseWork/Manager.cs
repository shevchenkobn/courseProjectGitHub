using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Awesomium.Core;

using static CourseWork.Program;

namespace CourseWork
{
    static class Manager
    {
        static string GetPathToProject()
        {
                var arr = Directory.GetCurrentDirectory().Split('\\');
                string[] toProj = new string[arr.Length - 2];
                Array.Copy(Directory.GetCurrentDirectory().Split('\\'), toProj, arr.Length - 2);
                return string.Join("\\", toProj) + "\\"; // up from \bin\Debug
        }
        public static readonly string PathToProject = GetPathToProject();
        public static readonly string PathToInputFiles = PathToProject + @"inputFiles\";
        public static readonly string PathToInvolvedFiles = PathToProject + @"involvedFiles\";
        public static readonly string PathToTestsFiles = PathToProject + @"tests\";
        public static readonly string PathToSystemFiles = PathToProject;
        public static readonly string PathToInputFilesIcon = PathToSystemFiles + "icon.ico";
        public static readonly string PathToMainIcon = PathToSystemFiles + "appIcon.ico";
        public static readonly string PathToBuiltInJScript = PathToSystemFiles + "service.js";
        public static readonly string PathToJQueryScript = PathToSystemFiles + "jquery-3.2.1.min.js";
        public static readonly string PathToJSMarkScript = PathToSystemFiles + "jquery.mark.min.js";

        static string[] filePathes;
        static string openedFile;
        public static List<FileDetailed> FilesWithKeyword;
        public static TestQuestions CurrentTest;

        public static void UpdateFiles()
        {
            var tmp = new StringBuilder();
            tmp.Append("<script src=\"" + new Uri(PathToJQueryScript) + "\"></script>");
            tmp.Append("<script src=\"" + new Uri(PathToJSMarkScript) + "\"></script>");
            string jsFunc = tmp.Append("<script src=\"" + new Uri(PathToBuiltInJScript) + "\"></script>").ToString();
            string[] inputFiles = Directory.GetFiles(PathToInputFiles);

            Program.MainWindow.Files.LargeImageList = CreateListIcon(192);
            filePathes = new string[inputFiles.Length];
            for (int i = 0; i < inputFiles.Length; i++)
            {
                if (inputFiles[i].Split('.').Last() == "html")
                {
                    bool wrote = false;
                    var curr = new FileDetailed(inputFiles[i]);
                    string pathToInvolvedFile = PathToInvolvedFiles + curr.FileName;
                    filePathes[i] = pathToInvolvedFile;
                    if (!File.Exists(pathToInvolvedFile))
                        using (StreamReader reader = new StreamReader(inputFiles[i]))
                        using (StreamWriter writer = new StreamWriter(pathToInvolvedFile))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (!wrote && line.IndexOf("</head>") != -1)
                                {
                                    string[] linePieces = line.Split(new string[] { "</head>" }, 2, StringSplitOptions.None);
                                    var nLine = new StringBuilder();
                                    nLine.Append(linePieces[0]);
                                    nLine.Append(jsFunc + "</head>");
                                    if (linePieces.Length == 2)
                                        nLine.Append(linePieces[1]);
                                    line = nLine.ToString();
                                    wrote = true;
                                }
                                writer.WriteLine(line);
                            }
                        }

                    var item = new ListViewItem();
                    item.Text = item.ToolTipText = curr.Display;
                    item.Name = pathToInvolvedFile;
                    item.ImageKey = "icon";
                    Program.MainWindow.Files.Items.Add(item);
                }
            }
        }

        public static ImageList CreateListIcon(int size)
        {
            var icon = new ImageList();
            icon.ImageSize = new Size(size, size);
            icon.ColorDepth = ColorDepth.Depth32Bit;
            icon.Images.Add("icon", Bitmap.FromFile(PathToInputFilesIcon));
            return icon;
        }

        internal static void PrepareFoundList()
        {
            MainWindow.SuitableFiles.View = View.List;
            MainWindow.SuitableFiles.ItemSelectionChanged += ChangeOpenedFile;
            ImageList filesWithKeywordIcon = new ImageList();
            filesWithKeywordIcon.ImageSize = new Size(64, 64);
            filesWithKeywordIcon.ColorDepth = ColorDepth.Depth32Bit;
            filesWithKeywordIcon.Images.Add("icon", Image.FromFile(PathToInputFilesIcon));
            MainWindow.SuitableFiles.SmallImageList = filesWithKeywordIcon;
        }

        static bool isTextHightlighted = true;
        internal static void ChangeOpenedFile(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var files = (System.Windows.Forms.ListView)sender;
            OpenFile(files.Items[e.ItemIndex]);
            if (files.Name == "SuitableFiles")
            {
                Program.MainWindow.MainOutput.DocumentReady += HighlightText;
                isTextHightlighted = false;
            }
            openedFile = files.Items[e.ItemIndex].Name;
        }
        static void HighlightText(object sender, DocumentReadyEventArgs e)
        {
            if (!isTextHightlighted)
            {
                var param = new JSValue[2];
                param[0] = new JSValue(MainWindow.KeywordNotification.Text);
                param[1] = new JSValue(true);
                JSObject window = MainWindow.MainOutput.ExecuteJavascriptWithResult("window");
                window.InvokeAsync("markAll", param);
                isTextHightlighted = true;
            }
        }

        public static void OpenFile(ListViewItem item)
        {
            MainWindow.MainOutput.Source = new Uri(item.Name);
            MainWindow.CurrentFileName.Text = item.Text;
            openedFile = item.Name;
            MainWindow.MainOutput.Zoom = MainWindow.ZoomTrackBar.Value;
        }

        public static void SearchAndDisplay(string key)
        {
            SearchInFiles(key);
            MainWindow.KeywordNotification.ForeColor = System.Drawing.SystemColors.WindowText;
            MainWindow.KeywordNotification.Text = key;
            MainWindow.SuitableFiles.Clear();
            for (int i = 0; i < FilesWithKeyword.Count; i++)
                MainWindow.SuitableFiles.Items.Add(FilesWithKeyword[i].GetListViewItem("icon"));
        }

        public static void PrepareTests()
        {
            Program.Tests.ChooseTestListView.Items.Clear();
            string[] testsFiles = Directory.GetFiles(PathToTestsFiles);
            foreach (var fileName in testsFiles)
            {
                var curr = new FileDetailed(fileName);
                var item = new ListViewItem();
                item.Text = item.ToolTipText = curr.Display;
                item.Name = curr.Path;
                Program.Tests.ChooseTestListView.Items.Add(item);
            }
        }

        static void SearchInFiles(string key)
        {
            var goodFiles = new List<string>(filePathes.Length);
            for (int i = 0; i < filePathes.Length; i++)
                using (StreamReader reader = new StreamReader(filePathes[i]))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        if (line.Contains(key))
                        {
                            goodFiles.Add(filePathes[i]);
                            break;
                        }
                }
            FilesWithKeyword = new List<FileDetailed>();
            for (int i = 0; i < goodFiles.Count; i++)
                FilesWithKeyword.Add(new FileDetailed(goodFiles[i]));
        }

        internal static void ProceedJSMessage(JavascriptMessageEventArgs e)
        {
            string msg = e.Message;
            if (msg == "textIsClicked")
            {
                string key = e.Arguments[0];
                SearchAndDisplay(key);
            }
        }

        internal static void ClearQueryTextBox(object sender)
        {
            var button = (Button)sender;
            MainWindow.KeywordNotification.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            MainWindow.KeywordNotification.Text = MainWindow.KeyWordNotificationDefault;
            FilesWithKeyword = null;
            MainWindow.SuitableFiles.Items.Clear();
            JSValue[] param = new JSValue[0];
            JSObject window = MainWindow.MainOutput.ExecuteJavascriptWithResult("window");
            window.InvokeAsync("removeMarks", param);
        }

        internal static void OpenAndDisplayTest(string fileName)
        {
            try
            {
                CurrentTest = new TestQuestions(File.ReadAllLines(fileName));
                Tests.DisplayCurrentTest();
            }
            catch (Exception e)
            {
                Tests.ReturnToTestSelection();
                string msg = "An error occured:\r\n" +
                    e.GetType() + ": " + e.Message + "\r\n" +
                    "Please, choose another option.";
                MessageBox.Show(Tests, msg);
            }
        }
    }
}
