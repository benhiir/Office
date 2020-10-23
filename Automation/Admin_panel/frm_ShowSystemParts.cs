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
    
    public partial class frm_ShowSystemParts : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_ShowSystemParts()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frm_ShowSystemParts_Load(object sender, EventArgs e)
        {

        }

        private void frm_ShowSystemParts_Activated(object sender, EventArgs e)
        {
            trv_systemPart.Nodes.Clear();
            TreeNode n = new TreeNode("Rights access system");
            n.ForeColor = Color.Red;
            n.Tag = "1";
            trv_systemPart.Nodes.Add(n);

            ///Load treeview
            LoadTreeview(n);
            //////

            n.Expand();

        }
        private void LoadTreeview (TreeNode TN)
        {
            int IntTag = Convert.ToInt32(TN.Tag);

            var query = from SYSP in database.Vw_systemParts
                        where SYSP.SystemPartLevel == IntTag
                        select SYSP;
            var result = query.ToList();
            if (result.Count > 0)
            {
                for (int I = 0; I< result.Count; I++)
                {
                    TreeNode M = new TreeNode();
                    M.Tag = result[I].SystemPartID; 
                    M.Text = result[I].SystemPartName;
                    M.ToolTipText = M.Tag.ToString();

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

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (trv_systemPart.SelectedNode == null)
            {
                MessageBox.Show("To define new components, please select a component.");
                return;

            }

            frm_addSystemPart frm_AS = new frm_addSystemPart();
 
            frm_AS.GetSystemPartID = Convert.ToInt32(trv_systemPart.SelectedNode.Tag);
            frm_AS.ShowDialog();
        }
    }
}
