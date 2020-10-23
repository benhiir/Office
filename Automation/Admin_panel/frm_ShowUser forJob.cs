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
    public partial class frm_ShowUserforJob : Form
    {
        public byte FormType {get; set;} /// 1= Job Assignment،  
                                         /// 2 = Assign access levels

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_ShowUserforJob()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowUserInfo(string searchStatement)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_Users>("select * from Vw_Users where 1=1" + searchStatement);
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_showUser.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showUser.Rows[i].Cells["userId"].Value = result[i].userID;
                    dgv_showUser.Rows[i].Cells["Firstname"].Value = result[i].UserFirstName;
                    dgv_showUser.Rows[i].Cells["family"].Value = result[i].UserFamily;
                    dgv_showUser.Rows[i].Cells["personalcode"].Value = result[i].PersonalCode;
                    dgv_showUser.Rows[i].Cells["gender"].Value = result[i].farsiGender;
                    dgv_showUser.Rows[i].Cells["activity"].Value = result[i].farsiActivity;
                }
                dgv_showUser.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showUser.Rows.Clear();
            }
        }

        private void frm_ShowUserforJob_Load(object sender, EventArgs e)
        {
            ShowUserInfo(createSearchString());
        }
        private string createSearchString()
        {
            string searchString = "";
            if (txt_firstName.Text != "")
                searchString += " and UserFirstName like '%" + txt_firstName.Text + "%'";
            if (txt_family.Text != "")
                searchString += " and UserFamily like'%" + txt_family.Text + "%'";
            if (txt_personalCode.Text != "")
                searchString += " and PersonalCode like'%" + txt_personalCode.Text + "%'";

            return searchString;
        }

        private void pictureBox_searchUser_Click(object sender, EventArgs e)
        {
            ShowUserInfo(createSearchString());
        }

        private void btn_jobHistory_Click(object sender, EventArgs e)
        {
            int item = dgv_showUser.SelectedCells.Count;

            if (item == 0)
            {
                MessageBox.Show("Please select a user.");
                return;
            }
            else
            {
                if (this.FormType == 1)
                {
                    Frm_JobsHistory frm_jh = new Frm_JobsHistory();
                    frm_jh.Get_UserID = Convert.ToInt32(dgv_showUser.CurrentRow.Cells["UserId"].Value);
                    frm_jh.lbl_UserFullName.Text = dgv_showUser.CurrentRow.Cells["Firstname"].Value + " " + dgv_showUser.CurrentRow.Cells["family"].Value;
                    frm_jh.ShowDialog();
                }
                else if (this.FormType == 2)
                {
                    frm_SabteDastresi frm_sd = new frm_SabteDastresi();
                    frm_sd.GetUserID = Convert.ToInt32(dgv_showUser.CurrentRow.Cells["UserId"].Value);
                    frm_sd.lbl_title.Text = "Access Level Determination Form for " + dgv_showUser.CurrentRow.Cells["Firstname"].Value.ToString() + " " + dgv_showUser.CurrentRow.Cells["family"].Value.ToString();
                    frm_sd.ShowDialog();
                }


            }
        }
    }
}
