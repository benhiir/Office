using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelLayer.Models;
using Automation.modula;


namespace Automation.Admin_panel
{
    public partial class Frm_JobsHistory : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public int Get_UserID { get; set; }
        public Frm_JobsHistory()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowUserInfo()
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_UserJobs>("select * from Vw_UserJobs where userId = " + this.Get_UserID);
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_JobHistory.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_JobHistory.Rows[i].Cells["userJobsId"].Value = result[i].userJobsId;
                    dgv_JobHistory.Rows[i].Cells["FullName"].Value = result[i].FullName;
                    dgv_JobHistory.Rows[i].Cells["StartDate"].Value = result[i].UserJobStartDate;
                    dgv_JobHistory.Rows[i].Cells["EndDate"].Value = result[i].UserJobEndDate;
                    dgv_JobHistory.Rows[i].Cells["Jobname"].Value = result[i].jobsName;
                    dgv_JobHistory.Rows[i].Cells["Status"].Value = result[i].FarsiStatus;

                }
                dgv_JobHistory.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_JobHistory.Rows.Clear();
            }
        }

        private void Frm_JobsHistory_Load(object sender, EventArgs e)
        {
            ShowUserInfo();
        }

        private void btn_SetJob_Click(object sender, EventArgs e)
        {
            var query = (from UserJ in database.Userjobs where UserJ.userID == Get_UserID where UserJ.Status == 1 select UserJ).ToList();
            if (query.Count > 0)
            {
                MessageBox.Show("This user already has a job. To be assigned a job, you must first be dismissed from its previous job.");

            }
            else
            {
                frm_setJobs frm_sj = new frm_setJobs();
                frm_sj.lbl_fullname.Text = lbl_UserFullName.Text;
                frm_sj.get_userIdForsetjob = this.Get_UserID;
                frm_sj.ShowDialog();
                ShowUserInfo();
            }


        }

        private void btn_giveJob_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you confident of dismissal?", "Dismissal", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                try
                {
                    var query = (from P in database.Userjobs where P.userID == this.Get_UserID where P.Status == 1 select P).SingleOrDefault();
                    query.Status = 2;
                    query.UserJobEndDate = PublicVariable.TodayDate;
                    database.SaveChanges();
                    MessageBox.Show("Job was taken successfully");
                    ShowUserInfo();
                }
                catch
                {
                    MessageBox.Show("There is a problem with the server. Please try again.");
                }
            }
            
            
        }
    }
}
