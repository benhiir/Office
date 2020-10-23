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
using System.Transactions;

namespace Automation.Users_panel
{
    public partial class Frm_SelectUserToSendLetter : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        public int GetLetterID { get; set; }

        public int GetReplyLetter_User { get; set; }  // Email sender in reply mode

        public byte IsReply { get; set; }  // 1=reply

        public byte IsErja { get; set; } //1= refer

        public Frm_SelectUserToSendLetter()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_SelectUserToSendLetter_Load(object sender, EventArgs e)
        {
            if (this.IsReply == 1)
            {
                ShowAllowedUsers_toReply(searchCondition());
            }
            else
            {
                if (this.IsErja == 1)
                {
                    lbl_descerja.Visible = true;
                    txt_descreptionErja.Visible = true;
                    ShowAllowedUserstoErja(searchCondition());
                }
                else
                {
                    ShowAllowedUsers(searchCondition());
                }
            }

        }

        private void ShowAllowedUsers(string search)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_UserJobs>("select * from Vw_UserJobs where [status] = 1 and DetermineJobsLevel >=" + PublicVariable.gDetermineJobsLevel + " - 1 "+ search +" except (select * from Vw_UserJobs where UserID =" + PublicVariable.gUserId + ")");
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_SelectUserToSend.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_SelectUserToSend.Rows[i].Cells["UserJobID"].Value = result[i].userJobsId;
                    dgv_SelectUserToSend.Rows[i].Cells["UserID"].Value = result[i].userID;
                    dgv_SelectUserToSend.Rows[i].Cells["FullName"].Value = result[i].FullName;
                    dgv_SelectUserToSend.Rows[i].Cells["JobName"].Value = result[i].jobsName;
                                 
                }
                dgv_SelectUserToSend.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_SelectUserToSend.Rows.Clear();
            }
        }

        private void ShowAllowedUsers_toReply(string search)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_UserJobs>("select * from Vw_UserJobs where [status] = 1 and userID = "+ this.GetReplyLetter_User + " and DetermineJobsLevel >=" + PublicVariable.gDetermineJobsLevel + " - 1 " + search );
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_SelectUserToSend.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_SelectUserToSend.Rows[i].Cells["UserJobID"].Value = result[i].userJobsId;
                    dgv_SelectUserToSend.Rows[i].Cells["UserID"].Value = result[i].userID;
                    dgv_SelectUserToSend.Rows[i].Cells["FullName"].Value = result[i].FullName;
                    dgv_SelectUserToSend.Rows[i].Cells["JobName"].Value = result[i].jobsName;

                }
                dgv_SelectUserToSend.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_SelectUserToSend.Rows.Clear();
            }
        }

        private void ShowAllowedUserstoErja(string search)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_UserJobs>("select * from Vw_UserJobs where [status] = 1 and DetermineJobsLevel >=" + PublicVariable.gDetermineJobsLevel + " - 1 " + search + " except (select * from Vw_UserJobs where UserID in(" + PublicVariable.gUserId + ", " + this.GetReplyLetter_User + "))");

            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_SelectUserToSend.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_SelectUserToSend.Rows[i].Cells["UserJobID"].Value = result[i].userJobsId;
                    dgv_SelectUserToSend.Rows[i].Cells["UserID"].Value = result[i].userID;
                    dgv_SelectUserToSend.Rows[i].Cells["FullName"].Value = result[i].FullName;
                    dgv_SelectUserToSend.Rows[i].Cells["JobName"].Value = result[i].jobsName;

                }
                dgv_SelectUserToSend.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_SelectUserToSend.Rows.Clear();
            }
        }

        private string searchCondition()
        {

            string searchString = "";
            if (txt_FullName.Text != "")
            {
                searchString += " and FullName like '%" + txt_FullName.Text.Trim() + "%'";
            }
            
            return searchString;
        }

        private void pictureBox_search_Click(object sender, EventArgs e)
        {
            ShowAllowedUsers(searchCondition());
        }

        private void btn_SendLetter_Click(object sender, EventArgs e)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    if (this.IsErja == 1)///if it was referal
                    {
                        List<DataGridView> row_with_check_column = new List<DataGridView>();
                        foreach (DataGridViewRow row in dgv_SelectUserToSend.Rows)
                        {
                            ReferenceLetter RL = new ReferenceLetter();
                            if (Convert.ToBoolean(row.Cells["selectUser"].Value) == true)
                            {
                                /// Letter control operation to prevent redirection.
                                int GetUserID_reciever = Convert.ToInt32(row.Cells["UserID"].Value);
                                var query_checkNotErja = (from RefL in database.ReferenceLetters where RefL.LetterId == this.GetLetterID where RefL.UserID_sender == PublicVariable.gUserId where RefL.UserID_Reciever == GetUserID_reciever select RefL).ToList();
                                if (query_checkNotErja.Count == 0)
                                {
                                    /// Will be referred
                                    /// Referral operations
                                    var query = (from Re in database.ReferenceLetters where Re.LetterId == this.GetLetterID orderby Re.LevelNo descending select Re).ToList();
                                    if (query.Count > 0)
                                    {
                                        var LastlevelNumber = query.First().LevelNo;
                                        RL.LevelNo = LastlevelNumber + 1;
                                    }
                                    else
                                    {
                                        RL.LevelNo = 1;
                                    }
                                    RL.LetterId = this.GetLetterID;
                                    RL.UserID_Reciever = Convert.ToInt32(row.Cells["UserID"].Value);
                                    RL.UserID_sender = PublicVariable.gUserId;
                                    RL.ReferenceDate = PublicVariable.TodayDate;
                                    RL.ReadType = 1;
                                    RL.Description = txt_descreptionErja.Text.Trim();
                                    RL.IsMessage = 1;

                                    database.ReferenceLetters.Add(RL);
                                }
                                else
                                {
                                    MessageBox.Show("This letter has already been referred to " + row.Cells["fullname"].Value.ToString());
                                    return;

                                }
                                
                            }
                        }
                        database.SaveChanges();
                        ts.Complete();
                        MessageBox.Show("The letter was successfully forwarded.");
                        this.Close();
                    }
                    else
                    {
                        /// Remove the letter from the draft
                        var query_update = (from L in database.Letters where L.LetterId == this.GetLetterID select L).SingleOrDefault();
                        query_update.DraftType = 2;
                        query_update.sentLetterDate = PublicVariable.TodayDate;
                        database.SaveChanges();

                        /// sending letter
                        List<DataGridView> row_with_check_column = new List<DataGridView>();
                        foreach (DataGridViewRow row in dgv_SelectUserToSend.Rows)
                        {
                            SentLetter SL = new SentLetter();
                            if (Convert.ToBoolean(row.Cells["selectUser"].Value) == true)
                            {
                                SL.LetterID = this.GetLetterID;
                                SL.UserID = Convert.ToInt32(row.Cells["UserID"].Value);
                                SL.ReadType = 1;
                                SL.Ismessage = 1;
                                database.SentLetters.Add(SL);
                            }
                        }
                        database.SaveChanges();
                        ts.Complete();
                        MessageBox.Show("Letter sent successfully.");
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("There are problems with the server. Please try again.");
                    return;
                }
            }
        }
    }
}
