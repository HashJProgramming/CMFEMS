using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using Computerized_Membership_fees_and_events_Management_System.Properties;


namespace Computerized_Membership_fees_and_events_Management_System.User
{
    public partial class User_Profile : Form
    {
        public User_Profile()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
            OleDbCommand cmd = con.CreateCommand();

            String sql = "UPDATE `Users` SET `Fullname` = @fullname, `Position` = @position, `Age` = @age, `Height` = @height, `Course` = @course, `School` = @school WHERE Username = '" + bunifuTextBox2.Text + "'";
            cmd.CommandText = sql;
            cmd.Connection = con;

            con.Open();

            cmd.Parameters.AddWithValue("@fullname", bunifuTextBox3.Text);
            cmd.Parameters.AddWithValue("@position", bunifuTextBox4.Text);
            cmd.Parameters.AddWithValue("@age", bunifuTextBox5.Text);
            cmd.Parameters.AddWithValue("@height", bunifuTextBox7.Text);
            cmd.Parameters.AddWithValue("@course", bunifuTextBox6.Text);
            cmd.Parameters.AddWithValue("@school", bunifuTextBox1.Text);
            cmd.ExecuteNonQuery();
            Settings.Default["Fullname"] = bunifuTextBox3.Text;
            MessageBox.Show("Done", "Congrats");

        }
    }
}
