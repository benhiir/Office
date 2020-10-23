using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Automation.Admin_panel;
using DataModelLayer.Models;
using Automation.modula;
using System.Net;

namespace Automation.Admin_panel
{
    public partial class frm_mainAdmin : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_mainAdmin()
        {
            InitializeComponent();
        }

        private void applicationButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_showUsers_Click(object sender, EventArgs e)
        {
            frm_showUsers shu = new frm_showUsers();
            shu.ShowDialog();
        }

        private void frm_mainAdmin_Load(object sender, EventArgs e)
        {

            showSystemInfo(sender, e);

            persianDateTimePickerTa.Value = DateTime.Now.AddDays(1);
            ShowRemember(searchCondition());

        }

        private void showSystemInfo(object sender, EventArgs e)
        {
            /// Show the date of the day
            lbl_date.Text = PublicVariable.TodayDate;
            /// Show clock
            timer1_Tick(sender, e);

            /// Show IP
            string computerName = System.Environment.MachineName;
            string IP = "";
            IPHostEntry ipe = Dns.GetHostByName(computerName);
            IPAddress[] IpAddress = ipe.AddressList;
            lbl_ip.Text = IpAddress[0].ToString();

            ///Show active users
            var query_activeUser = (from U in database.Users where U.Activity == 1 select U).ToList();
            lbl_allUsers.Text = query_activeUser.Count.ToString();

            /// Show last login date
            /// With commands sql server s.84
            var q_lastEnter = database.Database.SqlQuery<UserLog>("select top 1 * from Vw_UserLog where UserId = 1 and ExitDateTime is not NULL order by UserLogId desc");
            var result_lastEnter = q_lastEnter.ToList();
            if (result_lastEnter.Count > 0)
            {
                lbl_lastEnter.Text = result_lastEnter[0].EnterDateTime;
            }


            /// Show the number of people online 84
            var q_online = database.Database.SqlQuery<UserLog>("select distinct UserId, 1 as UserLogID, '1' as ComputerName, '1' as IpAddress, '1' as EnterDateTime, '1' as ExitDateTime  from UserLog where ExitDateTime is NULL and Left(EnterDateTime, 10) = '" + PublicVariable.TodayDate + "'");
            var result_online = q_online.ToList();
            lbl_onlinePerson.Text = result_online.Count.ToString();

            /// View received support requests
            var q_request = database.Database.SqlQuery<Vw_supports>("select * from Vw_supports where support_date = '" + PublicVariable.TodayDate + "'").ToList();
            lbl_requests.Text = q_request.Count.ToString();
        }

        private void ShowRemember(string search)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_Remember>("select * from Vw_Remember where 1=1" + search);
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_ShowRemember.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_ShowRemember.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgv_ShowRemember.Rows[i].Cells["matn"].Value = result[i].matn;
                    dgv_ShowRemember.Rows[i].Cells["CreateDate"].Value = result[i].createDate;
                    dgv_ShowRemember.Rows[i].Cells["dateRemember"].Value = result[i].DateRemember;
                    dgv_ShowRemember.Rows[i].Cells["FarsiIsRead"].Value = result[i].FarsiIsRead;
                    dgv_ShowRemember.Rows[i].Cells["RememberID"].Value = result[i].RememberID;
                    dgv_ShowRemember.Rows[i].Cells["IsRead"].Value = result[i].IsRead;

                    if (Convert.ToInt16(dgv_ShowRemember.Rows[i].Cells["isRead"].Value) == 1)
                    {
                        dgv_ShowRemember.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    else
                    {
                        dgv_ShowRemember.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
                dgv_ShowRemember.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_ShowRemember.Rows.Clear();
            }
        }
        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePickerAz.Value.Year.ToString() + "/" + persianDateTimePickerAz.Value.Month.ToString() + "/" + persianDateTimePickerAz.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePickerTa.Value.Year.ToString() + "/" + persianDateTimePickerTa.Value.Month.ToString() + "/" + persianDateTimePickerTa.Value.Day.ToString()));

            string searchString = " and DateRemember between '" + dateAz + "' and '" + dateTa + "'";
            if (txtSubject.Text != "")
            {
                searchString += " and [subject] like '%" + txtSubject.Text.Trim() + "%'";
            }

            return searchString;
        }

        private void picBoxSearch_Click(object sender, EventArgs e)
        {
            ShowRemember(searchCondition());
        }

        private void dgv_ShowRemember_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(dgv_ShowRemember.CurrentRow.Cells["matn"].Value.ToString(), dgv_ShowRemember.CurrentRow.Cells["subject"].Value.ToString());
            try
            {
                int getrememberID = Convert.ToInt32(dgv_ShowRemember.CurrentRow.Cells["RememberId"].Value);

                //////Update by linq to entity
                //////select * from Remember where rememberID = getrememberID
                var updateQuery = (from R in database.Remembers where R.RememberID == getrememberID select R).SingleOrDefault();
                updateQuery.IsRead = 2;
                database.SaveChanges();

                ShowRemember(searchCondition());
            }
            catch
            {
            }
        }

        private void btn_remember_Click(object sender, EventArgs e)
        {
            frm_AddRemember f_A = new frm_AddRemember();
            f_A.ShowDialog();
            ShowRemember(searchCondition());
        }

        private void frm_mainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // s.23
            database.SP_Update_ExitDate(PublicVariable.gUserId, PublicVariable.TodayDate + "-" + string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second)));
            database.SaveChanges();
        }

        private void btn_controlEnterExit_Click(object sender, EventArgs e)
        {
            frm_ControlEnterExit f_CEE = new frm_ControlEnterExit();
            f_CEE.ShowDialog();


        }

        private void btn_jobs_Click(object sender, EventArgs e)
        {
            frm__showJobs frm_sj = new frm__showJobs();
            frm_sj.ShowDialog();

        }

        private void btn_setJobs_Click(object sender, EventArgs e)
        {
            frm_ShowUserforJob frm_sj = new frm_ShowUserforJob();
            frm_sj.FormType = 1;
            frm_sj.ShowDialog();

        }

        private void btn_sendmessage_Click(object sender, EventArgs e)
        {
            Frm_CreateNews frm_cnews = new Frm_CreateNews();
            frm_cnews.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            lbl_time.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            lbl_time.Refresh();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            frm_ShowSystemParts frm_sys = new frm_ShowSystemParts();
            frm_sys.ShowDialog();
        }

        private void btn_sabteDatresi_Click(object sender, EventArgs e)
        {
            frm_ShowUserforJob frm_sj = new frm_ShowUserforJob();
            frm_sj.lbl_title.Text = "User view form to determine access";
            frm_sj.btn_jobHistory.Text = "Determine access";
            frm_sj.FormType = 2;
            frm_sj.ShowDialog();
        }

        private void lbl_requests_Click(object sender, EventArgs e)
        {
            frm_showRecievedSupports frm_r = new frm_showRecievedSupports();
            frm_r.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            showSystemInfo(sender, e);
            timer2.Start();
        }

        private void frm_mainAdmin_Activated(object sender, EventArgs e)
        {
            timer2_Tick(sender, e);
        }
    }
}
