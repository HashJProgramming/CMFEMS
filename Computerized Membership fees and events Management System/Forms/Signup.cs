using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Computerized_Membership_fees_and_events_Management_System.Forms
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            bunifuTransition1.Show(signin);
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmds;
            OleDbDataAdapter adapter;

            SignIn signin = new SignIn();
            String sql = "SELECT `ID` FROM `Users` WHERE `Username` = @username AND `Password` = @password";
            String text = "INSERT INTO `Users` (`Username`, `Password`, `Type`, `Fullname`, `Position`, `Age`, `Height`, `Course`, `School`, `UserStatus`) VALUES (@username, @password, @type, @fullname, @position, @age, @height, @course, @school, 'Not Paid')";
            cmd.CommandText = text;
            cmd.Connection = con;

            try
            {
                con.Open();


                cmds = new OleDbCommand(sql, con);
                cmds.Parameters.AddWithValue("@username", bunifuTextBox1.Text);
                cmds.Parameters.AddWithValue("@password", bunifuTextBox2.Text);


                adapter = new OleDbDataAdapter(cmds);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    cmd.Parameters.AddWithValue("@username", bunifuTextBox1.Text);
                    cmd.Parameters.AddWithValue("@password", bunifuTextBox2.Text);
                    cmd.Parameters.AddWithValue("@type", "User");
                    cmd.Parameters.AddWithValue("@fullname", bunifuTextBox3.Text);
                    cmd.Parameters.AddWithValue("@position", bunifuTextBox4.Text);
                    cmd.Parameters.AddWithValue("@age", bunifuTextBox5.Text);
                    cmd.Parameters.AddWithValue("@height", bunifuTextBox7.Text);
                    cmd.Parameters.AddWithValue("@course", bunifuTextBox6.Text);
                    cmd.Parameters.AddWithValue("@school", bunifuTextBox8.Text);
                    cmd.ExecuteNonQuery();

                    bunifuTextBox1.Clear();
                    bunifuTextBox2.Clear();
                    bunifuTextBox3.Clear();
                    bunifuTextBox4.Clear();
                    bunifuTextBox5.Clear();
                    bunifuTextBox6.Clear();
                    bunifuTextBox7.Clear();
                    bunifuTextBox8.Clear();

                    bunifuTransition1.Show(signin);
                    this.Hide();
                    MessageBox.Show("Thanks for signing up", "Congrats");
                }
                else
                {
                    MessageBox.Show("User already exist!");
                }
                

                
                con.Close();
            }
            catch (OleDbException ex)
            {
            
                MessageBox.Show(ex.Message);

            }

 
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
    }
}
