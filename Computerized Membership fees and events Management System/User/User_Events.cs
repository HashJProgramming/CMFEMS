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

namespace Computerized_Membership_fees_and_events_Management_System.User
{
    public partial class User_Events : Form
    {
        public User_Events()
        {
            InitializeComponent();
        }

        private void User_Events_Load(object sender, EventArgs e)
        {
            OleDbCommand cmd;
            OleDbDataAdapter adapter;
            OleDbDataReader dr;
            ListViewItem list;
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
    }
}
