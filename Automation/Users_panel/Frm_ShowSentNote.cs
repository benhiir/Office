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
    public partial class Frm_ShowSentNote : Form
    {
        public Frm_ShowSentNote()
        {
            InitializeComponent();
        }

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        private void Frm_ShowSentNote_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;
            persianDateTimePicker_az.Value = DateTime.Now.AddDays(-10);
            ShowSentNotes(searchCondition());

        }

        private void ShowSentNotes(string search)
        {
            var query = database.Database.SqlQuery<Vw_recieveNotes>("select * from vw_recieveNotes where UserID_creator =" + PublicVariable.gUserId + " " + search);
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_showAllSentNote.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showAllSentNote.Rows[i].Cells["SentNoteID"].Value = result[i].sentNoteID;
                    dgv_showAllSentNote.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgv_showAllSentNote.Rows[i].Cells["matn"].Value = result[i].matn;
                    dgv_showAllSentNote.Rows[i].Cells["Fullname_girande"].Value = result[i].FullName_reciever;
                    dgv_showAllSentNote.Rows[i].Cells["userID_girande"].Value = result[i].UserID_girande;
                    dgv_showAllSentNote.Rows[i].Cells["dateNote"].Value = result[i].NoteDate;
                }
                dgv_showAllSentNote.ScrollBars = ScrollBars.Both; 
            }
            else
            {
                dgv_showAllSentNote.Rows.Clear();
            }
        }

        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_az.Value.Year.ToString() + "/" + persianDateTimePicker_az.Value.Month.ToString() + "/" + persianDateTimePicker_az.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_ta.Value.Year.ToString() + "/" + persianDateTimePicker_ta.Value.Month.ToString() + "/" + persianDateTimePicker_ta.Value.Day.ToString()));

            string searchString = " and NoteDate between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_SearchSubject.Text != "")
            {
                searchString += " and [subject] like '%" + txt_SearchSubject.Text.Trim() + "%'";
            }
            if (txt_searchMatn.Text != "")
            {
                searchString += " and matn like '%" + txt_searchMatn.Text.Trim() + "%'";
            }
            if (txt_girandeh.Text != "")
            {
                searchString += " and FullName_reciever like '%" + txt_girandeh.Text.Trim() + "%'";
            }

            return searchString;
        }

        private void pictureBox_search_Click(object sender, EventArgs e)
        {
            ShowSentNotes(searchCondition());
        }
    }
}
