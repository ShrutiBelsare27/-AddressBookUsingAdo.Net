using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookUsingAdo.Net
{
    public class AddressBookRepo
    {
        public static string connectionString = "Server = localhost; Database=address_book_services; Uid=root;Pwd=root;";
        MySqlConnection connection = new MySqlConnection(connectionString);
        public void checkConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("connection established");
                this.connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }


        public bool addNewContactToDataBase(AddressBookModel addressBookModel)
        {
            try
            {
                using (this.connection)
                {
                    MySqlCommand cmd = new MySqlCommand("sp_address", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(" P_FirstName", addressBookModel.FirstName);
                    cmd.Parameters.AddWithValue(" P_LastName", addressBookModel.LastName);
                    cmd.Parameters.AddWithValue(" P_Address", addressBookModel.Address);
                    cmd.Parameters.AddWithValue(" P_City", addressBookModel.City);
                    cmd.Parameters.AddWithValue(" P_State", addressBookModel.State);
                    cmd.Parameters.AddWithValue(" P_Zip", addressBookModel.Zip);
                    cmd.Parameters.AddWithValue(" P_PhoneNumber", addressBookModel.PhoneNumber);
                    cmd.Parameters.AddWithValue(" P_Email", addressBookModel.Email);
                    cmd.Parameters.AddWithValue(" P_AddressBookName", addressBookModel.AddressBookName);
                    cmd.Parameters.AddWithValue(" P_AddressBookType", addressBookModel.AddressBookType);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}