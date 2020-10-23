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

namespace Automation.Users_panel
{
    public partial class Frm_SentLetters : Form
    {
        public Frm_SentLetters()
        {
            InitializeComponent();
        }

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        private void Frm_SentLetters_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;
            persianDateTimePicker_az.Value = DateTime.Now.AddDays(-10);
            ShowAllSentLetter(searchCondition());  
        }


        private void ShowAllSentLetter(string SearchString)
        {
            var query = database.Database.SqlQuery<Vw_recieveLetters>("select * from Vw_RecieveLetters where DraftType=2 and userId =" + PublicVariable.gUserId + " " + SearchString);
            var result = query.ToList();

            dgv_showAllSentLetters.Rows.Clear();  

            if (result.Count != 0)
            {
                dgv_showAllSentLetters.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showAllSentLetters.Rows[i].Cells["LetterID"].Value = result[i].LetterId;
                    dgv_showAllSentLetters.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgv_showAllSentLetters.Rows[i].Cells["LetterType"].Value = result[i].FarsiLetterType;
                    dgv_showAllSentLetters.Rows[i].Cells["ForceType"].Value = result[i].FarsiForceType;
                    dgv_showAllSentLetters.Rows[i].Cells["PeygiryType"].Value = result[i].FarsiPeygiriType;
                    dgv_showAllSentLetters.Rows[i].Cells["Security"].Value = result[i].FarsiSecurityType;
                    dgv_showAllSentLetters.Rows[i].Cells["AttachmentType"].Value = result[i].FarsiAttachmentType;
                    dgv_showAllSentLetters.Rows[i].Cells["AnswerDeadline"].Value = result[i].answerDeadline;
                    dgv_showAllSentLetters.Rows[i].Cells["LetterNo"].Value = result[i].letterNo;
                    dgv_showAllSentLetters.Rows[i].Cells["Bayeganitype"].Value = result[i].FarsiBayganiType;
                    dgv_showAllSentLetters.Rows[i].Cells["user_girande"].Value = result[i].girande_fullName;
                    dgv_showAllSentLetters.Rows[i].Cells["RefferenceTo"].Value = result[i].Reffrence;
                    dgv_showAllSentLetters.Rows[i].Cells["userID_girande"].Value = result[i].UserID_girande;
                    dgv_showAllSentLetters.Rows[i].Cells["SendDate"].Value = result[i].sentLetterDate;
                    dgv_showAllSentLetters.Rows[i].Cells["securityT"].Value = result[i].SecurityType;
                    dgv_showAllSentLetters.Rows[i].Cells["forceT"].Value = result[i].ForceType;
                    dgv_showAllSentLetters.Rows[i].Cells["BayeganyT"].Value = result[i].BayganiType;
                    dgv_showAllSentLetters.Rows[i].Cells["attachmentT"].Value = result[i].AttachmentType;

                    if (Convert.ToInt16(dgv_showAllSentLetters.Rows[i].Cells["attachmentT"].Value) == 1)
                    {
                        dgv_showAllSentLetters.Rows[i].Cells["DownloadAttachment"].Value = result[i].FileName;
                    }

                    //security
                    if (Convert.ToInt16(dgv_showAllSentLetters.Rows[i].Cells["securityT"].Value) == 2)
                    {
                        dgv_showAllSentLetters.Rows[i].Cells["Security"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt16(dgv_showAllSentLetters.Rows[i].Cells["securityT"].Value) == 3)
                    {
                        dgv_showAllSentLetters.Rows[i].Cells["Security"].Style.BackColor = Color.Red;
                    }


                    //urgency
                    if (Convert.ToInt16(dgv_showAllSentLetters.Rows[i].Cells["forceT"].Value) == 2)
                    {
                        dgv_showAllSentLetters.Rows[i].Cells["ForceType"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt16(dgv_showAllSentLetters.Rows[i].Cells["forceT"].Value) == 3)
                    {
                        dgv_showAllSentLetters.Rows[i].Cells["ForceType"].Style.BackColor = Color.Red;
                    }


                    //archive
                    if (Convert.ToInt16(dgv_showAllSentLetters.Rows[i].Cells["BayeganyT"].Value) == 2)
                    {
                        dgv_showAllSentLetters.Rows[i].Cells["Bayeganitype"].Style.BackColor = Color.Pink;
                    }
                }

                //show row
                dgv_showAllSentLetters.TopLeftHeaderCell.Value = "row";
                for (int counter = 0; counter <= dgv_showAllSentLetters.Rows.Count - 1; counter++)
                {
                    dgv_showAllSentLetters.Rows[counter].HeaderCell.Value = (counter + 1).ToString();
                }
                dgv_showAllSentLetters.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showAllSentLetters.Rows.Clear();
            }
        }

        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_az.Value.Year.ToString() + "/" + persianDateTimePicker_az.Value.Month.ToString() + "/" + persianDateTimePicker_az.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_ta.Value.Year.ToString() + "/" + persianDateTimePicker_ta.Value.Month.ToString() + "/" + persianDateTimePicker_ta.Value.Day.ToString()));

            string searchString = " and SentLetterDate between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_girandeName.Text != "")
            {
                searchString += " and Fullname like '%" + txt_girandeName.Text.Trim() + "%'";
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

            if (rdb_tabaghe_adi.Checked == true)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowAllSentLetter(searchCondition());
        }

        private void dgv_showAllSentLetters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_showAllSentLetters.CurrentCell.ColumnIndex.Equals(13) && e.RowIndex != -1)
            {
                if (dgv_showAllSentLetters.CurrentCell != null && dgv_showAllSentLetters.CurrentCell.Value != null)
                {
                    int GetLetterID = Convert.ToInt32(dgv_showAllSentLetters.CurrentRow.Cells["LetterID"].Value);
                    var query_fileName = (from AF in database.AttachFiles where AF.LetterID == GetLetterID select AF).ToList();
                    SaveAttachment(saveFileDialog1, dgv_showAllSentLetters, GetLetterID);
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
    }
}
