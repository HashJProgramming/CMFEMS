using System;
using System.Windows.Forms;
using System.Data.OleDb;
using Computerized_Membership_fees_and_events_Management_System.Properties;

namespace Computerized_Membership_fees_and_events_Management_System
{
    public partial class User_Dashboard : Form
    {
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        public User_Dashboard()
        {
            InitializeComponent();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Hide();
            SignIn signIn = new SignIn();
            bunifuTransition1.Show(signIn);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                con.Open();

                this.panel2.Controls.Clear();
                User.User_Profile user_form = new User.User_Profile() { TopLevel = false };
                User_Dashboard user_dash = new User_Dashboard();
                this.panel2.Controls.Add(user_form);

                String username = "SELECT `Username` FROM `Users` WHERE `Fullname` = @fullname";
                String position = "SELECT `Position` FROM `Users` WHERE `Fullname` = @fullname";
                String height = "SELECT `Height` FROM `Users` WHERE `Fullname` = @fullname";
                String age = "SELECT `Age` FROM `Users` WHERE `Fullname` = @fullname";
                String course = "SELECT `Course` FROM `Users` WHERE `Fullname` = @fullname";
                String school = "SELECT `School` FROM `Users` WHERE `Fullname` = @fullname";

                cmd = new OleDbCommand(username, con);
                cmd.Parameters.AddWithValue("@fullname", this.label1.Text);

                user_form.bunifuTextBox3.Text = this.label1.Text;
                user_form.bunifuTextBox2.Text = cmd.ExecuteScalar().ToString();

                cmd = new OleDbCommand(position, con);
                cmd.Parameters.AddWithValue("@fullname", this.label1.Text);
                user_form.bunifuTextBox4.Text = cmd.ExecuteScalar().ToString();

                cmd = new OleDbCommand(height, con);
                cmd.Parameters.AddWithValue("@fullname", this.label1.Text);
                user_form.bunifuTextBox7.Text = cmd.ExecuteScalar().ToString();

                cmd = new OleDbCommand(age, con);
                cmd.Parameters.AddWithValue("@fullname", this.label1.Text);
                user_form.bunifuTextBox5.Text = cmd.ExecuteScalar().ToString();

                cmd = new OleDbCommand(course, con);
                cmd.Parameters.AddWithValue("@fullname", this.label1.Text);
                user_form.bunifuTextBox6.Text = cmd.ExecuteScalar().ToString();

                cmd = new OleDbCommand(school, con);
                cmd.Parameters.AddWithValue("@fullname", this.label1.Text);
                user_form.bunifuTextBox1.Text = cmd.ExecuteScalar().ToString();


                user_form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                con.Open();


                this.panel2.Controls.Clear();
                User.User_Membership user_form = new User.User_Membership() { TopLevel = false };

                String EntranceFee = "SELECT `EntranceFee` FROM `Membership` WHERE `Username` = @username";
                String Jersey = "SELECT `Jersey` FROM `Membership` WHERE `Username` = @username";
                String Others = "SELECT `Others` FROM `Membership` WHERE `Username` = @username";
                String Status = "SELECT `Status` FROM `Membership` WHERE `Username` = @username";

                cmd = new OleDbCommand(EntranceFee, con);
                cmd.Parameters.AddWithValue("@username", Settings.Default["Username"].ToString());
                user_form.bunifuTextBox3.Text = cmd.ExecuteScalar().ToString();

                cmd = new OleDbCommand(Jersey, con);
                cmd.Parameters.AddWithValue("@username", Settings.Default["Username"].ToString());
                user_form.bunifuTextBox4.Text = cmd.ExecuteScalar().ToString();

                cmd = new OleDbCommand(Others, con);
                cmd.Parameters.AddWithValue("@username", Settings.Default["Username"].ToString());
                user_form.bunifuTextBox5.Text = cmd.ExecuteScalar().ToString();

                cmd = new OleDbCommand(Status, con);
                cmd.Parameters.AddWithValue("@username", Settings.Default["Username"].ToString());
                user_form.label3.Text = cmd.ExecuteScalar().ToString();

                this.panel2.Controls.Add(user_form);
                user_form.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            User.User_Events user_form = new User.User_Events() { TopLevel = false };
            this.panel2.Controls.Add(user_form);
            user_form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = Settings.Default["Fullname"].ToString();
        }
    }
}
