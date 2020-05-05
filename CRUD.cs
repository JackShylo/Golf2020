using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf2020
{
    class CRUD
    {
        Database myDatabase = new Database();
        public bool CreateEntry(string[] EntryArr)
        {
            // this puts the parameters into the code so that the data in the text boxes is added to the database
            string entryStatement = "INSERT INTO Golf (Title, Firstname, Surname, Gender, DOB, Street, Suburb, City, [Available week days], Handicap) VALUES(@Title, @Firstname, @Surname, @Gender, @DOB, @Street, @Suburb, @City, @Available, @Handicap)";

            // Define DB Connection
            SqlConnection Con = new SqlConnection(myDatabase.connectionString);

            using (SqlCommand entryData = new SqlCommand(entryStatement, Con))
            {
                // Assigns Parameters
                entryData.Parameters.AddWithValue("@Title", EntryArr[0]);
                entryData.Parameters.AddWithValue("@Firstname", EntryArr[1]);
                entryData.Parameters.AddWithValue("@Surname", EntryArr[2]);
                entryData.Parameters.AddWithValue("@Gender", EntryArr[3]);
                entryData.Parameters.AddWithValue("@DOB", EntryArr[4]);
                entryData.Parameters.AddWithValue("@Street", EntryArr[5]);
                entryData.Parameters.AddWithValue("@Suburb", EntryArr[6]);
                entryData.Parameters.AddWithValue("@City", EntryArr[7]);
                entryData.Parameters.AddWithValue("@Available", EntryArr[8]);
                entryData.Parameters.AddWithValue("@Handicap", EntryArr[9]);


                // Open DB Connection
                Con.Open();

                // Run SQL Command - Will return how many rows were effected
                int returnValue = entryData.ExecuteNonQuery();

                // Close DB Connection
                Con.Close();

                if (returnValue == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public DataTable ReadEntries()
        {
            // Define GolfTable
            DataTable GolfTable = new DataTable();

            // Clear Table
            GolfTable.Clear();

            // Define Column Titles
            GolfTable.Columns.Add("ID");
            GolfTable.Columns.Add("Title");
            GolfTable.Columns.Add("Firstname");
            GolfTable.Columns.Add("Surname");
            GolfTable.Columns.Add("Gender");
            GolfTable.Columns.Add("DOB");
            GolfTable.Columns.Add("Street");
            GolfTable.Columns.Add("Suburb");
            GolfTable.Columns.Add("City");
            GolfTable.Columns.Add("Available week days");
            GolfTable.Columns.Add("Handicap");

            // Instantiate Database
            Database myDatabase = new Database();

            // Define DB connection
            using (SqlConnection Con = new SqlConnection(myDatabase.connectionString))
            {
                // Define Query Statement
                string queryString = @"SELECT * FROM Golf order by ID";

                // Open DB Connection
                Con.Open();

                // Define SQL Command
                SqlCommand Command = new SqlCommand(queryString, Con);

                // Start the DB reader
                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    // Add in each row into DataTable
                    GolfTable.Rows.Add(
                        reader["ID"],
                        reader["Title"],
                        reader["Firstname"],
                        reader["Surname"],
                        reader["Gender"],
                        reader["DOB"],
                        reader["Street"],
                        reader["Suburb"],
                        reader["City"],
                        reader["Available week days"],
                        reader["Handicap"]);
                }

                // Close reader
                reader.Close();

                // Close DB Connection
                Con.Close();

                return GolfTable;
            }


        }

        public bool UpdateEntry(string[] UpdateArr)
        {
            // Define Update Statement
            string updateStatement = "UPDATE Golf SET Title=@Title, Firstname=@Firstname, Surname=@Surname, Gender = @Gender, DOB = @DOB, Street = @Street, Suburb = @Suburb, City = @City, [Available week days]=@Available, Handicap=@Handicap where ID = @ID";

            // Define DB Connection
            using (SqlConnection Con = new SqlConnection(myDatabase.connectionString))
            {
                // Define SQL Command
                SqlCommand updateData = new SqlCommand(updateStatement, Con);

                // Assigns Parameters
                updateData.Parameters.AddWithValue("@ID", UpdateArr[0]);
                updateData.Parameters.AddWithValue("@Title", UpdateArr[1]);
                updateData.Parameters.AddWithValue("@Firstname", UpdateArr[2]);
                updateData.Parameters.AddWithValue("@Surname", UpdateArr[3]);
                updateData.Parameters.AddWithValue("@Gender", UpdateArr[4]);
                updateData.Parameters.AddWithValue("@DOB", UpdateArr[5]);
                updateData.Parameters.AddWithValue("@Street", UpdateArr[6]);
                updateData.Parameters.AddWithValue("@Suburb", UpdateArr[7]);
                updateData.Parameters.AddWithValue("@City", UpdateArr[8]);
                updateData.Parameters.AddWithValue("@Available", UpdateArr[9]);
                updateData.Parameters.AddWithValue("@Handicap", UpdateArr[10]);

                // Open DB Connection
                Con.Open();

                // Run SQL Command - Will return how many rows were effected
                int returnValue = updateData.ExecuteNonQuery();

                // Close DB Connection
                Con.Close();

                if (returnValue == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteEntry(int ID)
        {
            // Define deleteStatement
            string deleteStatement = "DELETE FROM Golf WHERE ID=@ID";

            // Define DB Connection
            using (SqlConnection Con = new SqlConnection(myDatabase.connectionString))
            {
                // Define SQL Command
                SqlCommand deleteData = new SqlCommand(deleteStatement, Con);

                // Assign Parameters
                deleteData.Parameters.AddWithValue("@ID", ID);

                // Opens Connection to DB
                Con.Open();

                // Executes SQL Command - Will return how many rows were effected
                int returnValue = deleteData.ExecuteNonQuery();

                // Closes Connection to DB
                Con.Close();

                if (returnValue == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string CountEntries()
        {
            // Define queryString
            string queryString = "SELECT COUNT(ID) FROM GOLF";

            using (SqlConnection Con = new SqlConnection(myDatabase.connectionString))
            {
                // Define SQL Command
                SqlCommand Command = new SqlCommand(queryString, Con);

                // Open DB Connection
                Con.Open();

                // Run SQL Command
                string result = Command.ExecuteScalar().ToString();

                // Close DB Connection
                Con.Close();

                // Return result
                return result;
            }
        }
    }
}
