namespace schedule2
{
    partial class RunForm
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
            this.runButt = new CustomButtons.Buttons.class1();
            this.class13 = new CustomButtons.Buttons.class1();
            this.class14 = new CustomButtons.Buttons.class1();
            this.SuspendLayout();
            // 
            // runButt
            // 
            this.runButt.BackColor = System.Drawing.Color.Crimson;
            this.runButt.BackgroundColor = System.Drawing.Color.Crimson;
            this.runButt.BorderColor = System.Drawing.Color.White;
            this.runButt.BorderRadius = 25;
            this.runButt.BorderSize = 2;
            this.runButt.FlatAppearance.BorderSize = 0;
            this.runButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButt.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.runButt.ForeColor = System.Drawing.Color.White;
            this.runButt.Location = new System.Drawing.Point(624, 324);
            this.runButt.Name = "runButt";
            this.runButt.Size = new System.Drawing.Size(182, 71);
            this.runButt.TabIndex = 18;
            this.runButt.Text = "Run";
            this.runButt.TextColor = System.Drawing.Color.White;
            this.runButt.UseVisualStyleBackColor = false;
            this.runButt.Click += new System.EventHandler(this.class12_Click);
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
            this.class13.Location = new System.Drawing.Point(359, 324);
            this.class13.Name = "class13";
            this.class13.Size = new System.Drawing.Size(182, 71);
            this.class13.TabIndex = 19;
            this.class13.Text = "View Schedule";
            this.class13.TextColor = System.Drawing.Color.White;
            this.class13.UseVisualStyleBackColor = false;
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
            this.class14.Location = new System.Drawing.Point(77, 324);
            this.class14.Name = "class14";
            this.class14.Size = new System.Drawing.Size(182, 71);
            this.class14.TabIndex = 20;
            this.class14.Text = "View Schedule";
            this.class14.TextColor = System.Drawing.Color.White;
            this.class14.UseVisualStyleBackColor = false;
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(912, 542);
            this.Controls.Add(this.class14);
            this.Controls.Add(this.class13);
            this.Controls.Add(this.runButt);
            this.Name = "RunForm";
            this.Text = "Create Scheduling";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButtons.Buttons.class1 runButt;
        private CustomButtons.Buttons.class1 class13;
        private CustomButtons.Buttons.class1 class14;
    }
}