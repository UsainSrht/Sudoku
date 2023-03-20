namespace Sudoku
{
	partial class Form2
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
			label1 = new Label();
			putnumber_button1 = new Button();
			putnumber_button2 = new Button();
			putnumber_button3 = new Button();
			putnumber_button4 = new Button();
			putnumber_button5 = new Button();
			putnumber_button6 = new Button();
			putnumber_button7 = new Button();
			putnumber_button8 = new Button();
			putnumber_button9 = new Button();
			panel1 = new Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(454, 9);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 0;
			label1.Text = "label1";
			// 
			// putnumber_button1
			// 
			putnumber_button1.Location = new Point(30, 30);
			putnumber_button1.Name = "putnumber_button1";
			putnumber_button1.Size = new Size(50, 50);
			putnumber_button1.TabIndex = 1;
			putnumber_button1.Tag = "1";
			putnumber_button1.Text = "1";
			putnumber_button1.UseVisualStyleBackColor = true;
			putnumber_button1.MouseClick += Button_PutNumber;
			// 
			// putnumber_button2
			// 
			putnumber_button2.Location = new Point(90, 30);
			putnumber_button2.Name = "putnumber_button2";
			putnumber_button2.Size = new Size(50, 50);
			putnumber_button2.TabIndex = 2;
			putnumber_button2.Tag = "2";
			putnumber_button2.Text = "2";
			putnumber_button2.UseVisualStyleBackColor = true;
			putnumber_button2.MouseClick += Button_PutNumber;
			// 
			// putnumber_button3
			// 
			putnumber_button3.Location = new Point(150, 30);
			putnumber_button3.Name = "putnumber_button3";
			putnumber_button3.Size = new Size(50, 50);
			putnumber_button3.TabIndex = 3;
			putnumber_button3.Tag = "3";
			putnumber_button3.Text = "3";
			putnumber_button3.UseVisualStyleBackColor = true;
			putnumber_button3.MouseClick += Button_PutNumber;
			// 
			// putnumber_button4
			// 
			putnumber_button4.Location = new Point(150, 90);
			putnumber_button4.Name = "putnumber_button4";
			putnumber_button4.Size = new Size(50, 50);
			putnumber_button4.TabIndex = 6;
			putnumber_button4.Tag = "6";
			putnumber_button4.Text = "6";
			putnumber_button4.UseVisualStyleBackColor = true;
			putnumber_button4.MouseClick += Button_PutNumber;
			// 
			// putnumber_button5
			// 
			putnumber_button5.Location = new Point(90, 90);
			putnumber_button5.Name = "putnumber_button5";
			putnumber_button5.Size = new Size(50, 50);
			putnumber_button5.TabIndex = 5;
			putnumber_button5.Tag = "5";
			putnumber_button5.Text = "5";
			putnumber_button5.UseVisualStyleBackColor = true;
			putnumber_button5.MouseClick += Button_PutNumber;
			// 
			// putnumber_button6
			// 
			putnumber_button6.Location = new Point(30, 90);
			putnumber_button6.Name = "putnumber_button6";
			putnumber_button6.Size = new Size(50, 50);
			putnumber_button6.TabIndex = 4;
			putnumber_button6.Tag = "4";
			putnumber_button6.Text = "4";
			putnumber_button6.UseVisualStyleBackColor = true;
			putnumber_button6.MouseClick += Button_PutNumber;
			// 
			// putnumber_button7
			// 
			putnumber_button7.Location = new Point(150, 150);
			putnumber_button7.Name = "putnumber_button7";
			putnumber_button7.Size = new Size(50, 50);
			putnumber_button7.TabIndex = 9;
			putnumber_button7.Tag = "9";
			putnumber_button7.Text = "9";
			putnumber_button7.UseVisualStyleBackColor = true;
			putnumber_button7.MouseClick += Button_PutNumber;
			// 
			// putnumber_button8
			// 
			putnumber_button8.Location = new Point(90, 150);
			putnumber_button8.Name = "putnumber_button8";
			putnumber_button8.Size = new Size(50, 50);
			putnumber_button8.TabIndex = 8;
			putnumber_button8.Tag = "8";
			putnumber_button8.Text = "8";
			putnumber_button8.UseVisualStyleBackColor = true;
			putnumber_button8.MouseClick += Button_PutNumber;
			// 
			// putnumber_button9
			// 
			putnumber_button9.Location = new Point(30, 150);
			putnumber_button9.Name = "putnumber_button9";
			putnumber_button9.Size = new Size(50, 50);
			putnumber_button9.TabIndex = 7;
			putnumber_button9.Tag = "7";
			putnumber_button9.Text = "7";
			putnumber_button9.UseVisualStyleBackColor = true;
			putnumber_button9.MouseClick += Button_PutNumber;
			// 
			// panel1
			// 
			panel1.Controls.Add(putnumber_button1);
			panel1.Controls.Add(putnumber_button7);
			panel1.Controls.Add(putnumber_button2);
			panel1.Controls.Add(putnumber_button8);
			panel1.Controls.Add(putnumber_button3);
			panel1.Controls.Add(putnumber_button9);
			panel1.Controls.Add(putnumber_button6);
			panel1.Controls.Add(putnumber_button4);
			panel1.Controls.Add(putnumber_button5);
			panel1.Location = new Point(388, 104);
			panel1.Name = "panel1";
			panel1.Size = new Size(230, 230);
			panel1.TabIndex = 10;
			// 
			// Form2
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(653, 361);
			Controls.Add(panel1);
			Controls.Add(label1);
			KeyPreview = true;
			Name = "Form2";
			Text = "Sudoku";
			FormClosing += Form2_FormClosing;
			Shown += Form2_Shown;
			KeyPress += Form2_KeyPress;
			panel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button putnumber_button1;
		private Button putnumber_button2;
		private Button putnumber_button3;
		private Button putnumber_button4;
		private Button putnumber_button5;
		private Button putnumber_button6;
		private Button putnumber_button7;
		private Button putnumber_button8;
		private Button putnumber_button9;
		private Panel panel1;
	}
}