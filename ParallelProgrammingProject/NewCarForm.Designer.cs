﻿namespace ParallelProgrammingProject
{
    partial class NewCarForm
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
            this.NewCarButton = new System.Windows.Forms.Button();
            this.CarMake = new System.Windows.Forms.TextBox();
            this.CarModel = new System.Windows.Forms.TextBox();
            this.CarYear = new System.Windows.Forms.TextBox();
            this.CarHP = new System.Windows.Forms.TextBox();
            this.CarWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewCarButton
            // 
            this.NewCarButton.Location = new System.Drawing.Point(266, 390);
            this.NewCarButton.Name = "NewCarButton";
            this.NewCarButton.Size = new System.Drawing.Size(72, 29);
            this.NewCarButton.TabIndex = 0;
            this.NewCarButton.Text = "Add Car";
            this.NewCarButton.UseVisualStyleBackColor = true;
            this.NewCarButton.Click += new System.EventHandler(this.NewCarButton_Click);
            // 
            // CarMake
            // 
            this.CarMake.Location = new System.Drawing.Point(30, 53);
            this.CarMake.Name = "CarMake";
            this.CarMake.Size = new System.Drawing.Size(308, 27);
            this.CarMake.TabIndex = 1;
            // 
            // CarModel
            // 
            this.CarModel.Location = new System.Drawing.Point(30, 119);
            this.CarModel.Name = "CarModel";
            this.CarModel.Size = new System.Drawing.Size(308, 27);
            this.CarModel.TabIndex = 1;
            // 
            // CarYear
            // 
            this.CarYear.Location = new System.Drawing.Point(30, 188);
            this.CarYear.Name = "CarYear";
            this.CarYear.Size = new System.Drawing.Size(308, 27);
            this.CarYear.TabIndex = 1;
            // 
            // CarHP
            // 
            this.CarHP.Location = new System.Drawing.Point(30, 257);
            this.CarHP.Name = "CarHP";
            this.CarHP.Size = new System.Drawing.Size(308, 27);
            this.CarHP.TabIndex = 1;
            // 
            // CarWeight
            // 
            this.CarWeight.Location = new System.Drawing.Point(30, 324);
            this.CarWeight.Name = "CarWeight";
            this.CarWeight.Size = new System.Drawing.Size(308, 27);
            this.CarWeight.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Car Make:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Car Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Car Year:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Car HorsePower:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Car Weight:";
            // 
            // NewCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 505);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CarWeight);
            this.Controls.Add(this.CarHP);
            this.Controls.Add(this.CarYear);
            this.Controls.Add(this.CarModel);
            this.Controls.Add(this.CarMake);
            this.Controls.Add(this.NewCarButton);
            this.Name = "NewCarForm";
            this.Text = "NewCarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button NewCarButton;
        private TextBox CarMake;
        private TextBox CarModel;
        private TextBox CarYear;
        private TextBox CarHP;
        private TextBox CarWeight;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}