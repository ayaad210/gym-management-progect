namespace GymManageProject
{
    partial class UserPagesForm
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
            this.BtnSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listboxUsers = new System.Windows.Forms.ListBox();
            this.listBoxOages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.Black;
            this.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnSave.Location = new System.Drawing.Point(173, 288);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(153, 37);
            this.BtnSave.TabIndex = 77;
            this.BtnSave.Text = "حفظ";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(200, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 37);
            this.button3.TabIndex = 76;
            this.button3.Text = "<< اضافة";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(200, 162);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 37);
            this.btnDelete.TabIndex = 75;
            this.btnDelete.Text = "ازالة  >>";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listboxUsers
            // 
            this.listboxUsers.BackColor = System.Drawing.Color.Black;
            this.listboxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxUsers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listboxUsers.FormattingEnabled = true;
            this.listboxUsers.HorizontalExtent = 250;
            this.listboxUsers.HorizontalScrollbar = true;
            this.listboxUsers.ItemHeight = 16;
            this.listboxUsers.Location = new System.Drawing.Point(-1, 12);
            this.listboxUsers.Name = "listboxUsers";
            this.listboxUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listboxUsers.Size = new System.Drawing.Size(184, 244);
            this.listboxUsers.TabIndex = 73;
            // 
            // listBoxOages
            // 
            this.listBoxOages.BackColor = System.Drawing.Color.Black;
            this.listBoxOages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOages.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listBoxOages.FormattingEnabled = true;
            this.listBoxOages.HorizontalExtent = 250;
            this.listBoxOages.HorizontalScrollbar = true;
            this.listBoxOages.ItemHeight = 16;
            this.listBoxOages.Location = new System.Drawing.Point(317, 12);
            this.listBoxOages.Name = "listBoxOages";
            this.listBoxOages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBoxOages.Size = new System.Drawing.Size(180, 244);
            this.listBoxOages.TabIndex = 74;
            // 
            // UserPagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GymManageProject.Properties.Resources.download__2_;
            this.ClientSize = new System.Drawing.Size(501, 329);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listBoxOages);
            this.Controls.Add(this.listboxUsers);
            this.Name = "UserPagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserPagesForm_";
            this.Load += new System.EventHandler(this.UserPagesForm__Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox listboxUsers;
        private System.Windows.Forms.ListBox listBoxOages;
    }
}