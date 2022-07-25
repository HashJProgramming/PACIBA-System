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
    public partial class MemberEvents : Form
    {
        string ConnectionString = "Data Source=" + Application.StartupPath + "\\Database.db3;Version=3;";
        string sql = "SELECT * FROM `Events` ";
        ListViewItem list;
        public MemberEvents()
        {
            InitializeComponent();
        }

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
                            list.SubItems.Add(dr["EventName"].ToString());
                            list.SubItems.Add(dr["EventDescription"].ToString());
                            list.SubItems.Add(dr["EventDate"].ToString());
                            list.SubItems.Add(dr["Venue"].ToString());

                        }
                    }
                }
            }
        }

        private void search()
        {
            this.listView1.Items.Clear();
            using (SQLiteConnection c = new SQLiteConnection(ConnectionString))

            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM `Events` WHERE `EventName` LIKE '%" +this.gunaLineTextBox1.Text+ "%'", c))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list = this.listView1.Items.Add(dr["ID"].ToString());
                            list.SubItems.Add(dr["EventName"].ToString());
                            list.SubItems.Add(dr["EventDescription"].ToString());
                            list.SubItems.Add(dr["EventDate"].ToString());
                            list.SubItems.Add(dr["Venue"].ToString());

                        }
                    }
                }
            }
        }
        
        private void MemberEvents_Load(object sender, EventArgs e)
        {
            Fetch_data();
        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}
