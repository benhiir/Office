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
using System.IO;
using Stimulsoft.Report;
using Automation.modula;
namespace Automation.Admin_panel
{
    public partial class frm_showUserInfo : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public int Get_UserId { get; set; }
        public frm_showUserInfo()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_showUserInfo_Load(object sender, EventArgs e)     /// s.25
        {
            try
            {
                //var query = (from U in database.Vw_Users where U.userID == this.Get_UserId select U).ToList(); s.33 
                // s.33
                var query = (database.SP_Show_AllUserInfo(this.Get_UserId).ToList());

                if (query.Count == 1)
                {
                    lbl_FistName.Text = query[0].UserFirstName;
                    lbl_Family.Text = query[0].UserFamily;
                    lbl_tel.Text = query[0].UserTel;
                    lbl_PersonalCode.Text = query[0].PersonalCode;
                    lbl_BirthDayDate.Text = query[0].BirthDayDate;
                    lbl_Activity.Text = query[0].farsiActivity;
                    lbl_Email.Text = query[0].Email;
                    lbl_gender.Text = query[0].farsiGender;
                    lbl_UserName.Text = query[0].Username;
                    lbl_job.Text = query[0].jobsName;
                   
                    var dataUserImage = (Byte[])(query[0].UserImage);
                    var stream_UserImage = new MemoryStream(dataUserImage);
                    pictureBox_userImage.Image = Image.FromStream(stream_UserImage);

                    var dataUserSignature = (Byte[])(query[0].Signatures);
                    var stream_UserSignature = new MemoryStream(dataUserSignature);
                    pictureBox_signature.Image = Image.FromStream(stream_UserSignature);
                }  
             }
                catch
                  {
                MessageBox.Show("There was a problem communicating with the server. Please try again.");
                  }
            
       }

        private void btn_print_Click(object sender, EventArgs e)
        {
            /// Print the information
            StiReport report = new StiReport();
            report.Load(System.AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\UserPersonally.mrt");
            report.Dictionary.Variables["reportDate"].Value = PublicVariable.TodayDate;
            report["UserID"] = this.Get_UserId;
            report.Compile();
            report.Render();
            report.Show();
        }
    }
}
