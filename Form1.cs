using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Golf2020
{
    //Data Source=GARYLAPTOP\SQLEXPRESS;Initial Catalog=Golf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

    public partial class Form1 : Form
    {
        Database myDatabase = new Database();
        CRUD_Handler myHandler = new CRUD_Handler();
        CRUD myCRUD = new CRUD();

        public Form1()
        {
            InitializeComponent();
            LoadDB();
        }

        private void LoadDB()
        {
            // Directly call CRUD without Handler as we do not need to do any validations nor are we passing data
            dgvGolf.DataSource = myCRUD.ReadEntries();
        }

        private void dgvGolf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Grab the data from the cell clicked
                string newValue = dgvGolf.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                this.Text = "Row: " + e.RowIndex.ToString() + "     Col: " + e.ColumnIndex.ToString() + "     Value: " + newValue;

                // Pass data from this row to textboxes
                txtID.Text = dgvGolf.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = dgvGolf.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtFirstName.Text = dgvGolf.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSurname.Text = dgvGolf.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGender.Text = dgvGolf.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDOB.Text = dgvGolf.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtStreet.Text = dgvGolf.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSuburb.Text = dgvGolf.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCity.Text = dgvGolf.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtAvailable.Text = dgvGolf.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtHandicap.Text = dgvGolf.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
            catch
            {
            }
        }

        private void btnCount_Click(object sender, System.EventArgs e)
        {
            // Directly call CRUD without Handler as we do not need to do any validations nor are we passing data
            btnCount.Text = myCRUD.CountEntries();
        }

        private void btnInsert_Click(object sender, System.EventArgs e)
        {
            // Create Array to send to Handler
            string[] EntryArr = { txtTitle.Text, txtFirstName.Text, txtSurname.Text, txtGender.Text, txtDOB.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtAvailable.Text, txtHandicap.Text };

            if (myHandler.CreateEntryHandler(EntryArr))
            {
                // Successfully Created New Entry
                MessageBox.Show("Entry successfully added!");
            }
            else
            {
                MessageBox.Show("Sorry, there seems to have been an error creating this entry");
            }
            // Reloads Data
            LoadDB();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Create Array to send to Handler
            string[] UpdateArr = { txtID.Text, txtTitle.Text, txtFirstName.Text, txtSurname.Text, txtGender.Text, txtDOB.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtAvailable.Text, txtHandicap.Text };
            if (myHandler.UpdateEntryHandler(UpdateArr))
            {
                // Successfully Update New Entry
                MessageBox.Show("Successfully updated entry!");
            }
            else
            {
                MessageBox.Show("Sorry, there seems to have been an error updating this entry");
            }
            // Reloads Data
            LoadDB();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (myHandler.DeleteEntryHandler(Int16.Parse(txtID.Text)))
            {
                // Successfully Deleted Entry
                MessageBox.Show("Entry successfully deleted!");
            }
            else
            {
                MessageBox.Show("Failed to delete entry!");
            }
            // Reloads Data
            LoadDB();
        }
    }
}
