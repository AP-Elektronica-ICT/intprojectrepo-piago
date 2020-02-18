using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Multimedia.UI;

namespace PianoKeyDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PKDemoForm : System.Windows.Forms.Form
	{
        private Multimedia.UI.PianoKey pkeyDSharp1;
        private Multimedia.UI.PianoKey pkeyCSharp1;
        private Multimedia.UI.PianoKey pkeyE1;
        private Multimedia.UI.PianoKey pkeyD1;
        private Multimedia.UI.PianoKey pkeyC1;
        private Multimedia.UI.PianoKey pkeyFSharp1;
        private Multimedia.UI.PianoKey pkeyG1;
        private Multimedia.UI.PianoKey pkeyF1;
        private Multimedia.UI.PianoKey pkeyGSharp1;
        private Multimedia.UI.PianoKey pkeyA1;
        private Multimedia.UI.PianoKey pkeyASharp1;
        private Multimedia.UI.PianoKey pkeyB1;
        private Multimedia.UI.PianoKey pkeyCSharp2;
        private Multimedia.UI.PianoKey pkeyD2;
        private Multimedia.UI.PianoKey pkeyC2;
        private Multimedia.UI.PianoKey pkeyB2;
        private Multimedia.UI.PianoKey pkeyASharp2;
        private Multimedia.UI.PianoKey pkeyA2;
        private Multimedia.UI.PianoKey pkeyGSharp2;
        private Multimedia.UI.PianoKey pkeyFSharp2;
        private Multimedia.UI.PianoKey pkeyG2;
        private Multimedia.UI.PianoKey pkeyF2;
        private Multimedia.UI.PianoKey pkeyB4;
        private Multimedia.UI.PianoKey pkeyASharp4;
        private Multimedia.UI.PianoKey pkeyA4;
        private Multimedia.UI.PianoKey pkeyGSharp4;
        private Multimedia.UI.PianoKey pkeyFSharp4;
        private Multimedia.UI.PianoKey pkeyG4;
        private Multimedia.UI.PianoKey pkeyF4;
        private Multimedia.UI.PianoKey pkeyDSharp4;
        private Multimedia.UI.PianoKey pkeyCSharp4;
        private Multimedia.UI.PianoKey pkeyE4;
        private Multimedia.UI.PianoKey pkeyD4;
        private Multimedia.UI.PianoKey pkeyC4;
        private Multimedia.UI.PianoKey pkeyB3;
        private Multimedia.UI.PianoKey pkeyASharp3;
        private Multimedia.UI.PianoKey pkeyA3;
        private Multimedia.UI.PianoKey pkeyGSharp3;
        private Multimedia.UI.PianoKey pkeyFSharp3;
        private Multimedia.UI.PianoKey pkeyG3;
        private Multimedia.UI.PianoKey pkeyF3;
        private Multimedia.UI.PianoKey pkeyB5;
        private Multimedia.UI.PianoKey pkeyASharp5;
        private Multimedia.UI.PianoKey pkeyA5;
        private Multimedia.UI.PianoKey pkeyGSharp5;
        private Multimedia.UI.PianoKey pkeyFSharp5;
        private Multimedia.UI.PianoKey pkeyG5;
        private Multimedia.UI.PianoKey pkeyF5;
        private Multimedia.UI.PianoKey pkeyDSharp5;
        private Multimedia.UI.PianoKey pkeyCSharp5;
        private Multimedia.UI.PianoKey pkeyE5;
        private Multimedia.UI.PianoKey pkeyD5;
        private Multimedia.UI.PianoKey pkeyC5;
        private Multimedia.UI.PianoKey pkeyC6;
        private Multimedia.UI.PianoKey pkeyDSharp3;
        private Multimedia.UI.PianoKey pkeyCSharp3;
        private Multimedia.UI.PianoKey pkeyE3;
        private Multimedia.UI.PianoKey pkeyD3;
        private Multimedia.UI.PianoKey pkeyC3;
        private Multimedia.UI.PianoKey pkeyDSharp2;
        private Multimedia.UI.PianoKey pkeyE2;
        private System.Windows.Forms.Panel pnlPianoKeys;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private Multimedia.UI.PianoKey pianoKey1;
        private Multimedia.UI.PianoKey pianoKey2;
        private System.Windows.Forms.Label label2;
        private Multimedia.UI.PianoKey pianoKey3;
        private System.Windows.Forms.Label label3;
        private Multimedia.UI.PianoKey pkeyRect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private Multimedia.UI.PianoKey pianoKey4;
        private System.Windows.Forms.Label label5;
        private Multimedia.UI.PianoKey pianoKey5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Multimedia.UI.PianoKey pianoKey6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblKeyNumber;
        private System.Windows.Forms.Label label10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PKDemoForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            int noteNum = 1;

            foreach(Control ctrl in pnlPianoKeys.Controls)
            {
                if(ctrl is PianoKey)
                {
                    ctrl.Tag = noteNum;
                    noteNum++;
                }
            }
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pnlPianoKeys = new System.Windows.Forms.Panel();
            this.pkeyC1 = new Multimedia.UI.PianoKey();
            this.pkeyCSharp1 = new Multimedia.UI.PianoKey();
            this.pkeyD1 = new Multimedia.UI.PianoKey();
            this.pkeyDSharp1 = new Multimedia.UI.PianoKey();
            this.pkeyE1 = new Multimedia.UI.PianoKey();
            this.pkeyF1 = new Multimedia.UI.PianoKey();
            this.pkeyFSharp1 = new Multimedia.UI.PianoKey();
            this.pkeyG1 = new Multimedia.UI.PianoKey();
            this.pkeyGSharp1 = new Multimedia.UI.PianoKey();
            this.pkeyA1 = new Multimedia.UI.PianoKey();
            this.pkeyASharp1 = new Multimedia.UI.PianoKey();
            this.pkeyB1 = new Multimedia.UI.PianoKey();
            this.pkeyC2 = new Multimedia.UI.PianoKey();
            this.pkeyCSharp2 = new Multimedia.UI.PianoKey();
            this.pkeyD2 = new Multimedia.UI.PianoKey();
            this.pkeyDSharp2 = new Multimedia.UI.PianoKey();
            this.pkeyE2 = new Multimedia.UI.PianoKey();
            this.pkeyF2 = new Multimedia.UI.PianoKey();
            this.pkeyFSharp2 = new Multimedia.UI.PianoKey();
            this.pkeyG2 = new Multimedia.UI.PianoKey();
            this.pkeyGSharp2 = new Multimedia.UI.PianoKey();
            this.pkeyA2 = new Multimedia.UI.PianoKey();
            this.pkeyASharp2 = new Multimedia.UI.PianoKey();
            this.pkeyB2 = new Multimedia.UI.PianoKey();
            this.pkeyC3 = new Multimedia.UI.PianoKey();
            this.pkeyCSharp3 = new Multimedia.UI.PianoKey();
            this.pkeyD3 = new Multimedia.UI.PianoKey();
            this.pkeyDSharp3 = new Multimedia.UI.PianoKey();
            this.pkeyE3 = new Multimedia.UI.PianoKey();
            this.pkeyF3 = new Multimedia.UI.PianoKey();
            this.pkeyFSharp3 = new Multimedia.UI.PianoKey();
            this.pkeyG3 = new Multimedia.UI.PianoKey();
            this.pkeyGSharp3 = new Multimedia.UI.PianoKey();
            this.pkeyA3 = new Multimedia.UI.PianoKey();
            this.pkeyASharp3 = new Multimedia.UI.PianoKey();
            this.pkeyB3 = new Multimedia.UI.PianoKey();
            this.pkeyC4 = new Multimedia.UI.PianoKey();
            this.pkeyCSharp4 = new Multimedia.UI.PianoKey();
            this.pkeyD4 = new Multimedia.UI.PianoKey();
            this.pkeyDSharp4 = new Multimedia.UI.PianoKey();
            this.pkeyE4 = new Multimedia.UI.PianoKey();
            this.pkeyF4 = new Multimedia.UI.PianoKey();
            this.pkeyFSharp4 = new Multimedia.UI.PianoKey();
            this.pkeyG4 = new Multimedia.UI.PianoKey();
            this.pkeyGSharp4 = new Multimedia.UI.PianoKey();
            this.pkeyA4 = new Multimedia.UI.PianoKey();
            this.pkeyASharp4 = new Multimedia.UI.PianoKey();
            this.pkeyB4 = new Multimedia.UI.PianoKey();
            this.pkeyC5 = new Multimedia.UI.PianoKey();
            this.pkeyCSharp5 = new Multimedia.UI.PianoKey();
            this.pkeyD5 = new Multimedia.UI.PianoKey();
            this.pkeyDSharp5 = new Multimedia.UI.PianoKey();
            this.pkeyE5 = new Multimedia.UI.PianoKey();
            this.pkeyF5 = new Multimedia.UI.PianoKey();
            this.pkeyFSharp5 = new Multimedia.UI.PianoKey();
            this.pkeyG5 = new Multimedia.UI.PianoKey();
            this.pkeyGSharp5 = new Multimedia.UI.PianoKey();
            this.pkeyA5 = new Multimedia.UI.PianoKey();
            this.pkeyASharp5 = new Multimedia.UI.PianoKey();
            this.pkeyB5 = new Multimedia.UI.PianoKey();
            this.pkeyC6 = new Multimedia.UI.PianoKey();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pkeyRect = new Multimedia.UI.PianoKey();
            this.label3 = new System.Windows.Forms.Label();
            this.pianoKey3 = new Multimedia.UI.PianoKey();
            this.label2 = new System.Windows.Forms.Label();
            this.pianoKey2 = new Multimedia.UI.PianoKey();
            this.label1 = new System.Windows.Forms.Label();
            this.pianoKey1 = new Multimedia.UI.PianoKey();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pianoKey6 = new Multimedia.UI.PianoKey();
            this.label6 = new System.Windows.Forms.Label();
            this.pianoKey5 = new Multimedia.UI.PianoKey();
            this.label5 = new System.Windows.Forms.Label();
            this.pianoKey4 = new Multimedia.UI.PianoKey();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblKeyNumber = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlPianoKeys.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPianoKeys
            // 
            this.pnlPianoKeys.Controls.Add(this.pkeyC1);
            this.pnlPianoKeys.Controls.Add(this.pkeyCSharp1);
            this.pnlPianoKeys.Controls.Add(this.pkeyD1);
            this.pnlPianoKeys.Controls.Add(this.pkeyDSharp1);
            this.pnlPianoKeys.Controls.Add(this.pkeyE1);
            this.pnlPianoKeys.Controls.Add(this.pkeyF1);
            this.pnlPianoKeys.Controls.Add(this.pkeyFSharp1);
            this.pnlPianoKeys.Controls.Add(this.pkeyG1);
            this.pnlPianoKeys.Controls.Add(this.pkeyGSharp1);
            this.pnlPianoKeys.Controls.Add(this.pkeyA1);
            this.pnlPianoKeys.Controls.Add(this.pkeyASharp1);
            this.pnlPianoKeys.Controls.Add(this.pkeyB1);
            this.pnlPianoKeys.Controls.Add(this.pkeyC2);
            this.pnlPianoKeys.Controls.Add(this.pkeyCSharp2);
            this.pnlPianoKeys.Controls.Add(this.pkeyD2);
            this.pnlPianoKeys.Controls.Add(this.pkeyDSharp2);
            this.pnlPianoKeys.Controls.Add(this.pkeyE2);
            this.pnlPianoKeys.Controls.Add(this.pkeyF2);
            this.pnlPianoKeys.Controls.Add(this.pkeyFSharp2);
            this.pnlPianoKeys.Controls.Add(this.pkeyG2);
            this.pnlPianoKeys.Controls.Add(this.pkeyGSharp2);
            this.pnlPianoKeys.Controls.Add(this.pkeyA2);
            this.pnlPianoKeys.Controls.Add(this.pkeyASharp2);
            this.pnlPianoKeys.Controls.Add(this.pkeyB2);
            this.pnlPianoKeys.Controls.Add(this.pkeyC3);
            this.pnlPianoKeys.Controls.Add(this.pkeyCSharp3);
            this.pnlPianoKeys.Controls.Add(this.pkeyD3);
            this.pnlPianoKeys.Controls.Add(this.pkeyDSharp3);
            this.pnlPianoKeys.Controls.Add(this.pkeyE3);
            this.pnlPianoKeys.Controls.Add(this.pkeyF3);
            this.pnlPianoKeys.Controls.Add(this.pkeyFSharp3);
            this.pnlPianoKeys.Controls.Add(this.pkeyG3);
            this.pnlPianoKeys.Controls.Add(this.pkeyGSharp3);
            this.pnlPianoKeys.Controls.Add(this.pkeyA3);
            this.pnlPianoKeys.Controls.Add(this.pkeyASharp3);
            this.pnlPianoKeys.Controls.Add(this.pkeyB3);
            this.pnlPianoKeys.Controls.Add(this.pkeyC4);
            this.pnlPianoKeys.Controls.Add(this.pkeyCSharp4);
            this.pnlPianoKeys.Controls.Add(this.pkeyD4);
            this.pnlPianoKeys.Controls.Add(this.pkeyDSharp4);
            this.pnlPianoKeys.Controls.Add(this.pkeyE4);
            this.pnlPianoKeys.Controls.Add(this.pkeyF4);
            this.pnlPianoKeys.Controls.Add(this.pkeyFSharp4);
            this.pnlPianoKeys.Controls.Add(this.pkeyG4);
            this.pnlPianoKeys.Controls.Add(this.pkeyGSharp4);
            this.pnlPianoKeys.Controls.Add(this.pkeyA4);
            this.pnlPianoKeys.Controls.Add(this.pkeyASharp4);
            this.pnlPianoKeys.Controls.Add(this.pkeyB4);
            this.pnlPianoKeys.Controls.Add(this.pkeyC5);
            this.pnlPianoKeys.Controls.Add(this.pkeyCSharp5);
            this.pnlPianoKeys.Controls.Add(this.pkeyD5);
            this.pnlPianoKeys.Controls.Add(this.pkeyDSharp5);
            this.pnlPianoKeys.Controls.Add(this.pkeyE5);
            this.pnlPianoKeys.Controls.Add(this.pkeyF5);
            this.pnlPianoKeys.Controls.Add(this.pkeyFSharp5);
            this.pnlPianoKeys.Controls.Add(this.pkeyG5);
            this.pnlPianoKeys.Controls.Add(this.pkeyGSharp5);
            this.pnlPianoKeys.Controls.Add(this.pkeyA5);
            this.pnlPianoKeys.Controls.Add(this.pkeyASharp5);
            this.pnlPianoKeys.Controls.Add(this.pkeyB5);
            this.pnlPianoKeys.Controls.Add(this.pkeyC6);
            this.pnlPianoKeys.Location = new System.Drawing.Point(16, 48);
            this.pnlPianoKeys.Name = "pnlPianoKeys";
            this.pnlPianoKeys.Size = new System.Drawing.Size(406, 46);
            this.pnlPianoKeys.TabIndex = 0;
            // 
            // pkeyC1
            // 
            this.pkeyC1.KeyOffColor = System.Drawing.Color.White;
            this.pkeyC1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyC1.Location = new System.Drawing.Point(4, 2);
            this.pkeyC1.Name = "pkeyC1";
            this.pkeyC1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyC1.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyC1.Size = new System.Drawing.Size(12, 42);
            this.pkeyC1.TabIndex = 0;
            this.pkeyC1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyCSharp1
            // 
            this.pkeyCSharp1.BackColor = System.Drawing.Color.Black;
            this.pkeyCSharp1.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyCSharp1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyCSharp1.Location = new System.Drawing.Point(12, 2);
            this.pkeyCSharp1.Name = "pkeyCSharp1";
            this.pkeyCSharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyCSharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyCSharp1.Size = new System.Drawing.Size(8, 28);
            this.pkeyCSharp1.TabIndex = 3;
            this.pkeyCSharp1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyD1
            // 
            this.pkeyD1.KeyOffColor = System.Drawing.Color.White;
            this.pkeyD1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyD1.Location = new System.Drawing.Point(15, 2);
            this.pkeyD1.Name = "pkeyD1";
            this.pkeyD1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyD1.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyD1.Size = new System.Drawing.Size(12, 42);
            this.pkeyD1.TabIndex = 1;
            this.pkeyD1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyDSharp1
            // 
            this.pkeyDSharp1.BackColor = System.Drawing.Color.Black;
            this.pkeyDSharp1.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyDSharp1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyDSharp1.Location = new System.Drawing.Point(23, 2);
            this.pkeyDSharp1.Name = "pkeyDSharp1";
            this.pkeyDSharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyDSharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyDSharp1.Size = new System.Drawing.Size(8, 29);
            this.pkeyDSharp1.TabIndex = 4;
            this.pkeyDSharp1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyE1
            // 
            this.pkeyE1.KeyOffColor = System.Drawing.Color.White;
            this.pkeyE1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyE1.Location = new System.Drawing.Point(26, 2);
            this.pkeyE1.Name = "pkeyE1";
            this.pkeyE1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyE1.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyE1.Size = new System.Drawing.Size(12, 42);
            this.pkeyE1.TabIndex = 2;
            this.pkeyE1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyF1
            // 
            this.pkeyF1.KeyOffColor = System.Drawing.Color.White;
            this.pkeyF1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyF1.Location = new System.Drawing.Point(37, 2);
            this.pkeyF1.Name = "pkeyF1";
            this.pkeyF1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyF1.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyF1.Size = new System.Drawing.Size(12, 42);
            this.pkeyF1.TabIndex = 5;
            this.pkeyF1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyFSharp1
            // 
            this.pkeyFSharp1.BackColor = System.Drawing.Color.Black;
            this.pkeyFSharp1.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyFSharp1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyFSharp1.Location = new System.Drawing.Point(45, 2);
            this.pkeyFSharp1.Name = "pkeyFSharp1";
            this.pkeyFSharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyFSharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyFSharp1.Size = new System.Drawing.Size(8, 28);
            this.pkeyFSharp1.TabIndex = 7;
            this.pkeyFSharp1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyG1
            // 
            this.pkeyG1.KeyOffColor = System.Drawing.Color.White;
            this.pkeyG1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyG1.Location = new System.Drawing.Point(48, 2);
            this.pkeyG1.Name = "pkeyG1";
            this.pkeyG1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyG1.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyG1.Size = new System.Drawing.Size(12, 42);
            this.pkeyG1.TabIndex = 6;
            this.pkeyG1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyGSharp1
            // 
            this.pkeyGSharp1.BackColor = System.Drawing.Color.Black;
            this.pkeyGSharp1.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyGSharp1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyGSharp1.Location = new System.Drawing.Point(56, 2);
            this.pkeyGSharp1.Name = "pkeyGSharp1";
            this.pkeyGSharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyGSharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyGSharp1.Size = new System.Drawing.Size(8, 29);
            this.pkeyGSharp1.TabIndex = 8;
            this.pkeyGSharp1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyA1
            // 
            this.pkeyA1.KeyOffColor = System.Drawing.Color.White;
            this.pkeyA1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyA1.Location = new System.Drawing.Point(59, 2);
            this.pkeyA1.Name = "pkeyA1";
            this.pkeyA1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyA1.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyA1.Size = new System.Drawing.Size(12, 42);
            this.pkeyA1.TabIndex = 9;
            this.pkeyA1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyASharp1
            // 
            this.pkeyASharp1.BackColor = System.Drawing.Color.Black;
            this.pkeyASharp1.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyASharp1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyASharp1.Location = new System.Drawing.Point(67, 2);
            this.pkeyASharp1.Name = "pkeyASharp1";
            this.pkeyASharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyASharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyASharp1.Size = new System.Drawing.Size(8, 29);
            this.pkeyASharp1.TabIndex = 10;
            this.pkeyASharp1.Text = "pianoKey13";
            this.pkeyASharp1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyB1
            // 
            this.pkeyB1.KeyOffColor = System.Drawing.Color.White;
            this.pkeyB1.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyB1.Location = new System.Drawing.Point(70, 2);
            this.pkeyB1.Name = "pkeyB1";
            this.pkeyB1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyB1.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyB1.Size = new System.Drawing.Size(12, 42);
            this.pkeyB1.TabIndex = 11;
            this.pkeyB1.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyC2
            // 
            this.pkeyC2.KeyOffColor = System.Drawing.Color.White;
            this.pkeyC2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyC2.Location = new System.Drawing.Point(81, 2);
            this.pkeyC2.Name = "pkeyC2";
            this.pkeyC2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyC2.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyC2.Size = new System.Drawing.Size(12, 42);
            this.pkeyC2.TabIndex = 12;
            this.pkeyC2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyCSharp2
            // 
            this.pkeyCSharp2.BackColor = System.Drawing.Color.Black;
            this.pkeyCSharp2.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyCSharp2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyCSharp2.Location = new System.Drawing.Point(89, 2);
            this.pkeyCSharp2.Name = "pkeyCSharp2";
            this.pkeyCSharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyCSharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyCSharp2.Size = new System.Drawing.Size(8, 28);
            this.pkeyCSharp2.TabIndex = 15;
            this.pkeyCSharp2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyD2
            // 
            this.pkeyD2.KeyOffColor = System.Drawing.Color.White;
            this.pkeyD2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyD2.Location = new System.Drawing.Point(92, 2);
            this.pkeyD2.Name = "pkeyD2";
            this.pkeyD2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyD2.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyD2.Size = new System.Drawing.Size(12, 42);
            this.pkeyD2.TabIndex = 13;
            this.pkeyD2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyDSharp2
            // 
            this.pkeyDSharp2.BackColor = System.Drawing.Color.Black;
            this.pkeyDSharp2.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyDSharp2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyDSharp2.Location = new System.Drawing.Point(100, 2);
            this.pkeyDSharp2.Name = "pkeyDSharp2";
            this.pkeyDSharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyDSharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyDSharp2.Size = new System.Drawing.Size(8, 29);
            this.pkeyDSharp2.TabIndex = 16;
            this.pkeyDSharp2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyE2
            // 
            this.pkeyE2.KeyOffColor = System.Drawing.Color.White;
            this.pkeyE2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyE2.Location = new System.Drawing.Point(103, 2);
            this.pkeyE2.Name = "pkeyE2";
            this.pkeyE2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyE2.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyE2.Size = new System.Drawing.Size(12, 42);
            this.pkeyE2.TabIndex = 14;
            this.pkeyE2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyF2
            // 
            this.pkeyF2.KeyOffColor = System.Drawing.Color.White;
            this.pkeyF2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyF2.Location = new System.Drawing.Point(114, 2);
            this.pkeyF2.Name = "pkeyF2";
            this.pkeyF2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyF2.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyF2.Size = new System.Drawing.Size(12, 42);
            this.pkeyF2.TabIndex = 17;
            this.pkeyF2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyFSharp2
            // 
            this.pkeyFSharp2.BackColor = System.Drawing.Color.Black;
            this.pkeyFSharp2.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyFSharp2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyFSharp2.Location = new System.Drawing.Point(122, 2);
            this.pkeyFSharp2.Name = "pkeyFSharp2";
            this.pkeyFSharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyFSharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyFSharp2.Size = new System.Drawing.Size(8, 28);
            this.pkeyFSharp2.TabIndex = 19;
            this.pkeyFSharp2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyG2
            // 
            this.pkeyG2.KeyOffColor = System.Drawing.Color.White;
            this.pkeyG2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyG2.Location = new System.Drawing.Point(125, 2);
            this.pkeyG2.Name = "pkeyG2";
            this.pkeyG2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyG2.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyG2.Size = new System.Drawing.Size(12, 42);
            this.pkeyG2.TabIndex = 18;
            this.pkeyG2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyGSharp2
            // 
            this.pkeyGSharp2.BackColor = System.Drawing.Color.Black;
            this.pkeyGSharp2.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyGSharp2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyGSharp2.Location = new System.Drawing.Point(133, 2);
            this.pkeyGSharp2.Name = "pkeyGSharp2";
            this.pkeyGSharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyGSharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyGSharp2.Size = new System.Drawing.Size(8, 29);
            this.pkeyGSharp2.TabIndex = 20;
            this.pkeyGSharp2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyA2
            // 
            this.pkeyA2.KeyOffColor = System.Drawing.Color.White;
            this.pkeyA2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyA2.Location = new System.Drawing.Point(136, 2);
            this.pkeyA2.Name = "pkeyA2";
            this.pkeyA2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyA2.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyA2.Size = new System.Drawing.Size(12, 42);
            this.pkeyA2.TabIndex = 21;
            this.pkeyA2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyASharp2
            // 
            this.pkeyASharp2.BackColor = System.Drawing.Color.Black;
            this.pkeyASharp2.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyASharp2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyASharp2.Location = new System.Drawing.Point(144, 2);
            this.pkeyASharp2.Name = "pkeyASharp2";
            this.pkeyASharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyASharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyASharp2.Size = new System.Drawing.Size(8, 29);
            this.pkeyASharp2.TabIndex = 22;
            this.pkeyASharp2.Text = "pianoKey13";
            this.pkeyASharp2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyB2
            // 
            this.pkeyB2.KeyOffColor = System.Drawing.Color.White;
            this.pkeyB2.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyB2.Location = new System.Drawing.Point(147, 2);
            this.pkeyB2.Name = "pkeyB2";
            this.pkeyB2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyB2.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyB2.Size = new System.Drawing.Size(12, 42);
            this.pkeyB2.TabIndex = 23;
            this.pkeyB2.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyC3
            // 
            this.pkeyC3.KeyOffColor = System.Drawing.Color.White;
            this.pkeyC3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyC3.Location = new System.Drawing.Point(158, 2);
            this.pkeyC3.Name = "pkeyC3";
            this.pkeyC3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyC3.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyC3.Size = new System.Drawing.Size(12, 42);
            this.pkeyC3.TabIndex = 24;
            this.pkeyC3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyCSharp3
            // 
            this.pkeyCSharp3.BackColor = System.Drawing.Color.Black;
            this.pkeyCSharp3.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyCSharp3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyCSharp3.Location = new System.Drawing.Point(166, 2);
            this.pkeyCSharp3.Name = "pkeyCSharp3";
            this.pkeyCSharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyCSharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyCSharp3.Size = new System.Drawing.Size(8, 28);
            this.pkeyCSharp3.TabIndex = 27;
            this.pkeyCSharp3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyD3
            // 
            this.pkeyD3.KeyOffColor = System.Drawing.Color.White;
            this.pkeyD3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyD3.Location = new System.Drawing.Point(169, 2);
            this.pkeyD3.Name = "pkeyD3";
            this.pkeyD3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyD3.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyD3.Size = new System.Drawing.Size(12, 42);
            this.pkeyD3.TabIndex = 25;
            this.pkeyD3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyDSharp3
            // 
            this.pkeyDSharp3.BackColor = System.Drawing.Color.Black;
            this.pkeyDSharp3.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyDSharp3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyDSharp3.Location = new System.Drawing.Point(177, 2);
            this.pkeyDSharp3.Name = "pkeyDSharp3";
            this.pkeyDSharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyDSharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyDSharp3.Size = new System.Drawing.Size(8, 29);
            this.pkeyDSharp3.TabIndex = 28;
            this.pkeyDSharp3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyE3
            // 
            this.pkeyE3.KeyOffColor = System.Drawing.Color.White;
            this.pkeyE3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyE3.Location = new System.Drawing.Point(180, 2);
            this.pkeyE3.Name = "pkeyE3";
            this.pkeyE3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyE3.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyE3.Size = new System.Drawing.Size(12, 42);
            this.pkeyE3.TabIndex = 26;
            this.pkeyE3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyF3
            // 
            this.pkeyF3.KeyOffColor = System.Drawing.Color.White;
            this.pkeyF3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyF3.Location = new System.Drawing.Point(191, 2);
            this.pkeyF3.Name = "pkeyF3";
            this.pkeyF3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyF3.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyF3.Size = new System.Drawing.Size(12, 42);
            this.pkeyF3.TabIndex = 29;
            this.pkeyF3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyFSharp3
            // 
            this.pkeyFSharp3.BackColor = System.Drawing.Color.Black;
            this.pkeyFSharp3.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyFSharp3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyFSharp3.Location = new System.Drawing.Point(199, 2);
            this.pkeyFSharp3.Name = "pkeyFSharp3";
            this.pkeyFSharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyFSharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyFSharp3.Size = new System.Drawing.Size(8, 28);
            this.pkeyFSharp3.TabIndex = 31;
            this.pkeyFSharp3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyG3
            // 
            this.pkeyG3.KeyOffColor = System.Drawing.Color.White;
            this.pkeyG3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyG3.Location = new System.Drawing.Point(202, 2);
            this.pkeyG3.Name = "pkeyG3";
            this.pkeyG3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyG3.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyG3.Size = new System.Drawing.Size(12, 42);
            this.pkeyG3.TabIndex = 30;
            this.pkeyG3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyGSharp3
            // 
            this.pkeyGSharp3.BackColor = System.Drawing.Color.Black;
            this.pkeyGSharp3.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyGSharp3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyGSharp3.Location = new System.Drawing.Point(210, 2);
            this.pkeyGSharp3.Name = "pkeyGSharp3";
            this.pkeyGSharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyGSharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyGSharp3.Size = new System.Drawing.Size(8, 29);
            this.pkeyGSharp3.TabIndex = 32;
            this.pkeyGSharp3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyA3
            // 
            this.pkeyA3.KeyOffColor = System.Drawing.Color.White;
            this.pkeyA3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyA3.Location = new System.Drawing.Point(213, 2);
            this.pkeyA3.Name = "pkeyA3";
            this.pkeyA3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyA3.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyA3.Size = new System.Drawing.Size(12, 42);
            this.pkeyA3.TabIndex = 33;
            this.pkeyA3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyASharp3
            // 
            this.pkeyASharp3.BackColor = System.Drawing.Color.Black;
            this.pkeyASharp3.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyASharp3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyASharp3.Location = new System.Drawing.Point(221, 2);
            this.pkeyASharp3.Name = "pkeyASharp3";
            this.pkeyASharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyASharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyASharp3.Size = new System.Drawing.Size(8, 29);
            this.pkeyASharp3.TabIndex = 34;
            this.pkeyASharp3.Text = "pianoKey13";
            this.pkeyASharp3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyB3
            // 
            this.pkeyB3.KeyOffColor = System.Drawing.Color.White;
            this.pkeyB3.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyB3.Location = new System.Drawing.Point(224, 2);
            this.pkeyB3.Name = "pkeyB3";
            this.pkeyB3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyB3.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyB3.Size = new System.Drawing.Size(12, 42);
            this.pkeyB3.TabIndex = 35;
            this.pkeyB3.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyC4
            // 
            this.pkeyC4.KeyOffColor = System.Drawing.Color.White;
            this.pkeyC4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyC4.Location = new System.Drawing.Point(235, 2);
            this.pkeyC4.Name = "pkeyC4";
            this.pkeyC4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyC4.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyC4.Size = new System.Drawing.Size(12, 42);
            this.pkeyC4.TabIndex = 36;
            this.pkeyC4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyCSharp4
            // 
            this.pkeyCSharp4.BackColor = System.Drawing.Color.Black;
            this.pkeyCSharp4.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyCSharp4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyCSharp4.Location = new System.Drawing.Point(243, 2);
            this.pkeyCSharp4.Name = "pkeyCSharp4";
            this.pkeyCSharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyCSharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyCSharp4.Size = new System.Drawing.Size(8, 28);
            this.pkeyCSharp4.TabIndex = 39;
            this.pkeyCSharp4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyD4
            // 
            this.pkeyD4.KeyOffColor = System.Drawing.Color.White;
            this.pkeyD4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyD4.Location = new System.Drawing.Point(246, 2);
            this.pkeyD4.Name = "pkeyD4";
            this.pkeyD4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyD4.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyD4.Size = new System.Drawing.Size(12, 42);
            this.pkeyD4.TabIndex = 37;
            this.pkeyD4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyDSharp4
            // 
            this.pkeyDSharp4.BackColor = System.Drawing.Color.Black;
            this.pkeyDSharp4.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyDSharp4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyDSharp4.Location = new System.Drawing.Point(254, 2);
            this.pkeyDSharp4.Name = "pkeyDSharp4";
            this.pkeyDSharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyDSharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyDSharp4.Size = new System.Drawing.Size(8, 29);
            this.pkeyDSharp4.TabIndex = 40;
            this.pkeyDSharp4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyE4
            // 
            this.pkeyE4.KeyOffColor = System.Drawing.Color.White;
            this.pkeyE4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyE4.Location = new System.Drawing.Point(257, 2);
            this.pkeyE4.Name = "pkeyE4";
            this.pkeyE4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyE4.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyE4.Size = new System.Drawing.Size(12, 42);
            this.pkeyE4.TabIndex = 38;
            this.pkeyE4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyF4
            // 
            this.pkeyF4.KeyOffColor = System.Drawing.Color.White;
            this.pkeyF4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyF4.Location = new System.Drawing.Point(268, 2);
            this.pkeyF4.Name = "pkeyF4";
            this.pkeyF4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyF4.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyF4.Size = new System.Drawing.Size(12, 42);
            this.pkeyF4.TabIndex = 41;
            this.pkeyF4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyFSharp4
            // 
            this.pkeyFSharp4.BackColor = System.Drawing.Color.Black;
            this.pkeyFSharp4.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyFSharp4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyFSharp4.Location = new System.Drawing.Point(276, 2);
            this.pkeyFSharp4.Name = "pkeyFSharp4";
            this.pkeyFSharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyFSharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyFSharp4.Size = new System.Drawing.Size(8, 28);
            this.pkeyFSharp4.TabIndex = 43;
            this.pkeyFSharp4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyG4
            // 
            this.pkeyG4.KeyOffColor = System.Drawing.Color.White;
            this.pkeyG4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyG4.Location = new System.Drawing.Point(279, 2);
            this.pkeyG4.Name = "pkeyG4";
            this.pkeyG4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyG4.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyG4.Size = new System.Drawing.Size(12, 42);
            this.pkeyG4.TabIndex = 42;
            this.pkeyG4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyGSharp4
            // 
            this.pkeyGSharp4.BackColor = System.Drawing.Color.Black;
            this.pkeyGSharp4.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyGSharp4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyGSharp4.Location = new System.Drawing.Point(287, 2);
            this.pkeyGSharp4.Name = "pkeyGSharp4";
            this.pkeyGSharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyGSharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyGSharp4.Size = new System.Drawing.Size(8, 29);
            this.pkeyGSharp4.TabIndex = 44;
            this.pkeyGSharp4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyA4
            // 
            this.pkeyA4.KeyOffColor = System.Drawing.Color.White;
            this.pkeyA4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyA4.Location = new System.Drawing.Point(290, 2);
            this.pkeyA4.Name = "pkeyA4";
            this.pkeyA4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyA4.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyA4.Size = new System.Drawing.Size(12, 42);
            this.pkeyA4.TabIndex = 45;
            this.pkeyA4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyASharp4
            // 
            this.pkeyASharp4.BackColor = System.Drawing.Color.Black;
            this.pkeyASharp4.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyASharp4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyASharp4.Location = new System.Drawing.Point(298, 2);
            this.pkeyASharp4.Name = "pkeyASharp4";
            this.pkeyASharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyASharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyASharp4.Size = new System.Drawing.Size(8, 29);
            this.pkeyASharp4.TabIndex = 46;
            this.pkeyASharp4.Text = "pianoKey13";
            this.pkeyASharp4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyB4
            // 
            this.pkeyB4.KeyOffColor = System.Drawing.Color.White;
            this.pkeyB4.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyB4.Location = new System.Drawing.Point(301, 2);
            this.pkeyB4.Name = "pkeyB4";
            this.pkeyB4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyB4.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyB4.Size = new System.Drawing.Size(12, 42);
            this.pkeyB4.TabIndex = 47;
            this.pkeyB4.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyC5
            // 
            this.pkeyC5.KeyOffColor = System.Drawing.Color.White;
            this.pkeyC5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyC5.Location = new System.Drawing.Point(312, 2);
            this.pkeyC5.Name = "pkeyC5";
            this.pkeyC5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyC5.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyC5.Size = new System.Drawing.Size(12, 42);
            this.pkeyC5.TabIndex = 48;
            this.pkeyC5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyCSharp5
            // 
            this.pkeyCSharp5.BackColor = System.Drawing.Color.Black;
            this.pkeyCSharp5.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyCSharp5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyCSharp5.Location = new System.Drawing.Point(320, 2);
            this.pkeyCSharp5.Name = "pkeyCSharp5";
            this.pkeyCSharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyCSharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyCSharp5.Size = new System.Drawing.Size(8, 28);
            this.pkeyCSharp5.TabIndex = 51;
            this.pkeyCSharp5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyD5
            // 
            this.pkeyD5.KeyOffColor = System.Drawing.Color.White;
            this.pkeyD5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyD5.Location = new System.Drawing.Point(323, 2);
            this.pkeyD5.Name = "pkeyD5";
            this.pkeyD5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyD5.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyD5.Size = new System.Drawing.Size(12, 42);
            this.pkeyD5.TabIndex = 49;
            this.pkeyD5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyDSharp5
            // 
            this.pkeyDSharp5.BackColor = System.Drawing.Color.Black;
            this.pkeyDSharp5.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyDSharp5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyDSharp5.Location = new System.Drawing.Point(331, 2);
            this.pkeyDSharp5.Name = "pkeyDSharp5";
            this.pkeyDSharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyDSharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyDSharp5.Size = new System.Drawing.Size(8, 29);
            this.pkeyDSharp5.TabIndex = 52;
            this.pkeyDSharp5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyE5
            // 
            this.pkeyE5.KeyOffColor = System.Drawing.Color.White;
            this.pkeyE5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyE5.Location = new System.Drawing.Point(334, 2);
            this.pkeyE5.Name = "pkeyE5";
            this.pkeyE5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyE5.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyE5.Size = new System.Drawing.Size(12, 42);
            this.pkeyE5.TabIndex = 50;
            this.pkeyE5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyF5
            // 
            this.pkeyF5.KeyOffColor = System.Drawing.Color.White;
            this.pkeyF5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyF5.Location = new System.Drawing.Point(345, 2);
            this.pkeyF5.Name = "pkeyF5";
            this.pkeyF5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyF5.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pkeyF5.Size = new System.Drawing.Size(12, 42);
            this.pkeyF5.TabIndex = 53;
            this.pkeyF5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyFSharp5
            // 
            this.pkeyFSharp5.BackColor = System.Drawing.Color.Black;
            this.pkeyFSharp5.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyFSharp5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyFSharp5.Location = new System.Drawing.Point(353, 2);
            this.pkeyFSharp5.Name = "pkeyFSharp5";
            this.pkeyFSharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyFSharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyFSharp5.Size = new System.Drawing.Size(8, 28);
            this.pkeyFSharp5.TabIndex = 55;
            this.pkeyFSharp5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyG5
            // 
            this.pkeyG5.KeyOffColor = System.Drawing.Color.White;
            this.pkeyG5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyG5.Location = new System.Drawing.Point(356, 2);
            this.pkeyG5.Name = "pkeyG5";
            this.pkeyG5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyG5.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyG5.Size = new System.Drawing.Size(12, 42);
            this.pkeyG5.TabIndex = 54;
            this.pkeyG5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyGSharp5
            // 
            this.pkeyGSharp5.BackColor = System.Drawing.Color.Black;
            this.pkeyGSharp5.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyGSharp5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyGSharp5.Location = new System.Drawing.Point(364, 2);
            this.pkeyGSharp5.Name = "pkeyGSharp5";
            this.pkeyGSharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyGSharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyGSharp5.Size = new System.Drawing.Size(8, 29);
            this.pkeyGSharp5.TabIndex = 56;
            this.pkeyGSharp5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyA5
            // 
            this.pkeyA5.KeyOffColor = System.Drawing.Color.White;
            this.pkeyA5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyA5.Location = new System.Drawing.Point(367, 2);
            this.pkeyA5.Name = "pkeyA5";
            this.pkeyA5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyA5.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pkeyA5.Size = new System.Drawing.Size(12, 42);
            this.pkeyA5.TabIndex = 57;
            this.pkeyA5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyASharp5
            // 
            this.pkeyASharp5.BackColor = System.Drawing.Color.Black;
            this.pkeyASharp5.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyASharp5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyASharp5.Location = new System.Drawing.Point(375, 2);
            this.pkeyASharp5.Name = "pkeyASharp5";
            this.pkeyASharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyASharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyASharp5.Size = new System.Drawing.Size(8, 29);
            this.pkeyASharp5.TabIndex = 58;
            this.pkeyASharp5.Text = "pianoKey13";
            this.pkeyASharp5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyB5
            // 
            this.pkeyB5.KeyOffColor = System.Drawing.Color.White;
            this.pkeyB5.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyB5.Location = new System.Drawing.Point(378, 2);
            this.pkeyB5.Name = "pkeyB5";
            this.pkeyB5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyB5.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pkeyB5.Size = new System.Drawing.Size(12, 42);
            this.pkeyB5.TabIndex = 59;
            this.pkeyB5.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // pkeyC6
            // 
            this.pkeyC6.KeyOffColor = System.Drawing.Color.White;
            this.pkeyC6.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyC6.Location = new System.Drawing.Point(389, 2);
            this.pkeyC6.Name = "pkeyC6";
            this.pkeyC6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyC6.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyC6.Size = new System.Drawing.Size(12, 42);
            this.pkeyC6.TabIndex = 60;
            this.pkeyC6.StateChanged += new System.EventHandler(this.OnStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pkeyRect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pianoKey3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pianoKey2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pianoKey1);
            this.groupBox1.Location = new System.Drawing.Point(64, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Piano Key Shapes";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(232, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rectangle";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pkeyRect
            // 
            this.pkeyRect.BackColor = System.Drawing.Color.Black;
            this.pkeyRect.KeyOffColor = System.Drawing.Color.Black;
            this.pkeyRect.KeyOnColor = System.Drawing.Color.Blue;
            this.pkeyRect.Location = new System.Drawing.Point(264, 32);
            this.pkeyRect.Name = "pkeyRect";
            this.pkeyRect.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pkeyRect.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            this.pkeyRect.Size = new System.Drawing.Size(8, 32);
            this.pkeyRect.TabIndex = 9;
            this.pkeyRect.Text = "pianoKey4";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(144, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Upside down T";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pianoKey3
            // 
            this.pianoKey3.KeyOffColor = System.Drawing.Color.White;
            this.pianoKey3.KeyOnColor = System.Drawing.Color.Blue;
            this.pianoKey3.Location = new System.Drawing.Point(176, 24);
            this.pianoKey3.Name = "pianoKey3";
            this.pianoKey3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pianoKey3.Shape = Multimedia.UI.PianoKeyShape.TShape;
            this.pianoKey3.Size = new System.Drawing.Size(19, 40);
            this.pianoKey3.TabIndex = 7;
            this.pianoKey3.Text = "pianoKey3";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(64, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Backwards L";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pianoKey2
            // 
            this.pianoKey2.KeyOffColor = System.Drawing.Color.White;
            this.pianoKey2.KeyOnColor = System.Drawing.Color.Blue;
            this.pianoKey2.Location = new System.Drawing.Point(88, 24);
            this.pianoKey2.Name = "pianoKey2";
            this.pianoKey2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pianoKey2.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            this.pianoKey2.Size = new System.Drawing.Size(19, 40);
            this.pianoKey2.TabIndex = 5;
            this.pianoKey2.Text = "pianoKey2";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "L";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pianoKey1
            // 
            this.pianoKey1.KeyOffColor = System.Drawing.Color.White;
            this.pianoKey1.KeyOnColor = System.Drawing.Color.Blue;
            this.pianoKey1.Location = new System.Drawing.Point(16, 24);
            this.pianoKey1.Name = "pianoKey1";
            this.pianoKey1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pianoKey1.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pianoKey1.Size = new System.Drawing.Size(19, 40);
            this.pianoKey1.TabIndex = 3;
            this.pianoKey1.Text = "pianoKey1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.pianoKey6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.pianoKey5);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pianoKey4);
            this.groupBox2.Location = new System.Drawing.Point(80, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 112);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Orientation";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(184, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Horizontal Right";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pianoKey6
            // 
            this.pianoKey6.KeyOffColor = System.Drawing.Color.White;
            this.pianoKey6.KeyOnColor = System.Drawing.Color.Blue;
            this.pianoKey6.Location = new System.Drawing.Point(200, 48);
            this.pianoKey6.Name = "pianoKey6";
            this.pianoKey6.Orientation = Multimedia.UI.PianoKeyOrientation.HorizontalRight;
            this.pianoKey6.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pianoKey6.Size = new System.Drawing.Size(40, 19);
            this.pianoKey6.TabIndex = 12;
            this.pianoKey6.Text = "pianoKey6";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(88, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Horizontal Left";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pianoKey5
            // 
            this.pianoKey5.KeyOffColor = System.Drawing.Color.White;
            this.pianoKey5.KeyOnColor = System.Drawing.Color.Blue;
            this.pianoKey5.Location = new System.Drawing.Point(104, 48);
            this.pianoKey5.Name = "pianoKey5";
            this.pianoKey5.Orientation = Multimedia.UI.PianoKeyOrientation.HorizontalLeft;
            this.pianoKey5.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pianoKey5.Size = new System.Drawing.Size(40, 19);
            this.pianoKey5.TabIndex = 10;
            this.pianoKey5.Text = "pianoKey5";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Vertical";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pianoKey4
            // 
            this.pianoKey4.KeyOffColor = System.Drawing.Color.White;
            this.pianoKey4.KeyOnColor = System.Drawing.Color.Blue;
            this.pianoKey4.Location = new System.Drawing.Point(32, 24);
            this.pianoKey4.Name = "pianoKey4";
            this.pianoKey4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            this.pianoKey4.Shape = Multimedia.UI.PianoKeyShape.LShape;
            this.pianoKey4.Size = new System.Drawing.Size(19, 40);
            this.pianoKey4.TabIndex = 4;
            this.pianoKey4.Text = "pianoKey4";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblKeyNumber);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.pnlPianoKeys);
            this.groupBox3.Location = new System.Drawing.Point(16, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 112);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Collection of Piano Keys";
            // 
            // lblKeyNumber
            // 
            this.lblKeyNumber.Location = new System.Drawing.Point(88, 16);
            this.lblKeyNumber.Name = "lblKeyNumber";
            this.lblKeyNumber.TabIndex = 3;
            this.lblKeyNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(24, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "Key Number:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PKDemoForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(464, 366);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PKDemoForm";
            this.Text = "Piano Key Demo";
            this.Load += new System.EventHandler(this.PKDemoForm_Load);
            this.pnlPianoKeys.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PKDemoForm());
		}        

        private void PKDemoForm_Load(object sender, System.EventArgs e)
        {
        
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            PianoKey key = (PianoKey)sender;
            int noteNum = (int)key.Tag;

            // If the key has been turned on.
            if(key.IsKeyOn())
            {
                lblKeyNumber.Text = noteNum.ToString();
            }
            // Else the key has been turned off 
            else
            {
            }
        }
	}
}
