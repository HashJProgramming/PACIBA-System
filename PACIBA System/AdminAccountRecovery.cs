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
    public partial class AdminAccountRecovery : Form
    {
        string ConnectionString = "Data Source=" + Application.StartupPath + "\\Database.db3;Version=3;";
        string sql = "SELECT * FROM `Members`";
        ListViewItem list;
        private void Fetch_data()
        {
            this.listView1.Items.Clear();
            using (SQLiteConnection c = new SQLiteConnection(ConnectionString))

            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list = this.listView1.Items.Add(dr["ID"].ToString());
                            list.SubItems.Add(dr["Fullname"].ToString());
                            list.SubItems.Add(dr["ContactNumber"].ToString());
                            list.SubItems.Add(dr["Username"].ToString());
                            list.SubItems.Add(dr["Password"].ToString());

                        }
                    }
                }
            }
        }

        private void Search()
        {
            this.listView1.Items.Clear();
            using (SQLiteConnection c = new SQLiteConnection(ConnectionString))

            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM `Members` WHERE `Fullname` LIKE '%" + this.gunaLineTextBox1.Text + "%'", c))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list = this.listView1.Items.Add(dr["ID"].ToString());
                            list.SubItems.Add(dr["Fullname"].ToString());
                            list.SubItems.Add(dr["ContactNumber"].ToString());
                            list.SubItems.Add(dr["Username"].ToString());
                            list.SubItems.Add(dr["Password"].ToString());

                        }
                    }
                }
            }
        }
        
        public AdminAccountRecovery()
        {
            InitializeComponent();
        }

        private void AdminAccountRecovery_Load(object sender, EventArgs e)
        {
            Fetch_data();
        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this user password?", "PACIBA System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.gunaLineTextBox3.Text == this.gunaLineTextBox2.Text)
                {
                    using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
                    {
                        c.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand("UPDATE `Members` SET `Password` = '" + gunaLineTextBox2.Text + "' WHERE `ID` = '" + gunaLineTextBox4.Text + "'", c))
                        {

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Done!", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.gunaLineTextBox2.Clear();
                            this.gunaLineTextBox3.Clear();

                        }
                    }
                    Fetch_data();
                }
                else
                {
                    MessageBox.Show("Password is not match!", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gunaLineTextBox4.Text = this.listView1.FocusedItem.SubItems[0].Text;
        }
    }
}
