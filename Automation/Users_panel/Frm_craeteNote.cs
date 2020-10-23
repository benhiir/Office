using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.modula;
using DataModelLayer.Models;
using System.Transactions;

namespace Automation.Users_panel
{
    public partial class Frm_craeteNote : Form
    {
        public Frm_craeteNote()
        {
            InitializeComponent();
        }

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        private void Frm_craeteNote_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;

            lbl_dateNote.Text = PublicVariable.TodayDate;
            ShowAllowedUsers(searchCondition());
        }

        private void ShowAllowedUsers(string search)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_UserJobs>("select * from Vw_UserJobs where [status] = 1 and DetermineJobsLevel >=" + PublicVariable.gDetermineJobsLevel + " - 1 " + search + " except (select * from Vw_UserJobs where UserID =" + PublicVariable.gUserId + ")");
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

        private void btn_SendNote_Click(object sender, EventArgs e)
        {
            //Check that the subject and text are not empty
            if (txt_SubjectNote.Text == "" || txt_matnNote.Text == "")
            {
                MessageBox.Show("Please enter subject and text.");
                txt_SubjectNote.Focus();
                return;

            }
            // کنترل انتخاب نکردن گیرنده
            int counter = 0;
            foreach (DataGridViewRow row in dgv_SelectUserToSend.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selectUser"].Value) == true)
                {
                    counter += 1;
                }
            }
            if (counter == 0)
            {
                MessageBox.Show("Please select a note recipient.");
                return;
            }



            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    ///Create notes
                    Note N = new Note();
                    N.subject = txt_SubjectNote.Text.Trim();
                    N.matn = txt_matnNote.Text.Trim();
                    N.NoteDate = lbl_dateNote.Text;
                    N.userId = PublicVariable.gUserId;

                    database.Notes.Add(N);
                    database.SaveChanges();


                    ///Send notes
                    List<DataGridView> row_with_check_column = new List<DataGridView>();
                    foreach (DataGridViewRow row in dgv_SelectUserToSend.Rows)
                    {
                        SentNote SN = new SentNote();
                        if (Convert.ToBoolean(row.Cells["selectUser"].Value) == true)
                        {
                            SN.NoteID = N.noteID;
                            SN.UserID = Convert.ToInt32(row.Cells["UserID"].Value);
                    
                            database.SentNotes.Add(SN);
                        }
                    }
                    database.SaveChanges();
                    ts.Complete();
                    MessageBox.Show("The note was sent successfully.");
           

                }
                catch
                {
                    MessageBox.Show("There are problems with the server, please try again.");
                    return;


                }

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
