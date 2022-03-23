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
    
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private readonly RentCarNapsterEntities1 _db;
        public AddEditVehicle()
        {
            InitializeComponent();
            lbTitle.Text = "Add New Vehicle";
            isEditMode = false;
            _db = new RentCarNapsterEntities1();
            this.Text = " Add New vehicle";
        }

        public AddEditVehicle(carType carsToEdit)
        {
            InitializeComponent();
            lbTitle.Text = "Edit Vehicle";
            PopulateFiels(carsToEdit);
            isEditMode = true;
            _db = new RentCarNapsterEntities1();
            this.Text = "Edit vehicle";
        }

        private void PopulateFiels(carType car)
        {
            lbID.Text = car.id.ToString();
            txtCarName.Text = car.carType1;
            txtModel.Text = car.Model;
            txtVIN.Text = car.VIN;
            txtLicensePlate.Text = car.LicensePlateNumber;
            txtYear.Text = car.Year.ToString();
        }

        private void OpenBackWindows()
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "ManageVehicleListing");

            if (!isOpen)
            {
                var carlist = new ManageVehicleListing();
                carlist.MdiParent = this.MdiParent;
                carlist.Show();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtCarName.Text) || string.IsNullOrWhiteSpace(txtModel.Text))
                    {
                        MessageBox.Show("Please Enter a car name and a model ");
                    }
                    else
                    {
                        var id = int.Parse(lbID.Text);
                        var car = _db.carTypes.FirstOrDefault(q => q.id == id);
                        car.carType1 = txtCarName.Text;
                        car.Model = txtModel.Text;
                        car.VIN = txtVIN.Text;
                        car.LicensePlateNumber = txtLicensePlate.Text;
                        car.Year = int.Parse(txtYear.Text);

                        _db.SaveChanges();
                        OpenBackWindows();
                        this.Close();
                        


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Enter A Year");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtCarName.Text) || string.IsNullOrWhiteSpace(txtModel.Text))
                {
                    MessageBox.Show("Please Enter a car name and model ");
                }
                else
                {
                    try 
                    {
                        var newCar = new carType
                        {
                            carType1 = txtCarName.Text,
                            Model = txtModel.Text,
                            VIN = txtVIN.Text,
                            LicensePlateNumber = txtLicensePlate.Text,
                            Year = int.Parse(txtYear.Text),
                        };

                        _db.carTypes.Add(newCar);
                        _db.SaveChanges();
                        OpenBackWindows();
                        this.Close();
                       

                    }
                    catch(Exception) 
                    { 
                        MessageBox.Show("Enter A Year");
                    } 
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OpenBackWindows();
            this.Close();
            
        }

    }
}