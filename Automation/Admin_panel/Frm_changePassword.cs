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
using System.Security.Cryptography;
using Automation.modula;

namespace Automation.Admin_panel
{
    public partial class Frm_changePassword : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public int getUserId { get; set; }

        public Frm_changePassword()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sabt_Click(object sender, EventArgs e)
        {
            ////Control of empty values
            if (txt_newPassword.Text.Trim() == "" || txt_newPasswordAgain.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the requested values");
                return;
            }
            ///Check that the password is the same and repeat
            if (txt_newPassword.Text.Trim() == txt_newPasswordAgain.Text.Trim())
            {
                /////////////hashing password
                SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
                Byte[] B1;
                Byte[] B2;
                B1 = UTF8Encoding.UTF8.GetBytes(txt_newPassword.Text.Trim());
                B2 = SHA256.ComputeHash(B1);
                string HashedPassword = BitConverter.ToString(B2);


                var query_updatePassword = (from U in database.Users where U.userID == this.getUserId select U).SingleOrDefault();
                query_updatePassword.Password = HashedPassword;
                database.SaveChanges();
                MessageBox.Show("Password changed successfully.");
                this.Close();

            }
            else
            {
                MessageBox.Show("The new password is not the same as repeating it!!");
                return;
            }
        }
    }
}
