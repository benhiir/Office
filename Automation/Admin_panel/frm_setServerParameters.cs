using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.Modula;

namespace Automation.Admin_panel
{
    public partial class frm_setServerParameters : Form
    {
        public frm_setServerParameters()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string BuildEntityConnection(string EntityConnection_dynamic)
        {
            /// Build a connection that can be used dynamically by the entity.
            var entityConnection = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = EntityConnection_dynamic,
                Metadata = "res://*"
            };
            return (entityConnection.ToString());

        }


        private void btn_enter_Click(object sender, EventArgs e)
        {
            /// Set up the client computer connection to the server

            if (txt_DBName.Text == "" || txt_DBPassword.Text == "" || txt_serverIP.Text == "")
            {
                MessageBox.Show("Please enter all requests.");
                return;
            }

            var EntityConnectionString = BuildEntityConnection("Data Source=" + txt_serverIP.Text.Trim() + ";Initial Catalog=" + txt_DBName.Text.Trim()
                + ";user Id=sa;Password=" + txt_DBPassword.Text.Trim() + ";Integrated Security=false");  /// The last phrase means do not enter without a password, be sure to get a password.
            try
            {
                RegistryKey connctionKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\AutomationConnection");
                try
                {
                    connctionKey.SetValue("ConnectionForAutomation", CryptionAlgorithm.EncryptTextUsingUTF8(EntityConnectionString));
                }
                catch
                {
                    MessageBox.Show("There is a problem with the server.");
                }
                finally
                {
                    connctionKey.Close();
                }

                MessageBox.Show("The connection to the server was established successfully. Please log out and log back in.");
                this.Close();
            }
            catch
            {
                MessageBox.Show("There is a problem with the server.");
            }
        }
    }
}
