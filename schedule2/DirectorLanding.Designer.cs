namespace schedule2
{
    partial class DirectorLanding
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
            this.class13 = new CustomButtons.Buttons.class1();
            this.class11 = new CustomButtons.Buttons.class1();
            this.class12 = new CustomButtons.Buttons.class1();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 35);
            this.label1.TabIndex = 11;
            this.label1.Text = "Welcome to the Coe College Writing Center";
            // 
            // class13
            // 
            this.class13.BackColor = System.Drawing.Color.Crimson;
            this.class13.BackgroundColor = System.Drawing.Color.Crimson;
            this.class13.BorderColor = System.Drawing.Color.White;
            this.class13.BorderRadius = 25;
            this.class13.BorderSize = 2;
            this.class13.FlatAppearance.BorderSize = 0;
            this.class13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class13.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.class13.ForeColor = System.Drawing.Color.White;
            this.class13.Location = new System.Drawing.Point(446, 223);
            this.class13.Name = "class13";
            this.class13.Size = new System.Drawing.Size(182, 71);
            this.class13.TabIndex = 16;
            this.class13.Text = "Change Schedule";
            this.class13.TextColor = System.Drawing.Color.White;
            this.class13.UseVisualStyleBackColor = false;
            this.class13.Click += new System.EventHandler(this.class13_Click);
            // 
            // class11
            // 
            this.class11.BackColor = System.Drawing.Color.Crimson;
            this.class11.BackgroundColor = System.Drawing.Color.Crimson;
            this.class11.BorderColor = System.Drawing.Color.White;
            this.class11.BorderRadius = 25;
            this.class11.BorderSize = 2;
            this.class11.FlatAppearance.BorderSize = 0;
            this.class11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.class11.ForeColor = System.Drawing.Color.White;
            this.class11.Location = new System.Drawing.Point(38, 223);
            this.class11.Name = "class11";
            this.class11.Size = new System.Drawing.Size(182, 71);
            this.class11.TabIndex = 15;
            this.class11.Text = "View Schedule";
            this.class11.TextColor = System.Drawing.Color.White;
            this.class11.UseVisualStyleBackColor = false;
            this.class11.Click += new System.EventHandler(this.class11_Click);
            // 
            // class12
            // 
            this.class12.BackColor = System.Drawing.Color.Crimson;
            this.class12.BackgroundColor = System.Drawing.Color.Crimson;
            this.class12.BorderColor = System.Drawing.Color.White;
            this.class12.BorderRadius = 25;
            this.class12.BorderSize = 2;
            this.class12.FlatAppearance.BorderSize = 0;
            this.class12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.class12.ForeColor = System.Drawing.Color.White;
            this.class12.Location = new System.Drawing.Point(242, 223);
            this.class12.Name = "class12";
            this.class12.Size = new System.Drawing.Size(182, 71);
            this.class12.TabIndex = 14;
            this.class12.Text = "Create Schedule";
            this.class12.TextColor = System.Drawing.Color.White;
            this.class12.UseVisualStyleBackColor = false;
            this.class12.Click += new System.EventHandler(this.class12_Click);
            // 
            // DirectorLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(666, 403);
            this.Controls.Add(this.class13);
            this.Controls.Add(this.class11);
            this.Controls.Add(this.class12);
            this.Controls.Add(this.label1);
            this.Name = "DirectorLanding";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private CustomButtons.Buttons.class1 class13;
        private CustomButtons.Buttons.class1 class11;
        private CustomButtons.Buttons.class1 class12;
    }
}