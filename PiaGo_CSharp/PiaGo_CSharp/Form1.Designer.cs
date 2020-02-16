namespace PiaGo_CSharp
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
            this.btnUser = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rbLearn = new System.Windows.Forms.RadioButton();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.rbJam = new System.Windows.Forms.RadioButton();
            this.btnCustomize = new System.Windows.Forms.Button();
            this.btnBT = new System.Windows.Forms.Button();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(12, 12);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(96, 23);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "Login / User info";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Classic Piano",
            "Trumpet",
            "..."});
            this.comboBox1.Location = new System.Drawing.Point(218, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // rbLearn
            // 
            this.rbLearn.AutoSize = true;
            this.rbLearn.Location = new System.Drawing.Point(6, 19);
            this.rbLearn.Name = "rbLearn";
            this.rbLearn.Size = new System.Drawing.Size(52, 17);
            this.rbLearn.TabIndex = 2;
            this.rbLearn.TabStop = true;
            this.rbLearn.Text = "Learn";
            this.rbLearn.UseVisualStyleBackColor = true;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.rbJam);
            this.gb1.Controls.Add(this.rbLearn);
            this.gb1.Location = new System.Drawing.Point(114, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(98, 77);
            this.gb1.TabIndex = 3;
            this.gb1.TabStop = false;
            // 
            // rbJam
            // 
            this.rbJam.AutoSize = true;
            this.rbJam.Location = new System.Drawing.Point(6, 42);
            this.rbJam.Name = "rbJam";
            this.rbJam.Size = new System.Drawing.Size(44, 17);
            this.rbJam.TabIndex = 3;
            this.rbJam.TabStop = true;
            this.rbJam.Text = "Jam";
            this.rbJam.UseVisualStyleBackColor = true;
            // 
            // btnCustomize
            // 
            this.btnCustomize.Location = new System.Drawing.Point(345, 10);
            this.btnCustomize.Name = "btnCustomize";
            this.btnCustomize.Size = new System.Drawing.Size(96, 23);
            this.btnCustomize.TabIndex = 4;
            this.btnCustomize.Text = "Customize keys";
            this.btnCustomize.UseVisualStyleBackColor = true;
            // 
            // btnBT
            // 
            this.btnBT.Location = new System.Drawing.Point(692, 12);
            this.btnBT.Name = "btnBT";
            this.btnBT.Size = new System.Drawing.Size(96, 23);
            this.btnBT.TabIndex = 5;
            this.btnBT.Text = "BLOOTOOT";
            this.btnBT.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBT);
            this.Controls.Add(this.btnCustomize);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rbLearn;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.RadioButton rbJam;
        private System.Windows.Forms.Button btnCustomize;
        private System.Windows.Forms.Button btnBT;
    }
}

