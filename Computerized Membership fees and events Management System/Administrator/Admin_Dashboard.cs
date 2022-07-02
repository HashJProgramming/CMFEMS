using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computerized_Membership_fees_and_events_Management_System.Administrator
{
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
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
            this.panel2.Controls.Clear();
            Admin_Recovery user_form = new Admin_Recovery() { TopLevel = false };
            this.panel2.Controls.Add(user_form);
            user_form.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            Admin_Membership user_form = new Admin_Membership() { TopLevel = false };
            this.panel2.Controls.Add(user_form);
            user_form.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            Admin_Members user_form = new Admin_Members() { TopLevel = false };
            this.panel2.Controls.Add(user_form);
            user_form.Show();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            Admin_Event user_form = new Admin_Event() { TopLevel = false };
            this.panel2.Controls.Add(user_form);
            user_form.Show();
        }
    }
}
