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
    public partial class frm_setJobs : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public int get_userIdForsetjob {get; set;}

        public frm_setJobs()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_setJobs_Activated(object sender, EventArgs e)
        {
            treeView_setJob.Nodes.Clear();
            TreeNode n = new TreeNode("Managing Director");
            n.ForeColor = Color.Red;
            n.Tag = 1;
            treeView_setJob.Nodes.Add(n);

            //// call load method 
            LoadTreeViewNode(n);
            /////

            n.Expand(); /// open treeview
        }
        private void LoadTreeViewNode(TreeNode TN)   //// s.27 
        {
           
            int TagInt;
            TagInt = Convert.ToInt32(TN.Tag);
            var query = (from Vw_j in database.Vw_jobs where Vw_j.jobsLevel == TagInt select Vw_j).ToList();

            if (query.Count > 0)
            {
                for (int i = 0; i < query.Count; i++)
                {
                    TreeNode M = new TreeNode();
                    M.Tag = query[i].jobsID;
                    M.Text = query[i].jobsID + "-" + query[i].jobsName;

                    if (TN.Level < this.imageList1.Images.Count - 1)
                    {
                        M.ImageIndex = TN.Level + 1;
                        M.SelectedImageIndex = TN.Level + 1;

                    }
                    else
                    {
                        M.ImageIndex = this.imageList1.Images.Count - 1;
                        M.SelectedImageIndex = this.imageList1.Images.Count - 1;

                    }

                    TN.Nodes.Add(M);
                    int CH = Convert.ToInt32(query[i].childCount);

                    if (CH > 0)
                    {
                        LoadTreeViewNode(M);
                    }
                    M = null;
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e) ////s.32
        {
            try
            {
                GetCheckedNodes(treeView_setJob.Nodes);
            }
            catch
            {
                MessageBox.Show("There was a problem communicating with the server. Please try again.");
            }
        }

       public List<string> GetCheckedNodes(TreeNodeCollection nodes)
        {
            List<string> nodelist = new List<string>();
            if (nodes == null)
            {
                return nodelist;
            }
                foreach (TreeNode childNodes in nodes)
                {
                    if (childNodes.IsSelected)
                    {
                        Userjob uj = new Userjob();
                        uj.userID = get_userIdForsetjob;
                        uj.JobId = Convert.ToInt32(childNodes.Tag);
                        uj.UserJobStartDate = PublicVariable.TodayDate;
                        uj.Status = 1;

                    //  Control that the user does not take a job twice
                    int GetJobId = Convert.ToInt32(childNodes.Tag);
                        var query = (from Usj in database.Userjobs where Usj.userID == this.get_userIdForsetjob where Usj.JobId == GetJobId select Usj).ToList();

                    //  Warning / controlling the possession of another person's job

                    var query_job = (from UJob in database.Userjobs where UJob.JobId == GetJobId where UJob.Status == 1 select UJob).ToList();
                    if (query_job.Count>0)
                    {
                        if(MessageBox.Show("This job is in the possession of someone else, will you continue?", "Attention ", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            break;
                        }
                  
                    }

                    if (query.Count == 0)
                        {
                            database.Userjobs.Add(uj);
                            database.SaveChanges();
                            MessageBox.Show("The new job was successfully assigned to the user");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Note, this user has already had this job.");
                        // با وجود سابقه داشتن شغل باز هم شغل تخصیص مییابد
                            database.Userjobs.Add(uj);
                            database.SaveChanges();
                            MessageBox.Show("The new job was successfully assigned to the user");
                            this.Close();

                    }

                    }
                    nodelist.AddRange(GetCheckedNodes(childNodes.Nodes));
                    
                }
            return nodelist;
        }
            
        
        
        // private string GetArreyofcheckNodes
    }
}
