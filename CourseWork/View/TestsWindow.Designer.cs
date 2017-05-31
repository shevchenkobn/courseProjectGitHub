namespace CourseWork
{
    partial class TestsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chooseTestPanel = new System.Windows.Forms.Panel();
            this.ChooseTestListView = new System.Windows.Forms.ListView();
            this.StartTest = new System.Windows.Forms.Button();
            this.TestingPanel = new System.Windows.Forms.Panel();
            this.ConfirmTest = new System.Windows.Forms.Button();
            this.testGroupBox = new System.Windows.Forms.GroupBox();
            this.TestQuestion = new System.Windows.Forms.TextBox();
            this.Variant3 = new System.Windows.Forms.RadioButton();
            this.Variant2 = new System.Windows.Forms.RadioButton();
            this.Variant1 = new System.Windows.Forms.RadioButton();
            this.Variant0 = new System.Windows.Forms.RadioButton();
            this.chooseTestPanel.SuspendLayout();
            this.TestingPanel.SuspendLayout();
            this.testGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseTestPanel
            // 
            this.chooseTestPanel.Controls.Add(this.ChooseTestListView);
            this.chooseTestPanel.Controls.Add(this.StartTest);
            this.chooseTestPanel.Location = new System.Drawing.Point(-3, 0);
            this.chooseTestPanel.Name = "chooseTestPanel";
            this.chooseTestPanel.Size = new System.Drawing.Size(335, 413);
            this.chooseTestPanel.TabIndex = 0;
            // 
            // ChooseTestListView
            // 
            this.ChooseTestListView.Location = new System.Drawing.Point(13, 13);
            this.ChooseTestListView.Name = "ChooseTestListView";
            this.ChooseTestListView.Size = new System.Drawing.Size(309, 227);
            this.ChooseTestListView.TabIndex = 2;
            this.ChooseTestListView.UseCompatibleStateImageBehavior = false;
            this.ChooseTestListView.View = System.Windows.Forms.View.List;
            // 
            // StartTest
            // 
            this.StartTest.Location = new System.Drawing.Point(13, 376);
            this.StartTest.Name = "StartTest";
            this.StartTest.Size = new System.Drawing.Size(309, 23);
            this.StartTest.TabIndex = 1;
            this.StartTest.Text = "Начать тест";
            this.StartTest.UseVisualStyleBackColor = true;
            this.StartTest.Click += new System.EventHandler(this.StartTest_Click);
            // 
            // TestingPanel
            // 
            this.TestingPanel.Controls.Add(this.ConfirmTest);
            this.TestingPanel.Controls.Add(this.testGroupBox);
            this.TestingPanel.Location = new System.Drawing.Point(3, 0);
            this.TestingPanel.Name = "TestingPanel";
            this.TestingPanel.Size = new System.Drawing.Size(332, 413);
            this.TestingPanel.TabIndex = 3;
            // 
            // ConfirmTest
            // 
            this.ConfirmTest.Location = new System.Drawing.Point(13, 376);
            this.ConfirmTest.Name = "ConfirmTest";
            this.ConfirmTest.Size = new System.Drawing.Size(306, 23);
            this.ConfirmTest.TabIndex = 1;
            this.ConfirmTest.Text = "Я сделал(-а) свой выбор";
            this.ConfirmTest.UseVisualStyleBackColor = true;
            this.ConfirmTest.Click += new System.EventHandler(this.ConfirmTest_Click);
            // 
            // testGroupBox
            // 
            this.testGroupBox.Controls.Add(this.TestQuestion);
            this.testGroupBox.Controls.Add(this.Variant3);
            this.testGroupBox.Controls.Add(this.Variant2);
            this.testGroupBox.Controls.Add(this.Variant1);
            this.testGroupBox.Controls.Add(this.Variant0);
            this.testGroupBox.Location = new System.Drawing.Point(12, 28);
            this.testGroupBox.Name = "testGroupBox";
            this.testGroupBox.Size = new System.Drawing.Size(307, 288);
            this.testGroupBox.TabIndex = 0;
            this.testGroupBox.TabStop = false;
            // 
            // TestQuestion
            // 
            this.TestQuestion.Location = new System.Drawing.Point(33, 29);
            this.TestQuestion.Multiline = true;
            this.TestQuestion.Name = "TestQuestion";
            this.TestQuestion.ReadOnly = true;
            this.TestQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TestQuestion.Size = new System.Drawing.Size(251, 127);
            this.TestQuestion.TabIndex = 5;
            // 
            // Variant3
            // 
            this.Variant3.AutoSize = true;
            this.Variant3.Location = new System.Drawing.Point(33, 244);
            this.Variant3.Name = "Variant3";
            this.Variant3.Size = new System.Drawing.Size(64, 17);
            this.Variant3.TabIndex = 4;
            this.Variant3.TabStop = true;
            this.Variant3.Text = "Variant3";
            this.Variant3.UseVisualStyleBackColor = true;
            // 
            // Variant2
            // 
            this.Variant2.AutoSize = true;
            this.Variant2.Location = new System.Drawing.Point(33, 220);
            this.Variant2.Name = "Variant2";
            this.Variant2.Size = new System.Drawing.Size(64, 17);
            this.Variant2.TabIndex = 3;
            this.Variant2.TabStop = true;
            this.Variant2.Text = "Variant2";
            this.Variant2.UseVisualStyleBackColor = true;
            // 
            // Variant1
            // 
            this.Variant1.AutoSize = true;
            this.Variant1.Location = new System.Drawing.Point(33, 196);
            this.Variant1.Name = "Variant1";
            this.Variant1.Size = new System.Drawing.Size(64, 17);
            this.Variant1.TabIndex = 2;
            this.Variant1.TabStop = true;
            this.Variant1.Text = "Variant1";
            this.Variant1.UseVisualStyleBackColor = true;
            // 
            // Variant0
            // 
            this.Variant0.AutoSize = true;
            this.Variant0.Location = new System.Drawing.Point(33, 172);
            this.Variant0.Name = "Variant0";
            this.Variant0.Size = new System.Drawing.Size(64, 17);
            this.Variant0.TabIndex = 1;
            this.Variant0.TabStop = true;
            this.Variant0.Text = "Variant0";
            this.Variant0.UseVisualStyleBackColor = true;
            // 
            // TestsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.TestingPanel);
            this.Controls.Add(this.chooseTestPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 450);
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Name = "TestsWindow";
            this.Text = "Тесты по высшей математике";
            this.Load += new System.EventHandler(this.TestsWindow_Load);
            this.chooseTestPanel.ResumeLayout(false);
            this.TestingPanel.ResumeLayout(false);
            this.testGroupBox.ResumeLayout(false);
            this.testGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel chooseTestPanel;
        public System.Windows.Forms.Button StartTest;
        public System.Windows.Forms.ListView ChooseTestListView;
        private System.Windows.Forms.Panel TestingPanel;
        private System.Windows.Forms.Button ConfirmTest;
        private System.Windows.Forms.GroupBox testGroupBox;
        private System.Windows.Forms.RadioButton Variant3;
        private System.Windows.Forms.RadioButton Variant2;
        private System.Windows.Forms.RadioButton Variant1;
        private System.Windows.Forms.RadioButton Variant0;
        private System.Windows.Forms.TextBox TestQuestion;
    }
}