using System;
// Use the following namespace to access the database
using System.Data.SQLite;
using System.Windows.Forms;


namespace PACIBA_System
{
    public partial class Loginfrm : Form
    {
        public SQLiteDataReader sqldr;
        string ConnectionString = "Data Source=" + Application.StartupPath + "\\Database.db3;Version=3;";
        private void login()
        {
            string sql = "SELECT * FROM `Members` WHERE `Username` = '" + this.gunaLineTextBox1.Text + "' AND `Password` = '" + gunaLineTextBox2.Text + "'";

            using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            MemberDashboardfrm dashboard = new MemberDashboardfrm();
                            this.Hide();
                            gunaTransition1.ShowSync(dashboard);
                            PACIBA_System.Properties.Settings.Default.Username = this.gunaLineTextBox1.Text;
                            dashboard.gunaLabel1.Text = this.gunaLineTextBox1.Text;
                        }
                        else
                        {
                            MessageBox.Show("Wrong username or password, please try again", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                        }
                    }
                }
            }

        }



        private void register()
        {
            using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM `Members` WHERE `Username` = '" + this.gunaLineTextBox3.Text + "'", c))
                {
                    sqldr = cmd.ExecuteReader();
                    if (sqldr.Read())
                    {
                        MessageBox.Show("Username already taken, please try another username!", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        SQLiteCommand sqlcmd = new SQLiteCommand("INSERT INTO `Members` (`Username`, `Password`, `Fullname`, `CreatedDate`) VALUES (@Username, @Password, @Fullname, @CreatedDate)", c);
                        sqlcmd.Parameters.AddWithValue("@Username", this.gunaLineTextBox3.Text);
                        sqlcmd.Parameters.AddWithValue("@Password", this.gunaLineTextBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@Fullname", this.gunaLineTextBox5.Text);
                        sqlcmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        sqlcmd.ExecuteNonQuery();
                        MessageBox.Show("Done!", "PACIBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gunaLineTextBox3.Clear();
                        this.gunaLineTextBox4.Clear();
                        this.gunaLineTextBox5.Clear();
                        gunaTransition1.HideSync(gunaGradient2Panel2);
                    }
                }
            }





        }
        public Loginfrm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                gunaTransition1.ShowSync(gunaGradient2Panel2);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                gunaTransition1.HideSync(gunaGradient2Panel2);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            // Login Account
            login();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            // Create Account
            register();
        }

        private void Loginfrm_Load(object sender, EventArgs e)
        {
            // Check connection

        }

        private void gunaLineTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void gunaLineTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }

        }

        private void Loginfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PACIBA System have incounter an system error please contact the admin/developer! \n" + ex.Message, "PACIBA System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
