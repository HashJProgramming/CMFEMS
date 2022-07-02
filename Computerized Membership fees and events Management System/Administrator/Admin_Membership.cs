using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Computerized_Membership_fees_and_events_Management_System.Properties;

namespace Computerized_Membership_fees_and_events_Management_System.Administrator
{
    public partial class Admin_Membership : Form
    {
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        OleDbDataReader dr;
        ListViewItem list;
        public Admin_Membership()
        {
            InitializeComponent();
        }

        private void Admin_Membership_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                con.Open();

                cmd = new OleDbCommand("SELECT * FROM `users`", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                while (dr.Read())
                {
                    
                    if (dr["UserStatus"].ToString() != "Fully Paid")
                    {
                        list = this.listView1.Items.Add(dr["ID"].ToString());
                        list.SubItems.Add(dr["Username"].ToString());
                        list.SubItems.Add(dr["Fullname"].ToString());
                        list.SubItems.Add(dr["UserStatus"].ToString());
                    }
                    

                }

                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox3.Clear();
                bunifuTextBox4.Clear();
                bunifuTextBox5.Clear();

                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                con.Open();


                cmd = new OleDbCommand("SELECT * FROM `Membership` WHERE Username LIKE '" + this.listView1.FocusedItem.SubItems[1].Text  + "'", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (this.listView1.FocusedItem.SubItems[3].Text == "Fully Paid")
                {
                    while (dr.Read())
                    {

                        bunifuTextBox3.Text = dr["EntranceFee"].ToString();
                        bunifuTextBox4.Text = dr["Jersey"].ToString();
                        bunifuTextBox5.Text = dr["Others"].ToString();

                    }
                    dr.Close();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                OleDbCommand cmd = con.CreateCommand();
                con.Open();

                String sql = "INSERT INTO `Membership` (`Username`, `EntranceFee`, `Jersey`, `Others`, `Status`, `CreatedDate`) VALUES (@username, @entrancefee, @jersey, @others, 'Fully Paid', @createddated)";
                cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", this.listView1.FocusedItem.SubItems[1].Text);
                cmd.Parameters.AddWithValue("@entrancefee", bunifuTextBox3.Text);
                cmd.Parameters.AddWithValue("@jersey", bunifuTextBox4.Text);
                cmd.Parameters.AddWithValue("@others", bunifuTextBox5.Text);
                cmd.Parameters.AddWithValue("@createddated", DateTime.Now);
                
                cmd.ExecuteNonQuery();

                String updatesql = "UPDATE `Users` SET `UserStatus` = 'Fully Paid' WHERE Username LIKE '" + this.listView1.FocusedItem.SubItems[1].Text + "'";
                cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();

                this.listView1.Items.Clear();

                cmd = new OleDbCommand("SELECT * FROM `users`", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                while (dr.Read())
                {
                    list = this.listView1.Items.Add(dr["ID"].ToString());
                    list.SubItems.Add(dr["Username"].ToString());
                    list.SubItems.Add(dr["Fullname"].ToString());
                    if (dr["UserStatus"].ToString() != null)
                    {
                        list.SubItems.Add(dr["UserStatus"].ToString());
                    }
                    else
                    {
                        list.SubItems.Add("Not Paid");
                    }


                }

                dr.Close();
                MessageBox.Show("Done", "Congrats");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
