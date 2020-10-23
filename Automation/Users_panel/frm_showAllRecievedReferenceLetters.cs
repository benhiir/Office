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
    public partial class frm_showAllRecievedReferenceLetters : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        public frm_showAllRecievedReferenceLetters()
        {
            InitializeComponent();
        }

        private void fillCombobox()
        {
            cmb_security.SelectedIndex = 0;
            cmb_forceType.SelectedIndex = 0;
            cmb_LetterType.SelectedIndex = 0;
            cmb_peygiriT.SelectedIndex = 0;
            cmb_ReadType.SelectedIndex = 0;
            cmb_attachment.SelectedIndex = 0;


            /////Fill in the combo box from the database

            var query = (from U in database.Vw_Users where U.Activity == 1 select U).ToList();

            query.Insert(0, new Vw_Users { userID = -1, Fullname = "all" }); /// To add the "All" option to the data base combo box

            cmb_Usercreator.DataSource = query;
            cmb_Usercreator.ValueMember = "UserID";
            cmb_Usercreator.DisplayMember = "fullname";

        }
        private void frm_showAllRecievedReferenceLetters_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;

            fillCombobox();
            persianDateTimePicker_az.Value = DateTime.Now.AddDays(-10);
            ShowAllRecievedReferenceLetter(searchCondition());
        }

        private void ShowAllRecievedReferenceLetter(string search)
        {
            var query = database.Database.SqlQuery<Vw_recieveReference>("select * from Vw_recieveReference where DraftType=2 and userId_reciever =" + PublicVariable.gUserId + " " + search);
           // MessageBox.Show(query.ToString());
            var result = query.ToList();

            dgv_showAllRecievedReferenceLetters.Rows.Clear();  ///Clear previous information in the table

            if (result.Count != 0)
            {
                dgv_showAllRecievedReferenceLetters.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["LetterID"].Value = result[i].LetterId;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["LetterType"].Value = result[i].FarsiLetterType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["ForceType"].Value = result[i].FarsiForceType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["PeygiryType"].Value = result[i].FarsiPeygiriType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["Security"].Value = result[i].FarsiSecurityType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["AttachmentType"].Value = result[i].FarsiAttachmentType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["AnswerDeadline"].Value = result[i].answerDeadline;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["LetterNo"].Value = result[i].letterNo;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["ReadType"].Value = result[i].farsiReadType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["user_creator"].Value = result[i].Fullname;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["RefferenceTo"].Value = result[i].Reffrence;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["userID_creator"].Value = result[i].userID;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["recieveDate"].Value = result[i].ReferenceDate;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["securityT"].Value = result[i].SecurityType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["forceT"].Value = result[i].ForceType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["attachmentT"].Value = result[i].AttachmentType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["description"].Value = result[i].Description;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["User_erjadahande"].Value = result[i].fullname_sender;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["attachmentType"].Value = result[i].FarsiAttachmentType;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["UserID_erjadahande"].Value = result[i].UserID_sender;
                    dgv_showAllRecievedReferenceLetters.Rows[i].Cells["answerType"].Value = result[i].answerType;


                    if (Convert.ToInt16(dgv_showAllRecievedReferenceLetters.Rows[i].Cells["attachmentT"].Value) == 1)
                    {
                        dgv_showAllRecievedReferenceLetters.Rows[i].Cells["DownloadAttachment"].Value = result[i].FileName;
                    }

                    //security
                    if (Convert.ToInt16(dgv_showAllRecievedReferenceLetters.Rows[i].Cells["securityT"].Value) == 2)
                    {
                        dgv_showAllRecievedReferenceLetters.Rows[i].Cells["Security"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt16(dgv_showAllRecievedReferenceLetters.Rows[i].Cells["securityT"].Value) == 3)
                    {
                        dgv_showAllRecievedReferenceLetters.Rows[i].Cells["Security"].Style.BackColor = Color.Red;
                    }


                    //urgency
                    if (Convert.ToInt16(dgv_showAllRecievedReferenceLetters.Rows[i].Cells["forceT"].Value) == 2)
                    {
                        dgv_showAllRecievedReferenceLetters.Rows[i].Cells["ForceType"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt16(dgv_showAllRecievedReferenceLetters.Rows[i].Cells["forceT"].Value) == 3)
                    {
                        dgv_showAllRecievedReferenceLetters.Rows[i].Cells["ForceType"].Style.BackColor = Color.Red;
                    }

                    

                }

                dgv_showAllRecievedReferenceLetters.TopLeftHeaderCell.Value = "row";
                for (int counter = 0; counter <= dgv_showAllRecievedReferenceLetters.Rows.Count - 1; counter++)
                {
                    dgv_showAllRecievedReferenceLetters.Rows[counter].HeaderCell.Value = (counter + 1).ToString();
                }
                dgv_showAllRecievedReferenceLetters.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showAllRecievedReferenceLetters.Rows.Clear();
            }
        }

        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_az.Value.Year.ToString() + "/" + persianDateTimePicker_az.Value.Month.ToString() + "/" + persianDateTimePicker_az.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_ta.Value.Year.ToString() + "/" + persianDateTimePicker_ta.Value.Month.ToString() + "/" + persianDateTimePicker_ta.Value.Day.ToString()));

            string searchString = " and Referencedate between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_sender.Text != "")
            {
                searchString += " and Fullname_sender like '%" + txt_sender.Text.Trim() + "%'";
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

            if (cmb_security.SelectedIndex == 1)
            {
                searchString += "and securityType = 1";
            }
            else if (cmb_security.SelectedIndex == 2)
            {
                searchString += "and securityType = 2";
            }
            else if (cmb_security.SelectedIndex == 3)
            {
                searchString += "and securityType = 3";
            }
            
            if (cmb_forceType.SelectedIndex ==  1)
            {
                searchString += "and forceType = 1";
            }
            else if (cmb_forceType.SelectedIndex == 2)
            {
                searchString += "and forceType = 2";
            }
            else if (cmb_forceType.SelectedIndex == 3)
            {
                searchString += "and forceType = 3";
            }

            //readtype
            if (cmb_ReadType.SelectedIndex == 2)
            {
                searchString += "and readType = 2";
            }
            else if (cmb_ReadType.SelectedIndex == 1)
            {
                searchString += "and readType = 1";
            }
            // letter Type
            if (cmb_LetterType.SelectedIndex == 1)
            {
                searchString += "and LetterType = 1";
            }
            else if (cmb_LetterType.SelectedIndex == 2)
            {
                searchString += "and LetterType = 2";
            }

            // attachment
            if (cmb_attachment.SelectedIndex == 1)
            {
                searchString += "and attachmentType = 1";
            }
            else if (cmb_attachment.SelectedIndex == 2)
            {
                searchString += "and attachmentType = 2";
            }

            //follow up
            if (cmb_peygiriT.SelectedIndex == 1)
            {
                searchString += "and PeygiryType = 1";
            }
            else if (cmb_peygiriT.SelectedIndex == 2)
            {
                searchString += "and PeygiryType = 2";
            }

            // creator
            if (cmb_Usercreator.SelectedIndex != 0)
            {
                searchString += "and userID =" + cmb_Usercreator.SelectedValue;
            }
        
            return searchString;
        }

        private void dgv_showAllRecievedReferenceLetters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_showAllRecievedReferenceLetters.CurrentCell.ColumnIndex.Equals(13) && e.RowIndex != -1)
            {
                if (dgv_showAllRecievedReferenceLetters.CurrentCell != null && dgv_showAllRecievedReferenceLetters.CurrentCell.Value != null)
                {
                    int GetLetterID = Convert.ToInt32(dgv_showAllRecievedReferenceLetters.CurrentRow.Cells["LetterID"].Value);
                    var query_fileName = (from AF in database.AttachFiles where AF.LetterID == GetLetterID select AF).ToList();
                    SaveAttachment(saveFileDialog1, dgv_showAllRecievedReferenceLetters, GetLetterID);
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
                MessageBox.Show("There was a problem communicating with the server, please try again.");
                return;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowAllRecievedReferenceLetter(searchCondition());
        }

        private void ReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Reference letter
            Frm_SelectUserToSendLetter frm_SU = new Frm_SelectUserToSendLetter();
            frm_SU.btn_SendLetter.Text = "Reference letter";
            frm_SU.labelX1.Text = "Reference letter form";
            frm_SU.GetLetterID = Convert.ToInt32(dgv_showAllRecievedReferenceLetters.CurrentRow.Cells["LetterID"].Value);
            frm_SU.IsErja = 1;
            frm_SU.GetReplyLetter_User = Convert.ToInt32(dgv_showAllRecievedReferenceLetters.CurrentRow.Cells["userID_creator"].Value);
            frm_SU.ShowDialog();
        }

        private void ReadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Commands for displaying letters
            StiReport report = new StiReport();
            report.Load(System.AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\RefferenceReport.mrt");

            report.Dictionary.Variables["reportDate"].Value = PublicVariable.TodayDate;
            //report.Dictionary.Variables["to"].Value = PublicVariable.gUserFirstName + " " + PublicVariable.gUserFamilyName;
            report["@LetterID"] = dgv_showAllRecievedReferenceLetters.CurrentRow.Cells["LetterID"].Value;
            report["@userID"] = PublicVariable.gUserId; 
            report.Compile();
            report.Render();
            report.Show();

            /////Commands to convert letters to read
            int GetLetterID = Convert.ToInt32(dgv_showAllRecievedReferenceLetters.CurrentRow.Cells["LetterID"].Value);
            var query_update = (from RL in database.ReferenceLetters where RL.UserID_Reciever == PublicVariable.gUserId where RL.LetterId == GetLetterID where RL.ReadType == 1 select RL).ToList();
            if (query_update.Count > 0) // Checking that the letter has not been read, if any, does not require an update
            {
                var query_updateReadtype = (from RL in database.ReferenceLetters where RL.UserID_Reciever == PublicVariable.gUserId where RL.LetterId == GetLetterID where RL.ReadType == 1 select RL).SingleOrDefault();

                query_updateReadtype.ReadType = 2;
                database.SaveChanges();

                ShowAllRecievedReferenceLetter(searchCondition());
            }

        }


    }
   
}
