using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computerized_Membership_fees_and_events_Management_System.Administrator
{
    public partial class Admin_Recovery : Form
    {
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        OleDbDataReader dr;
        ListViewItem list;
        public Admin_Recovery()
        {
            InitializeComponent();
        }

        private void Admin_Recovery_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                con.Open();

                cmd = new OleDbCommand("SELECT * FROM `Users`", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                while (dr.Read())
                {
                    if (dr["Username"].ToString() != "Admin")
                    {
                        list = this.listView1.Items.Add(dr["ID"].ToString());
                        list.SubItems.Add(dr["Username"].ToString());
                        list.SubItems.Add(dr["Password"].ToString());
                        list.SubItems.Add(dr["Fullname"].ToString());
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
                label2.Text = "SELECTED: " + this.listView1.FocusedItem.SubItems[0].Text;
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
                OleDbCommand cmd = con.CreateCommand();
                con.Open();

                String sql = "DELETE FROM `Users` WHERE ID LIKE '" + this.listView1.FocusedItem.SubItems[0].Text + "'";

                DialogResult result = MessageBox.Show("Do you want to remove this event?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    this.listView1.Items.Clear();
                    cmd = new OleDbCommand("SELECT * FROM `Users`", con);
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                    while (dr.Read())
                    {
                        list = this.listView1.Items.Add(dr["ID"].ToString());
                        list.SubItems.Add(dr["Username"].ToString());
                        list.SubItems.Add(dr["Password"].ToString());
                        list.SubItems.Add(dr["Fullname"].ToString());

                    }

                    dr.Close();
                    MessageBox.Show("Done", "Congrats");

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

                if (bunifuTextBox1.Text == bunifuTextBox2.Text)
                {
                    String sql = "UPDATE `Users` SET `Password` = @password WHERE ID LIKE '" + this.listView1.FocusedItem.SubItems[0].Text + "'";
                    cmd.CommandText = sql;
                    cmd.Connection = con;

                    con.Open();

                    cmd.Parameters.AddWithValue("@password", bunifuTextBox2.Text);

                    cmd.ExecuteNonQuery();

                    this.listView1.Items.Clear();
                    cmd = new OleDbCommand("SELECT * FROM `Users`", con);
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                    while (dr.Read())
                    {
                        list = this.listView1.Items.Add(dr["ID"].ToString());
                        list.SubItems.Add(dr["Username"].ToString());
                        list.SubItems.Add(dr["Password"].ToString());
                        list.SubItems.Add(dr["Fullname"].ToString());

                    }

                    dr.Close();
                    MessageBox.Show("Done", "Congrats");
                }
                else
                {
                    MessageBox.Show("Password not match!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
