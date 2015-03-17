namespace JapanExample
{
    partial class MainForm
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
            this._scMain = new System.Windows.Forms.SplitContainer();
            this._rtbOutput = new System.Windows.Forms.RichTextBox();
            this._msMain = new System.Windows.Forms.MenuStrip();
            this._ssMain = new System.Windows.Forms.StatusStrip();
            this._rtbInput = new System.Windows.Forms.RichTextBox();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guessTheNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._scMain)).BeginInit();
            this._scMain.Panel1.SuspendLayout();
            this._scMain.Panel2.SuspendLayout();
            this._scMain.SuspendLayout();
            this._msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _scMain
            // 
            this._scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._scMain.Location = new System.Drawing.Point(0, 0);
            this._scMain.Name = "_scMain";
            this._scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _scMain.Panel1
            // 
            this._scMain.Panel1.Controls.Add(this._rtbOutput);
            this._scMain.Panel1.Controls.Add(this._msMain);
            // 
            // _scMain.Panel2
            // 
            this._scMain.Panel2.Controls.Add(this._ssMain);
            this._scMain.Panel2.Controls.Add(this._rtbInput);
            this._scMain.Size = new System.Drawing.Size(392, 333);
            this._scMain.SplitterDistance = 288;
            this._scMain.TabIndex = 0;
            this._scMain.TabStop = false;
            // 
            // _rtbOutput
            // 
            this._rtbOutput.BackColor = System.Drawing.SystemColors.Window;
            this._rtbOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this._rtbOutput.DetectUrls = false;
            this._rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbOutput.Location = new System.Drawing.Point(0, 24);
            this._rtbOutput.Name = "_rtbOutput";
            this._rtbOutput.ReadOnly = true;
            this._rtbOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this._rtbOutput.Size = new System.Drawing.Size(392, 264);
            this._rtbOutput.TabIndex = 5;
            this._rtbOutput.TabStop = false;
            this._rtbOutput.Text = "";
            // 
            // _msMain
            // 
            this._msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem});
            this._msMain.Location = new System.Drawing.Point(0, 0);
            this._msMain.Name = "_msMain";
            this._msMain.Size = new System.Drawing.Size(392, 24);
            this._msMain.TabIndex = 5;
            this._msMain.Text = "menuStrip1";
            // 
            // _ssMain
            // 
            this._ssMain.Location = new System.Drawing.Point(0, 19);
            this._ssMain.Name = "_ssMain";
            this._ssMain.Size = new System.Drawing.Size(392, 22);
            this._ssMain.TabIndex = 5;
            this._ssMain.Text = "statusStrip1";
            // 
            // _rtbInput
            // 
            this._rtbInput.DetectUrls = false;
            this._rtbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbInput.Location = new System.Drawing.Point(0, 0);
            this._rtbInput.Multiline = false;
            this._rtbInput.Name = "_rtbInput";
            this._rtbInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this._rtbInput.Size = new System.Drawing.Size(392, 41);
            this._rtbInput.TabIndex = 0;
            this._rtbInput.Text = "";
            this._rtbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this._rtbInput_KeyDown);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examplesToolStripMenuItem});
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // examplesToolStripMenuItem
            // 
            this.examplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guessTheNumberToolStripMenuItem});
            this.examplesToolStripMenuItem.Name = "examplesToolStripMenuItem";
            this.examplesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.examplesToolStripMenuItem.Text = "Examples";
            // 
            // guessTheNumberToolStripMenuItem
            // 
            this.guessTheNumberToolStripMenuItem.Name = "guessTheNumberToolStripMenuItem";
            this.guessTheNumberToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.guessTheNumberToolStripMenuItem.Text = "Guess the Number";
            this.guessTheNumberToolStripMenuItem.Click += new System.EventHandler(this.guessTheNumberToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 333);
            this.Controls.Add(this._scMain);
            this.MainMenuStrip = this._msMain;
            this.MinimumSize = new System.Drawing.Size(112, 132);
            this.Name = "MainForm";
            this.Text = "Japan";
            this._scMain.Panel1.ResumeLayout(false);
            this._scMain.Panel1.PerformLayout();
            this._scMain.Panel2.ResumeLayout(false);
            this._scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scMain)).EndInit();
            this._scMain.ResumeLayout(false);
            this._msMain.ResumeLayout(false);
            this._msMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _scMain;
        private System.Windows.Forms.RichTextBox _rtbOutput;
        private System.Windows.Forms.MenuStrip _msMain;
        private System.Windows.Forms.StatusStrip _ssMain;
        private System.Windows.Forms.RichTextBox _rtbInput;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guessTheNumberToolStripMenuItem;
    }
}

