using DemoWF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWF
{
    public partial class FrmAddMember : Form
    {
        private static Member member;

        public Member _memer
        {
            get { return member; }
        }

        public FrmAddMember()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtFirstName.Text.Trim()) && !string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                member = new Member() { UserName = txtUserName.Text.Trim(), FirstName = txtFirstName.Text.Trim(), LastName = txtLastName.Text.Trim() };
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
