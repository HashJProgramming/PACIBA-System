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
    public partial class AdminMembersList : Form
    {

        string ConnectionString = "Data Source=" + Application.StartupPath + "\\Database.db3;Version=3;";
        string sql = "SELECT * FROM `Members` ";
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
                            list.SubItems.Add(dr["Username"].ToString());
                            list.SubItems.Add(dr["Fullname"].ToString());
                            list.SubItems.Add(dr["Address"].ToString());
                            list.SubItems.Add(dr["Job"].ToString());
                            list.SubItems.Add(dr["ContactNumber"].ToString());
                            list.SubItems.Add(dr["JerseyNumber"].ToString());
                            list.SubItems.Add(dr["Team"].ToString());
                            list.SubItems.Add(dr["CreatedDate"].ToString());

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
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM `Members` WHERE `Fullname` LIKE = '%" + this.gunaLineTextBox1.Text + "%'", c))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list = this.listView1.Items.Add(dr["ID"].ToString());
                            list.SubItems.Add(dr["Username"].ToString());
                            list.SubItems.Add(dr["Fullname"].ToString());
                            list.SubItems.Add(dr["Address"].ToString());
                            list.SubItems.Add(dr["Job"].ToString());
                            list.SubItems.Add(dr["ContactNumber"].ToString());
                            list.SubItems.Add(dr["JerseyNumber"].ToString());
                            list.SubItems.Add(dr["Team"].ToString());
                            list.SubItems.Add(dr["CreatedDate"].ToString());

                        }
                    }
                }
            }

        }

        public AdminMembersList()
        {
            InitializeComponent();
        }

        private void AdminMembersList_Load(object sender, EventArgs e)
        {
            Fetch_data();
        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
