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
    public partial class Frm_documents : Form
    {

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        public Frm_documents()
        {
            InitializeComponent();
        }

        private void Frm_documents_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;

            lbl_date.Text = PublicVariable.TodayDate;
            persianDateTimePicker_az.Value = DateTime.Now.AddDays(-10);
            ShowAllDocuments(searchCondition());
        }
        private void ShowAllDocuments(string SearchString)
        {
            //Query performance
            var query = database.Database.SqlQuery<Document>("select * from Documents where userId =" + PublicVariable.gUserId + " " + SearchString);
            var result = query.ToList();

            dgv_showDocument.Rows.Clear();  ///Clear previous information in the table

            if (result.Count != 0)
            {
                dgv_showDocument.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showDocument.Rows[i].Cells["DocID"].Value = result[i].DocumentID;
                    dgv_showDocument.Rows[i].Cells["Doc_subject"].Value = result[i].Doc_subject;
                    dgv_showDocument.Rows[i].Cells["Doc_exporter"].Value = result[i].Doc_exporter;
                    dgv_showDocument.Rows[i].Cells["Doc_description"].Value = result[i].Doc_description;
                    dgv_showDocument.Rows[i].Cells["Doc_tahvil"].Value = result[i].Doc_DeliveryFullname;
                    dgv_showDocument.Rows[i].Cells["Doc_date"].Value = result[i].Doc_date;
                    dgv_showDocument.Rows[i].Cells["Attach"].Value = result[i].FileName;
                }

                //Show row
                dgv_showDocument.TopLeftHeaderCell.Value = "قخص";
                for (int counter = 0; counter <= dgv_showDocument.Rows.Count - 1; counter++)
                {
                    dgv_showDocument.Rows[counter].HeaderCell.Value = (counter + 1).ToString();
                }
                dgv_showDocument.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showDocument.Rows.Clear();
            }
        }
        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_az.Value.Year.ToString() + "/" + persianDateTimePicker_az.Value.Month.ToString() + "/" + persianDateTimePicker_az.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_ta.Value.Year.ToString() + "/" + persianDateTimePicker_ta.Value.Month.ToString() + "/" + persianDateTimePicker_ta.Value.Day.ToString()));

            string searchString = " and Doc_date between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_searchSubject.Text != "")
            {
                searchString += " and Doc_subject like '%" + txt_searchSubject.Text.Trim() + "%'";
            }

            if (txt_searchTahvil.Text != "")
            {
                searchString += " and Doc_DeliveryFullname like '%" + txt_searchTahvil.Text.Trim() + "%'";
            }


            if (txt_searchSader.Text != "")
            {
                searchString += " and Doc_exporter like '%" + txt_searchSader.Text.Trim() + "%'";
            }

            return searchString;
        }

        private void btn_attachment_Click(object sender, EventArgs e)
        {
            var file = "";
            openFileDialog1.Filter = "All Files (*.*) | *.*";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var lst = new string[] { ".jpg", ".bmp", ".png", ".rar", ".zip", ".pdf", ".doc", ".docx", ".txt", ".xls", ".xlsx" };
                file = openFileDialog1.FileName;


                if (!lst.Contains(Path.GetExtension(file)))
                {
                    MessageBox.Show("Please select a file with the allowed extension.");
                    return;
                }

                lbl_attachmentFile.Text = file;
            }
            else
            {
                return;
            }
        }
  

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!checkNullable())
            {
                return;
            }
            try
            {
                Document D = new Document();
                D.UserID = PublicVariable.gUserId;
                D.Doc_subject = txt_subject.Text.Trim();
                D.Doc_description = txt_description.Text.Trim();
                D.Doc_date = lbl_date.Text;
                D.Doc_exporter = txt_saderkonandeh.Text.Trim();
                D.Doc_DeliveryFullname = txt_tahvildahandeh.Text.Trim();

                /// attachment
                if (lbl_attachmentFile.Text != "")
                {
                    FileStream objFileStream = new FileStream(lbl_attachmentFile.Text, FileMode.Open, FileAccess.Read);
                    int intLength = Convert.ToInt32(objFileStream.Length);
                    byte[] objData;
                    objData = new byte[intLength];
                    String[] strPath = lbl_attachmentFile.Text.Split(Convert.ToChar(@"\"));

                    objFileStream.Read(objData, 0, intLength);
                    objFileStream.Close();
                    D.FileData = objData;
                    D.FileSize = intLength;
                    D.FileName = strPath[strPath.Length - 1];

                }

                database.Documents.Add(D);
                database.SaveChanges();

                MessageBox.Show("The document was successfully registered.");
                txt_description.Text = "";
                txt_saderkonandeh.Text = "";
                txt_subject.Text = "";
                txt_tahvildahandeh.Text = "";
                lbl_attachmentFile.Text = "";
                ShowAllDocuments(searchCondition());

            }
            catch
            {
                MessageBox.Show("There is a problem with the server.");
                return;
            }
        }

        private bool checkNullable()
        {
            if(txt_subject.Text.Trim() == "")
            {
                MessageBox.Show("Enter the subject of the document");
                return false;
            }
            if (txt_description.Text.Trim() == "")
            {
                MessageBox.Show("Enter the document description");
                return false;
            }
            if (string.IsNullOrEmpty(txt_saderkonandeh.Text))
            {
                MessageBox.Show("Enter the document issuer");
                return false;
            }
            if (string.IsNullOrEmpty(txt_tahvildahandeh.Text))
            {
                MessageBox.Show("Enter the document deliverer");
                return false;
            }
            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowAllDocuments(searchCondition());
        }

        private void dgv_showDocument_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_showDocument.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1)
            {
                if (dgv_showDocument.CurrentCell != null && dgv_showDocument.CurrentCell.Value != null)
                {
                    int GetDocID = Convert.ToInt32(dgv_showDocument.CurrentRow.Cells["DocID"].Value);
                    var query_fileName = (from AF in database.AttachFiles where AF.LetterID == GetDocID select AF).ToList();
                    SaveAttachment(saveFileDialog1, dgv_showDocument, GetDocID);
                }
            }
        }

        private void SaveAttachment(SaveFileDialog objsfd, DataGridView objGrid, int DocID)
        {
            try
            {
                string strID = objGrid.CurrentRow.Cells["Attach"].Value.ToString();

                if (strID != null)
                {
                    var query_attachment = (from AF in database.Documents where AF.DocumentID == DocID select AF).ToList();

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
