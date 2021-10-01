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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            CrystalReport1 rpt = new CrystalReport1();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Trainee_Course.Properties.Settings.TraineeCourseDBConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Trainees", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Trainees");
            da.SelectCommand.CommandText = "SELECT * FROM Courses";
            da.Fill(ds, "Courses");
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
