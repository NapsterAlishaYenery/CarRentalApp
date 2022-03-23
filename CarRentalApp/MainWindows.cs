using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainWindows : Form
    {
        private Login _Login;
        //We add a property to the class

        //We create this public property so that from
        //each form we have access to the role of the user that is being logged.
        public string _roleShortName;
        public string _userName;
        public MainWindows()
        {
            InitializeComponent();
        }

        public MainWindows(Login login, string roleShortName, string userName)
        {
            InitializeComponent();
            _Login = login;
            //We initialize that property with the parameter sent to the constructor
            _roleShortName = roleShortName;
            _userName = userName;
        }

        private void manageVeiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "ManageVehicleListing");

            if (!isOpen)
            {
                var carlist = new ManageVehicleListing();
                carlist.MdiParent = this;
                carlist.Show();
            }
           
        }

        private void manageRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "ManageRentalRecordcs");

            if (!isOpen)
            {
                ManageRentalRecordcs manageRentalRecordcs = new ManageRentalRecordcs();
                manageRentalRecordcs.MdiParent = this;
                manageRentalRecordcs.Show();
            }

        }

        private void MainWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Login.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "ManageRentalRecordcs");

            if (!isOpen)
            {
                ManageUser manageUser = new ManageUser();
                manageUser.MdiParent = this;
                manageUser.Show();
            }
        }


        //An example of what we can do by having user roles is to
        //give them access to some options of our app.
        //For example we have the event that is executed when the main form is loaded.
        private void MainWindows_Load(object sender, EventArgs e)
        {
            var usuarioLog = _userName;
            tsStatusLabel.Text = $"Logged in As: {usuarioLog} ";
            //This causes that if the logged in user does not have his Shortname role
            //equal to "admin" he will have the button (manageUsersToolStripMenuItem)
            //invisible.
            if (_roleShortName != "admin")
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
        }
    }
}
