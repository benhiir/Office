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
using Stimulsoft.Report;
using Automation.modula;

namespace Automation.Admin_panel
{
    public partial class frm_showUsers : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_showUsers()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_showUsers_Load(object sender, EventArgs e)
        {
            ShowUserInfo(createSearchString());
        }

        private void ShowUserInfo(string searchStatement)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_Users>("select * from Vw_Users where 1=1" + searchStatement);
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_showUsers.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showUsers.Rows[i].Cells["col_userId"].Value = result[i].userID;
                    dgv_showUsers.Rows[i].Cells["col_name"].Value = result[i].UserFirstName;
                    dgv_showUsers.Rows[i].Cells["col_family"].Value = result[i].UserFamily;
                    dgv_showUsers.Rows[i].Cells["col_personalcode"].Value = result[i].PersonalCode;
                    dgv_showUsers.Rows[i].Cells["col_tel"].Value = result[i].UserTel;
                    dgv_showUsers.Rows[i].Cells["col_email"].Value = result[i].Email;
                    dgv_showUsers.Rows[i].Cells["col_gender"].Value = result[i].farsiGender;
                    dgv_showUsers.Rows[i].Cells["col_status"].Value = result[i].farsiActivity;
                    dgv_showUsers.Rows[i].Cells["col_birthdaydate"].Value = result[i].BirthDayDate;
                    dgv_showUsers.Rows[i].Cells["col_username"].Value = result[i].Username;
                    dgv_showUsers.Rows[i].Cells["gender"].Value = result[i].Gender;
                }
                dgv_showUsers.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showUsers.Rows.Clear();
            }
        }
            private string createSearchString()
        {
            string searchString = "";
            if (txt_name.Text != "")
                searchString += " and UserFirstName like '%" + txt_name.Text + "%'";
            if (txt_family.Text != "")
                searchString += " and UserFamily like'%" + txt_family.Text + "%'";
            if (rdb_active.Checked)
                searchString += " and Activity = 1";
            if (rdb_deactive.Checked)
                searchString += " and Activity = 2";
            if (rdb_man.Checked)
                searchString += "and Gender = 1 ";
            if (rdb_woman.Checked)
                searchString += "and Gender = 2 ";
            
            return searchString;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            ShowUserInfo(createSearchString());
        }

        private void btn_newUser_Click(object sender, EventArgs e)
        {
            frm_add_edit_user f_ae = new frm_add_edit_user();
            f_ae.formtype = 1;//insert
            f_ae.ShowDialog();
            ShowUserInfo(createSearchString());
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            int item = dgv_showUsers.SelectedCells.Count;
            if (item == 1)
            {
                frm_add_edit_user f_ae = new frm_add_edit_user();
                f_ae.formtype = 2;//update
                f_ae.UserFirstName = dgv_showUsers.CurrentRow.Cells["col_name"].Value.ToString();
                f_ae.UserFamilyName = dgv_showUsers.CurrentRow.Cells["col_family"].Value.ToString();
                f_ae.UserUserName = dgv_showUsers.CurrentRow.Cells["col_username"].Value.ToString();
                f_ae.UserPersonalCode = dgv_showUsers.CurrentRow.Cells["col_personalcode"].Value.ToString();
                f_ae.UserTel = dgv_showUsers.CurrentRow.Cells["col_tel"].Value.ToString();
                f_ae.UserEmail = dgv_showUsers.CurrentRow.Cells["col_email"].Value.ToString();
                f_ae.UserBirthDayDate = dgv_showUsers.CurrentRow.Cells["col_birthdaydate"].Value.ToString();
                f_ae.Userpassword = "******";
                f_ae.UserUserName = dgv_showUsers.CurrentRow.Cells["col_username"].Value.ToString();
                f_ae.Usergender = Convert.ToByte(dgv_showUsers.CurrentRow.Cells["gender"].Value);
                f_ae.userID = Convert.ToInt32(dgv_showUsers.CurrentRow.Cells["col_userid"].Value);

                f_ae.ShowDialog();

                ShowUserInfo(createSearchString());

            }
            else
            {
                MessageBox.Show("Please select a user");
                return;
            }
                ShowUserInfo(createSearchString());
        }

        /// s.21
        private void btn_deactiveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to deactivate " + dgv_showUsers.CurrentRow.Cells["col_name"].Value.ToString() + " " + dgv_showUsers.CurrentRow.Cells["col_family"].Value.ToString() + " 's account", "Disable user", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int GetUserId = Convert.ToInt32(dgv_showUsers.CurrentRow.Cells["col_userId"].Value);
                    var query = (from U in database.Users where U.userID == GetUserId select U).SingleOrDefault();
                    query.Activity = 2;
                    database.SaveChanges();
                    MessageBox.Show("User successfully disabled.");
                    ShowUserInfo(createSearchString());

                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("There was a problem with the server. Please try again");
            }
            
        }

        private void mun_activeuser_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to activate " + dgv_showUsers.CurrentRow.Cells["col_name"].Value.ToString() + " " + dgv_showUsers.CurrentRow.Cells["col_family"].Value.ToString() + " account?", " Enable user", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int GetUserId = Convert.ToInt32(dgv_showUsers.CurrentRow.Cells["col_userId"].Value);
                    var query = (from U in database.Users where U.userID == GetUserId select U).SingleOrDefault();
                    query.Activity = 1;
                    database.SaveChanges();
                    MessageBox.Show("User successfully activated.");
                    ShowUserInfo(createSearchString());

                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("There was a problem with the server. Please try again");
            }
        }

        private void dgv_showUsers_DoubleClick(object sender, EventArgs e)
        {
            frm_showUserInfo frm_SU = new frm_showUserInfo();
            frm_SU.Get_UserId = Convert.ToInt32(dgv_showUsers.CurrentRow.Cells["col_userId"].Value);
            frm_SU.ShowDialog();
        }

        private void mun_changePass_Click(object sender, EventArgs e)
        {
            int item = dgv_showUsers.SelectedCells.Count;

            if (item> 0)
            {
                Frm_changePassword frm_cp = new Frm_changePassword();
                frm_cp.lbl_title.Text = "Change password for " + dgv_showUsers.CurrentRow.Cells["col_name"].Value.ToString() + " " + dgv_showUsers.CurrentRow.Cells["col_family"].Value.ToString();
                frm_cp.getUserId = Convert.ToInt32(dgv_showUsers.CurrentRow.Cells["col_userid"].Value);
                frm_cp.ShowDialog();
            }

        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            ///View reports in the application

            StiReport report = new StiReport();
            report.Load(System.AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\UserInfo.mrt");

            report.Dictionary.Variables["reportDate"].Value = PublicVariable.TodayDate;
            if (rdb_man.Checked)
                {
                    report["Gender"] = 1;
                }
            else if (rdb_woman.Checked)
                {
                   report["Gender"] = 2;
                }
            report.Compile();
            report.Render();
            report.Show();
        }
    }

    }

