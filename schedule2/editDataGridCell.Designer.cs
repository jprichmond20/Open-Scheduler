namespace schedule2
{
    partial class editDataGridCell
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.class11 = new CustomButtons.Buttons.class1();
            this.class12 = new CustomButtons.Buttons.class1();
            this.class13 = new CustomButtons.Buttons.class1();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(34, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 186);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
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
            this.class11.Location = new System.Drawing.Point(213, 88);
            this.class11.Name = "class11";
            this.class11.Size = new System.Drawing.Size(150, 40);
            this.class11.TabIndex = 1;
            this.class11.Text = "Add";
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
            this.class12.Location = new System.Drawing.Point(213, 134);
            this.class12.Name = "class12";
            this.class12.Size = new System.Drawing.Size(150, 40);
            this.class12.TabIndex = 2;
            this.class12.Text = "Remove";
            this.class12.TextColor = System.Drawing.Color.White;
            this.class12.UseVisualStyleBackColor = false;
            this.class12.Click += new System.EventHandler(this.class12_Click);
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
            this.class13.Location = new System.Drawing.Point(213, 180);
            this.class13.Name = "class13";
            this.class13.Size = new System.Drawing.Size(150, 40);
            this.class13.TabIndex = 3;
            this.class13.Text = "Replace";
            this.class13.TextColor = System.Drawing.Color.White;
            this.class13.UseVisualStyleBackColor = false;
            // 
            // editDataGridCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 332);
            this.Controls.Add(this.class13);
            this.Controls.Add(this.class12);
            this.Controls.Add(this.class11);
            this.Controls.Add(this.listBox1);
            this.Name = "editDataGridCell";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.editDataGridCell_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private CustomButtons.Buttons.class1 class11;
        private CustomButtons.Buttons.class1 class12;
        private CustomButtons.Buttons.class1 class13;
    }
}