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
    public partial class frm_sabteKarkard : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_sabteKarkard()
        {
            InitializeComponent();
        }

        private void frm_sabteKarkard_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;
            persianDateTimePicker_az.Value = DateTime.Now.AddDays(-10);

            fillComboRequest();
            fillComboRequest_search();
            ShowWorks(searchCondition());
        }

        private void ShowWorks(string search)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_works>("select * from Vw_works where userid =" + PublicVariable.gUserId + " " + search);
            var result = query.ToList();

            dgv_showAllWorks.Rows.Clear();  ///Clear previous information in the table

            if (result.Count != 0)
            {
                dgv_showAllWorks.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showAllWorks.Rows[i].Cells["worksId"].Value = result[i].worksID;
                    dgv_showAllWorks.Rows[i].Cells["works_subject"].Value = result[i].work_subject;
                    dgv_showAllWorks.Rows[i].Cells["works_description"].Value = result[i].work_description;
                    dgv_showAllWorks.Rows[i].Cells["works_request"].Value = result[i].jobsName;
                    dgv_showAllWorks.Rows[i].Cells["works_requestid"].Value = result[i].jobID;
                    dgv_showAllWorks.Rows[i].Cells["works_time"].Value = result[i].timeDone;
                    dgv_showAllWorks.Rows[i].Cells["works_dateDone"].Value = result[i].dateDone;
                }
                dgv_showAllWorks.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showAllWorks.Rows.Clear();
            }
        }

        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_az.Value.Year.ToString() + "/" + persianDateTimePicker_az.Value.Month.ToString() + "/" + persianDateTimePicker_az.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_ta.Value.Year.ToString() + "/" + persianDateTimePicker_ta.Value.Month.ToString() + "/" + persianDateTimePicker_ta.Value.Day.ToString()));

            string searchString = " and dateDone between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_searchSubject.Text != "")
            {
                searchString += " and works_subject like '%" + txt_searchSubject.Text.Trim() + "%'";
            }

            if (txt_seatcgDescription.Text != "")
            {
                searchString += " and works_description like '%" + txt_seatcgDescription.Text.Trim() + "%'";
            }

            if (cmb_searchRequest.SelectedIndex != 0)
            {
                searchString += "and Jobid = " + cmb_searchRequest.SelectedValue;
            }
           
            return searchString;
        }

        private void fillComboRequest()
        {
            var query = (from J in database.Jobs select J).ToList();

            cmb_request.DataSource = query;
            cmb_request.ValueMember = "JobsID";
            cmb_request.DisplayMember = "JobsName";

        }

        private void fillComboRequest_search()
        {
            var query = (from J in database.Jobs select J).ToList();

            query.Insert(0, new Job { jobsID = -1, jobsName = "همه" });
            cmb_searchRequest.DataSource = query;
            cmb_searchRequest.ValueMember = "JobsID";
            cmb_searchRequest.DisplayMember = "JobsName";

            cmb_request.SelectedIndex = 0;

        }
        private void txt_timeDone_KeyPress(object sender, KeyPressEventArgs e)
        {
            /// Just enter the number
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.')> -1 ))
            {
                e.Handled = true;
            }
        }

        private void btn_sabt_Click(object sender, EventArgs e)
        {
            if (txt_subject.Text.Trim() == "" || txt_description.Text.Trim() == "" || txt_timeDone.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in the required values.");
                return;
            }
            try
            {
                work W = new work();
                W.work_subject = txt_subject.Text.Trim();
                W.work_description = txt_description.Text.Trim();
                W.userID = PublicVariable.gUserId;
                W.timeDone = Convert.ToInt32(txt_timeDone.Text.Trim());
                W.dateDone = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_done.Value.Year.ToString() + "/" + persianDateTimePicker_done.Value.Month.ToString() + "/" + persianDateTimePicker_done.Value.Day.ToString()));
                W.jobID = Convert.ToInt32(cmb_request.SelectedValue);

                database.works.Add(W);
                database.SaveChanges();
                MessageBox.Show("Your information was successfully registered.");
                ClearForm();


            }
            catch
            {
                MessageBox.Show("There was a problem with the server. try again.");
            }
            ShowWorks(searchCondition());

        }
        private void ClearForm()
        {
            txt_description.Text = "";
            txt_subject.Text = "";
            txt_timeDone.Text = "";
            fillComboRequest();
            persianDateTimePicker_done.Value = DateTime.Now;
        }

        private void pictureBox_search_Click(object sender, EventArgs e)
        {
            ShowWorks(searchCondition());
        }
    }
}
