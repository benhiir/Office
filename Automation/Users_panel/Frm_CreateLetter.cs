using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelLayer.Models;
using Automation.modula;
using System.Transactions;


namespace Automation.Users_panel
{
    public partial class Frm_CreateLetter : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        public byte FormType { get; set; }  // 1 = new letter 2 = edit letter
        public int Get_LetterID { get; set; }  // To fill in the fields in edit mode

        public string Get_LetterNo { get; set; } // To send the letter number in reply mode

        public byte IsReply { get; set; } //Is the letter or reply to the letter 1 = reply  



        public Frm_CreateLetter()
        {
            InitializeComponent();
        }

        private void Frm_CretateLetter_Load(object sender, EventArgs e)
        {
            this.Left = 216;
            this.Top = 141;
            lbl_createDate.Text = PublicVariable.TodayDate;

            if (this.FormType == 1)  // add
            {
                //nothing
            }
            else if (this.FormType == 2) //edit
            {
                main_tabControl.SelectedTabIndex = 1;
                btn_newLetter.Text = "Edit letter";

                var query_attachName = (from AF in database.AttachFiles where AF.LetterID == this.Get_LetterID select AF).ToList();
                if (query_attachName.Count > 0)
                {
                    lbl_path.Text = query_attachName[0].FileName;
                }
                ShowLetterInfoForEdit();

            }
        }


        private void ShowLetterInfoForEdit()
        {
            try
            {
                var query_letterInfo = (from L in database.Vw_Letters where L.LetterId == this.Get_LetterID select L).ToList();
                if (query_letterInfo.Count > 0)
                {
                    txt_subject.Text = query_letterInfo[0].subject;
                    txt_chekideh.Text = query_letterInfo[0].abstrct;
                    advancedTextEditor_matn.TextEditor.Text = query_letterInfo[0].matn;
                    main_tabControl.SelectedTabIndex = 0;

                    // Classification
                    if (query_letterInfo[0].SecurityType == 1)
                    {
                        rdb_tabaghe_adi.Checked = true;
                    }
                    else if (query_letterInfo[0].SecurityType == 2)
                    {
                        rdb_tabaghe_mahramane.Checked = true;
                    }
                    else if (query_letterInfo[0].SecurityType == 3)
                    {
                        rdb_tabaghe_seri.Checked = true;
                    }
                    // Urgency
                    if (query_letterInfo[0].ForceType == 1)
                    {
                        rdb_foriyat_adi.Checked = true;
                    }
                    else if (query_letterInfo[0].ForceType == 2)
                    {
                        rdb_foriyat_fori.Checked = true;
                    }
                    else if (query_letterInfo[0].ForceType == 3)
                    {
                        rdb_foriyat_ani.Checked = true;
                    }
                    // Follow up
                    if (query_letterInfo[0].PeygiryType == 1)
                    {
                        rdb_peygiri_darad.Checked = true;

                    }
                    else if (query_letterInfo[0].PeygiryType == 2)
                    {
                        rdb_peygiri_nadarad.Checked = true;
                    }
                    // the attachment
                    if (query_letterInfo[0].AttachmentType == 1)
                    {
                        rdb_peyvast_darad.Checked = true;
                    }
                    else if (query_letterInfo[0].AttachmentType == 2)
                    {
                        rdb_peyvast_nadarad.Checked = true;
                    }
                    // Response deadline
                    if (query_letterInfo[0].answerType == 1)
                    {
                        rdb_mohlat_darad.Checked = true;
                        persianDateTimePicker_mohlatPasokh.Value = Convert.ToDateTime(query_letterInfo[0].answerDeadline);
                    }
                    else if (query_letterInfo[0].answerType == 2)
                    {
                        rdb_mohlat_nadarad.Checked = true;
                    }
                }


            }
            catch
            {
                MessageBox.Show("There are problems with the server");
                return;

            }
        }
        private void rdb_mohlat_darad_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_mohlat_darad.Checked)
            {
                persianDateTimePicker_mohlatPasokh.Enabled = true;
            }
            else
            {
                persianDateTimePicker_mohlatPasokh.Enabled = false;
            }

        }

        private void rdb_peyvast_darad_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_peyvast_darad.Checked)
            {
                btn_attachment.Enabled = true;
            }
            else
            {
                btn_attachment.Enabled = false;
            }
        }

        private void btn_attachment_Click(object sender, EventArgs e)
        {
            var file = "";
            openFiledlg_attachment.Filter = "All Files (*.*) | *.*";
            openFiledlg_attachment.Multiselect = false;
            if (openFiledlg_attachment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var lst = new string[] { ".jpg", ".bmp", ".png", ".rar", ".zip", ".pdf", ".doc", ".docx", ".txt", ".xls", ".xlsx" };
                file = openFiledlg_attachment.FileName;


                if (!lst.Contains(Path.GetExtension(file)))
                {
                    MessageBox.Show("Please select a file with the allowed extension.");
                    return;

                }
                lbl_path.Text = file;
            }
            else
            {
                return;
            }
        }

        private void btn_newLetter_Click(object sender, EventArgs e)
        {


            if (txt_subject.Text.Trim() == "" || txt_chekideh.Text.Trim() == "" || advancedTextEditor_matn.TextEditor.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the full letter information");
                return;
            }


            if (this.FormType == 1)
            {
                using (TransactionScope ts = new TransactionScope())

                {
                    try
                    {
                        Letter L = new Letter();
                        L.subject = txt_subject.Text.Trim();
                        L.abstrct = txt_chekideh.Text.Trim();
                        L.matn = advancedTextEditor_matn.TextEditor.Text;

                        ///Make a letter number
                        {
                            /// Year + User job level + / + Last ID Letter +1
                            var Last_LetterID = (from Leter in database.Letters orderby Leter.LetterId descending select Leter).First();
                            L.letterNo = PublicVariable.TodayDate.Substring(2, 2) + PublicVariable.gDetermineJobsLevel + "/" + (Last_LetterID.LetterId + 1);

                        }

                        L.createDate = lbl_createDate.Text;
                        L.userID = PublicVariable.gUserId;

                        if (rdb_tabaghe_adi.Checked)
                        {
                            L.SecurityType = 1;
                        }
                        else if (rdb_tabaghe_mahramane.Checked)
                        {
                            L.SecurityType = 2;
                        }
                        else if (rdb_tabaghe_seri.Checked)
                        {
                            L.SecurityType = 3;
                        }


                        if (rdb_foriyat_adi.Checked)
                        {
                            L.ForceType = 1;
                        }
                        else if (rdb_foriyat_fori.Checked)
                        {
                            L.ForceType = 2;
                        }
                        else if (rdb_foriyat_ani.Checked)
                        {
                            L.ForceType = 3;
                        }

                        L.BayganiType = 1;

                        if (rdb_peygiri_darad.Checked)
                        {
                            L.PeygiryType = 1;
                        }
                        else if (rdb_peygiri_nadarad.Checked)
                        {
                            L.PeygiryType = 2;
                        }

                        if (rdb_peyvast_darad.Checked)
                        {
                            L.AttachmentType = 1;
                        }
                        else if (rdb_peyvast_nadarad.Checked)
                        {
                            L.AttachmentType = 2;
                        }


                    //    L.ReadType = 1;
                        if (this.IsReply == 1)// reply 
                        {
                            L.LetterType = 2;
                        }
                        else
                        {
                            L.LetterType = 1;
                        }
                       

                        L.DraftType = 1;

                        if (rdb_mohlat_darad.Checked)
                        {
                            L.answerType = 1;
                            L.answerDeadline = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_mohlatPasokh.Value.Year + "/" + persianDateTimePicker_mohlatPasokh.Value.Month + "/" + persianDateTimePicker_mohlatPasokh.Value.Day));
                        }
                        else if (rdb_mohlat_nadarad.Checked)
                        {
                            L.answerType = 2;
                            L.Reffrence = this.Get_LetterNo;
                            L.replyLetterId = this.Get_LetterID;
                        }

                        database.Letters.Add(L);
                        database.SaveChanges();


                        ///////// Attach File

                        if (rdb_peyvast_darad.Checked == true)
                        {
                            if (lbl_path.Text != "")
                            {
                                FileStream objFileStream = new FileStream(lbl_path.Text, FileMode.Open, FileAccess.Read);
                                int intLength = Convert.ToInt32(objFileStream.Length);
                                byte[] objData;
                                objData = new byte[intLength];
                                String[] strPath = lbl_path.Text.Split(Convert.ToChar(@"\"));

                                objFileStream.Read(objData, 0, intLength);
                                objFileStream.Close();

                                AttachFile AF = new AttachFile();
                                AF.FileSize = intLength / 1024; ///KB
                                AF.FileName = strPath[strPath.Length - 1];
                                AF.FileData = objData;
                                AF.LetterID = L.LetterId;

                                database.AttachFiles.Add(AF);
                                database.SaveChanges();

                            }

                        }

                        ts.Complete();
                        
                        if (this.IsReply == 1)
                        {
                            MessageBox.Show("The reply was successfully created and moved to the drafts section.");
                        }
                        else
                        {
                            MessageBox.Show("The letter was successfully created and moved to the drafts section.");
                        }
                        
                    }
                    catch
                    {
                        MessageBox.Show("There is a problem with the server. try again.");
                    }

                }
            }


            else if (this.FormType == 2)  //edit
            {
                using (TransactionScope ts = new TransactionScope())

                {
                    try
                    {
                        var query_update = (from L in database.Letters where L.LetterId == this.Get_LetterID where L.userID == PublicVariable.gUserId select L).SingleOrDefault();


                        query_update.subject = txt_subject.Text.Trim();
                        query_update.abstrct = txt_chekideh.Text.Trim();
                        query_update.matn = advancedTextEditor_matn.TextEditor.Text;
                        query_update.createDate = lbl_createDate.Text;

                        if (rdb_tabaghe_adi.Checked)
                        {
                            query_update.SecurityType = 1;
                        }
                        else if (rdb_tabaghe_mahramane.Checked)
                        {
                            query_update.SecurityType = 2;
                        }
                        else if (rdb_tabaghe_seri.Checked)
                        {
                            query_update.SecurityType = 3;
                        }


                        if (rdb_foriyat_adi.Checked)
                        {
                            query_update.ForceType = 1;
                        }
                        else if (rdb_foriyat_fori.Checked)
                        {
                            query_update.ForceType = 2;
                        }
                        else if (rdb_foriyat_ani.Checked)
                        {
                            query_update.ForceType = 3;
                        }



                        if (rdb_peygiri_darad.Checked)
                        {
                            query_update.PeygiryType = 1;
                        }
                        else if (rdb_peygiri_nadarad.Checked)
                        {
                            query_update.PeygiryType = 2;
                        }

                        if (rdb_peyvast_darad.Checked)
                        {
                            query_update.AttachmentType = 1;
                        }
                        else if (rdb_peyvast_nadarad.Checked)
                        {
                            ///پیوست ندارد
                            query_update.AttachmentType = 2;
                        }


                        if (rdb_mohlat_darad.Checked)
                        {
                            query_update.answerType = 1;
                            query_update.answerDeadline = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePicker_mohlatPasokh.Value.Year + "/" + persianDateTimePicker_mohlatPasokh.Value.Month + "/" + persianDateTimePicker_mohlatPasokh.Value.Day));
                        }
                        else if (rdb_mohlat_nadarad.Checked)
                        {
                            query_update.answerType = 2;
                            query_update.answerDeadline = "";
                        }

                        database.SaveChanges();

                        ///////// attach file

                        if (rdb_peyvast_darad.Checked == true)
                        {

                            if (lbl_path.Text != "")
                            {

                                var query_checkAttachment = (from AF in database.AttachFiles where AF.LetterID == Get_LetterID select AF).ToList();

                                //The letter has not had attachment but now it has
                                if (query_checkAttachment.Count == 0)
                                {
                                    FileStream objfilestream = new FileStream(lbl_path.Text, FileMode.Open, FileAccess.Read);
                                    int intlength = Convert.ToInt32(objfilestream.Length);
                                    byte[] objdata;
                                    objdata = new byte[intlength];
                                    string[] strpath = lbl_path.Text.Split(Convert.ToChar(@"\"));

                                    objfilestream.Read(objdata, 0, intlength);
                                    objfilestream.Close();
                                    AttachFile af = new AttachFile();
                                    af.FileSize = intlength / 1024; ///kb
                                    af.FileName = strpath[strpath.Length - 1];
                                    af.FileData = objdata;
                                    af.LetterID = this.Get_LetterID;

                                    database.AttachFiles.Add(af);
                                    database.SaveChanges();
                                }
                                else if (query_checkAttachment.Count == 1) // The letter has already had attachment and still has
                                {
                                    if (lbl_path.Text != query_checkAttachment[0].FileName)///The letter already has an attachment, but it is the same as the previous file
                                    {
                                        FileStream objfilestream = new FileStream(lbl_path.Text, FileMode.Open, FileAccess.Read);
                                        int intlength = Convert.ToInt32(objfilestream.Length);
                                        byte[] objdata;
                                        objdata = new byte[intlength];
                                        string[] strpath = lbl_path.Text.Split(Convert.ToChar(@"\"));

                                        objfilestream.Read(objdata, 0, intlength);
                                        objfilestream.Close();

                                        var query_updateAttach = (from AF in database.AttachFiles where AF.LetterID == this.Get_LetterID select AF).SingleOrDefault();

                                        query_updateAttach.FileSize = intlength / 1024; ///kb
                                        query_updateAttach.FileName = strpath[strpath.Length - 1];
                                        query_updateAttach.FileData = objdata;

                                        database.SaveChanges();
                                    }

                                }

                            }
                        }
                          else if (rdb_peyvast_nadarad.Checked = true) ///If it already had it, but not now
                        {
                            try
                                {
                                    var query_checkAttachment = (from AF in database.AttachFiles where AF.LetterID == this.Get_LetterID select AF).ToList();
                                    if (query_checkAttachment.Count > 0)
                                    {
                                        var query_delete = (from AF in database.AttachFiles where AF.LetterID == this.Get_LetterID select AF).SingleOrDefault();
                                        database.AttachFiles.Remove(query_delete);
                                        database.SaveChanges();

                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("There is a problem with the server. try again");
                                    return;
                                }
                            }

                            ts.Complete();


                            MessageBox.Show("The letter was successfully edited and moved to the drafts section.");
                        
                    }
                    catch
                    {
                        MessageBox.Show("There is a problem with the server. try again.");
                        return;
                    }
                    
                }
            }

            
        }

        private void rdb_peyvast_nadarad_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Frm_sendEmail frm_se = new Frm_sendEmail();
            frm_se.ShowDialog();

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
