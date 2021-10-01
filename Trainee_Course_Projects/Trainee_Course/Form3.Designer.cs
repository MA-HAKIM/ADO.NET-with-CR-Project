
namespace Trainee_Course
{
    partial class Form3
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.Cname = new System.Windows.Forms.TextBox();
            this.CAdmit = new System.Windows.Forms.DateTimePicker();
            this.CTname = new System.Windows.Forms.ComboBox();
            this.Cid = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.Cname);
            this.groupBox4.Controls.Add(this.CAdmit);
            this.groupBox4.Controls.Add(this.CTname);
            this.groupBox4.Controls.Add(this.Cid);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(418, 228);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Insert_Course";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(115, 174);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Cname
            // 
            this.Cname.Location = new System.Drawing.Point(115, 99);
            this.Cname.Name = "Cname";
            this.Cname.Size = new System.Drawing.Size(151, 20);
            this.Cname.TabIndex = 4;
            // 
            // CAdmit
            // 
            this.CAdmit.Location = new System.Drawing.Point(115, 139);
            this.CAdmit.Name = "CAdmit";
            this.CAdmit.Size = new System.Drawing.Size(200, 20);
            this.CAdmit.TabIndex = 3;
            // 
            // CTname
            // 
            this.CTname.DisplayMember = "TraineeName";
            this.CTname.FormattingEnabled = true;
            this.CTname.Location = new System.Drawing.Point(115, 63);
            this.CTname.Name = "CTname";
            this.CTname.Size = new System.Drawing.Size(151, 21);
            this.CTname.TabIndex = 2;
            this.CTname.ValueMember = "TraineeId";
            // 
            // Cid
            // 
            this.Cid.AutoSize = true;
            this.Cid.Location = new System.Drawing.Point(112, 33);
            this.Cid.Name = "Cid";
            this.Cid.Size = new System.Drawing.Size(35, 13);
            this.Cid.TabIndex = 1;
            this.Cid.Text = "label5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Course Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Admit Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Trainee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Course Id";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 294);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox Cname;
        private System.Windows.Forms.DateTimePicker CAdmit;
        private System.Windows.Forms.ComboBox CTname;
        private System.Windows.Forms.Label Cid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}