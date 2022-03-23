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
    public partial class AddEditRentalRecord : Form
    {
        private readonly RentCarNapsterEntities1 _db;
        private bool isEditMode;
        public AddEditRentalRecord()
        {
            InitializeComponent();
            _db = new RentCarNapsterEntities1();
            lbTitle.Text = "Add New Rental Record";
            isEditMode = false;
            this.Text = " Add New Record";
        }

        public AddEditRentalRecord(CarRentalRecord record)
        {
            InitializeComponent();
            _db = new RentCarNapsterEntities1();
            lbTitle.Text = "Edit Selected Rental Record";
            PopulateGrid(record);
            isEditMode = true;
            this.Text = "Edit Rental Record";
        }

        private void PopulateGrid(CarRentalRecord record)
        {
            lbID.Text = record.carRentalRecord_id.ToString();
            txtFristName.Text = record.customerFirstName;
            txtLastName.Text = record.customerLastName;
            dtDateReted.Value = (DateTime)record.dateRented;
            dtDateReturned.Value = (DateTime)record.dateReturned;
            txtCost.Text = record.cost.ToString();
        }

        private void OpenFormback()
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "ManageRentalRecordcs");

            if (!isOpen)
            {
                ManageRentalRecordcs manageRentalRecordcs = new ManageRentalRecordcs();
                manageRentalRecordcs.MdiParent = this.MdiParent;
                manageRentalRecordcs.Show();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtFristName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
                    {
                        MessageBox.Show("Please Enter a car name and a model ");
                    }
                    else
                    {
                        var id = int.Parse(lbID.Text);
                        var record = _db.CarRentalRecords.FirstOrDefault(q => q.carRentalRecord_id == id);
                        record.customerFirstName = txtFristName.Text;
                        record.customerLastName = txtLastName.Text;
                        record.dateRented = dtDateReted.Value;
                        record.dateReturned = dtDateReturned.Value;
                        record.cost = Convert.ToDecimal(txtCost.Text);
                        record.IdCarType = (int)cbTypeOfCars.SelectedValue;

                        _db.SaveChanges();

                        MessageBox.Show($"Cutomer's Name: {txtFristName.Text} {txtLastName.Text}\n" +
                                        $"Date Out: {dtDateReted.Value}\n" +
                                        $"Date In: {dtDateReturned.Value}\n" +
                                        $"Car Type: {cbTypeOfCars.SelectedItem.ToString()}\n" +
                                        $"THANKS FOR YOUR BUSSINES");

                        //need to be finished


                        _db.SaveChanges();
                        OpenFormback();
                        this.Close(); 
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Enter valid Price");
                }
            }
            else 
            {
                try
                {

                    string firstName = txtFristName.Text;
                    string lastName = txtLastName.Text;
                    var dateOut = dtDateReted.Value;
                    var dateIn = dtDateReturned.Value;
                    double cost = Convert.ToDouble(txtCost.Text);
                    var carType = cbTypeOfCars.SelectedItem.ToString();
                    bool isValid = true;
                    string errormessages = "";

                    if (dateOut > dateIn)
                    {
                        isValid = false;
                        errormessages += "Error: Date invalid";

                    }

                    if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(carType))
                    {
                        isValid = false;
                        errormessages += "Error: Data missing (Name or car type)";
                    }

                    if (isValid)
                    {
                        var carRentalRecord = new CarRentalRecord();

                        carRentalRecord.customerFirstName = firstName;
                        carRentalRecord.customerLastName = lastName;
                        carRentalRecord.dateRented = dateOut;
                        carRentalRecord.dateReturned = dateIn;
                        carRentalRecord.cost = (decimal)cost;
                        carRentalRecord.IdCarType = (int)cbTypeOfCars.SelectedValue;

                        _db.CarRentalRecords.Add(carRentalRecord);
                        _db.SaveChanges();

                        MessageBox.Show($"Cutomer's Name: {firstName} {lastName}\n" +
                                        $"Date Out: {dateOut}\n" +
                                        $"Date In: {dateIn}\n" +
                                        $"Car Type: {cbTypeOfCars}\n" +
                                        $"THANKS FOR YOUR BUSSINES");
                        OpenFormback();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show(errormessages);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            var cars = _db.carTypes.Select(q => new { Id = q.id, Name = q.carType1 + " " + q.Model}).ToList();

            cbTypeOfCars.DisplayMember = "Name";
            cbTypeOfCars.ValueMember = "Id";
            cbTypeOfCars.DataSource = cars;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            OpenFormback();
            this.Close();
        }
    }
}
