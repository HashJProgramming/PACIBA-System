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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Loginfrm frm = new Loginfrm();
            this.Hide();
            this.gunaTransition1.ShowSync(frm);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            // Account Recovery
            this.gunaGradient2Panel2.Controls.Clear();
            AdminAccountRecovery frm = new AdminAccountRecovery() { TopLevel = false, TopMost = true };
            this.gunaGradient2Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            // Membership fees
            this.gunaGradient2Panel2.Controls.Clear();
            AdminMembership frm = new AdminMembership() { TopLevel = false, TopMost = true };
            this.gunaGradient2Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            // Members List
            this.gunaGradient2Panel2.Controls.Clear();
            AdminMembersList frm = new AdminMembersList() { TopLevel = false, TopMost = true };
            this.gunaGradient2Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            // Events
            this.gunaGradient2Panel2.Controls.Clear();
            AdminEvents frm = new AdminEvents() { TopLevel = false, TopMost = true };
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

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            // Dashboard - Admin Statistic
            this.gunaGradient2Panel2.Controls.Clear();
            AdminStatistic frm = new AdminStatistic() { TopLevel = false, TopMost = true };
            this.gunaGradient2Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Dashboard 
            this.gunaGradient2Panel2.Controls.Clear();
            AdminStatistic frm = new AdminStatistic() { TopLevel = false, TopMost = true };
            this.gunaGradient2Panel2.Controls.Add(frm);
            frm.Show();
        }
    }
}
