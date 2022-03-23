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
    public partial class Login : Form
    {
        private readonly RentCarNapsterEntities1 _db;
        public Login()
        {
            InitializeComponent();
            _db = new RentCarNapsterEntities1();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SHA256 sha = SHA256.Create();

                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text;

                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                var hashed_password = sBuilder.ToString();

                var user = _db.usuarios.FirstOrDefault(q => q.username == username && q.password == hashed_password && q.isActivate== true);
                
                if (user == null)
                {
                    MessageBox.Show("Pleas provide valid credentials or use a active Account");
                }
                else
                {

                    //As we already have an object of type "user" called user,
                    //we extract the role it has with the following statement.
                    var role = user.UserRoles.FirstOrDefault();

                    // Then to the extracted role, using the role table, we extract
                    // the ShortName
                    var roleShortName = role.Role.shortname;

                    var OpenForm = Application.OpenForms.Cast<Form>();
                    var isOpen = OpenForm.Any(q => q.Name == "MainWindows");

                    if (!isOpen)
                    {

                        //Followed by this we pass the String to the constructor
                        //of the main Window form.
                        var mainWindows = new MainWindows(this, roleShortName, user.username);

                        mainWindows.Show();
                    }
                    this.Hide();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Somethig is Wrong Try Again" + ex.Message);
            }
        }

        private void lbResetPassword_Click(object sender, EventArgs e)
        {
           var resetPassword = new ResetPassword();
           resetPassword.ShowDialog(); 
        }
    }
}
