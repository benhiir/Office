using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelLayer.Models;
using System.IO;
using Automation.modula;

namespace Automation.Admin_panel
{
    public partial class frm_add_edit_user : Form
    {
        string userImageName;
        string UserSignatureName;
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);


        public byte formtype;

        public int userID { get; set; }
        public string UserFirstName { get; set; }
        public string UserFamilyName { get; set; }
        public string UserUserName { get; set; }
        public string Userpassword { get; set; }
        public string UserEmail { get; set; }
        public string UserTel { get; set; }
        public string UserPersonalCode { get; set; }
        public string UserBirthDayDate { get; set; }
        public byte Usergender { get; set; }


        public frm_add_edit_user()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picbox_userImage_Click(object sender, EventArgs e)
        {
            openFileDlg.Filter = "Image(*.jpg;*.bmp;*.jpeg;*.png) |*.jpg;*.bmp;*.jpeg;*.png";
            if (openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                userImageName = openFileDlg.FileName;
                picbox_userImage.Image = new Bitmap(userImageName);
            }
        }

        private void picbox_signature_Click(object sender, EventArgs e)
        {
            openFileDlg.Filter = "Image(*.jpg;*.bmp;*.jpeg;) |*.jpg;*.bmp;*.jpeg;";
            if (openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UserSignatureName = openFileDlg.FileName;
                picbox_signature.Image = new Bitmap(UserSignatureName);
            }
        }

        private void btn_sabt_Click(object sender, EventArgs e)
        {


            if (this.formtype == 1) ///add user
            {
                if (!CheckNotNull())
                {
                    return;
                }
                try
                {
                    //// check not duplicate user
                    var checkRepeateUsername_query = (from U in database.Users where U.Username == txt_username.Text.Trim() where U.Activity == 1 select U).ToList();
                    if (checkRepeateUsername_query.Count == 1)
                    {
                        MessageBox.Show("The username entered is already selected");
                        return;

                    }


                    /////////////hashing password
                    SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
                    Byte[] B1;
                    Byte[] B2;
                    B1 = UTF8Encoding.UTF8.GetBytes(txt_password.Text.Trim());
                    B2 = SHA256.ComputeHash(B1);
                    string HashedPassword = BitConverter.ToString(B2);

                    //////////// Create Image Array
                    FileStream fs_userImage = new FileStream(userImageName, FileMode.Open, FileAccess.Read);
                    byte[] imageByteArray = new byte[fs_userImage.Length];
                    fs_userImage.Read(imageByteArray, 0, Convert.ToInt32(fs_userImage.Length));
                    fs_userImage.Close();

                    //////////// Create Signature Image
                    FileStream fs_UserSignature = new FileStream(UserSignatureName, FileMode.Open, FileAccess.Read);
                    byte[] imageByteArray_Signature = new byte[fs_UserSignature.Length];
                    fs_UserSignature.Read(imageByteArray_Signature, 0, Convert.ToInt32(fs_UserSignature.Length));
                    fs_UserSignature.Close();

                    ///// check Gender
                    byte checkGender = 0;
                    if (rdb_man.Checked)
                    {
                        checkGender = 1;
                    }
                    else
                    {
                        checkGender = 2;
                    }
                    /////// Get Birthday Date
                    string Birthday = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDate_birthDay.Value.Year + "/" + persianDate_birthDay.Value.Month + "/" + persianDate_birthDay.Value.Day));

                    database.Sp_insert_Users(txt_name.Text, txt_family.Text, txt_username.Text, HashedPassword, txt_personalCode.Text, txt_email.Text, checkGender, 1, txt_tel.Text, Birthday.Trim(), imageByteArray
                        , lbl_date.Text, imageByteArray_Signature);
                    database.SaveChanges();
                    MessageBox.Show("New user created successfully");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Errors in recording information. Please try again.");
                }
            }
            else if (this.formtype == 2)  //// update user (s.20)
            {
                if (!CheckNotNull_forUpdateUser())
                {
                    return;
                }
                try
                {
                    byte[] imageByteArray = null;
                    if (userImageName != null)
                    {
                        //////////// Create User Image Array
                        FileStream fs_userImage = new FileStream(userImageName, FileMode.Open, FileAccess.Read);
                        imageByteArray = new byte[fs_userImage.Length];
                        fs_userImage.Read(imageByteArray, 0, Convert.ToInt32(fs_userImage.Length));
                        fs_userImage.Close();
                    }


                    ///// check Gender
                    byte checkGender = 0;
                    if (rdb_man.Checked)
                    {
                        checkGender = 1;
                    }
                    else
                    {
                        checkGender = 2;
                    }

                    /////// User Birthday Date
                    string Birthday = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDate_birthDay.Value.Year + "/" + persianDate_birthDay.Value.Month + "/" + persianDate_birthDay.Value.Day));

                    if (userImageName != "")
                    {
                        database.Sp_Update_Users(this.userID, txt_name.Text.Trim(), txt_family.Text.Trim(), txt_personalCode.Text.Trim(), txt_email.Text.Trim(), checkGender, txt_tel.Text.Trim(), Birthday, imageByteArray);
                    }
                    else if (userImageName == "")
                    {
                        database.Sp_Update_Users_noImage(this.userID, txt_name.Text.Trim(), txt_family.Text.Trim(), txt_personalCode.Text.Trim(), txt_email.Text.Trim(), checkGender, txt_tel.Text.Trim(), Birthday);
                    }

                    database.SaveChanges();
                    MessageBox.Show("User information successfully edited");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("There was a problem registering user information. Please try again");
                    return;
                }


            }
        }

        private bool CheckNotNull()
        {
            if (txt_name.Text == "")
            {
                MessageBox.Show("Enter the first name");
                txt_name.Focus();
                return false;
            }
            if (txt_family.Text == "")
            {
                MessageBox.Show("Enter the last name");
                txt_family.Focus();
                return false;
            }
            if (txt_username.Text == "")
            {
                MessageBox.Show("Enter the username");
                txt_username.Focus();
                return false;
            }
            if (txt_password.Text == "")
            {
                MessageBox.Show("Enter your password");
                txt_password.Focus();
                return false;
            }
            if (txt_tel.Text == "")
            {
                MessageBox.Show("Enter the phone");
                txt_tel.Focus();
                return false;
            }
            if (txt_personalCode.Text == "")
            {
                MessageBox.Show("Enter the personnel code");
                txt_personalCode.Focus();
                return false;
            }
            if (userImageName == "" | UserSignatureName == "")
            {
                MessageBox.Show("No user image or signature selected");
                return false;
            }

            return true;
        }

        private bool CheckNotNull_forUpdateUser()
        {
            if (txt_name.Text == "")
            {
                MessageBox.Show("Enter the first name");
                txt_name.Focus();
                return false;
            }
            if (txt_family.Text == "")
            {
                MessageBox.Show("Enter the last name");
                txt_family.Focus();
                return false;
            }

            if (txt_tel.Text == "")
            {
                MessageBox.Show("Enter the phone");
                txt_tel.Focus();
                return false;
            }
            if (txt_personalCode.Text == "")
            {
                MessageBox.Show("Enter the personnel code");
                txt_personalCode.Focus();
                return false;
            }

            return true;
        }

        private void frm_add_edit_user_Load(object sender, EventArgs e)
        {
            lbl_date.Text = PublicVariable.TodayDate;

            if (formtype == 2)
            {
                txt_name.Text = this.UserFirstName;
                txt_family.Text = this.UserFamilyName;
                txt_email.Text = this.UserEmail;
                txt_password.Text = this.Userpassword;
                txt_password.Enabled = false;
                txt_personalCode.Text = this.UserPersonalCode;
                txt_tel.Text = this.UserTel;
                txt_username.Text = this.UserUserName;
                txt_username.Enabled = false;
                ///birthday date
                persianDate_birthDay.Value = Convert.ToDateTime(this.UserBirthDayDate);
                if (this.Usergender == 1)
                {
                    rdb_man.Checked = true;
                }
                else
                {
                    rdb_woman.Checked = true;
                }

                //// get image and signature
                var query = (from U in database.Users where U.userID == this.userID select U).ToList();

                if (query.Count == 1)
                {
                    if (query[0].UserImage != null)
                    {
                        var dataUserImage = (Byte[])(query[0].UserImage);
                        var stream_UserImage = new MemoryStream(dataUserImage);
                        picbox_userImage.Image = Image.FromStream(stream_UserImage);
                    }
                    if (query[0].Signatures != null)
                    {
                        var dataUserSignature = (Byte[])(query[0].Signatures);
                        var stream_UserSignature = new MemoryStream(dataUserSignature);
                        picbox_signature.Image = Image.FromStream(stream_UserSignature);
                    }

                }


            }
        }
    }
}

