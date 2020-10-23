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
    public partial class frm_showNewMessage : Form
    {
        public byte WhatType { get; set; }
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_showNewMessage()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {

            if (WhatType == 1)   /// Letter
            {
                database.SP_UpdateMessage(PublicVariable.gUserId);
            }
            else if (WhatType == 2)/// Reference
            {
                database.Sp_updateErjaMessage(PublicVariable.gUserId);
            }

            database.SaveChanges();
            this.Close();
        }
    }
}
