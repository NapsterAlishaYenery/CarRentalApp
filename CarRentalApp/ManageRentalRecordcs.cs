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
    public partial class ManageRentalRecordcs : Form
    {
        private readonly RentCarNapsterEntities1 _db;
        public ManageRentalRecordcs()
        {
            InitializeComponent();
            _db = new RentCarNapsterEntities1();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ManageRentalRecordcs_Load(sender, e);
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            var OpenForm = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForm.Any(q => q.Name == "AddEditRentalRecord");
            if (!isOpen)
            {
                AddEditRentalRecord addRentalRecord = new AddEditRentalRecord();
                addRentalRecord.MdiParent = this.MdiParent;
                addRentalRecord.Show();
            }
            this.Close();

        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var OpenForm = Application.OpenForms.Cast<Form>();
                var isOpen = OpenForm.Any(q => q.Name == "AddEditRentalRecord");
                if (!isOpen)
                {
                    var id = (int)gvRecordList.SelectedRows[0].Cells["ID"].Value;
                    var record = _db.CarRentalRecords.FirstOrDefault(q => q.carRentalRecord_id == id);
                    AddEditRentalRecord addEditRecord = new AddEditRentalRecord(record);
                    addEditRecord.MdiParent = this.MdiParent;
                    addEditRecord.Show();
                    _db.SaveChanges();
                }
                this.Close();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a complete row");
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvRecordList.SelectedRows[0].Cells["ID"].Value;
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.carRentalRecord_id == id);
                _db.CarRentalRecords.Remove(record);
                _db.SaveChanges();
                PopulateGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageRentalRecordcs_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Error" );
            }
        }

        public void PopulateGrid()
        {
            var record = _db.CarRentalRecords.Select(q => new 
            { 
                Name = q.customerFirstName,
                LastName = q.customerLastName,
                DateOut = q.dateRented,
                DateIn = q.dateRented,
                ID = q.carRentalRecord_id,
                Cost = q.cost,
                //When we have a foreign key (FK) in a table to be able
                //to do an INER JOIN as in SQL, we use the following sentence.
                car = q.carType.carType1 + " " + q.carType.Model
                //This means that using the FK of which row, it will look up
                //the name and model in the other table.

            }).ToList();

            gvRecordList.DataSource = record;
            gvRecordList.Columns["ID"].Visible= false;
            gvRecordList.Columns["DateIn"].HeaderText = "Date in";
            gvRecordList.Columns["DateOut"].HeaderText = "Date out";
        }
    }
}
