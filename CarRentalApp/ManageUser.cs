using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{

    public partial class ManageUser : Form
    {
        private readonly RentCarNapsterEntities1 _db;   
        public ManageUser()
        {
            InitializeComponent();
            _db = new RentCarNapsterEntities1();
        }

        //We create this function to encrypt password
        public static string HashPassword(string password)
        {
            SHA256 sha = SHA256.Create();
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ManageUser_Load(sender, e);
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "AddUser");

            if (!isOpen)
            {
                var addUser = new AddUser();
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
              
                var id = (int)gvUserList.SelectedRows[0].Cells["UserID"].Value;
                var user = _db.usuarios.FirstOrDefault(q => q.id == id);

                var password = "Password@1234";
                var hash_password = HashPassword(password);
                user.password = hash_password;
                _db.SaveChanges();
                ManageUser_Load(sender, e);

                MessageBox.Show("Password has been changed");

            }
            catch (Exception)
            {
                MessageBox.Show("Please select a complete row");
            }
        }

        private void btnDesactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvUserList.SelectedRows[0].Cells["UserID"].Value;
                var user = _db.usuarios.FirstOrDefault(q => q.id == id);

                //The following statement is like writing an IF-ELSE
                user.isActivate = user.isActivate == true ? false : true;
                _db.SaveChanges();
                ManageUser_Load(sender, e);

                MessageBox.Show("Status has been reset" );
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a complete row");
            }
        }

        public void ManageUser_Load(object sender, EventArgs e)
        {
            var user = _db.usuarios
               .Select(q => new
               {
                   UserID = q.id,
                   UserName = q.username,
                   UserRole = q.UserRoles.FirstOrDefault().Role.name,
                   isActive = q.isActivate
                  
               }).ToList();

            gvUserList.DataSource = user;
            gvUserList.Columns[0].HeaderText = "User ID";
            gvUserList.Columns[1].HeaderText = "User Name";
            gvUserList.Columns[2].HeaderText = "Role";
            gvUserList.Columns[3].HeaderText = "Active / UnActive";

        }
    }
}
