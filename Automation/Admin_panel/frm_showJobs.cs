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
    public partial class frm__showJobs : Form
    {
        int GetJobLevel;
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm__showJobs()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm__showJobs_Activated(object sender, EventArgs e)   /// s.27
        {
            treeView_jobLest.Nodes.Clear();
            TreeNode n = new TreeNode("Managing Director");
            n.ForeColor = Color.Red;
            n.Tag = 1;
            treeView_jobLest.Nodes.Add(n);

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

            if (query.Count >0)
            {
                for(int i=0; i<query.Count;i++)
                {
                    TreeNode M = new TreeNode();
                    M.Tag = query[i].jobsID;
                    M.Text = query[i].jobsID + "-" + query[i].jobsName;

                    if (TN.Level<this.imageList1.Images.Count -1)
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

                    if (CH>0)
                    {
                        LoadTreeViewNode(M);
                    }
                    M = null;
                }
            }
        }

        private void btn_addJob_Click(object sender, EventArgs e) /// s.28
        {
            if (treeView_jobLest.SelectedNode == null)
            {
                MessageBox.Show("Please select one of the components to create a new job.");
                return;
            }

            Frm_add_edit_Jobs w_aej = new Frm_add_edit_Jobs();
            int getTag = Convert.ToInt32(treeView_jobLest.SelectedNode.Tag);
            w_aej.Get_jobLevel = getTag;
            w_aej.Get_DetermineJobLevel = GetJobLevel;

            w_aej.formType = 1;
            w_aej.ShowDialog();

        }

        private void treeView_jobLest_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView_jobLest.SelectedNode;
            GetJobLevel = e.Node.Level;

        }

        private void btn_editJob_Click(object sender, EventArgs e)
        {
            if (treeView_jobLest.SelectedNode == null)
            {
                MessageBox.Show("Please select one of the components to edit the job first.");
                return;
            }
            Frm_add_edit_Jobs w_aej = new Frm_add_edit_Jobs();
            int getTag = Convert.ToInt32(treeView_jobLest.SelectedNode.Tag);
            w_aej.Get_jobId = getTag;

            w_aej.formType = 2; ///update
            w_aej.ShowDialog();

        }
    }
}
