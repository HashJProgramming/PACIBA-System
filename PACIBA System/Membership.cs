using System;
// Use the following namespace to access the database
using System.Data.SQLite;
using System.Windows.Forms;

namespace PACIBA_System
{
    public partial class Membership : Form
    {
        string ConnectionString = "Data Source=" + Application.StartupPath + "\\Database.db3;Version=3;";

        public Membership()
        {
            InitializeComponent();
        }

        private void fetch_data()
        {
            string sql = "SELECT * FROM `Members` WHERE `Username` = '" + this.gunaLineTextBox1.Text + "'";
            int jerseyFee = 0, entranceFee = 0;
            using (SQLiteConnection c = new SQLiteConnection(ConnectionString))

            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            // Fullname
                            if (rdr["Fullname"].ToString() == "")
                            {
                                gunaLineTextBox3.Text = "Fullname";
                            }
                            else
                            {
                                gunaLineTextBox3.Text = rdr["Fullname"].ToString();
                            }

                            // Jersey No.
                            if (rdr["JerseyNumber"].ToString() == "")
                            {
                                gunaLineTextBox2.Text = "Jersey No.";
                            }
                            else
                            {
                                gunaLineTextBox2.Text = rdr["JerseyNumber"].ToString();
                            }
                            // Team
                            if (rdr["Team"].ToString() == "")
                            {
                                gunaLineTextBox4.Text = "Team";
                            }
                            else
                            {
                                gunaLineTextBox4.Text = rdr["Team"].ToString();
                            }
                            // JerseyFee
                            if (rdr["JerseyFee"].ToString() == "")
                            {
                                gunaLineTextBox5.Text = "0";

                            }
                            else
                            {
                                gunaLineTextBox5.Text = rdr["JerseyFee"].ToString();
                                jerseyFee = Convert.ToInt32(rdr["JerseyFee"].ToString());
                            }
                            // EntranceFee
                            if (rdr["EntranceFee"].ToString() == "")
                            {
                                gunaLineTextBox6.Text = "0";
                            }
                            else
                            {
                                gunaLineTextBox6.Text = rdr["EntranceFee"].ToString();
                                jerseyFee = Convert.ToInt32(rdr["EntranceFee"].ToString());
                            }
                            // Status
                            if (rdr["Status"].ToString() == "")
                            {
                                label3.Text = "UNKOWN";
                            }
                            else
                            {
                                label3.Text = rdr["Status"].ToString();
                            }

                           
                        }
                    }
                }
                gunaLineTextBox7.Text = "TOTAL : " + (jerseyFee + entranceFee).ToString();


            }
        }
        private void Membership_Load(object sender, EventArgs e)
        {
            this.gunaLineTextBox1.Text = PACIBA_System.Properties.Settings.Default.Username;
            fetch_data();
        }

        private void gunaLineTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
