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
    public class FileDetailed
    {
        public string Path { get; set; }
        public string FileName { get { return Path.Split(new char[] { '\\', '\\' }).Last(); } }
        public string Display { get { return FileName.Split('.')[0]; } }
        public ListViewItem GetListViewItem(string iconId = null)
        {
            var item = new ListViewItem();
            item.Text = item.ToolTipText = Display;
            item.Name = Path;
            if (iconId != null)
                item.ImageKey = iconId;
            return item;
        }
        public override string ToString()
        {
            return Display;
        }
        public FileDetailed(string path)
        {
            Path = path;
        }
    }

    public class TestLines
    {
        public enum IndexerParams
        { VariantsNumber }
        private int result;
        public int Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value < 0 ? 0 : value;
            }
        }
        public string this[int i]
        {
            get
            {
                CurrentTask = i;
                return taskNames[i];
            }
        }
        public int this[int i, IndexerParams param]
        {
            get
            {
                if (param == IndexerParams.VariantsNumber)
                    return variants[i].Length;
                else
                    return 0;
            }
        }
        public string this[int i, int j]
        {
            get
            {
                return variants[i][j];
            }
        }
        public int Count { get { return taskNames.Length; } }
        public int CurrentTask { get; private set; }
        string[][] variants { get; }
        string[] taskNames { get; }
        int[] rightVariants { get; }
        public void MarkAsDone(int variantNumber)
        {
            if (variantNumber == rightVariants[CurrentTask])
                Result++;
        }
        public TestLines(string[] testInFileNotation)
        {
            if (testInFileNotation.Length == 0)
                throw new ArgumentException("No questions for test");
            CurrentTask = 0;
            variants = new string[testInFileNotation.Length][];
            rightVariants = new int[testInFileNotation.Length];
            taskNames = new string[testInFileNotation.Length];
            for (int i = 0; i < testInFileNotation.Length; i++)
            {
                string[] temp = testInFileNotation[i].Split(new string[] { ":::" }, StringSplitOptions.None);
                taskNames[i] = temp[0];
                variants[i] = temp[1].Split(new string[] { ";;;" }, StringSplitOptions.None);
                for (int j = 0; j < variants[i].Length; j++)
                {
                    if (variants[i][j][0] == '@' && variants[i][j][1] == '@')
                    {
                        variants[i][j] = variants[i][j].Substring(2);
                        rightVariants[i] = j;
                        break;
                    }
                }                
            }
        }
    }

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
        public static TestLines CurrentTest;

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
                CurrentTest = new TestLines(File.ReadAllLines(fileName));
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
