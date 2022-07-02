using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Computerized_Membership_fees_and_events_Management_System.Properties;

namespace Computerized_Membership_fees_and_events_Management_System
{
    public partial class SignIn : Form
    {
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
    
        public SignIn()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {


                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                con.Open();
                String sql = "SELECT `ID` FROM `Users` WHERE `Username` = @username AND `Password` = @password";
                String usersql1 = "SELECT `Fullname` FROM `Users` WHERE `Username` = @username AND `Password` = @password";
                String usersql2 = "SELECT `Type` FROM `Users` WHERE `Username` = @username AND `Password` = @password";

                cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", bunifuTextBox1.Text);
                cmd.Parameters.AddWithValue("@password", bunifuTextBox2.Text);


                adapter = new OleDbDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Username Or Password");
                }
                else
                {

                    cmd = new OleDbCommand(usersql2, con);
                    cmd.Parameters.AddWithValue("@username", bunifuTextBox1.Text);
                    cmd.Parameters.AddWithValue("@password", bunifuTextBox2.Text);

                    if (cmd.ExecuteScalar().ToString() == "Admin")
                    {
                        Hide();
                        Administrator.Admin_Dashboard AdminDashboard = new Administrator.Admin_Dashboard();
                        bunifuTransition1.Show(AdminDashboard);
                    }
                    else
                    {
                        Hide();
                        User_Dashboard UserDashboard = new User_Dashboard();
                        bunifuTransition1.Show(UserDashboard);
                    }


                    cmd = new OleDbCommand(usersql1, con);
                    cmd.Parameters.AddWithValue("@username", bunifuTextBox1.Text);
                    cmd.Parameters.AddWithValue("@password", bunifuTextBox2.Text);


                    User.User_Profile user_form = new User.User_Profile() { TopLevel = false };

                    Settings.Default["Fullname"] = cmd.ExecuteScalar().ToString();
                    Settings.Default["Username"] = bunifuTextBox1.Text;


                }

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.Signup signup = new Forms.Signup();
            bunifuTransition1.Show(signup);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuCheckBox1.Checked == true)
            {
                bunifuTextBox2.PasswordChar = '\0';
            }
            else
            {
                bunifuTextBox2.PasswordChar = '•';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact the administrator for account recovery");
        }
    }
}
