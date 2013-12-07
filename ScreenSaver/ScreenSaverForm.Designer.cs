namespace ScreenSaver
{
    partial class ScreenSaverForm
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
            this.components = new System.ComponentModel.Container();
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.bisonPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bisonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bisonPictureBox
            // 
            this.bisonPictureBox.Image = global::ScreenSaver.Properties.Resources.BlackBison_Converted3;
            this.bisonPictureBox.Location = new System.Drawing.Point(229, 90);
            this.bisonPictureBox.Name = "bisonPictureBox";
            this.bisonPictureBox.Size = new System.Drawing.Size(270, 202);
            this.bisonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bisonPictureBox.TabIndex = 1;
            this.bisonPictureBox.TabStop = false;
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(787, 480);
            this.Controls.Add(this.bisonPictureBox);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScreenSaverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenSaverForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.bisonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.PictureBox bisonPictureBox;
    }
}

