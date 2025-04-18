namespace ParallelProgrammingProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartRace = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.GameTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartRace
            // 
            this.StartRace.Location = new System.Drawing.Point(111, 146);
            this.StartRace.Name = "StartRace";
            this.StartRace.Size = new System.Drawing.Size(94, 29);
            this.StartRace.TabIndex = 0;
            this.StartRace.Text = "Start Race";
            this.StartRace.UseVisualStyleBackColor = true;
            this.StartRace.Click += new System.EventHandler(this.StartRace_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(270, 146);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(94, 29);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit Game";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // GameTitle
            // 
            this.GameTitle.AutoSize = true;
            this.GameTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameTitle.Location = new System.Drawing.Point(31, 62);
            this.GameTitle.Name = "GameTitle";
            this.GameTitle.Size = new System.Drawing.Size(415, 41);
            this.GameTitle.TabIndex = 3;
            this.GameTitle.Text = "Welcome to F1 2026! (Official)";
            this.GameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GameTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 243);
            this.Controls.Add(this.GameTitle);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StartRace);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartRace;
        private Button ExitButton;
        private Label GameTitle;
    }
}