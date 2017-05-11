using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awesomium.Core;
using System.Text.RegularExpressions;

using static CourseWork.Manager;


namespace CourseWork
{
    public partial class Form1 : Form
    {
        public string KeyWordNotificationDefault = "К сожалению, мы ничего не ищем..";

        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            this.Icon = new Icon(PATH_TO_MAIN_ICON);
            InitializeComponent();
            MinimumSize = new Size(800, 600);

            this.MainOutput.JavascriptMessage += proceedJSMessage;
            this.zoomTextBox.Text = "100%";
            this.zoomTextBox.KeyPress += ZoomTextBox_OnChange;
            ZoomTrackBar.Value = 100;
            this.ZoomTrackBar.ValueChanged += ZoomTrackBar_ValueChanged;
            KeywordNotification.KeyPress += KeywordNotification_KeyPress;
            KeywordNotification.LostFocus += KeywordNotification_LostFocus;
        }

        private void KeywordNotification_LostFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text.Length == 0)
            {
                textBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                textBox.Text = KeyWordNotificationDefault;
            }
        }

        private void KeywordNotification_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text.Length == 0 && (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back))
                textBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            else
                textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchAndDisplay(textBox.Text);
            }
        }

        private void vertSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SplitContainer s = sender as SplitContainer;
            Files.LargeImageList = CreateListIcon(s.SplitterDistance > 306 ? 256 : s.SplitterDistance - 50);
        }

        private void ZoomTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            zoomTextBox.Text = (MainOutput.Zoom = (sender as TrackBar).Value).ToString() + "%";
        }

        private void ResetZoomBtn_Click(object sender, EventArgs e)
        {
            ZoomTrackBar.Value = 100;
        }

        private void ZoomTextBox_OnChange(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                var textBox = sender as TextBox;
                string numStr = Regex.Match(textBox.Text, @"\d+").Value;
                int newZoom;
                if (int.TryParse(numStr, out newZoom) && newZoom >= 50 && newZoom <= 350)
                {
                    ZoomTrackBar.Value = newZoom;
                    textBox.Text += "%";
                }
                else
                    textBox.Text = ZoomTrackBar.Value.ToString() + "%";
            }
        }

        private void OpenTestWindow_Click(object sender, EventArgs e)
        {
            Program.Tests.ShowDialog(this);
        }
    }
}
