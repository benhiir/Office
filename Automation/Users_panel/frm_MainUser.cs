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
    public partial class frm_MainUser : Form
    {
        // frm_MainUser frm_Main;
        frm_addRemember frm_ar;   //Record reminders
        Frm_ShowRemembers frm_sr; //Show reminders
        Frm_ShowDraft frm_sd;//Show drafts
        Frm_CreateLetter frm_cLetter; //Create a letter
        frm_RecieveAllLetters frm_recieveallletter; //Show all incoming letters
        Frm_SentLetters frm_sentLetter; //Show all sent letters
        Frm_craeteNote frm_cNote; //View creating and sending notes
        Frm_ShowSentNote frm_SSN; //View sent notes
        Frm_showAllRecieveNote frm_showrnote; // View incoming notes
        Frm_showAllReadLetters frm_showAllRL; // show read letters
        Frm_showAllNotReadLetters frm_showAllNotRL; // show unread letters
        Frm_foriLetters frm_fori; // show Urgent action letters
        Frm_showAllMahramane frm_mahramane; //Form showing all confidential letters 
        frm_ShowAllnewsforUser frm_showallnews; //View news and announcements form
        frm_showAllRecievedReferenceLetters frm_reference; // show all incoming referal letters
        frm_ShowAllSentReferenceLetters frm_SentReference; // show all issued referal letters
        frm_ShowAllPeygiryLetters frm_peygiry; //Show letter tracking form
        frm_sabteKarkard frm_SK; //Display daily function registration form
        frm_showKarkard frm_sKarkard; //View Form View Personnel Function
        Frm_documents frm_D; // Registration of documents and letters outside the organization

        byte FormNumber = 7;   /// <Form number to execute a method for closing other windows s.38>

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_MainUser()
        {
            InitializeComponent();
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            database.SP_Update_ExitDate(PublicVariable.gUserId, PublicVariable.TodayDate + "-" + string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second)));
            database.SaveChanges();
            System.Environment.Exit(0);
        }

        private Boolean checkAccess(int userID, int sysPartId)
        {
            Boolean result = true;
            var query_accsess = (from UA in database.UsereAccesses where UA.userID == userID where UA.SystemPardID == sysPartId select UA).ToList();
            if (query_accsess.Count == 0)
            {
                MessageBox.Show("You do not have access to this section");
                result = false;                
            }
            return result;
        }

        private void frm_MainUser_Load(object sender, EventArgs e)
        {
            ShowUserInfo();


            /// show Remember form

            frm_sr = new Frm_ShowRemembers();
            frm_sr.MdiParent = this;
            frm_sr.Show();

            timer1.Start();
            timer1_Tick(sender, e);

        }
        private void ShowUserInfo()
        {
            var query = database.SP_Show_AllUserInfo2(PublicVariable.gUserId).ToList();
            if (query.Count == 1)
            {
                lblBirthDayDate.Text = query[0].BirthDayDate;
                lblFamily.Text = query[0].UserFamily;
                lblFirstname.Text = query[0].UserFirstName;
                lblGender.Text = query[0].farsiGender;

                lblJob.Text = query[0].jobsName;
                lbl_jobId.Text = query[0].JobId.ToString();
                lblPersonalCode.Text = query[0].PersonalCode;
                PublicVariable.gDetermineJobsLevel = Convert.ToInt32(query[0].DetermineJobsLevel);


                //// Image
                var dataUserImage = (Byte[])(query[0].UserImage);
                var stream_UserImage = new MemoryStream(dataUserImage);
                pictureBox_UserImage.Image = Image.FromStream(stream_UserImage);

                /// letter count
                var query_letterCount = database.SP_letterCount(PublicVariable.gUserId).ToList();
                lblRecievedLetters.Text = query_letterCount[0].recieveLettersCount.ToString();
                lblSentLetter.Text = query_letterCount[0].sentLettersCount.ToString();

                lblEnterTime.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                lblEnterDate.Text = PublicVariable.TodayDate;
            }
            else
            {
                MessageBox.Show("This username does not have a job. Login is not allowed.");
                System.Environment.Exit(0);

            }

        }

        private void frm_MainUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            database.SP_Update_ExitDate(PublicVariable.gUserId, PublicVariable.TodayDate + "-" + string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second)));
            database.SaveChanges();
        }

        private void lbl_createyadavari_Click(object sender, EventArgs e)
        {
            CloseOtherForms();
            FormNumber = 14;
            frm_ar = new frm_addRemember();
            frm_ar.MdiParent = this;
            frm_ar.Show();
        }

        private void CloseOtherForms()
        {
            if (FormNumber == 1)
            {
                frm_recieveallletter.Close();
            }
            if (FormNumber == 2)
            {
                frm_showAllRL.Close();
            }
            if (FormNumber == 3)
            {
                frm_showAllNotRL.Close();
            }
            if (FormNumber == 4)
            {
                frm_fori.Close();
            }
            if (FormNumber == 5)
            {
                frm_mahramane.Close();
            }
            if (FormNumber == 7)
            {
                frm_sr.Close();
            }
            if (FormNumber == 6)
            {
                frm_showrnote.Close();
            }
            if (FormNumber == 8)
            {
                frm_sentLetter.Close();
            }
            if (FormNumber == 9)
            {
                frm_peygiry.Close();
            }
            if (FormNumber == 10)
            {
                frm_SSN.Close();
            }
            if (FormNumber == 11)
            {
                frm_SentReference.Close();
            }
            if (FormNumber == 12)
            {
                frm_cLetter.Close();
            }
            if (FormNumber == 13)
            {
                frm_cNote.Close();
            }
            if (FormNumber == 14)
            {
                frm_ar.Close();
            }
            if (FormNumber == 15)
            {
                frm_sd.Close();
            }
            if (FormNumber == 16)
            {
                frm_showallnews.Close();
            }
            if (FormNumber == 17)
            {
                frm_reference.Close();
            }
            if (FormNumber == 100)
            {
                frm_SK.Close();
            }
            if (FormNumber == 101)
            {
                frm_sKarkard.Close();
            }
            if (FormNumber == 102)
            {
                frm_D.Close();
            }
        }

        private void lbl_yadavary_Click(object sender, EventArgs e)
        {

            // Reminder form
            CloseOtherForms();
            FormNumber = 7;
            frm_sr = new Frm_ShowRemembers();
            frm_sr.MdiParent = this;
            frm_sr.Show();
        }

        private void lbl_createPishnevis_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 25))
            {
                CloseOtherForms();
                FormNumber = 15;
                frm_sd = new Frm_ShowDraft(this);
                frm_sd.MdiParent = this;
                frm_sd.Show();
            }


        }

        //private void buttonItem1_Click(object sender, EventArgs e)
        //{
        //    Frm_mainTamin frm_mt = new Frm_mainTamin();
        //    this.Hide();
        //    frm_mt.ShowDialog();
        //    this.Show();
        //}

        private void lbl_createLetter_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 22))
            {
                CloseOtherForms();
                FormNumber = 12;
                frm_cLetter = new Frm_CreateLetter();
                frm_cLetter.MdiParent = this;
                frm_cLetter.FormType = 1; // new letter
                frm_cLetter.Show();
            }




        }

        private void lbl_AllRecievedletter_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 14))
            {
                // Form of all incoming letters
                CloseOtherForms();
                FormNumber = 1;
                frm_recieveallletter = new frm_RecieveAllLetters(this);
                frm_recieveallletter.MdiParent = this;
                frm_recieveallletter.Show();
            }
            
        }

        private void lbl_sentLetters_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 10))
            {
                //sent letter form
                CloseOtherForms();
                FormNumber = 8;
                frm_sentLetter = new Frm_SentLetters();
                frm_sentLetter.MdiParent = this;
                frm_sentLetter.Show();
            }

        }

        private void lbl_createYaddasht_Click(object sender, EventArgs e)
        {
            if (checkAccess(PublicVariable.gUserId, 23))
            {
                //create note form
                CloseOtherForms();
                FormNumber = 13;
                frm_cNote = new Frm_craeteNote();
                frm_cNote.MdiParent = this;
                frm_cNote.Show();

            }
        }
        private void lbl_sentYaddasht_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 12))
            {
                // sent note form
                CloseOtherForms();
                FormNumber = 10;
                frm_SSN = new Frm_ShowSentNote();
                frm_SSN.MdiParent = this;
                frm_SSN.Show();
            }

        }

        private void lbl_recieviedYaddasht_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 19))
            {
                // recieved note form
                CloseOtherForms();
                FormNumber = 6;
                frm_showrnote = new Frm_showAllRecieveNote();
                frm_showrnote.MdiParent = this;
                frm_showrnote.Show();
            }

        }

        private void lbl_readLetters_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 15))
            {
                // show all read letters
                CloseOtherForms();
                FormNumber = 2;
                frm_showAllRL = new Frm_showAllReadLetters();
                frm_showAllRL.MdiParent = this;
                frm_showAllRL.Show();
            } 

        }

        private void lbl_UnreadLetters_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 16))
            {
                // show all unread letters
                CloseOtherForms();
                FormNumber = 3;
                frm_showAllNotRL = new Frm_showAllNotReadLetters();
                frm_showAllNotRL.MdiParent = this;
                frm_showAllNotRL.Show();
            }

        }

        private void lbl_foriLetters_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 17))
            {
                // show all urgent letters
                CloseOtherForms();
                FormNumber = 4;
                frm_fori = new Frm_foriLetters();
                frm_fori.MdiParent = this;
                frm_fori.Show();
            }

        }

        private void lbl_mahramanehLetters_Click(object sender, EventArgs e)
        {
            if (checkAccess(PublicVariable.gUserId, 18))
            {
                // show all classified letters
                CloseOtherForms();
                FormNumber = 5;
                frm_mahramane = new Frm_showAllMahramane();
                frm_mahramane.MdiParent = this;
                frm_mahramane.Show();
            }

        }

        private void lbl_newsandInfo_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 26))
            {
                //show news and announcements
                CloseOtherForms();
                FormNumber = 16;
                frm_showallnews = new frm_ShowAllnewsforUser();
                frm_showallnews.MdiParent = this;
                frm_showallnews.Show();
            }

        }

        private void lbl_ShowAllRecieveReferenceLetter_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 21))
            {
                //show income referals
                CloseOtherForms();
                FormNumber = 17;
                frm_reference = new frm_showAllRecievedReferenceLetters();
                frm_reference.MdiParent = this;
                frm_reference.Show();
            }

        }

        private void lbl_erjaLetters_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 13))
            {
                //show snet referals
                CloseOtherForms();
                FormNumber = 11;
                frm_SentReference = new frm_ShowAllSentReferenceLetters();
                frm_SentReference.MdiParent = this;
                frm_SentReference.Show();
            }

        }

        private void lbl_peygiry_Click(object sender, EventArgs e)
        {
            if(checkAccess(PublicVariable.gUserId, 11))
            {
                //show all need to be followed up letters
                CloseOtherForms();
                FormNumber = 9;
                frm_peygiry = new frm_ShowAllPeygiryLetters();
                frm_peygiry.MdiParent = this;
                frm_peygiry.Show();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)   /// s.85
        {
            ///Check if a new letter has arrived
            var query_checkMessage = (from RR in database.Vw_recieveLetters where RR.UserID_girande == PublicVariable.gUserId where RR.Ismessage == 1 select RR).ToList();
            if (query_checkMessage.Count > 0)
            {
                timer1.Stop();
                frm_showNewMessage frm_m = new frm_showNewMessage();
                frm_m.lbl_userName.Text = "Dear user " + PublicVariable.gUserFirstName + " " + PublicVariable.gUserFamilyName + "!!!";
                frm_m.lbl_ShowMessage.Text = "You have " + query_checkMessage.Count.ToString() + " new letters, please read them as soon as possible.";
                lbl_AllRecievedletter.Text = "All incoming letters(" + query_checkMessage.Count.ToString() +")";
                frm_m.WhatType = 1;
                frm_m.ShowDialog();

            }


            //// Check if a new referral has been received
            var query_checkErja = (from RRe in database.Vw_recieveReference where RRe.UserID_Reciever == PublicVariable.gUserId where RRe.IsMessage == 1 select RRe).ToList();
            if (query_checkErja.Count > 0)
            {
                timer1.Stop();
                frm_showNewMessage frm_m = new frm_showNewMessage();
                frm_m.lbl_userName.Text = "Dear user " + PublicVariable.gUserFirstName + " " + PublicVariable.gUserFamilyName + "!!!";
                frm_m.lbl_ShowMessage.Text = "You have " + query_checkErja.Count.ToString() + " new referals, please read them as soon as possible..";
                lbl_ShowAllRecieveReferenceLetter.Text = "Received referral letters (" + query_checkErja.Count.ToString() + ")";
                frm_m.WhatType = 2;
                frm_m.ShowDialog();
            }

            /// News and announcements
            var query_news = (from n in database.news where n.NewsDate == PublicVariable.TodayDate select n).ToList();
            if (query_news.Count > 0)
            {
                lbl_news.Text = query_news.Count + " new news";
                lbl_news.Visible = true;
                lbl_newsandInfo.Text = "News and announcements " + "(" + query_news.Count + ")";
            }

            timer1.Start();

        }

        private void lbl_sabteKarkard_Click(object sender, EventArgs e)
        {
            if (checkAccess(PublicVariable.gUserId, 32))
            {
                //Function registration
                CloseOtherForms();
                FormNumber = 100;
                frm_SK = new frm_sabteKarkard();
                frm_SK.MdiParent = this;
                frm_SK.Show();
            }

        }

        private void lbl_showKarkard_Click(object sender, EventArgs e)
        {
            if (checkAccess(PublicVariable.gUserId, 33))
            {
                //View staff function
                CloseOtherForms();
                FormNumber = 101;
                frm_sKarkard = new frm_showKarkard();
                frm_sKarkard.MdiParent = this;
                frm_sKarkard.UserJobName = lblJob.Text.Trim();
                frm_sKarkard.UserJobID = Convert.ToInt32(lbl_jobId.Text.Trim());
                frm_sKarkard.Show();
            }
        }

        private void lbl_changePass_Click(object sender, EventArgs e)
        {
            Frm_changePasswordByUser frm_cp = new Frm_changePasswordByUser();
            frm_cp.ShowDialog();
        }

        private void lbl_poshtibani_Click(object sender, EventArgs e)
        {
            Frm_createSupport frm_support = new Frm_createSupport();
            frm_support.ShowDialog();
        }

        private void lbl_document_Click(object sender, EventArgs e)
        {
            if (checkAccess(PublicVariable.gUserId, 34))
            {
                //Registration of documents outside the organization
                CloseOtherForms();
                FormNumber = 102;
                frm_D = new Frm_documents();
                frm_D.MdiParent = this;
                frm_D.Show();
            }
        }
    }
}
