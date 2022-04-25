namespace schedule2
{
    partial class ChangePassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.NewPasswordAgain = new CustomButtons.TextBox.newTextBox();
            this.NewPassword = new CustomButtons.TextBox.newTextBox();
            this.Submit = new CustomButtons.Buttons.class1();
            this.Back = new CustomButtons.Buttons.class1();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(92, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 35);
            this.label2.TabIndex = 20;
            this.label2.Text = "New Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(11, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 35);
            this.label1.TabIndex = 22;
            this.label1.Text = "New Password Again:";
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.ErrorMessage.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMessage.ForeColor = System.Drawing.Color.Crimson;
            this.ErrorMessage.Location = new System.Drawing.Point(13, 183);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(0, 20);
            this.ErrorMessage.TabIndex = 23;
            // 
            // NewPasswordAgain
            // 
            this.NewPasswordAgain.BackColor = System.Drawing.SystemColors.Window;
            this.NewPasswordAgain.BorderColor = System.Drawing.Color.Silver;
            this.NewPasswordAgain.BorderFocusColor = System.Drawing.Color.Crimson;
            this.NewPasswordAgain.BorderSize = 2;
            this.NewPasswordAgain.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordAgain.ForeColor = System.Drawing.Color.Black;
            this.NewPasswordAgain.Location = new System.Drawing.Point(305, 115);
            this.NewPasswordAgain.Margin = new System.Windows.Forms.Padding(4);
            this.NewPasswordAgain.Multiline = false;
            this.NewPasswordAgain.Name = "NewPasswordAgain";
            this.NewPasswordAgain.Padding = new System.Windows.Forms.Padding(7);
            this.NewPasswordAgain.PasswordChar = false;
            this.NewPasswordAgain.Size = new System.Drawing.Size(278, 32);
            this.NewPasswordAgain.TabIndex = 21;
            this.NewPasswordAgain.Texts = "";
            this.NewPasswordAgain.UnderlinedStyle = false;
            // 
            // NewPassword
            // 
            this.NewPassword.BackColor = System.Drawing.SystemColors.Window;
            this.NewPassword.BorderColor = System.Drawing.Color.Silver;
            this.NewPassword.BorderFocusColor = System.Drawing.Color.Crimson;
            this.NewPassword.BorderSize = 2;
            this.NewPassword.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPassword.ForeColor = System.Drawing.Color.Black;
            this.NewPassword.Location = new System.Drawing.Point(305, 47);
            this.NewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.NewPassword.Multiline = false;
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.Padding = new System.Windows.Forms.Padding(7);
            this.NewPassword.PasswordChar = false;
            this.NewPassword.Size = new System.Drawing.Size(278, 32);
            this.NewPassword.TabIndex = 19;
            this.NewPassword.Texts = "";
            this.NewPassword.UnderlinedStyle = false;
            // 
            // Submit
            // 
            this.Submit.BackColor = System.Drawing.Color.Crimson;
            this.Submit.BackgroundColor = System.Drawing.Color.Crimson;
            this.Submit.BorderColor = System.Drawing.Color.White;
            this.Submit.BorderRadius = 25;
            this.Submit.BorderSize = 2;
            this.Submit.FlatAppearance.BorderSize = 0;
            this.Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Submit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.Submit.ForeColor = System.Drawing.Color.White;
            this.Submit.Location = new System.Drawing.Point(449, 164);
            this.Submit.Margin = new System.Windows.Forms.Padding(2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(136, 58);
            this.Submit.TabIndex = 18;
            this.Submit.Text = "Submit";
            this.Submit.TextColor = System.Drawing.Color.White;
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.class14_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Crimson;
            this.Back.BackgroundColor = System.Drawing.Color.Crimson;
            this.Back.BorderColor = System.Drawing.Color.White;
            this.Back.BorderRadius = 25;
            this.Back.BorderSize = 2;
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.Back.ForeColor = System.Drawing.Color.White;
            this.Back.Location = new System.Drawing.Point(305, 164);
            this.Back.Margin = new System.Windows.Forms.Padding(2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(136, 58);
            this.Back.TabIndex = 24;
            this.Back.Text = "Back";
            this.Back.TextColor = System.Drawing.Color.White;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(596, 230);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.NewPasswordAgain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Submit);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButtons.Buttons.class1 Submit;
        private CustomButtons.TextBox.newTextBox NewPassword;
        private System.Windows.Forms.Label label2;
        private CustomButtons.TextBox.newTextBox NewPasswordAgain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrorMessage;
        private CustomButtons.Buttons.class1 Back;
    }
}