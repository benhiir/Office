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
    public partial class Frm_ShowRemembers : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public Frm_ShowRemembers()
        {
            InitializeComponent();
        }

        private void Frm_ShowRemembers_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;
            persianDateTimePicker_Ta.Value = DateTime.Now.AddDays(1);

            ShowRemember(searchCondition());
        }
        private void ShowRemember(string search)
        {
            var query = database.Database.SqlQuery<Vw_Remember>("select * from Vw_Remember where 1=1" + search + "and userid =" + PublicVariable.gUserId );
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgvShowRemembers.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgvShowRemembers.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgvShowRemembers.Rows[i].Cells["matn"].Value = result[i].matn;
                    dgvShowRemembers.Rows[i].Cells["datesabt"].Value = result[i].createDate;
                    dgvShowRemembers.Rows[i].Cells["dateRemember"].Value = result[i].DateRemember;
                    dgvShowRemembers.Rows[i].Cells["status"].Value = result[i].FarsiIsRead;
                    dgvShowRemembers.Rows[i].Cells["RememberId"].Value = result[i].RememberID;
                    dgvShowRemembers.Rows[i].Cells["IsRead"].Value = result[i].IsRead;

                    if (Convert.ToInt16(dgvShowRemembers.Rows[i].Cells["isRead"].Value) == 1)
                    {
                        dgvShowRemembers.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    else
                    {
                        dgvShowRemembers.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
                dgvShowRemembers.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgvShowRemembers.Rows.Clear();
            }
        }
        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_Az.Value.Year.ToString() + "/" + persianDateTimePicker_Az.Value.Month.ToString() + "/" + persianDateTimePicker_Az.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_Ta.Value.Year.ToString() + "/" + persianDateTimePicker_Ta.Value.Month.ToString() + "/" + persianDateTimePicker_Ta.Value.Day.ToString()));

            string searchString = " and DateRemember between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_subject.Text != "")
            {
                searchString += " and [subject] like '%" + txt_subject.Text.Trim() + "%'";
            }

            return searchString;
        }


        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            ShowRemember(searchCondition());
        }

        private void dgvShowRemembers_DoubleClick(object sender, EventArgs e)
        {
            if (dgvShowRemembers.SelectedCells.Count > 0)
            {
                MessageBox.Show(dgvShowRemembers.CurrentRow.Cells["matn"].Value.ToString(), dgvShowRemembers.CurrentRow.Cells["subject"].Value.ToString());
                try
                {
                    int getrememberID = Convert.ToInt32(dgvShowRemembers.CurrentRow.Cells["RememberId"].Value);

                    //////Update by linq to entity
                    //////select * from Remember where rememberID = getrememberID
                    var updateQuery = (from R in database.Remembers where R.RememberID == getrememberID select R).SingleOrDefault();
                    updateQuery.IsRead = 2;
                    database.SaveChanges();

                    ShowRemember(searchCondition());
                }
                catch
                {
                    MessageBox.Show("There was a problem communicating with the server. Try again.");
                }
            }
        }
    }
}
