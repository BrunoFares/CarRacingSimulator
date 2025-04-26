namespace ParallelProgrammingProject
{
    partial class RemoveCarForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.RemoveCar = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure you want to remove this car?";
            // 
            // RemoveCar
            // 
            this.RemoveCar.Location = new System.Drawing.Point(78, 121);
            this.RemoveCar.Name = "RemoveCar";
            this.RemoveCar.Size = new System.Drawing.Size(86, 29);
            this.RemoveCar.TabIndex = 1;
            this.RemoveCar.Text = "Remove";
            this.RemoveCar.UseVisualStyleBackColor = true;
            this.RemoveCar.Click += new System.EventHandler(this.RemoveCar_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(217, 121);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(86, 29);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // RemoveCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 202);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.RemoveCar);
            this.Controls.Add(this.label1);
            this.Name = "RemoveCarForm";
            this.Text = "RemoveCarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button RemoveCar;
        private Button Cancel;
    }
}