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
using System.Security.Cryptography;

namespace Automation.Users_panel
{
    public partial class Frm_changePasswordByUser : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public Frm_changePasswordByUser()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sabt_Click(object sender, EventArgs e)
        {
            if (txt_oldPassword.Text.Trim() == "" || txt_newPassword.Text.Trim() == "" || txt_newPasswordAgain.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the required values");
                return;
            }

            try
            {
                ///Check that the previous password is correct
                /////////////hashing password
                SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
                Byte[] B1;
                Byte[] B2;
                B1 = UTF8Encoding.UTF8.GetBytes(txt_oldPassword.Text.Trim());
                B2 = SHA256.ComputeHash(B1);
                string HashedPassword = BitConverter.ToString(B2);

                var query_oldPass = (from U in database.Users where U.userID == PublicVariable.gUserId where U.Password == HashedPassword select U).ToList();

                if (query_oldPass.Count == 0)
                {
                    MessageBox.Show("The old password is incorrect.");
                    return;
                }
                if (txt_newPassword.Text.Trim() == txt_newPasswordAgain.Text.Trim())
                {
                    /////////////hashing password
                    SHA256CryptoServiceProvider SHA256_newPass = new SHA256CryptoServiceProvider();
                    Byte[] B1_newPass;
                    Byte[] B2_newPass;
                    B1_newPass = UTF8Encoding.UTF8.GetBytes(txt_newPassword.Text.Trim());
                    B2_newPass = SHA256.ComputeHash(B1_newPass);
                    string HashedPassword_newPass = BitConverter.ToString(B2_newPass);

                    var query_updatePassword = (from U in database.Users where U.userID == PublicVariable.gUserId select U).SingleOrDefault();
                    query_updatePassword.Password = HashedPassword_newPass;
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
            catch
            {
                MessageBox.Show("There was a problem communicating with the server.");
            }


        }
    }
}
