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
using System.IO;
using Stimulsoft.Report;

namespace Automation.Users_panel
{
    public partial class frm_RecieveAllLetters : Form
    {

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        public frm_MainUser MainUser;
        public frm_RecieveAllLetters(frm_MainUser inParent)
        {

            MainUser = inParent;
            InitializeComponent();
        }

        private void frm_RecieveAllLetters_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;

            persianDateTimePicker_az.Value = DateTime.Now.AddDays(-10);
            ShowAllRecievedLetter(searchCondition());
        }

        private void ShowAllRecievedLetter(string SearchString)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_recieveLetters>("select * from Vw_RecieveLetters where DraftType=2 and userId_girande =" + PublicVariable.gUserId + " " +SearchString);
            var result = query.ToList();

            dgv_showAllRecievedLetters.Rows.Clear();  ///Clear previous information in the table

            if (result.Count != 0)
            {
                dgv_showAllRecievedLetters.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showAllRecievedLetters.Rows[i].Cells["LetterID"].Value = result[i].LetterId;
                    dgv_showAllRecievedLetters.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgv_showAllRecievedLetters.Rows[i].Cells["LetterType"].Value = result[i].FarsiLetterType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["ForceType"].Value = result[i].FarsiForceType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["PeygiryType"].Value = result[i].FarsiPeygiriType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["Security"].Value = result[i].FarsiSecurityType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["AttachmentType"].Value = result[i].FarsiAttachmentType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["AnswerDeadline"].Value = result[i].answerDeadline;
                    dgv_showAllRecievedLetters.Rows[i].Cells["LetterNo"].Value = result[i].letterNo;
                    dgv_showAllRecievedLetters.Rows[i].Cells["ReadType"].Value = result[i].farsiReadType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["Bayeganitype"].Value = result[i].FarsiBayganiType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["user_sender"].Value = result[i].Fullname;
                    dgv_showAllRecievedLetters.Rows[i].Cells["RefferenceTo"].Value = result[i].Reffrence;
                    dgv_showAllRecievedLetters.Rows[i].Cells["userID_sender"].Value = result[i].userID;
                    dgv_showAllRecievedLetters.Rows[i].Cells["recieveDate"].Value = result[i].sentLetterDate;
                    dgv_showAllRecievedLetters.Rows[i].Cells["securityT"].Value = result[i].SecurityType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["forceT"].Value = result[i].ForceType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["BayeganyT"].Value = result[i].BayganiType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["attachmentT"].Value = result[i].AttachmentType;
                    dgv_showAllRecievedLetters.Rows[i].Cells["answerType"].Value = result[i].answerType;


                    if (Convert.ToInt16(dgv_showAllRecievedLetters.Rows[i].Cells["attachmentT"].Value) == 1)
                    {
                        dgv_showAllRecievedLetters.Rows[i].Cells["DownloadAttachment"].Value = result[i].FileName;
                    }

                    //security
                    if (Convert.ToInt16(dgv_showAllRecievedLetters.Rows[i].Cells["securityT"].Value) == 2)
                    {
                        dgv_showAllRecievedLetters.Rows[i].Cells["Security"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt16(dgv_showAllRecievedLetters.Rows[i].Cells["securityT"].Value) == 3)
                    {
                        dgv_showAllRecievedLetters.Rows[i].Cells["Security"].Style.BackColor = Color.Red;
                    }


                    //urgency
                    if (Convert.ToInt16(dgv_showAllRecievedLetters.Rows[i].Cells["forceT"].Value) == 2)
                    {
                        dgv_showAllRecievedLetters.Rows[i].Cells["ForceType"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt16(dgv_showAllRecievedLetters.Rows[i].Cells["forceT"].Value) == 3)
                    {
                        dgv_showAllRecievedLetters.Rows[i].Cells["ForceType"].Style.BackColor = Color.Red;
                    }


                    //archive
                    if (Convert.ToInt16(dgv_showAllRecievedLetters.Rows[i].Cells["BayeganyT"].Value) == 2)
                    {
                        dgv_showAllRecievedLetters.Rows[i].Cells["Bayeganitype"].Style.BackColor = Color.Pink;
                    }


                   
                }

                //show row
                dgv_showAllRecievedLetters.TopLeftHeaderCell.Value = "row";
                for (int counter = 0; counter <= dgv_showAllRecievedLetters.Rows.Count -1; counter ++)
                {
                    dgv_showAllRecievedLetters.Rows[counter].HeaderCell.Value = (counter + 1).ToString();
                }
                dgv_showAllRecievedLetters.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showAllRecievedLetters.Rows.Clear();
            }
        }


        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_az.Value.Year.ToString() + "/" + persianDateTimePicker_az.Value.Month.ToString() + "/" + persianDateTimePicker_az.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_ta.Value.Year.ToString() + "/" + persianDateTimePicker_ta.Value.Month.ToString() + "/" + persianDateTimePicker_ta.Value.Day.ToString()));

            string searchString = " and SentLetterDate between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_sender.Text != "")
            {
                searchString += " and Fullname like '%" + txt_sender.Text.Trim() + "%'";
            }

            if (txt_LetterNo.Text != "")
            {
                searchString += " and letterNo like '%" + txt_LetterNo.Text.Trim() + "%'";
            }


            if (txt_subject.Text != "")
            {
                searchString += " and [subject] like '%" + txt_subject.Text.Trim() + "%'";
            }

            if (txt_referenceTo.Text != "")
            {
                searchString += " and Refference like '%" + txt_referenceTo.Text.Trim() + "%'";
            }

            if (rdb_tabaghe_adi.Checked== true)
            {
                searchString += "and securityType = 1";
            }
            else if (rdb_tabaghe_mahramane.Checked == true)
            {
                searchString += "and securityType = 2";
            }
            else if (rdb_tabaghe_seri.Checked == true)
            {
                searchString += "and securityType = 3";
            }

            if (rdb_foriyat_adi.Checked == true)
            {
                searchString += "and forceType = 1";
            }
            else if (rdb_foriyat_fori.Checked == true)
            {
                searchString += "and forceType = 2";
            }
            else if (rdb_foriyat_ani.Checked == true)
            {
                searchString += "and forceType = 3";
            }

            //archive
            if (rdb_bayeganiShode.Checked == true)
            {
                searchString += "and Bayganitype = 2";
            }
            else if (rdb_bayeganiNashode.Checked == true)
            {
                searchString += "and Bayganitype = 1";
            }
            // letter Type
            if (rdb_LetterType_Name.Checked == true)
            {
                searchString += "and LetterType = 1";
            }
            else if (rdb_LetterType_answer.Checked == true)
            {
                searchString += "and LetterType = 2";
            }
            //read Type
            if (rdb_readType_read.Checked == true)
            {
                searchString += "and ReadType = 2";
            }
            else if (rdb_readType_notRead.Checked == true)
            {
                searchString += "and ReadType = 1";
            }

            // attachment
            if (rdb_attachment_darad.Checked == true)
            {
                searchString += "and attachmentType = 1";
            }
            else if (rdb_attachment_nadarad.Checked == true)
            {
                searchString += "and attachmentType = 2";
            }

            //follow up
            if (rdb_peygiry_darad.Checked == true)
            {
                searchString += "and PeygiryType = 1";
            }
            else if (rdb_peygiry_nadarad.Checked == true)
            {
                searchString += "and PeygiryType = 2";
            }
            return searchString;
        }


        private void dgv_showAllRecievedLetters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_showAllRecievedLetters.CurrentCell.ColumnIndex.Equals(14) && e.RowIndex != -1)
            {
                if (dgv_showAllRecievedLetters.CurrentCell != null && dgv_showAllRecievedLetters.CurrentCell.Value !=null)
                {
                    int GetLetterID = Convert.ToInt32(dgv_showAllRecievedLetters.CurrentRow.Cells["LetterID"].Value);
                    var query_fileName = (from AF in database.AttachFiles where AF.LetterID == GetLetterID select AF).ToList();
                    SaveAttachment(saveFileDialog1, dgv_showAllRecievedLetters, GetLetterID);
                }
            }
        }

        private void SaveAttachment(SaveFileDialog objsfd, DataGridView objGrid, int GetLetterID)
        {
            try
            {
                string strID = objGrid.CurrentRow.Cells["DownloadAttachment"].Value.ToString();

                if (strID != null)
                {
                    var query_attachment = (from AF in database.AttachFiles where AF.LetterID == GetLetterID select AF).ToList();

                    byte[] objData;
                    objData = (byte[])query_attachment[0].FileData;

                    objsfd.FileName = query_attachment[0].FileName;
                    if (objsfd.ShowDialog() != DialogResult.Cancel)
                    {
                        string strFiletoSave = objsfd.FileName;
                        FileStream objFileStream = new FileStream(strFiletoSave, FileMode.Create, FileAccess.Write);
                        objFileStream.Write(objData, 0, objData.Length);
                        objFileStream.Close();

                        MessageBox.Show("Attachment downloaded successfully");


                    }
                }
            }
            catch
            {
                MessageBox.Show("There was a problem communicating with the server. Please try again.");
                return;
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowAllRecievedLetter(searchCondition());
        }

        private void mnu_replytoletter_Click(object sender, EventArgs e)
        {
            var query_accsess = (from UA in database.UsereAccesses where UA.userID == PublicVariable.gUserId where UA.SystemPardID == 28 select UA).ToList();
            if (query_accsess.Count == 0)
            {
                MessageBox.Show("You do not have access to this section");
               
            }



            //Letter response commands

            int item = dgv_showAllRecievedLetters.SelectedCells.Count;
            if (item>0)
            {
                if (Convert.ToByte(dgv_showAllRecievedLetters.CurrentRow.Cells["answerType"].Value) == 1) /// Response deadline 
                {
                    if (Convert.ToDateTime(dgv_showAllRecievedLetters.CurrentRow.Cells["answerDeadline"].Value.ToString())< Convert.ToDateTime(PublicVariable.TodayDate))
                    {
                        MessageBox.Show("The reply to this letter has expired.");
                        return;
                    }
                }


                Frm_CreateLetter frm_c = new Frm_CreateLetter();

                frm_c.MdiParent = MainUser;
                frm_c.FormType = 1;
                frm_c.Get_LetterID = Convert.ToInt32(dgv_showAllRecievedLetters.CurrentRow.Cells["LetterId"].Value);
                frm_c.Get_LetterNo = dgv_showAllRecievedLetters.CurrentRow.Cells["letterNo"].Value.ToString();
                frm_c.lbl_letterType.Visible = true;
                frm_c.lbl_letterType.Text = "Reply to letter number " + dgv_showAllRecievedLetters.CurrentRow.Cells["letterNo"].Value.ToString() + "related to " + dgv_showAllRecievedLetters.CurrentRow.Cells["user_sender"].Value.ToString();
                frm_c.IsReply = 1;
                this.Close();
                frm_c.Show();
            }

        }

        private void mnu_bayegany_Click(object sender, EventArgs e)
        {
            var query_accsess = (from UA in database.UsereAccesses where UA.userID == PublicVariable.gUserId where UA.SystemPardID == 27 select UA).ToList();
            if (query_accsess.Count == 0)
            {
                MessageBox.Show("You do not have access to this section");
               
            }
            ///Archive letters
            int item = dgv_showAllRecievedLetters.SelectedCells.Count;
            if (item>0)
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to archive letter" + dgv_showAllRecievedLetters.CurrentRow.Cells["Letterno"].Value.ToString(), "Archive the letter", MessageBoxButtons.YesNo)== DialogResult.Yes)
                    {
                        int GetLetterID = Convert.ToInt32(dgv_showAllRecievedLetters.CurrentRow.Cells["LetterID"].Value);
                        var query = (from L in database.Letters where L.LetterId == GetLetterID select L).SingleOrDefault();
                        query.BayganiType = 2;
                        database.SaveChanges();
                        MessageBox.Show("The letter was successfully archived.");
                        ShowAllRecievedLetter(searchCondition());
                    }

                }
                catch
                {
                    MessageBox.Show("There was a problem with the server. Please try again.");
                }


            }
            else
            {
                MessageBox.Show("Please select a letter first.");
                return;
            }
        }

        private void mnu_erja_Click(object sender, EventArgs e)
        {
            var query_accsess = (from UA in database.UsereAccesses where UA.userID == PublicVariable.gUserId where UA.SystemPardID == 29 select UA).ToList();
            if (query_accsess.Count == 0)
            {
                MessageBox.Show("You do not have access to this section");
                
            }



            ///Reference letter
            Frm_SelectUserToSendLetter frm_SU = new Frm_SelectUserToSendLetter();
            frm_SU.btn_SendLetter.Text = "Reference letter";
            frm_SU.labelX1.Text = "Reference form";
            frm_SU.GetLetterID = Convert.ToInt32(dgv_showAllRecievedLetters.CurrentRow.Cells["LetterID"].Value);
            frm_SU.IsErja = 1;
            frm_SU.GetReplyLetter_User = Convert.ToInt32(dgv_showAllRecievedLetters.CurrentRow.Cells["userID_sender"].Value);
            frm_SU.ShowDialog();
        }

        private void mnu_readLetter_Click(object sender, EventArgs e)
        {
            var query_accsess = (from UA in database.UsereAccesses where UA.userID == PublicVariable.gUserId where UA.SystemPardID == 30 select UA).ToList();
            if (query_accsess.Count == 0)
            {
                MessageBox.Show("You do not have access to this section");
            
            }

            /// Print information
            StiReport report = new StiReport();
            report.Load(System.AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\Letters.mrt");
            report.Dictionary.Variables["reportDate"].Value = PublicVariable.TodayDate;
            report.Dictionary.Variables["to"].Value = PublicVariable.gUserFirstName + " " + PublicVariable.gUserFamilyName;
            report["LetterID"] = dgv_showAllRecievedLetters.CurrentRow.Cells["LetterID"].Value;
            report.Compile();
            report.Render();
            report.Show();

            /// Convert letter status to read
            int GetLetterID = Convert.ToInt32(dgv_showAllRecievedLetters.CurrentRow.Cells["LetterID"].Value);
            var query_update = (from SL in database.SentLetters where SL.UserID == PublicVariable.gUserId where SL.LetterID == GetLetterID where SL.ReadType == 1 select SL).ToList();
            if (query_update.Count >0) // Check that the letter is not read. If so, there is no need to update.
            {
                var query_updateReadtype = (from SL in database.SentLetters where SL.UserID == PublicVariable.gUserId where SL.LetterID == GetLetterID where SL.ReadType == 1 select SL).SingleOrDefault();

                query_updateReadtype.ReadType = 2;
                database.SaveChanges();

                ShowAllRecievedLetter(searchCondition());
            }




        }
    }
}
