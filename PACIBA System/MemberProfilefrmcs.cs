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
    public partial class MemberProfilefrmcs : Form
    {
        string ConnectionString = "Data Source=" + Application.StartupPath + "\\Database.db3;Version=3;";


        public MemberProfilefrmcs()
        {
            InitializeComponent();
        }

        private void fetch_data()
        {
            string sql = "SELECT * FROM `Members` WHERE `Username` = '" + this.gunaLineTextBox1.Text + "'";
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
                            // Address
                            if (rdr["Address"].ToString() == "")
                            {
                                gunaLineTextBox4.Text = "Address";
                            }
                            else
                            {
                                gunaLineTextBox4.Text = rdr["Address"].ToString();
                            }
                            // Contact No.
                            if (rdr["ContactNumber"].ToString() == "")
                            {
                                gunaLineTextBox5.Text = "Contact No.";
                            }
                            else
                            {
                                gunaLineTextBox5.Text = rdr["ContactNumber"].ToString();
                            }
                            // JOB
                            if (rdr["Job"].ToString() == "")
                            {
                                gunaLineTextBox6.Text = "Job";
                            }
                            else
                            {
                                gunaLineTextBox6.Text = rdr["Job"].ToString();
                            }
                            // TEAM
                            if (rdr["Team"].ToString() == "")
                            {
                                gunaLineTextBox7.Text = "Team";
                            }
                            else
                            {
                                gunaLineTextBox7.Text = rdr["Team"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void MemberProfilefrmcs_Load(object sender, EventArgs e)
        {
            try
            {
                this.gunaLineTextBox1.Text = PACIBA_System.Properties.Settings.Default.Username;
                fetch_data();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("PACIBA System " + ex.Message, "PACIBA System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to delete this account?", "PACIBA System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // delete user
                    string sql = "DELETE FROM `Members` WHERE `Username` = '" + this.gunaLineTextBox1.Text + "'";
                    using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
                    {
                        c.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Member's profile has been updated!", "PACIBA System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PACIBA System " + ex.Message, "PACIBA System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE `Members` SET `Fullname` = '" + gunaLineTextBox3.Text + "', `JerseyNumber` = '" + gunaLineTextBox2.Text + "', `Address` = '" + gunaLineTextBox4.Text + "', `ContactNumber` = '" + gunaLineTextBox5.Text + "', `Job` = '" + gunaLineTextBox6.Text + "', `Team` = '" + gunaLineTextBox7.Text + "' WHERE `Username` = '" + gunaLineTextBox1.Text + "'";
                //confirmation message yes or no
                if (MessageBox.Show("Are you sure you want to update this member's profile?", "PACIBA System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
                    {
                        c.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Member's profile has been updated!", "PACIBA System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("PACIBA System " + ex.Message, "PACIBA System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE `Members` SET `Passwordhas` = '" + gunaLineTextBox9.Text + "'";
                //confirmation message yes or no
                if (MessageBox.Show("Are you sure you want to update your password?", "PACIBA System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
                    {
                        c.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Member's password has been updated!", "PACIBA System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PACIBA System " + ex.Message, "PACIBA System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
