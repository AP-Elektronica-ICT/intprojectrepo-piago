namespace PiaGo_CSharp
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbSignUp = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbLogIn = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.metroSMUser = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbSignUp.SuspendLayout();
            this.gbLogIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroSMUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(404, 10);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(156, 63);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbSignUp
            // 
            this.gbSignUp.Controls.Add(this.button1);
            this.gbSignUp.Controls.Add(this.label3);
            this.gbSignUp.Controls.Add(this.label2);
            this.gbSignUp.Controls.Add(this.label1);
            this.gbSignUp.Location = new System.Drawing.Point(12, 10);
            this.gbSignUp.Name = "gbSignUp";
            this.gbSignUp.Size = new System.Drawing.Size(386, 339);
            this.gbSignUp.TabIndex = 1;
            this.gbSignUp.TabStop = false;
            this.gbSignUp.Text = "SIGN UP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Sign Up!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // gbLogIn
            // 
            this.gbLogIn.Controls.Add(this.label6);
            this.gbLogIn.Controls.Add(this.button2);
            this.gbLogIn.Controls.Add(this.label5);
            this.gbLogIn.Controls.Add(this.label4);
            this.gbLogIn.Location = new System.Drawing.Point(566, 10);
            this.gbLogIn.Name = "gbLogIn";
            this.gbLogIn.Size = new System.Drawing.Size(406, 339);
            this.gbLogIn.TabIndex = 2;
            this.gbLogIn.TabStop = false;
            this.gbLogIn.Text = "LOG IN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Google logo";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Log In";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email";
            // 
            // metroSMUser
            // 
            this.metroSMUser.Owner = this;
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 361);
            this.Controls.Add(this.gbLogIn);
            this.Controls.Add(this.gbSignUp);
            this.Controls.Add(this.pbLogo);
            this.MaximizeBox = false;
            this.Name = "StartScreen";
            this.Text = "TitleScreen";
            this.Load += new System.EventHandler(this.StartScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbSignUp.ResumeLayout(false);
            this.gbSignUp.PerformLayout();
            this.gbLogIn.ResumeLayout(false);
            this.gbLogIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroSMUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbSignUp;
        private System.Windows.Forms.GroupBox gbLogIn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Components.MetroStyleManager metroSMUser;
    }
}