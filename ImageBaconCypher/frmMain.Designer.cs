namespace ImageBaconCypher
{
    partial class frmMain
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
            this.grpSrcImage = new System.Windows.Forms.GroupBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.picSrcImage = new System.Windows.Forms.PictureBox();
            this.cmdSelectSrc = new System.Windows.Forms.Button();
            this.grpHdnMessage = new System.Windows.Forms.GroupBox();
            this.lblHdnMsgCharRemain = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();
            this.grpSrcImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSrcImage)).BeginInit();
            this.grpHdnMessage.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSrcImage
            // 
            this.grpSrcImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSrcImage.Controls.Add(this.btnParse);
            this.grpSrcImage.Controls.Add(this.picSrcImage);
            this.grpSrcImage.Controls.Add(this.cmdSelectSrc);
            this.grpSrcImage.Location = new System.Drawing.Point(3, 3);
            this.grpSrcImage.Name = "grpSrcImage";
            this.grpSrcImage.Size = new System.Drawing.Size(372, 359);
            this.grpSrcImage.TabIndex = 0;
            this.grpSrcImage.TabStop = false;
            this.grpSrcImage.Text = "Source Image";
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnParse.Location = new System.Drawing.Point(6, 330);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(140, 23);
            this.btnParse.TabIndex = 2;
            this.btnParse.Text = "Search for Hidden Text";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // picSrcImage
            // 
            this.picSrcImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSrcImage.Location = new System.Drawing.Point(6, 19);
            this.picSrcImage.Name = "picSrcImage";
            this.picSrcImage.Size = new System.Drawing.Size(360, 305);
            this.picSrcImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSrcImage.TabIndex = 1;
            this.picSrcImage.TabStop = false;
            // 
            // cmdSelectSrc
            // 
            this.cmdSelectSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectSrc.Location = new System.Drawing.Point(291, 330);
            this.cmdSelectSrc.Name = "cmdSelectSrc";
            this.cmdSelectSrc.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectSrc.TabIndex = 0;
            this.cmdSelectSrc.Text = "Select";
            this.cmdSelectSrc.UseVisualStyleBackColor = true;
            this.cmdSelectSrc.Click += new System.EventHandler(this.cmdSelectSrc_Click);
            // 
            // grpHdnMessage
            // 
            this.grpHdnMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHdnMessage.Controls.Add(this.chkEncrypt);
            this.grpHdnMessage.Controls.Add(this.lblHdnMsgCharRemain);
            this.grpHdnMessage.Controls.Add(this.textBox1);
            this.grpHdnMessage.Location = new System.Drawing.Point(3, 3);
            this.grpHdnMessage.Name = "grpHdnMessage";
            this.grpHdnMessage.Size = new System.Drawing.Size(370, 330);
            this.grpHdnMessage.TabIndex = 1;
            this.grpHdnMessage.TabStop = false;
            this.grpHdnMessage.Text = "Hidden Message";
            // 
            // lblHdnMsgCharRemain
            // 
            this.lblHdnMsgCharRemain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHdnMsgCharRemain.Location = new System.Drawing.Point(191, 314);
            this.lblHdnMsgCharRemain.Name = "lblHdnMsgCharRemain";
            this.lblHdnMsgCharRemain.Size = new System.Drawing.Size(173, 13);
            this.lblHdnMsgCharRemain.TabIndex = 1;
            this.lblHdnMsgCharRemain.Text = "Characters Remaining: 0";
            this.lblHdnMsgCharRemain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(358, 292);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(278, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save As";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpSrcImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpHdnMessage);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(758, 365);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 3;
            // 
            // chkEncrypt
            // 
            this.chkEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEncrypt.AutoSize = true;
            this.chkEncrypt.Location = new System.Drawing.Point(6, 313);
            this.chkEncrypt.Name = "chkEncrypt";
            this.chkEncrypt.Size = new System.Drawing.Size(88, 17);
            this.chkEncrypt.TabIndex = 3;
            this.chkEncrypt.Text = "Encrypt Data";
            this.chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 389);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "Image Stenographer";
            this.grpSrcImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSrcImage)).EndInit();
            this.grpHdnMessage.ResumeLayout(false);
            this.grpHdnMessage.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSrcImage;
        private System.Windows.Forms.PictureBox picSrcImage;
        private System.Windows.Forms.Button cmdSelectSrc;
        private System.Windows.Forms.GroupBox grpHdnMessage;
        private System.Windows.Forms.Label lblHdnMsgCharRemain;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkEncrypt;
    }
}

