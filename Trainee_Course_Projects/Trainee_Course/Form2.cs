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
    public partial class Form2 : Form
    {
        string image = "";
        public Form2()
        {
            InitializeComponent();
        }

        public ITraineeCourse FormData { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Trainee_Course.Properties.Settings.TraineeCourseDBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select isnull(max(TraineeId),0)+1 From Trainees";
                    con.Open();
                    int id = (int)cmd.ExecuteScalar();
                    con.Close();
                    Tid.Text = id.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image = openFileDialog1.FileName;
                Tpic.Image = Image.FromFile(image);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Trainee_Course.Properties.Settings.TraineeCourseDBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Trainees(TraineeId, TraineeName, Email,Picture)" +
                        "VALUES(@id, @name, @email, @pic)";
                    cmd.Parameters.AddWithValue("@id", Tid.Text);
                    cmd.Parameters.AddWithValue("@name", Tname.Text);
                    cmd.Parameters.AddWithValue("@pic", File.ReadAllBytes(image));
                    cmd.Parameters.AddWithValue("@email", Tmail.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.FormData.RebindTrainee();

                    
                    this.Close();
                }
            }
        }
    }
    
}
