namespace GymManageProject
{
    partial class AddEditUserForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEddit = new System.Windows.Forms.Button();
            this.txtUsrName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblConcirm = new System.Windows.Forms.Label();
            this.txtPassConfirm = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblalert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label5.Location = new System.Drawing.Point(309, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = "كلمةالمرور";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.Lavender;
            this.txtPass.Location = new System.Drawing.Point(71, 142);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(211, 20);
            this.txtPass.TabIndex = 70;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(23, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 37);
            this.btnDelete.TabIndex = 69;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEddit
            // 
            this.btnEddit.BackColor = System.Drawing.Color.Black;
            this.btnEddit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEddit.Location = new System.Drawing.Point(169, 240);
            this.btnEddit.Name = "btnEddit";
            this.btnEddit.Size = new System.Drawing.Size(204, 37);
            this.btnEddit.TabIndex = 68;
            this.btnEddit.Text = "حفظ التعديلات";
            this.btnEddit.UseVisualStyleBackColor = false;
            this.btnEddit.Visible = false;
            this.btnEddit.Click += new System.EventHandler(this.btnEddit_Click);
            // 
            // txtUsrName
            // 
            this.txtUsrName.BackColor = System.Drawing.Color.Lavender;
            this.txtUsrName.Location = new System.Drawing.Point(71, 109);
            this.txtUsrName.Name = "txtUsrName";
            this.txtUsrName.Size = new System.Drawing.Size(212, 20);
            this.txtUsrName.TabIndex = 67;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Lavender;
            this.txtName.Location = new System.Drawing.Point(71, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 20);
            this.txtName.TabIndex = 60;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.Lavender;
            this.txtID.Cursor = System.Windows.Forms.Cursors.No;
            this.txtID.Location = new System.Drawing.Point(195, 44);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(87, 20);
            this.txtID.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label4.Location = new System.Drawing.Point(310, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "اسم المستخدم";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label2.Location = new System.Drawing.Point(309, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "الاسم";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label1.Location = new System.Drawing.Point(310, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "الرقم";
            // 
            // LblConcirm
            // 
            this.LblConcirm.AutoSize = true;
            this.LblConcirm.BackColor = System.Drawing.Color.Black;
            this.LblConcirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblConcirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConcirm.ForeColor = System.Drawing.Color.LavenderBlush;
            this.LblConcirm.Location = new System.Drawing.Point(310, 185);
            this.LblConcirm.Margin = new System.Windows.Forms.Padding(0);
            this.LblConcirm.Name = "LblConcirm";
            this.LblConcirm.Size = new System.Drawing.Size(102, 13);
            this.LblConcirm.TabIndex = 73;
            this.LblConcirm.Text = "تأكيد كلمة المرور";
            // 
            // txtPassConfirm
            // 
            this.txtPassConfirm.BackColor = System.Drawing.Color.Lavender;
            this.txtPassConfirm.Location = new System.Drawing.Point(72, 178);
            this.txtPassConfirm.Name = "txtPassConfirm";
            this.txtPassConfirm.Size = new System.Drawing.Size(211, 20);
            this.txtPassConfirm.TabIndex = 72;
            this.txtPassConfirm.UseSystemPasswordChar = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Black;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdd.Location = new System.Drawing.Point(168, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(204, 37);
            this.btnAdd.TabIndex = 74;
            this.btnAdd.Text = "حفظ";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblalert
            // 
            this.lblalert.AutoSize = true;
            this.lblalert.BackColor = System.Drawing.Color.Transparent;
            this.lblalert.Location = new System.Drawing.Point(150, 211);
            this.lblalert.Name = "lblalert";
            this.lblalert.Size = new System.Drawing.Size(13, 13);
            this.lblalert.TabIndex = 75;
            this.lblalert.Text = "_";
            // 
            // AddEditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GymManageProject.Properties.Resources.download__2_;
            this.ClientSize = new System.Drawing.Size(418, 303);
            this.Controls.Add(this.lblalert);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.LblConcirm);
            this.Controls.Add(this.txtPassConfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEddit);
            this.Controls.Add(this.txtUsrName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditUserForm";
            this.Load += new System.EventHandler(this.AddEditUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEddit;
        private System.Windows.Forms.TextBox txtUsrName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblConcirm;
        private System.Windows.Forms.TextBox txtPassConfirm;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblalert;
    }
}