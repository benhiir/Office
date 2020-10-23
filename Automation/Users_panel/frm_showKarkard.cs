using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.modula;
using DataModelLayer.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace Automation.Users_panel
{
    public partial class frm_showKarkard : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        public string UserJobName { get; set; }
        public int UserJobID { get; set; }

        List<int> UID = new List<int>();
        List<string> Family = new List<string>();
        List<int> time = new List<int>();
        public frm_showKarkard()
        {
            InitializeComponent();
        }

        private void frm_showKarkard_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 142;
        }

        private void frm_showKarkard_Activated(object sender, EventArgs e)
        {
            trv_yourPersonel.Nodes.Clear();
            TreeNode n = new TreeNode(UserJobName);
            n.ForeColor = Color.Red;
            n.Tag = UserJobID;
            trv_yourPersonel.Nodes.Add(n);

            //// call load method 
            LoadTreeViewNode(n);
         

            n.Expand(); /// open treeview

            showChart();
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
                    ////To display the name of the employee who has the job
                    int currentJobId = query[i].jobsID;
                    var query_name = (from UJ in database.Vw_UserJobs where UJ.JobId == currentJobId where UJ.Status == 1 select UJ).ToList();
                    if (query_name.Count > 0)
                    {
                        M.Text = M.Text + " (" + query_name[0].FullName + ")";
                        UID.Add(query_name[0].userID); //Collect each user's subset of IDs to fill out the chart
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

        private void trv_yourPersonel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int GetJobID = Convert.ToInt32(trv_yourPersonel.SelectedNode.Tag);

            var query_getUser = (from UJ in database.Vw_UserJobs where UJ.JobId == GetJobID where UJ.Status == 1 select UJ).ToList();
            lbl_totalRequest.Text = "0";
            lbl_totalTime.Text = "0";
            dgv_showAllWorks.Rows.Clear();
            if (query_getUser.Count > 0)
            {
                var query = database.Database.SqlQuery<Vw_works>("select * from Vw_works where userid =" + query_getUser[0].userID + " ");
                var result = query.ToList();

                dgv_showAllWorks.Rows.Clear();  

                if (result.Count != 0)
                {
                    int total_time = 0;
                    dgv_showAllWorks.RowCount = result.Count;
                    for (int i = 0; i <= result.Count - 1; i++)
                    {
                        dgv_showAllWorks.Rows[i].Cells["worksId"].Value = result[i].worksID;
                        dgv_showAllWorks.Rows[i].Cells["works_subject"].Value = result[i].work_subject;
                        dgv_showAllWorks.Rows[i].Cells["works_description"].Value = result[i].work_description;
                        dgv_showAllWorks.Rows[i].Cells["works_request"].Value = result[i].jobsName;
                        dgv_showAllWorks.Rows[i].Cells["works_requestid"].Value = result[i].jobID;
                        dgv_showAllWorks.Rows[i].Cells["works_time"].Value = result[i].timeDone;
                        dgv_showAllWorks.Rows[i].Cells["works_dateDone"].Value = result[i].dateDone;
                        total_time += Convert.ToInt32(result[i].timeDone);

                    }
                    dgv_showAllWorks.ScrollBars = ScrollBars.Both;

                    int total_hour = total_time / 60;
                    int total_min = total_time % 60;
                    lbl_totalTime.Text = total_hour + " Hours and " + total_min + " minutes ";
                    lbl_totalRequest.Text = dgv_showAllWorks.RowCount.ToString() + " Request ";
                }
                else
                {
                    dgv_showAllWorks.Rows.Clear();
                }

            }
        }

        private void showChart()
        {
            string userid = "";
            for (int counter = 0; counter < UID.Count ; counter++)
            {
                userid += UID[counter].ToString() + ",";

            }
            userid = userid.Substring(0, userid.Length - 1); /// To clear the last comma
            string[] ListFamily = { };
            int[] ListTime = { };

            var query = database.Database.SqlQuery<Vw_showChartInfo>("select * from Vw_showChartInfo where userID in(" + userid + ") order by TotalTime").ToList();
            if (query.Count >0)
            {
                lbl_maxWork.Text = query[query.Count - 1].Fullname;
                /// Create chart columns
                for (int ii = 0; ii < query.Count; ii++)
                {
                    Family.Add(query[ii].Fullname.ToString());
                    time.Add(Convert.ToInt32(query[ii].totalTime));

                    ListFamily = Family.ToArray();
                    ListTime = time.ToArray();

                }
                this.chart1.Series.Clear();
                this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
                this.chart1.Titles.Add("Personnel performance chart");
                /// Chart guide

                for (int i = 0; i < ListFamily.Length; i++)
                {
                    Series series = this.chart1.Series.Add(ListFamily[i] + "-" + query[i].totalTime);
                    series.Points.Add(ListTime[i]);
                }
            }


        }
    }
}
