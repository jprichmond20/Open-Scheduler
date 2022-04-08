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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectorLanding));
            this.class13 = new CustomButtons.Buttons.class1();
            this.class11 = new CustomButtons.Buttons.class1();
            this.class12 = new CustomButtons.Buttons.class1();
            this.class14 = new CustomButtons.Buttons.class1();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.class13.Location = new System.Drawing.Point(284, 223);
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
            this.class11.Location = new System.Drawing.Point(42, 223);
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
            this.class12.Location = new System.Drawing.Point(526, 223);
            this.class12.Name = "class12";
            this.class12.Size = new System.Drawing.Size(182, 71);
            this.class12.TabIndex = 14;
            this.class12.Text = "Run Scheduler";
            this.class12.TextColor = System.Drawing.Color.White;
            this.class12.UseVisualStyleBackColor = false;
            this.class12.Click += new System.EventHandler(this.class12_Click);
            // 
            // class14
            // 
            this.class14.BackColor = System.Drawing.Color.Crimson;
            this.class14.BackgroundColor = System.Drawing.Color.Crimson;
            this.class14.BorderColor = System.Drawing.Color.White;
            this.class14.BorderRadius = 25;
            this.class14.BorderSize = 2;
            this.class14.FlatAppearance.BorderSize = 0;
            this.class14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class14.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.class14.ForeColor = System.Drawing.Color.White;
            this.class14.Location = new System.Drawing.Point(284, 320);
            this.class14.Name = "class14";
            this.class14.Size = new System.Drawing.Size(182, 71);
            this.class14.TabIndex = 17;
            this.class14.Text = "Sign Out";
            this.class14.TextColor = System.Drawing.Color.White;
            this.class14.UseVisualStyleBackColor = false;
            this.class14.Click += new System.EventHandler(this.class14_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(666, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // DirectorLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(750, 441);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.class14);
            this.Controls.Add(this.class13);
            this.Controls.Add(this.class11);
            this.Controls.Add(this.class12);
            this.Name = "DirectorLanding";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.DirectorLanding_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomButtons.Buttons.class1 class13;
        private CustomButtons.Buttons.class1 class11;
        private CustomButtons.Buttons.class1 class12;
        private CustomButtons.Buttons.class1 class14;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}