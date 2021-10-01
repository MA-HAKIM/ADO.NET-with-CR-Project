using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trainee_Course
{
    public partial class Form1 : Form,ITraineeCourse
    {
        DataSet ds = new DataSet();
        SqlDataAdapter daTrainees, daCourses;
        BindingSource bsTrainees = new BindingSource();
        BindingSource bsCourses = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trainee"].ConnectionString);
            daTrainees = new SqlDataAdapter("SELECT * FROM Trainees", con);
            daCourses = new SqlDataAdapter("SELECT * FROM Courses", con);
            FillDataSet();
            SetUpDataBindings();
            SqlCommandBuilder b1 = new SqlCommandBuilder(daTrainees);
            SqlCommandBuilder b2 = new SqlCommandBuilder(daCourses);

            this.dataGridView1.DataSource = bsTrainees;
            this.dataGridView2.DataSource = bsCourses;
            this.CTname.DataSource = bsTrainees;

            this.groupBox2.Text = $"Trainee {bsTrainees.Position + 1} of {bsTrainees.Count }";
            this.groupBox4.Text = $"Course {bsCourses.Position + 1} of {bsCourses.Count }";
        }

        private void FillDataSet()
        {
            daTrainees.Fill(ds, "Trainees");
            daCourses.Fill(ds, "Courses");
            ds.Tables["Trainees"].PrimaryKey = new DataColumn[] { ds.Tables["Trainees"].Columns["TraineeId"] };
            ds.Tables["Courses"].PrimaryKey = new DataColumn[] { ds.Tables["Courses"].Columns["CourseId"] };
            DataRelation rel = new DataRelation("FK_TR_CS", ds.Tables["Trainees"].Columns["TraineeId"], ds.Tables["Courses"].Columns["TraineeId"]);
            ds.Relations.Add(rel);
        }

        private void SetUpDataBindings()
        {
            bsTrainees.DataSource = ds;
            bsTrainees.DataMember = "Trainees";
            bsCourses.DataSource = bsTrainees;
            bsCourses.DataMember = "FK_TR_CS";

            bsTrainees.CurrentChanged += BsTrainees_CurrentChanged;
            bsCourses.CurrentChanged += BsCourses_CurrentChanged;

            Tid.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsTrainees, "TraineeId", true));
            Tname.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsTrainees, "TraineeName", true));
            Tmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsTrainees, "Email", true));
            Tpic.DataBindings.Add(new System.Windows.Forms.Binding("Image", bsTrainees, "Picture", true));

            Cid.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCourses, "CourseId", true));
            CTname.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", bsCourses, "TraineeId", true));
            CAdmit.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCourses, "Admit", true));
            Cname.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCourses, "CourseName", true));
        }

        private void BsTrainees_CurrentChanged(object sender, EventArgs e)
        {
            this.groupBox2.Text = $"Trainee {bsTrainees.Position + 1} of {bsTrainees.Count }";
        }

        private void BsCourses_CurrentChanged(object sender, EventArgs e)
        {
            this.groupBox4.Text = $"Course {bsCourses.Position + 1} of {bsCourses.Count }";
        }

        public void RebindTrainee()
        {
            daTrainees.Fill(ds, "Trainees");
        }

        public void RebindCourse()
        {
            daCourses.Fill(ds, "Courses");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Form2 { FormData = this }.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bsTrainees.EndEdit();
            daTrainees.Update(ds.Tables["Trainees"]);
            ds.Tables["Trainees"].AcceptChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.bsTrainees.EndEdit();
            var r = ds.Tables["Trainees"].Rows.Find(int.Parse(Tid.Text));
            var child = r.GetChildRows("FK_TR_CS");
            if (child.Length > 0)
            {
                MessageBox.Show("Trainee has related records. Cannot detete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                r.Delete();
                this.daTrainees.Update(ds.Tables["Trainees"]);
                ds.Tables["Trainees"].AcceptChanges();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form3 { DataForm = this }.ShowDialog();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReportForm().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.bsCourses.EndEdit();
            var r = ds.Tables["Courses"].Rows.Find(int.Parse(Cid.Text));
            r.Delete();
            this.daCourses.Update(ds.Tables["Courses"]);
            ds.Tables["Courses"].AcceptChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.bsTrainees.EndEdit();
                var r = ds.Tables["Trainees"].Rows.Find(int.Parse(Tid.Text));

                r["Picture"] = File.ReadAllBytes(openFileDialog1.FileName);
            }
        }
    }
}
