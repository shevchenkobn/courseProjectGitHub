using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using Awesomium.Core;

using static CourseWork.Manager;

namespace CourseWork
{
    

    static class Program
    {
        
        internal static Form1 MainWindow;
        internal static TestsWindow Tests;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow = new Form1();
            Tests = new TestsWindow();
            UpdateFiles();
            
            MainWindow.Files.ItemSelectionChanged += Files_ItemSelectionChanged;
            OpenFile(MainWindow.Files.Items[0]);

            PrepareFoundList();
            MainWindow.ResetQuery.Click += Reset_Click;
            Application.Run(MainWindow);
        }
    }
}
