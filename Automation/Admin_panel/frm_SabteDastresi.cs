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
    public partial class frm_SabteDastresi : Form
    {
        public int GetUserID { get; set; }

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_SabteDastresi()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_SabteDastresi_Activated(object sender, EventArgs e)
        {
            trv_dastresi.Nodes.Clear();
            TreeNode n = new TreeNode("Rights access system");
            n.ForeColor = Color.Red;
            n.Tag = "1";
            trv_dastresi.Nodes.Add(n);

            ///Load treeview
            LoadTreeview(n);



            //////

            n.Expand();
        }

        private void LoadTreeview(TreeNode TN)
        {
            int IntTag = Convert.ToInt32(TN.Tag);

            var query = from SYSP in database.Vw_systemParts
                        where SYSP.SystemPartLevel == IntTag
                        select SYSP;
            var result = query.ToList();
            if (result.Count > 0)
            {
                int GetsystemPartsID; /// Previous accesses s.93
                for (int I = 0; I < result.Count; I++)
                {
                    TreeNode M = new TreeNode();
                    M.Tag = result[I].SystemPartID;
                    M.Text = result[I].SystemPartName;
                    M.ToolTipText = M.Tag.ToString();
                    ////
                    GetsystemPartsID = Convert.ToInt32(M.Tag);
                    var query_check = (from UA in database.UsereAccesses where UA.userID == this.GetUserID where UA.SystemPardID == GetsystemPartsID select UA).ToList();
                    if (query_check.Count > 0)
                    {
                        M.Checked = true;
                    }




                    /////
                    TN.Nodes.Add(M);

                    /// Add children
                    int childConter = Convert.ToInt32(result[I].childCount);
                    if (childConter > 0)
                    {
                        LoadTreeview(M);
                    }

                    M = null;
                }
            }
        }

        private void trv_dastresi_AfterCheck(object sender, TreeViewEventArgs e)
        {
            checkTeeViewChild(e.Node, e.Node.Checked);  /// A method to select subcategories if a branch is selected.
        }


        private void checkTeeViewChild(TreeNode node, Boolean ischecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = ischecked;
                if (item.Nodes.Count > 0 )
                {
                    this.checkTeeViewChild(item, ischecked);

                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            GetCheckedNode(trv_dastresi.Nodes);

            MessageBox.Show("Accesses applied successfully.");
        }

        private List<string> GetCheckedNode(TreeNodeCollection nodes)
        {
            List<string> nodelist = new List<string>();
            if (nodes == null)
            {
                return nodelist;
            }

            foreach (TreeNode childnode in nodes)
            {
                if (childnode.Checked)
                {
                    /// Registration of access s.92
                    UsereAccess UA = new UsereAccess();
                    UA.userID = this.GetUserID;
                    UA.SystemPardID = Convert.ToInt32(childnode.Tag);

                    var query = from UAccess in database.UsereAccesses
                                where UAccess.userID == this.GetUserID
                                where UAccess.SystemPardID == UA.SystemPardID
                                select UAccess;
                    var result = query.ToList();
                    if (result.Count == 0) /// Did he already have this access?
                    {
                        database.UsereAccesses.Add(UA);
                        database.SaveChanges();
                    }
                }
                else if (childnode.Checked == false && (childnode.Tag)!= "1")  ///Get access
                {
                    try
                    {
                        database.Sp_DeleteUserAccess(this.GetUserID, Convert.ToInt32(childnode.Tag));
                        database.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("There was a problem with the server. Try again.");

                    }
                }
                nodelist.AddRange(GetCheckedNode(childnode.Nodes));

            }
            return (nodelist);
        }
    }
}
