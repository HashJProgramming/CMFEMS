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

namespace Computerized_Membership_fees_and_events_Management_System.Administrator
{
    public partial class Admin_Members : Form
    {
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        OleDbDataReader dr;
        ListViewItem list;
        public Admin_Members()
        {
            InitializeComponent();
        }

        private void Admin_Members_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Database.accdb");
                con.Open();

                cmd = new OleDbCommand("SELECT * FROM `users` WHERE UserStatus LIKE 'Fully Paid'", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                while (dr.Read())
                {
                    list = this.listView1.Items.Add(dr["ID"].ToString());
                    list.SubItems.Add(dr["Username"].ToString());
                    list.SubItems.Add(dr["Fullname"].ToString());
                    list.SubItems.Add(dr["UserStatus"].ToString());
                }

                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
