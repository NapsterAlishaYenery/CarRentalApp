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
    public partial class ManageVehicleListing : Form
    {
        private readonly RentCarNapsterEntities1 _db;
        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new RentCarNapsterEntities1();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            var cars = _db.carTypes
                .Select(q => new 
                {
                    CarId = q.id,
                    CarName = q.carType1, 
                    Model = q.Model, 
                    VIN = q.VIN, 
                    License = q.LicensePlateNumber, 
                    Year = q.Year,
                }).ToList();

            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[0].HeaderText = "ID";
            gvVehicleList.Columns[1].HeaderText = "NAME";
            gvVehicleList.Columns[2].HeaderText = "MODEL";
            gvVehicleList.Columns[3].HeaderText = "VEHICLE ID#";
            gvVehicleList.Columns[4].HeaderText = "LICENSE PLATE";
            gvVehicleList.Columns[5].HeaderText = "YEAR";

        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "AddEditVehicle");
            if (!isOpen)
            {
                AddEditVehicle addEditVehicle = new AddEditVehicle();
                addEditVehicle.MdiParent = this.MdiParent;
                addEditVehicle.Show();
            }
            this.Close();

        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                var OpenForm = Application.OpenForms.Cast<Form>();
                var isOpen = OpenForm.Any(q => q.Name == "AddEditVehicle");
                if (!isOpen)
                {
                    var id = (int)gvVehicleList.SelectedRows[0].Cells["CarId"].Value;
                    var car = _db.carTypes.FirstOrDefault(q => q.id == id);
                    AddEditVehicle addEditVehicle = new AddEditVehicle(car);
                    addEditVehicle.MdiParent = this.MdiParent;
                    addEditVehicle.Show();
                    _db.SaveChanges();
                }
                this.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Please select a complete row");
            }


        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvVehicleList.SelectedRows[0].Cells["CarId"].Value;
                var car = _db.carTypes.FirstOrDefault(q => q.id == id);
                _db.carTypes.Remove(car);
                _db.SaveChanges();
                ManageVehicleListing_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Please select the complete row");
            }


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ManageVehicleListing_Load(sender, e);
        }
    }
}
