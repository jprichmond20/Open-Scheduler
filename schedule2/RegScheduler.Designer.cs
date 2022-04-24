namespace schedule2
{
    partial class RegScheduler
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
            this.class11 = new CustomButtons.Buttons.class1();
            this.class12 = new CustomButtons.Buttons.class1();
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label1.Location = new System.Drawing.Point(379, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Weekly Availability";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 133);
            this.label2.TabIndex = 3;
            this.label2.Text = "Click and drag to enter you availability to work at the Writing Center. Press Sub" +
    "mit when finished or press Clear to restart.";
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.class11.Location = new System.Drawing.Point(718, 132);
            this.class11.Margin = new System.Windows.Forms.Padding(2);
            this.class11.Name = "class11";
            this.class11.Size = new System.Drawing.Size(136, 58);
            this.class11.TabIndex = 2;
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
            this.class12.Location = new System.Drawing.Point(718, 56);
            this.class12.Margin = new System.Windows.Forms.Padding(2);
            this.class12.Name = "class12";
            this.class12.Size = new System.Drawing.Size(136, 58);
            this.class12.TabIndex = 1;
            this.class12.Text = "Submit";
            this.class12.TextColor = System.Drawing.Color.White;
            this.class12.UseVisualStyleBackColor = false;
            this.class12.Click += new System.EventHandler(this.class12_Click);
            // 
            // RegScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(863, 671);
            this.Controls.Add(this.class12);
            this.Controls.Add(this.class11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RegScheduler";
            this.Text = "RegScheduler";
            this.Load += new System.EventHandler(this.RegScheduler_Load);
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
        private CustomButtons.Buttons.class1 class11;
        private CustomButtons.Buttons.class1 class12;
    }
}