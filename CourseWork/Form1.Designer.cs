using System.Diagnostics;

namespace CourseWork
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.vertSplitContainer = new System.Windows.Forms.SplitContainer();
            this.Files = new System.Windows.Forms.ListView();
            this.horSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MainOutput = new Awesomium.Windows.Forms.WebControl(this.components);
            this.openTestsWindow = new System.Windows.Forms.Button();
            this.zoomTextBox = new System.Windows.Forms.TextBox();
            this.KeywordNotification = new System.Windows.Forms.TextBox();
            this.resetZoomButton = new System.Windows.Forms.Button();
            this.CurrentFileName = new System.Windows.Forms.TextBox();
            this.currentFilesLabel = new System.Windows.Forms.Label();
            this.ResetQuery = new System.Windows.Forms.Button();
            this.keywordNotificationLabel = new System.Windows.Forms.Label();
            this.SuitableFiles = new System.Windows.Forms.ListView();
            this.ZoomTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.vertSplitContainer)).BeginInit();
            this.vertSplitContainer.Panel1.SuspendLayout();
            this.vertSplitContainer.Panel2.SuspendLayout();
            this.vertSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horSplitContainer)).BeginInit();
            this.horSplitContainer.Panel1.SuspendLayout();
            this.horSplitContainer.Panel2.SuspendLayout();
            this.horSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // vertSplitContainer
            // 
            this.vertSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vertSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vertSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.vertSplitContainer.Name = "vertSplitContainer";
            // 
            // vertSplitContainer.Panel1
            // 
            this.vertSplitContainer.Panel1.Controls.Add(this.Files);
            this.vertSplitContainer.Panel1MinSize = 100;
            // 
            // vertSplitContainer.Panel2
            // 
            this.vertSplitContainer.Panel2.Controls.Add(this.horSplitContainer);
            this.vertSplitContainer.Panel2MinSize = 600;
            this.vertSplitContainer.Size = new System.Drawing.Size(800, 600);
            this.vertSplitContainer.SplitterDistance = 148;
            this.vertSplitContainer.TabIndex = 1;
            this.vertSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.vertSplitContainer_SplitterMoved);
            // 
            // Files
            // 
            this.Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Files.FullRowSelect = true;
            this.Files.Location = new System.Drawing.Point(0, 0);
            this.Files.Margin = new System.Windows.Forms.Padding(24);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(144, 596);
            this.Files.TabIndex = 2;
            this.Files.UseCompatibleStateImageBehavior = false;
            // 
            // horSplitContainer
            // 
            this.horSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.horSplitContainer.Name = "horSplitContainer";
            this.horSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // horSplitContainer.Panel1
            // 
            this.horSplitContainer.Panel1.Controls.Add(this.MainOutput);
            this.horSplitContainer.Panel1MinSize = 430;
            // 
            // horSplitContainer.Panel2
            // 
            this.horSplitContainer.Panel2.Controls.Add(this.openTestsWindow);
            this.horSplitContainer.Panel2.Controls.Add(this.zoomTextBox);
            this.horSplitContainer.Panel2.Controls.Add(this.KeywordNotification);
            this.horSplitContainer.Panel2.Controls.Add(this.resetZoomButton);
            this.horSplitContainer.Panel2.Controls.Add(this.CurrentFileName);
            this.horSplitContainer.Panel2.Controls.Add(this.currentFilesLabel);
            this.horSplitContainer.Panel2.Controls.Add(this.ResetQuery);
            this.horSplitContainer.Panel2.Controls.Add(this.keywordNotificationLabel);
            this.horSplitContainer.Panel2.Controls.Add(this.SuitableFiles);
            this.horSplitContainer.Panel2.Controls.Add(this.ZoomTrackBar);
            this.horSplitContainer.Panel2MinSize = 135;
            this.horSplitContainer.Size = new System.Drawing.Size(648, 600);
            this.horSplitContainer.SplitterDistance = 430;
            this.horSplitContainer.TabIndex = 4;
            // 
            // MainOutput
            // 
            this.MainOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainOutput.Location = new System.Drawing.Point(0, 0);
            this.MainOutput.Size = new System.Drawing.Size(644, 426);
            this.MainOutput.TabIndex = 3;
            // 
            // OpenTestWindow
            // 
            this.openTestsWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openTestsWindow.Location = new System.Drawing.Point(537, 36);
            this.openTestsWindow.MaximumSize = new System.Drawing.Size(103, 23);
            this.openTestsWindow.MinimumSize = new System.Drawing.Size(103, 23);
            this.openTestsWindow.Name = "OpenTestWindow";
            this.openTestsWindow.Size = new System.Drawing.Size(103, 23);
            this.openTestsWindow.TabIndex = 14;
            this.openTestsWindow.Text = "Открыть тесты";
            this.openTestsWindow.UseVisualStyleBackColor = true;
            this.openTestsWindow.Click += new System.EventHandler(this.OpenTestWindow_Click);
            // 
            // zoomTextBox
            // 
            this.zoomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomTextBox.Location = new System.Drawing.Point(608, 11);
            this.zoomTextBox.Name = "zoomTextBox";
            this.zoomTextBox.Size = new System.Drawing.Size(31, 20);
            this.zoomTextBox.TabIndex = 13;
            // 
            // KeywordNotification
            // 
            this.KeywordNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeywordNotification.BackColor = System.Drawing.Color.WhiteSmoke;
            this.KeywordNotification.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.KeywordNotification.Location = new System.Drawing.Point(84, 38);
            this.KeywordNotification.Name = "KeywordNotification";
            this.KeywordNotification.Size = new System.Drawing.Size(226, 20);
            this.KeywordNotification.TabIndex = 5;
            // 
            // ResetZoomBtn
            // 
            this.resetZoomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.resetZoomButton.Location = new System.Drawing.Point(325, 8);
            this.resetZoomButton.MaximumSize = new System.Drawing.Size(97, 23);
            this.resetZoomButton.MinimumSize = new System.Drawing.Size(97, 23);
            this.resetZoomButton.Name = "ResetZoomBtn";
            this.resetZoomButton.Size = new System.Drawing.Size(97, 23);
            this.resetZoomButton.TabIndex = 12;
            this.resetZoomButton.Text = "Масштаб 100%";
            this.resetZoomButton.UseVisualStyleBackColor = true;
            this.resetZoomButton.Click += new System.EventHandler(this.ResetZoomBtn_Click);
            // 
            // CurrentFileName
            // 
            this.CurrentFileName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CurrentFileName.Enabled = false;
            this.CurrentFileName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CurrentFileName.Location = new System.Drawing.Point(84, 10);
            this.CurrentFileName.Name = "CurrentFileName";
            this.CurrentFileName.ReadOnly = true;
            this.CurrentFileName.Size = new System.Drawing.Size(226, 20);
            this.CurrentFileName.TabIndex = 9;
            // 
            // CurrentFileLabel
            // 
            this.currentFilesLabel.AutoSize = true;
            this.currentFilesLabel.Location = new System.Drawing.Point(2, 14);
            this.currentFilesLabel.Name = "CurrentFileLabel";
            this.currentFilesLabel.Size = new System.Drawing.Size(84, 13);
            this.currentFilesLabel.TabIndex = 8;
            this.currentFilesLabel.Text = "Текущий файл:";
            // 
            // ResetQuery
            // 
            this.ResetQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetQuery.Location = new System.Drawing.Point(325, 36);
            this.ResetQuery.MaximumSize = new System.Drawing.Size(97, 23);
            this.ResetQuery.MinimumSize = new System.Drawing.Size(97, 23);
            this.ResetQuery.Name = "ResetQuery";
            this.ResetQuery.Size = new System.Drawing.Size(97, 23);
            this.ResetQuery.TabIndex = 6;
            this.ResetQuery.Text = "Очистить";
            this.ResetQuery.UseVisualStyleBackColor = true;
            // 
            // KeywordNotificationLabel
            // 
            this.keywordNotificationLabel.AutoSize = true;
            this.keywordNotificationLabel.Location = new System.Drawing.Point(22, 41);
            this.keywordNotificationLabel.Name = "KeywordNotificationLabel";
            this.keywordNotificationLabel.Size = new System.Drawing.Size(47, 13);
            this.keywordNotificationLabel.Text = "Запрос:";
            // 
            // SuitableFiles
            // 
            this.SuitableFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SuitableFiles.Location = new System.Drawing.Point(-2, 65);
            this.SuitableFiles.Name = "SuitableFiles";
            this.SuitableFiles.Size = new System.Drawing.Size(648, 99);
            this.SuitableFiles.TabIndex = 7;
            this.SuitableFiles.UseCompatibleStateImageBehavior = false;
            // 
            // ZoomTrackBar
            // 
            this.ZoomTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomTrackBar.Location = new System.Drawing.Point(428, 6);
            this.ZoomTrackBar.Maximum = 350;
            this.ZoomTrackBar.Minimum = 50;
            this.ZoomTrackBar.Name = "ZoomTrackBar";
            this.ZoomTrackBar.Size = new System.Drawing.Size(174, 45);
            this.ZoomTrackBar.TabIndex = 3;
            this.ZoomTrackBar.TickFrequency = 20;
            this.ZoomTrackBar.Value = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.vertSplitContainer);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Справочник по высшей математике";
            this.vertSplitContainer.Panel1.ResumeLayout(false);
            this.vertSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vertSplitContainer)).EndInit();
            this.vertSplitContainer.ResumeLayout(false);
            this.horSplitContainer.Panel1.ResumeLayout(false);
            this.horSplitContainer.Panel2.ResumeLayout(false);
            this.horSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horSplitContainer)).EndInit();
            this.horSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer vertSplitContainer;
        private System.Windows.Forms.SplitContainer horSplitContainer;
        public System.Windows.Forms.ListView Files;
        public Awesomium.Windows.Forms.WebControl MainOutput;
        public System.Windows.Forms.ListView SuitableFiles;
        private System.Windows.Forms.Label keywordNotificationLabel;
        public System.Windows.Forms.TextBox KeywordNotification;
        public System.Windows.Forms.Button ResetQuery;
        public System.Windows.Forms.TextBox CurrentFileName;
        private System.Windows.Forms.Label currentFilesLabel;
        private System.Windows.Forms.Button resetZoomButton;
        public System.Windows.Forms.TrackBar ZoomTrackBar;
        private System.Windows.Forms.TextBox zoomTextBox;
        private System.Windows.Forms.Button openTestsWindow;
    }
}

