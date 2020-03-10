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
            this.canvas.Location = new System.Drawing.Point(0, 128);
            this.canvas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1312, 316);
            this.canvas.TabIndex = 6;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(387, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnCustomize
            // 
            this.btnCustomize.Location = new System.Drawing.Point(556, 12);
            this.btnCustomize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCustomize.Name = "btnCustomize";
            this.btnCustomize.Size = new System.Drawing.Size(128, 28);
            this.btnCustomize.TabIndex = 4;
            this.btnCustomize.Text = "Customize keys";
            this.btnCustomize.UseVisualStyleBackColor = true;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.rbJam);
            this.gb1.Controls.Add(this.rbLearn);
            this.gb1.Location = new System.Drawing.Point(248, 4);
            this.gb1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb1.Size = new System.Drawing.Size(131, 95);
            this.gb1.TabIndex = 3;
            this.gb1.TabStop = false;
            // 
            // rbJam
            // 
            this.rbJam.AutoSize = true;
            this.rbJam.Location = new System.Drawing.Point(8, 52);
            this.rbJam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbJam.Name = "rbJam";
            this.rbJam.Size = new System.Drawing.Size(55, 21);
            this.rbJam.TabIndex = 3;
            this.rbJam.TabStop = true;
            this.rbJam.Text = "Jam";
            this.rbJam.UseVisualStyleBackColor = true;
            // 
            // rbLearn
            // 
            this.rbLearn.AutoSize = true;
            this.rbLearn.Location = new System.Drawing.Point(8, 23);
            this.rbLearn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbLearn.Name = "rbLearn";
            this.rbLearn.Size = new System.Drawing.Size(66, 21);
            this.rbLearn.TabIndex = 2;
            this.rbLearn.TabStop = true;
            this.rbLearn.Text = "Learn";
            this.rbLearn.UseVisualStyleBackColor = true;
            // 
            // btnBT
            // 
            this.btnBT.Location = new System.Drawing.Point(1171, 17);
            this.btnBT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBT.Name = "btnBT";
            this.btnBT.Size = new System.Drawing.Size(128, 28);
            this.btnBT.TabIndex = 5;
            this.btnBT.Text = "BLOOTOOT";
            this.btnBT.UseVisualStyleBackColor = true;
            this.btnBT.Click += new System.EventHandler(this.btnBT_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(4, 92);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(128, 28);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 128);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(4, 4);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(236, 84);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 9;
            this.pbLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 444);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

