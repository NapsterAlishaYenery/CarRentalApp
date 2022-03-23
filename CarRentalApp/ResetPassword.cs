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
    public partial class ResetPassword : Form
    {
        private readonly RentCarNapsterEntities1 _db;
        public ResetPassword()
        {
            InitializeComponent();
            _db = new RentCarNapsterEntities1();
        }

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

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var oldPassword = txtOldPassword.Text;
            var enterNewPassword = txtEnterPassword.Text;
            var confirmNewPassword = txtConfirmPassword.Text;
           

            var HashOldPassword = HashPassword(oldPassword);
            var HashNewPassword = HashPassword(enterNewPassword);
            var HashConfirmNewPassword = HashPassword(confirmNewPassword);

            if (HashNewPassword == HashConfirmNewPassword)
            {
                var user = _db.usuarios.FirstOrDefault(q => q.username == userName && q.password == HashOldPassword);
                user.password = HashNewPassword;

                _db.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password are not similars");
            }
        }
    }
}
