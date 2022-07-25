using System;
// Use the following namespace to access the database
using System.Data.SQLite;
using System.Windows.Forms;

namespace PACIBA_System
{
    public partial class AdminEvents : Form
    {
        string ConnectionString = "Data Source=" + Application.StartupPath + "\\Database.db3;Version=3;";
        string sql = "SELECT * FROM `Events` ";
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
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM `Events` WHERE `EventName` LIKE '%" + this.gunaLineTextBox1.Text + "%'", c))
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

        public AdminEvents()
        {
            InitializeComponent();
        }

        private void AdminEvents_Load(object sender, EventArgs e)
        {
            Fetch_data();
        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            // Add Event
            if (MessageBox.Show("Are you sure you want to add this event?", "PACIBA System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO `Events` (`EventName`, `EventDescription`, `EventDate`, `Venue`) VALUES (@EventName, @EventDescription, @EventDate, @Venue)", c))
                    {
                        cmd.Parameters.AddWithValue("@EventName", this.gunaLineTextBox2.Text);
                        cmd.Parameters.AddWithValue("@EventDescription", this.gunaLineTextBox3.Text);
                        cmd.Parameters.AddWithValue("@EventDate", this.gunaLineTextBox4.Text);
                        cmd.Parameters.AddWithValue("@Venue", this.gunaLineTextBox5.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Done!", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gunaLineTextBox2.Clear();
                        this.gunaLineTextBox3.Clear();
                        this.gunaLineTextBox4.Clear();
                        this.gunaLineTextBox5.Clear();

                    }
                }
                Fetch_data();
            }


        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            // Update Event
            if (MessageBox.Show("Are you sure you want to update this event?", "PACIBA System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("UPDATE `Events` SET `EventName` = '" + gunaLineTextBox2.Text + "', `EventDescription` = '" + gunaLineTextBox3.Text + "', `EventDate` = '" + gunaLineTextBox4.Text + "', `Venue` = '" + gunaLineTextBox5.Text + "' WHERE `ID` = '" + gunaLineTextBox6.Text + "'", c))
                    {

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Done!", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gunaLineTextBox2.Clear();
                        this.gunaLineTextBox3.Clear();
                        this.gunaLineTextBox4.Clear();
                        this.gunaLineTextBox5.Clear();

                    }
                }
                Fetch_data();
            }

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            // Remove Event
            if (MessageBox.Show("Are you sure you want to remove this event?", "PACIBA System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM `Events` WHERE `ID` = " + this.gunaLineTextBox6.Text, c))
                    {

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Done!", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                Fetch_data();
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gunaLineTextBox6.Text = this.listView1.FocusedItem.SubItems[0].Text;
            gunaLineTextBox2.Text = this.listView1.FocusedItem.SubItems[1].Text;
            gunaLineTextBox3.Text = this.listView1.FocusedItem.SubItems[2].Text;
            gunaLineTextBox4.Text = this.listView1.FocusedItem.SubItems[3].Text;
            gunaLineTextBox5.Text = this.listView1.FocusedItem.SubItems[4].Text;
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            this.gunaLineTextBox6.Clear();
            this.gunaLineTextBox2.Clear();
            this.gunaLineTextBox3.Clear();
            this.gunaLineTextBox4.Clear();
            this.gunaLineTextBox5.Clear();
        }
    }
}
