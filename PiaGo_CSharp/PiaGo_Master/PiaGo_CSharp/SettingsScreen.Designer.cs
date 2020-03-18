namespace PiaGo_CSharp
{
    partial class SettingsScreen
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
            this.btnChangeControlPanelBGImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangePianoBGImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChangeControlPanelBGImage
            // 
            this.btnChangeControlPanelBGImage.Location = new System.Drawing.Point(189, 12);
            this.btnChangeControlPanelBGImage.Name = "btnChangeControlPanelBGImage";
            this.btnChangeControlPanelBGImage.Size = new System.Drawing.Size(71, 23);
            this.btnChangeControlPanelBGImage.TabIndex = 0;
            this.btnChangeControlPanelBGImage.Text = "Open File";
            this.btnChangeControlPanelBGImage.UseVisualStyleBackColor = true;
            this.btnChangeControlPanelBGImage.Click += new System.EventHandler(this.btnChangeControlPanelBGImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Change control panel background:";
            // 
            // btnChangePianoBGImage
            // 
            this.btnChangePianoBGImage.Location = new System.Drawing.Point(189, 41);
            this.btnChangePianoBGImage.Name = "btnChangePianoBGImage";
            this.btnChangePianoBGImage.Size = new System.Drawing.Size(71, 23);
            this.btnChangePianoBGImage.TabIndex = 2;
            this.btnChangePianoBGImage.Text = "Open File";
            this.btnChangePianoBGImage.UseVisualStyleBackColor = true;
            this.btnChangePianoBGImage.Click += new System.EventHandler(this.btnChangePianoBGImage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Change piano background:";
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 230);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangePianoBGImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeControlPanelBGImage);
            this.Name = "SettingsScreen";
            this.Text = "SettingsScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangeControlPanelBGImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangePianoBGImage;
        private System.Windows.Forms.Label label2;
    }
}