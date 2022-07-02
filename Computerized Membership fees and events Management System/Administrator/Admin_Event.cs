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
    public partial class Admin_Event : Form
    {
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        OleDbDataReader dr;
        ListViewItem list;

        public Admin_Event()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "SELECTED: " + this.listView1.FocusedItem.SubItems[0].Text;
            bunifuTextBox3.Text = this.listView1.FocusedItem.SubItems[1].Text;
            bunifuTextBox4.Text = this.listView1.FocusedItem.SubItems[2].Text;
            bunifuTextBox5.Text = this.listView1.FocusedItem.SubItems[3].Text;


        }

        private void Admin_Event_Load(object sender, EventArgs e)
        {

            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                con.Open();

                cmd = new OleDbCommand("SELECT * FROM `Events`", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                while (dr.Read())
                {
                    list = this.listView1.Items.Add(dr["ID"].ToString());
                    list.SubItems.Add(dr["EventDate"].ToString());
                    list.SubItems.Add(dr["EventTime"].ToString());
                    list.SubItems.Add(dr["Event"].ToString());

                }

                dr.Close();
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

                String sql = "INSERT INTO `Events` (`EventDate`, `EventTime`, `Event`) VALUES (@eventdate, @eventtime, @event)";
                cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddWithValue("@eventdate", bunifuTextBox3.Text);
                cmd.Parameters.AddWithValue("@eventtime", bunifuTextBox4.Text);
                cmd.Parameters.AddWithValue("@event", bunifuTextBox5.Text);
                cmd.ExecuteNonQuery();

                this.listView1.Items.Clear();
                cmd = new OleDbCommand("SELECT * FROM `Events`", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    list = this.listView1.Items.Add(dr["ID"].ToString());
                    list.SubItems.Add(dr["EventDate"].ToString());
                    list.SubItems.Add(dr["EventTime"].ToString());
                    list.SubItems.Add(dr["Event"].ToString());

                }
                dr.Close();
                MessageBox.Show("Done", "Congrats");
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

                String sql = "UPDATE `Events` SET `EventDate` = @eventdate, `EventTime` = @eventtime, `Event` = @event WHERE ID LIKE '" + this.listView1.FocusedItem.SubItems[0].Text + "'";
                cmd.CommandText = sql;
                cmd.Connection = con;

                con.Open();

                cmd.Parameters.AddWithValue("@eventdate", bunifuTextBox3.Text);
                cmd.Parameters.AddWithValue("@eventtime", bunifuTextBox4.Text);
                cmd.Parameters.AddWithValue("@event", bunifuTextBox5.Text);

                cmd.ExecuteNonQuery();

                this.listView1.Items.Clear();
                cmd = new OleDbCommand("SELECT * FROM `Events`", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    list = this.listView1.Items.Add(dr["ID"].ToString());
                    list.SubItems.Add(dr["EventDate"].ToString());
                    list.SubItems.Add(dr["EventTime"].ToString());
                    list.SubItems.Add(dr["Event"].ToString());

                }
                dr.Close();
                MessageBox.Show("Done", "Congrats");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                OleDbCommand cmd = con.CreateCommand();
                con.Open();

                String sql = "DELETE FROM `Events` WHERE ID LIKE '" + this.listView1.FocusedItem.SubItems[0].Text + "'";
                
                DialogResult result = MessageBox.Show("Do you want to remove this event?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    this.listView1.Items.Clear();
                    cmd = new OleDbCommand("SELECT * FROM `Events`", con);
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        list = this.listView1.Items.Add(dr["ID"].ToString());
                        list.SubItems.Add(dr["EventDate"].ToString());
                        list.SubItems.Add(dr["EventTime"].ToString());
                        list.SubItems.Add(dr["Event"].ToString());

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
    }
}
