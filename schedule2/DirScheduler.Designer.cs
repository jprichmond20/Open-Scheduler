namespace schedule2
{
    partial class DirScheduler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.database1DataSet1 = new schedule2.Database1DataSet();
            this.class15 = new CustomButtons.Buttons.class1();
            this.class14 = new CustomButtons.Buttons.class1();
            this.class13 = new CustomButtons.Buttons.class1();
            this.class11 = new CustomButtons.Buttons.class1();
            this.class12 = new CustomButtons.Buttons.class1();
            this.class16 = new CustomButtons.Buttons.class1();
            this.class17 = new CustomButtons.Buttons.class1();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(235, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(469, 603);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Create/Change Writing Center Schedule";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 522);
            this.label2.TabIndex = 3;
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // class15
            // 
            this.class15.BackColor = System.Drawing.Color.Crimson;
            this.class15.BackgroundColor = System.Drawing.Color.Crimson;
            this.class15.BorderColor = System.Drawing.Color.White;
            this.class15.BorderRadius = 25;
            this.class15.BorderSize = 2;
            this.class15.FlatAppearance.BorderSize = 0;
            this.class15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class15.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.class15.ForeColor = System.Drawing.Color.White;
            this.class15.Location = new System.Drawing.Point(38, 117);
            this.class15.Margin = new System.Windows.Forms.Padding(2);
            this.class15.Name = "class15";
            this.class15.Size = new System.Drawing.Size(136, 58);
            this.class15.TabIndex = 10;
            this.class15.Text = "Sign Out";
            this.class15.TextColor = System.Drawing.Color.White;
            this.class15.UseVisualStyleBackColor = false;
            this.class15.Click += new System.EventHandler(this.class15_Click);
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
            this.class14.Location = new System.Drawing.Point(38, 56);
            this.class14.Margin = new System.Windows.Forms.Padding(2);
            this.class14.Name = "class14";
            this.class14.Size = new System.Drawing.Size(136, 58);
            this.class14.TabIndex = 9;
            this.class14.Text = "Back";
            this.class14.TextColor = System.Drawing.Color.White;
            this.class14.UseVisualStyleBackColor = false;
            this.class14.Click += new System.EventHandler(this.class14_Click);
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
            this.class13.Location = new System.Drawing.Point(718, 56);
            this.class13.Margin = new System.Windows.Forms.Padding(2);
            this.class13.Name = "class13";
            this.class13.Size = new System.Drawing.Size(136, 58);
            this.class13.TabIndex = 8;
            this.class13.Text = "Submit";
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
            this.class11.Location = new System.Drawing.Point(718, 117);
            this.class11.Margin = new System.Windows.Forms.Padding(2);
            this.class11.Name = "class11";
            this.class11.Size = new System.Drawing.Size(136, 58);
            this.class11.TabIndex = 7;
            this.class11.Text = "Clear";
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
            this.class12.Location = new System.Drawing.Point(718, 178);
            this.class12.Margin = new System.Windows.Forms.Padding(2);
            this.class12.Name = "class12";
            this.class12.Size = new System.Drawing.Size(136, 58);
            this.class12.TabIndex = 6;
            this.class12.Text = "Reset";
            this.class12.TextColor = System.Drawing.Color.White;
            this.class12.UseVisualStyleBackColor = false;
            this.class12.Click += new System.EventHandler(this.class12_Click);
            // 
            // class16
            // 
            this.class16.BackColor = System.Drawing.Color.Crimson;
            this.class16.BackgroundColor = System.Drawing.Color.Crimson;
            this.class16.BorderColor = System.Drawing.Color.White;
            this.class16.BorderRadius = 25;
            this.class16.BorderSize = 2;
            this.class16.FlatAppearance.BorderSize = 0;
            this.class16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class16.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.class16.ForeColor = System.Drawing.Color.White;
            this.class16.Location = new System.Drawing.Point(718, 300);
            this.class16.Name = "class16";
            this.class16.Size = new System.Drawing.Size(136, 56);
            this.class16.TabIndex = 11;
            this.class16.Text = "Save Schedule";
            this.class16.TextColor = System.Drawing.Color.White;
            this.class16.UseVisualStyleBackColor = false;
            // 
            // class17
            // 
            this.class17.BackColor = System.Drawing.Color.Crimson;
            this.class17.BackgroundColor = System.Drawing.Color.Crimson;
            this.class17.BorderColor = System.Drawing.Color.White;
            this.class17.BorderRadius = 25;
            this.class17.BorderSize = 2;
            this.class17.FlatAppearance.BorderSize = 0;
            this.class17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class17.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.class17.ForeColor = System.Drawing.Color.White;
            this.class17.Location = new System.Drawing.Point(718, 362);
            this.class17.Name = "class17";
            this.class17.Size = new System.Drawing.Size(136, 56);
            this.class17.TabIndex = 12;
            this.class17.Text = "Open Schedule";
            this.class17.TextColor = System.Drawing.Color.White;
            this.class17.UseVisualStyleBackColor = false;
            // 
            // DirScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 671);
            this.Controls.Add(this.class17);
            this.Controls.Add(this.class16);
            this.Controls.Add(this.class15);
            this.Controls.Add(this.class14);
            this.Controls.Add(this.class13);
            this.Controls.Add(this.class11);
            this.Controls.Add(this.class12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DirScheduler";
            this.Text = "DirScheduler";
            this.Load += new System.EventHandler(this.DirScheduler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Database1DataSet database1DataSet1;
        private CustomButtons.Buttons.class1 class12;
        private CustomButtons.Buttons.class1 class11;
        private CustomButtons.Buttons.class1 class13;
        private CustomButtons.Buttons.class1 class14;
        private CustomButtons.Buttons.class1 class15;
        private CustomButtons.Buttons.class1 class16;
        private CustomButtons.Buttons.class1 class17;
    }
}