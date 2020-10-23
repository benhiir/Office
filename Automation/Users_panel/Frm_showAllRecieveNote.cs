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
    public partial class Frm_showAllRecieveNote : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public Frm_showAllRecieveNote()
        {
            InitializeComponent();
        }

        private void Frm_showAllRecieveNote_Load(object sender, EventArgs e)
        {
            this.Top = 142;
            this.Left = 216;
            persianDateTimePicker_az.Value = DateTime.Now.AddDays(-10);
            ShowReciveNotes(searchCondition());
        }

        private void ShowReciveNotes(string search)
        {
            var query = database.Database.SqlQuery<Vw_recieveNotes>("select * from vw_recieveNotes where UserID_girande =" + PublicVariable.gUserId + " " + search);
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_showAllReciveNotes.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showAllReciveNotes.Rows[i].Cells["SentNoteID"].Value = result[i].sentNoteID;
                    dgv_showAllReciveNotes.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgv_showAllReciveNotes.Rows[i].Cells["matn"].Value = result[i].matn;
                    dgv_showAllReciveNotes.Rows[i].Cells["Fullname_ferestande"].Value = result[i].FullNameCreator;
                    dgv_showAllReciveNotes.Rows[i].Cells["userID_creator"].Value = result[i].UserID_creator;
                    dgv_showAllReciveNotes.Rows[i].Cells["NoteDate"].Value = result[i].NoteDate;
                }
                dgv_showAllReciveNotes.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showAllReciveNotes.Rows.Clear();
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
            if (txt_ferestande.Text != "")
            {
                searchString += " and FullNameCreator like '%" + txt_ferestande.Text.Trim() + "%'";
            }

            return searchString; 
        }

        private void pictureBox_search_Click(object sender, EventArgs e)
        {
            ShowReciveNotes(searchCondition());
        }
    }
}
