using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf2020
{
    class CRUD_Handler
    {
        CRUD myCRUD = new CRUD();
        public bool CreateEntryHandler(string[] EntryArr)
        {
            // Check if EntryArr has correct ammount of items (10)
            if (EntryArr.Length == 10)
            {
                // Loop through EntryArr checking if data is not Empty
                for (int i = 0; i < EntryArr.Length; i++)
                {
                    if (EntryArr[i] == String.Empty)
                    {
                        // If ANY Array items are empty return false
                        return false;
                    }
                }

                if (myCRUD.CreateEntry(EntryArr))
                {
                    // Returns true if CreateEntry successfully runs
                    return true;
                }
                else
                {
                    // Returns false if CreateEntry unsuccessfully runs
                    return false;
                }
            }

            else
            {
                // Returns false if EntryArr does not have 10 items
                return false;
            }
        }

        public bool UpdateEntryHandler(string[] UpdateArr)
        {
            // Check if EntryArr has correct ammount of items (10)
            if (UpdateArr.Length == 11)
            {
                // Loop through EntryArr checking if data is not Empty
                for (int i = 0; i < UpdateArr.Length; i++)
                {
                    if (UpdateArr[i] == String.Empty)
                    {
                        // If ANY Array items are empty return false
                        return false;
                    }
                }

                if (myCRUD.UpdateEntry(UpdateArr))
                {
                    // Returns true if UpdateEntry successfully runs
                    return true;
                }
                else
                {
                    // Returns false if UpdateEntry unsuccessfully runs
                    return false;
                }
            }
            else
            {
                // Returns false if UpdateArr does not have 10 items
                return false;
            }
        }

        // This is completely unnecessary but I did not want to link the CRUD.cs directly to Form1
        public bool DeleteEntryHandler(int ID)
        {
            if (myCRUD.DeleteEntry(ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
