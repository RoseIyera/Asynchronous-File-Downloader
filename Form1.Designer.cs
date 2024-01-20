using System;

namespace Asynchronous_File_Downloader
{
    partial class Form1
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
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.downloadBtn = new MaterialSkin.Controls.MaterialButton();
            this.progressLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Location = new System.Drawing.Point(203, 321);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(362, 5);
            this.materialProgressBar1.TabIndex = 0;
            this.materialProgressBar1.Click += new System.EventHandler(this.materialProgressBar1_Click);
            // 
            // downloadBtn
            // 
            this.downloadBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.downloadBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.downloadBtn.Depth = 0;
            this.downloadBtn.HighEmphasis = true;
            this.downloadBtn.Icon = null;
            this.downloadBtn.Location = new System.Drawing.Point(311, 227);
            this.downloadBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.downloadBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.downloadBtn.Size = new System.Drawing.Size(135, 36);
            this.downloadBtn.TabIndex = 1;
            this.downloadBtn.Text = "Download File";
            this.downloadBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.downloadBtn.UseAccentColor = false;
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Depth = 0;
            this.progressLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.progressLabel.Location = new System.Drawing.Point(346, 286);
            this.progressLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(63, 19);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "Progress";
            this.progressLabel.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // materialTextBox1
            // 
            this.materialTextBox1.AnimateReadOnly = false;
            this.materialTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox1.Depth = 0;
            this.materialTextBox1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox1.LeadingIcon = null;
            this.materialTextBox1.Location = new System.Drawing.Point(227, 153);
            this.materialTextBox1.MaxLength = 50;
            this.materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox1.Multiline = false;
            this.materialTextBox1.Name = "materialTextBox1";
            this.materialTextBox1.Size = new System.Drawing.Size(314, 50);
            this.materialTextBox1.TabIndex = 3;
            this.materialTextBox1.Text = "";
            this.materialTextBox1.TrailingIcon = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialTextBox1);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.materialProgressBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private MaterialSkin.Controls.MaterialButton downloadBtn;
        private MaterialSkin.Controls.MaterialLabel progressLabel;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
    }
}

