using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Security;

namespace WinMembership
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MembershipUserCollection users = Membership.GetAllUsers();
            foreach (MembershipUser user in users)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = user.UserName;
                lvi.SubItems.Add(user.Email);
                lvi.SubItems.Add(user.CreationDate.ToString());

                UsersListView.Items.Add(lvi);
            }
        }

        private void AddCommand_Click(object sender, EventArgs e)
        {
            try
            {
                Membership.CreateUser(UserNameText.Text, PasswordText.Text, EmailText.Text);
                MessageBox.Show("User created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create user: " + ex.Message);
            }
        }
    }
}