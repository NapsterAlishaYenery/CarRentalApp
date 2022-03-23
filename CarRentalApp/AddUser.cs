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
    public partial class AddUser : Form
    {
        private readonly RentCarNapsterEntities1 _db;
        public AddUser()
        {
            InitializeComponent();
            _db = new RentCarNapsterEntities1();
        }
        private void OpenBackWindows()
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "ManageUser");

            if (!isOpen)
            {
                var ManageUser = new ManageUser();
                ManageUser.MdiParent = this.MdiParent;
                ManageUser.Show();
            }
        }




        public static string DefaultHashPassword()
        {
            SHA256 sha = SHA256.Create();
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes("Password@1234"));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var userRole = _db.Roles.ToList();

            cbRoles.DataSource = userRole;
            cbRoles.ValueMember = "Id";
            cbRoles.DisplayMember = "Name";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var username = txtUserName.Text;
                var roleId = (int)cbRoles.SelectedValue;
                var password = DefaultHashPassword();

                var user = new usuario
                {
                    username = username,
                    password = password,
                    isActivate = true
                };

                _db.usuarios.Add(user);
                _db.SaveChanges();


                //This time something different happens, when creating
                //a new user, the database assigns a new id since it
                //is auto-incremental. then to fill the roles table you
                //need the Id of the new user and the id of the role
                //that will be given obtained in the ComboBox.
                //Refresh de id in the object.
                var userID = user.id;

                var useRole = new UserRole
                {
                    roleid = roleId,
                    userid = userID
                };
                _db.UserRoles.Add(useRole);
                _db.SaveChanges();
                OpenBackWindows();
                MessageBox.Show("User Added");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An Error has Occured");
                
            }
        }
    }
}
