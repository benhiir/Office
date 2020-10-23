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
    public partial class Frm_CreateNews : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public Frm_CreateNews()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_CreateNews_Load(object sender, EventArgs e)
        {
            lbl_newsDate.Text = PublicVariable.TodayDate;
            lbl_userCreator.Text = PublicVariable.gUserFirstName + " " + PublicVariable.gUserFamilyName;

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
            if (txt_subject.Text == "" || txt_matn.Text == "")
                {
                MessageBox.Show("Enter the subject and text of the news to create and send news.");
                txt_subject.Focus();
                return;
                }
            try
            {
                news N = new news();
                N.UserID = PublicVariable.gUserId;
                N.subject = txt_subject.Text.Trim();
                N.matn = txt_matn.Text.Trim();
                N.NewsDate = lbl_newsDate.Text.Trim();
                //// attachment
                if (lbl_attachmentFile.Text != "")
                {
                    FileStream objFileStream = new FileStream(lbl_attachmentFile.Text, FileMode.Open, FileAccess.Read);
                    int intLength = Convert.ToInt32(objFileStream.Length);
                    byte[] objData;
                    objData = new byte[intLength];
                    String[] strPath = lbl_attachmentFile.Text.Split(Convert.ToChar(@"\"));

                    objFileStream.Read(objData, 0, intLength);
                    objFileStream.Close();
                    N.Attachment = objData;
                    N.AttachmentFileSize = intLength;
                    N.AttachmentFileName = strPath[strPath.Length - 1];

                }
                database.news.Add(N);
                database.SaveChanges();

                MessageBox.Show("Announcement sent successfully.");
                this.Close();
              
                
            }
            catch
            {
                MessageBox.Show("There is something wrong with the server. Please try again.");
                return;
            }
        }

        private void btn_showallnews_Click(object sender, EventArgs e)
        {
            frm_showAllNews frm_s = new frm_showAllNews();
            frm_s.ShowDialog();
        }

        private void btn_sendSMS_Click(object sender, EventArgs e)
        {
            Frm_sendSMS frm_s = new Frm_sendSMS();
            frm_s.ShowDialog();
        }
    }
}
