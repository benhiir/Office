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
    public partial class Frm_add_edit_Jobs : Form
    {
        public int Get_jobLevel { get; set; }
        public int Get_DetermineJobLevel { get; set; }

        automation_systemEntities db = new automation_systemEntities(PublicVariable.MainConnectionString);
        public byte formType { get; set;}
        public int Get_jobId { get; set; }
        public Frm_add_edit_Jobs()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e) //s.28
        {
            try
            {
                if (this.formType == 1)
                {
                    if (txt_jobName.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter the job title.");
                        return;
                    }
                    Job j = new Job();
                    j.jobsName = txt_jobName.Text.Trim();
                    j.jobsDetail = txt_jobDetail.Text.Trim();
                    j.jobsLevel = this.Get_jobLevel;
                    j.DetermineJobsLevel = this.Get_DetermineJobLevel + 1;
                    db.Jobs.Add(j);
                    db.SaveChanges();
                    MessageBox.Show("New job created successfully.");
                    this.Close();
                }
                else if (this.formType == 2)
                {
                    if (txt_jobName.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter the job title.");
                        return;
                    }
                    var query_update = (from J in db.Jobs where J.jobsID == this.Get_jobId select J).SingleOrDefault();
                    query_update.jobsName = txt_jobName.Text.Trim();
                    query_update.jobsDetail = txt_jobDetail.Text.Trim();
                    db.SaveChanges();
                    MessageBox.Show("Job information successfully edited.");
                    this.Close();

                }
            }
            catch
            {
                MessageBox.Show("There are problems with the server, please try again.");
                return;
            }
        }

        private void Frm_add_edit_Jobs_Load(object sender, EventArgs e)
        {
            if (this.formType ==2)
            {
                var query = (from J in db.Jobs where J.jobsID == this.Get_jobId select J).ToList();

                if (query.Count ==1)
                {
                    txt_jobName.Text = query[0].jobsName;
                    txt_jobDetail.Text = query[0].jobsDetail;
                }
            }
        }
    }
}
