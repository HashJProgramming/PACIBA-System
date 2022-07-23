using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACIBA_System
{
    public partial class MemberDashboardfrm : Form
    {
        public MemberDashboardfrm()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            // Profile
            this.gunaGradient2Panel2.Controls.Clear();
            MemberProfilefrmcs frm = new MemberProfilefrmcs() { TopLevel = false, TopMost = true };
            this.gunaGradient2Panel2.Controls.Add(frm);
            frm.Show();
        }
        
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            // Membership
            this.gunaGradient2Panel2.Controls.Clear();
            Membership frm = new Membership() { TopLevel = false, TopMost = true };
            this.gunaGradient2Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            // Events
            this.gunaGradient2Panel2.Controls.Clear();
            MemberEvents frm = new MemberEvents() { TopLevel = false, TopMost = true };
            this.gunaGradient2Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            // Logout
            Loginfrm frm = new Loginfrm();
            this.Hide();
            this.gunaTransition1.ShowSync(frm);
            
        }

        private void MemberDashboardfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Loginfrm frm = new Loginfrm();
                this.Hide();
                this.gunaTransition1.ShowSync(frm);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MemberDashboardfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
           

        }
    }
}
