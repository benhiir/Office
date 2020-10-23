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

namespace Automation.Users_panel
{
    public partial class Frm_ShowDraft : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        public frm_MainUser MainUser;

        public Frm_ShowDraft(frm_MainUser inParent)
        {
            MainUser = inParent;
            InitializeComponent();
        }

        private void Frm_ShowDraft_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;
            ShowDraft(searchCondition());
        }
        private void ShowDraft(string search)
        {
            var query = database.Database.SqlQuery<Vw_Letters>("select * from Vw_Letters where DraftType=1" + search + "and userid =" + PublicVariable.gUserId);
            var result = query.ToList();

            dgv_ShowDraft.Rows.Clear();  

            if (result.Count != 0)
            {
                dgv_ShowDraft.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_ShowDraft.Rows[i].Cells["LetterID"].Value = result[i].LetterId;
                    dgv_ShowDraft.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgv_ShowDraft.Rows[i].Cells["LetterType"].Value = result[i].FarsiLetterType;
                    dgv_ShowDraft.Rows[i].Cells["ForceType"].Value = result[i].FarsiForceType;
                    dgv_ShowDraft.Rows[i].Cells["PeygiryType"].Value = result[i].FarsiPeygiriType;
                    dgv_ShowDraft.Rows[i].Cells["SecurityType"].Value = result[i].FarsiSecurityType;
                    dgv_ShowDraft.Rows[i].Cells["Attachment"].Value = result[i].FarsiAttachmentType;
                    dgv_ShowDraft.Rows[i].Cells["AnswerType"].Value = result[i].FarsiAnswerType;
                    dgv_ShowDraft.Rows[i].Cells["AnswerDate"].Value = result[i].answerDeadline;
                    dgv_ShowDraft.Rows[i].Cells["LetterNo"].Value = result[i].letterNo;
                    dgv_ShowDraft.Rows[i].Cells["forceT"].Value = result[i].ForceType;
                    dgv_ShowDraft.Rows[i].Cells["securityT"].Value = result[i].SecurityType;
                    dgv_ShowDraft.Rows[i].Cells["LetterT"].Value = result[i].LetterType;
                    dgv_ShowDraft.Rows[i].Cells["ReplyLetterID"].Value = result[i].replyLetterId;

                    if (Convert.ToInt32(dgv_ShowDraft.Rows[i].Cells["forceT"].Value) == 2)
                    {
                        dgv_ShowDraft.Rows[i].Cells["forceType"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt32(dgv_ShowDraft.Rows[i].Cells["forceT"].Value) == 3)
                    {
                        dgv_ShowDraft.Rows[i].Cells["forceType"].Style.BackColor = Color.Red;
                    }
                    if (Convert.ToInt32(dgv_ShowDraft.Rows[i].Cells["SecurityT"].Value) == 2)
                    {
                        dgv_ShowDraft.Rows[i].Cells["securityType"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt32(dgv_ShowDraft.Rows[i].Cells["SecurityT"].Value) == 3)
                    {
                        dgv_ShowDraft.Rows[i].Cells["securityType"].Style.BackColor = Color.Red;
                    }
                }
                dgv_ShowDraft.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_ShowDraft.Rows.Clear();
            }
        }
        private string searchCondition()
        {

            string searchString = "";
            if (txt_subject.Text != "")
            {
                searchString += " and [subject] like '%" + txt_subject.Text.Trim() + "%'";
            }
            if (Rdb_foriatFori.Checked)
            {
                searchString += " and forceType = 2 ";
            }
            else if (rdb_foriyatAni.Checked)
            {
                searchString += " and forceType = 3 ";
            }
            else if(rdb_foriyatAdy.Checked)
            {
                searchString += " and forceType = 1 ";
            }
            if(rdb_tabagheAdi.Checked)
            {
                searchString += " and SecurityType = 1 ";
            }
            else if(rdb_tabagheMahramane.Checked)
            {
                searchString += " and SecurityType = 2 ";
            }
            else if(rdb_tabagheSeri.Checked)
            {
                searchString += " and SecurityType = 3 ";
            }
            return searchString;
        }


        private void pictureBox_Search_Click(object sender, EventArgs e)
        {
            ShowDraft(searchCondition());
        }

        private void btn_delDraft_Click(object sender, EventArgs e)
        {

            try
            {
                int item = dgv_ShowDraft.SelectedCells.Count;
                if (item >0)
                {
                    if (MessageBox.Show("Are you sure you want to delete this draft?", "Delete draft", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int get_letterID = Convert.ToInt32(dgv_ShowDraft.CurrentRow.Cells["LetterID"].Value);
                        var deleteQuery = (from L in database.Letters where L.LetterId == get_letterID select L).SingleOrDefault();
                        database.Letters.Remove(deleteQuery);
                        database.SaveChanges();
                
                        MessageBox.Show("The letter was successfully removed from the draft.");
                        ShowDraft(searchCondition());
                    }

                }
            }
            catch
            {
                MessageBox.Show("There are problems with the server. try again");
            }
        }

        private void btn_SendLetter_Click(object sender, EventArgs e)
        {
            int item = dgv_ShowDraft.SelectedCells.Count;
            if (item>0)
            {
                int getReplyLetterID;
                int getcreatorLetter;
                if (Convert.ToInt32(dgv_ShowDraft.CurrentRow.Cells["LetterT"].Value) == 2)
                {
                    getReplyLetterID = Convert.ToInt32(dgv_ShowDraft.CurrentRow.Cells["ReplyLetterID"].Value);
                    var query = (from L in database.Letters where L.LetterId == getReplyLetterID select L).ToList();
                    if (query.Count> 0)
                    {
                        getcreatorLetter = query[0].userID;

                        Frm_SelectUserToSendLetter frm_SU = new Frm_SelectUserToSendLetter();
                        frm_SU.GetLetterID = Convert.ToInt32(dgv_ShowDraft.CurrentRow.Cells["LetterID"].Value);
                        frm_SU.GetReplyLetter_User = getcreatorLetter;
                        frm_SU.IsReply = 1;
                        frm_SU.ShowDialog();
                    }
                }

                else
                {
                    Frm_SelectUserToSendLetter frm_SU = new Frm_SelectUserToSendLetter();
                    frm_SU.GetLetterID = Convert.ToInt32(dgv_ShowDraft.CurrentRow.Cells["LetterID"].Value);
                    frm_SU.ShowDialog();
                }

                ShowDraft(searchCondition());
            }
            else
            {
                MessageBox.Show("To send a letter, select a letter from the draft list.");
            }
        }

        private void mnu_editLetter_Click(object sender, EventArgs e)
        {
            int item = dgv_ShowDraft.SelectedCells.Count;
            if (item >0)
            {
                Frm_CreateLetter frm_c = new Frm_CreateLetter();
                frm_c.MdiParent = MainUser;

                frm_c.FormType = 2; // edit letter
                frm_c.Get_LetterID = Convert.ToInt32(dgv_ShowDraft.CurrentRow.Cells["LetterID"].Value);

                this.Close();
                frm_c.Show();

            }
            else
            {
                MessageBox.Show("To edit a letter, first select a letter.");
                return;
            }
        }
    }
}
