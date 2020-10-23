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


namespace Automation.Users_panel
{
    public partial class frm_gardesheName : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public int GetLetterID { get; set; }
        public frm_gardesheName()
        {
            InitializeComponent();
        }

        private void frm_gardesheName_Load(object sender, EventArgs e)
        {
            showgardesh();
        }

        private void showgardesh()
        {
            try
            {
                var query_gardesh = (from RR in database.Vw_recieveReference where RR.LetterId == this.GetLetterID orderby RR.LevelNo select RR).ToList();
                if (query_gardesh.Count > 0)
                {
                    for (int i = 0; i <= query_gardesh.Count - 1; i++)
                    {
                        lbl_gardesh.Text +=(i+1) + "-"+ "Your letter was referred to " + query_gardesh[i].Fullname_reciever + " by " + query_gardesh[i].fullname_sender + " on " + query_gardesh[i].ReferenceDate + " Initial letter: " + query_gardesh[i].Description + "\r\n";

                    }
                }
            }
            catch
            {
                MessageBox.Show("دThere is something wrong with the server. Please try again.");
                return;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
