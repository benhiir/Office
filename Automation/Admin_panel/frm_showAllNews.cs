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

namespace Automation.Admin_panel
{
    public partial class frm_showAllNews : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_showAllNews()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_showAllNews_Load(object sender, EventArgs e)
        {

            persianDateTimePicker_az.Value = DateTime.Now.AddDays(-10);
            ShowAllNews(searchCondition());


        }


        private void ShowAllNews(string search)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_news>("select * from Vw_news where 1=1 " + search);
            var result = query.ToList();

            dgvShowallnews.Rows.Clear();  ///Clear previous information in the table

            if (result.Count != 0)
            {
                dgvShowallnews.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgvShowallnews.Rows[i].Cells["newsid"].Value = result[i].newsid;
                    dgvShowallnews.Rows[i].Cells["subject"].Value = result[i].subject;
                    dgvShowallnews.Rows[i].Cells["matn"].Value = result[i].matn;
                    dgvShowallnews.Rows[i].Cells["NewsDate"].Value = result[i].NewsDate;
                    dgvShowallnews.Rows[i].Cells["Fullname"].Value = result[i].Fullname;
                    dgvShowallnews.Rows[i].Cells["attachment"].Value = result[i].AttachmentFileName;
                }

                //Show row
                dgvShowallnews.TopLeftHeaderCell.Value = "row";
                for (int counter = 0; counter <= dgvShowallnews.Rows.Count - 1; counter++)
                {
                    dgvShowallnews.Rows[counter].HeaderCell.Value = (counter + 1).ToString();
                }
                dgvShowallnews.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgvShowallnews.Rows.Clear();
            }

        }
      private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_az.Value.Year.ToString() + "/" + persianDateTimePicker_az.Value.Month.ToString() + "/" + persianDateTimePicker_az.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_ta.Value.Year.ToString() + "/" + persianDateTimePicker_ta.Value.Month.ToString() + "/" + persianDateTimePicker_ta.Value.Day.ToString()));

            string searchString = " and newsDate between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_matn.Text != "")
            {
                searchString += " and Fullname like '%" + txt_matn.Text.Trim() + "%'";
            }

            if (txt_subject.Text != "")
            {
                searchString += " and [subject] like '%" + txt_subject.Text.Trim() + "%'";
            }

 
            return searchString;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowAllNews(searchCondition());
        }

        private void dgvShowallnews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShowallnews.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                if (dgvShowallnews.CurrentCell != null && dgvShowallnews.CurrentCell.Value != null)
                {
                    int GetNewsID = Convert.ToInt32(dgvShowallnews.CurrentRow.Cells["newsId"].Value);
                    var query_fileName = (from AF in database.news where AF.newsid == GetNewsID select AF).ToList();
                    SaveAttachment(saveFileDialog1, dgvShowallnews, GetNewsID);
                }
            }
        }

        private void SaveAttachment(SaveFileDialog objsfd, DataGridView objGrid, int GetNewsID)
        {
            try
            {
                string strID = objGrid.CurrentRow.Cells["attachment"].Value.ToString();

                if (strID != null)
                {
                    var query_attachment = (from AF in database.news where AF.newsid == GetNewsID select AF).ToList();

                    byte[] objData;
                    objData = (byte[])query_attachment[0].Attachment;

                    objsfd.FileName = query_attachment[0].AttachmentFileName;
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

