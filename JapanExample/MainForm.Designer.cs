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
            ((System.ComponentModel.ISupportInitialize)(this._scMain)).BeginInit();
            this._scMain.Panel1.SuspendLayout();
            this._scMain.Panel2.SuspendLayout();
            this._scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _scMain
            // 
            this._scMain.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this._scMain.Size = new System.Drawing.Size(819, 589);
            this._scMain.SplitterDistance = 535;
            this._scMain.TabIndex = 0;
            // 
            // _rtbOutput
            // 
            this._rtbOutput.BackColor = System.Drawing.SystemColors.Window;
            this._rtbOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._rtbOutput.DetectUrls = false;
            this._rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbOutput.Location = new System.Drawing.Point(0, 24);
            this._rtbOutput.Name = "_rtbOutput";
            this._rtbOutput.ReadOnly = true;
            this._rtbOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this._rtbOutput.Size = new System.Drawing.Size(819, 511);
            this._rtbOutput.TabIndex = 1;
            this._rtbOutput.TabStop = false;
            this._rtbOutput.Text = "";
            // 
            // _msMain
            // 
            this._msMain.Location = new System.Drawing.Point(0, 0);
            this._msMain.Name = "_msMain";
            this._msMain.Size = new System.Drawing.Size(819, 24);
            this._msMain.TabIndex = 2;
            this._msMain.Text = "menuStrip1";
            // 
            // _ssMain
            // 
            this._ssMain.Location = new System.Drawing.Point(0, 28);
            this._ssMain.Name = "_ssMain";
            this._ssMain.Size = new System.Drawing.Size(819, 22);
            this._ssMain.TabIndex = 2;
            this._ssMain.Text = "statusStrip1";
            // 
            // _rtbInput
            // 
            this._rtbInput.DetectUrls = false;
            this._rtbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbInput.Location = new System.Drawing.Point(0, 0);
            this._rtbInput.Name = "_rtbInput";
            this._rtbInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._rtbInput.Size = new System.Drawing.Size(819, 50);
            this._rtbInput.TabIndex = 1;
            this._rtbInput.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 589);
            this.Controls.Add(this._scMain);
            this.MainMenuStrip = this._msMain;
            this.Name = "MainForm";
            this.Text = "Japan";
            this._scMain.Panel1.ResumeLayout(false);
            this._scMain.Panel1.PerformLayout();
            this._scMain.Panel2.ResumeLayout(false);
            this._scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scMain)).EndInit();
            this._scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _scMain;
        private System.Windows.Forms.RichTextBox _rtbOutput;
        private System.Windows.Forms.MenuStrip _msMain;
        private System.Windows.Forms.StatusStrip _ssMain;
        private System.Windows.Forms.RichTextBox _rtbInput;
    }
}

