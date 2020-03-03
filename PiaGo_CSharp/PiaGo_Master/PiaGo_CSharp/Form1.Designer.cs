namespace PiaGo_CSharp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer keyboardXiable.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.canvas = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCustomize = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.rbJam = new System.Windows.Forms.RadioButton();
            this.rbLearn = new System.Windows.Forms.RadioButton();
            this.btnBT = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gb1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 104);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(984, 257);
            this.canvas.TabIndex = 6;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Classic Piano",
            "Trumpet",
            "..."});
            this.comboBox1.Location = new System.Drawing.Point(290, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // btnCustomize
            // 
            this.btnCustomize.Location = new System.Drawing.Point(417, 10);
            this.btnCustomize.Name = "btnCustomize";
            this.btnCustomize.Size = new System.Drawing.Size(96, 23);
            this.btnCustomize.TabIndex = 4;
            this.btnCustomize.Text = "Customize keys";
            this.btnCustomize.UseVisualStyleBackColor = true;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.rbJam);
            this.gb1.Controls.Add(this.rbLearn);
            this.gb1.Location = new System.Drawing.Point(186, 3);
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
            // btnBT
            // 
            this.btnBT.Location = new System.Drawing.Point(878, 14);
            this.btnBT.Name = "btnBT";
            this.btnBT.Size = new System.Drawing.Size(96, 23);
            this.btnBT.TabIndex = 5;
            this.btnBT.Text = "BLOOTOOT";
            this.btnBT.UseVisualStyleBackColor = true;
            this.btnBT.Click += new System.EventHandler(this.btnBT_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(3, 75);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(96, 23);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "Login / User info";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Controls.Add(this.btnUser);
            this.panel1.Controls.Add(this.btnBT);
            this.panel1.Controls.Add(this.gb1);
            this.panel1.Controls.Add(this.btnCustomize);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 104);
            this.panel1.TabIndex = 7;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(3, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(177, 68);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 9;
            this.pbLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 361);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PiaGo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnCustomize;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.RadioButton rbJam;
        private System.Windows.Forms.RadioButton rbLearn;
        private System.Windows.Forms.Button btnBT;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}

