using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using static CourseWork.Manager;

namespace CourseWork
{
    public partial class TestsWindow : Form
    {
        public TestsWindow()
        {
            this.Icon = new Icon(PATH_TO_MAIN_ICON);
            InitializeComponent();
            TestingPanel.Visible = false;
        }

        private void TestsWindow_Load(object sender, EventArgs e)
        {
            PrepareTests();
        }

        private void StartTest_Click(object sender, EventArgs e)
        {
            OpenAndDisplayTest(ChooseTestListView.SelectedItems[0].Name);
        }

        public void DisplayCurrentTest()
        {
            TestingPanel.Visible = true;
            chooseTestPanel.Visible = false;
            UpdateTest(0);
        }

        private void UpdateTest(int indexOfQuestion)
        {
            if (indexOfQuestion < CurrentTest.Count)
            {
                if (testGroupBox.Controls.OfType<RadioButton>().Count()
                  != CurrentTest[0, TestLines.IndexerParams.VariantsNumber])
                    throw new ArgumentException("Not enough variants to proceed");
                testGroupBox.Text = "Вопрос " + (indexOfQuestion + 1).ToString() + " из " + CurrentTest.Count + ".";
                TestQuestion.Text = CurrentTest[indexOfQuestion];
                for (int i = 0; i < 4; i++)
                {
                    RadioButton c = testGroupBox.Controls["Variant" + i] as RadioButton;

                    c.Text = Convert.ToChar(0x410 + i) + ": " + CurrentTest[indexOfQuestion, i];
                }
            }
            else
            {
                MessageBox.Show(this, "Твой результат " + CurrentTest.Result + " из " + CurrentTest.Count + "баллов.");
                ReturnToTestSelection();
            }
        }

        public void ReturnToTestSelection()
        {
            TestingPanel.Visible = false;
            chooseTestPanel.Visible = true;
        }

        private void ConfirmTest_Click(object sender, EventArgs e)
        {
            RadioButton checkedButton = testGroupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (checkedButton != null)
            {
                int buttonIndex = Convert.ToInt32(Regex.Match(checkedButton.Name, "[0-9]+").Value);
                CurrentTest.MarkAsDone(buttonIndex);
                checkedButton.Checked = false;
                UpdateTest(CurrentTest.CurrentTask + 1);
            }
        }
    }
}
