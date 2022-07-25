using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Use the following namespace to access the database
using System.Data.SQLite;

namespace PACIBA_System
{
    public partial class AdminStatistic : Form
    {
        string ConnectionString = "Data Source=" + Application.StartupPath + "\\Database.db3;Version=3;";
        
        private void get_data()
        {
             using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(`ID`) FROM `Members`", c))
                {
                    label1.Text = cmd.ExecuteScalar().ToString();
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(`ID`) FROM `Members` WHERE `STATUS` LIKE 'NOT PAID'", c))
                {
                    label6.Text = cmd.ExecuteScalar().ToString();
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(`ID`) FROM `Members` WHERE `STATUS` LIKE 'FULLY PAID'", c))
                {
                    label4.Text = cmd.ExecuteScalar().ToString();
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(`ID`) FROM `Members` WHERE `STATUS` LIKE 'NOT FULLY PAID'", c))
                {
                    label8.Text = cmd.ExecuteScalar().ToString();
                }

            }
        }

        public AdminStatistic()
        {
            InitializeComponent();
        }

        private void AdminStatistic_Load(object sender, EventArgs e)
        {
            get_data();
        }
    }
}
