using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trainee_Course
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public ITraineeCourse DataForm { get; set; }

        private void Form3_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trainee"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT ISNULL(MAX(CourseId ), 0)+1 FROM Courses";

                    con.Open();
                    int id = (int)cmd.ExecuteScalar();
                    con.Close();
                    Cid.Text = id.ToString();
                }
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT TraineeId, TraineeName FROM Trainees", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    CTname.DataSource = dt;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Trainee_Course.Properties.Settings.TraineeCourseDBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Courses (CourseId,CourseName,Admit,TraineeId) VALUES(@cid,@cname,@admit,@tid)";
                    cmd.Parameters.AddWithValue("@cid", Cid.Text);
                    cmd.Parameters.AddWithValue("@cname", Cname.Text);
                    cmd.Parameters.AddWithValue("@admit", CAdmit.Value.Date);
                    cmd.Parameters.AddWithValue("@tid", CTname.SelectedValue);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.DataForm.RebindCourse();

                    this.Close();
                }
            }
        }
    }
}
