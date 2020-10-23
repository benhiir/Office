using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Automation.modula;
using Automation.Admin_panel;
using DataModelLayer.Models;
using System.Security.Cryptography;
using Microsoft.Win32;
using Automation.Modula;

namespace Automation
{
    public partial class frm_Login : Form
    {
        
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

            //Read the connection string from the registry S118
            string registryConnectionString = "";
            RegistryKey ConnectionString = Registry.CurrentUser.CreateSubKey("SOFTWARE\\AutomationConnection");
            registryConnectionString = ConnectionString.GetValue("ConnectionForAutomation").ToString();

            try
            {
                if (registryConnectionString == "")
                {
                    MessageBox.Show("The connection to the server is not established, please check the connection parameters with the server.");
                    frm_setServerParameters frm_ssparam = new frm_setServerParameters();
                    frm_ssparam.ShowDialog();

                    btn_enter.Enabled = false;
                }
                else
                {
                    PublicVariable.MainConnectionString = CryptionAlgorithm.DecryptTextUsingUTF8(registryConnectionString);
                }
            }
            catch
            {
                btn_enter.Enabled = false;
                MessageBox.Show("No connection to the server");
            }

            
            
            
            // show date
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            PublicVariable.TodayDate = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime((pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now))));
            lbl_date.Text = PublicVariable.TodayDate;

            // show ip
            string computerName = System.Environment.MachineName;
            string IP = "";
            IPHostEntry ipe = Dns.GetHostByName(computerName);
            IPAddress[] IpAddress = ipe.AddressList;
            lbl_IP.Text = IpAddress[0].ToString();

            //show time
            timer1_Tick(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            lbl_time.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            lbl_time.Refresh();

        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
            try
            {
                if (txt_username.Text.Trim() !="" && txt_password.Text.Trim()!="")
                {
                    /////////////hashing password
                    SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
                    Byte[] B1;
                    Byte[] B2;
                    B1 = UTF8Encoding.UTF8.GetBytes(txt_password.Text.Trim());
                    B2 = SHA256.ComputeHash(B1);
                    string HashedPassword = BitConverter.ToString(B2);


                    var login_query = (from U in database.Users
                                       where U.Username == txt_username.Text.Trim()
                                       where U.Password == HashedPassword
                                       where U.Activity == 1
                                       select U).ToList();
                    if (login_query.Count == 1)
                    {
                        /// Obtain user profile for use throughout the app 
                        PublicVariable.gUserFirstName = login_query[0].UserFirstName;
                        PublicVariable.gUserFamilyName = login_query[0].UserFamily;
                        PublicVariable.gUserId = login_query[0].userID;

                        /////Register user profile in log file to control entry and exit s.22
                        string computerName = System.Environment.MachineName;

                        UserLog UL = new UserLog();
                        UL.ComputerName = computerName;
                        UL.IpAddress = lbl_IP.Text.Trim();
                        UL.EnterDateTime = lbl_date.Text.Trim() + "-" + string.Format("{0:HH:mm:ss}", Convert.ToDateTime(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second));
                        UL.UserId = PublicVariable.gUserId;

                        database.UserLogs.Add(UL);
                        database.SaveChanges();

                    }
                    else
                    {
                        MessageBox.Show("The user was not found");
                        return;
                    }
                    if (rdb_admin.Checked)
                    {
                        if (txt_username.Text.Trim() == "admin")
                        {
                            PublicVariable.gSetUser = 1; ////admin
                        }
                        else
                        {
                            MessageBox.Show("The user does not have administrator access");
                            return;
                        }
                    }
                    else
                    {
                        PublicVariable.gSetUser = 2; ///users
                    }

                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("There is a problem with the server, please try again");
            }
        }

        private void lbl_setServerParameter_Click(object sender, EventArgs e)
        {
            frm_setServerParameters frm_ssparam = new frm_setServerParameters();
            frm_ssparam.ShowDialog();
        }
    }
}
