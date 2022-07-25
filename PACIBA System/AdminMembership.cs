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
    public partial class AdminMembership : Form
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
                            list.SubItems.Add(dr["EntranceFee"].ToString());
                            list.SubItems.Add(dr["JerseyFee"].ToString());
                            list.SubItems.Add(dr["JerseyNumber"].ToString());
                            list.SubItems.Add(dr["Status"].ToString());

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
                            list.SubItems.Add(dr["EntranceFee"].ToString());
                            list.SubItems.Add(dr["JerseyFee"].ToString());
                            list.SubItems.Add(dr["JerseyNumber"].ToString());
                            list.SubItems.Add(dr["Status"].ToString());

                        }
                    }
                }
            }
        }


        public AdminMembership()
        {
            InitializeComponent();
        }

        private void AdminMembership_Load(object sender, EventArgs e)
        {
            Fetch_data();
        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gunaLineTextBox4.Text = this.listView1.FocusedItem.SubItems[0].Text;
            gunaLineTextBox3.Text = this.listView1.FocusedItem.SubItems[3].Text;
            gunaLineTextBox2.Text = this.listView1.FocusedItem.SubItems[4].Text;
            gunaComboBox1.Text = this.listView1.FocusedItem.SubItems[6].Text;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this membership?", "PACIBA System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("UPDATE `Members` SET `EntranceFee` = '" + gunaLineTextBox3.Text + "', `JerseyFee` = '" + gunaLineTextBox2.Text + "', `Status` = '" + gunaComboBox1.Text + "' WHERE `ID` = '" + gunaLineTextBox4.Text + "'", c))
                    {

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Done!", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gunaLineTextBox2.Clear();
                        this.gunaLineTextBox3.Clear();
                        this.gunaLineTextBox4.Clear();
                    }
                }
                Fetch_data();
            }
        }
    }
}
