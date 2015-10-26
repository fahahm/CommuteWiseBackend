using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommuteWise.Model;

namespace CommuteWise.DAL
{
    public class UserDAL
    {
        private SqlConnection connection;        
        private SqlCommand command;        
        private static List<User> userList;
        
        //private ErrorHandler.ErrorHandler err;

        public UserDAL()
        {            
        }

        /// <summary>
        /// Database SELECT - Get a User
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public User GetUser(string userId)
        {
            User user = new User();
            try
            {
                using (connection)
                {                    
                    connection = new SqlConnection(DAL.ConnectionString);

                    string sqlSelectString = "SELECT firstname, lastname, userid, phone, streetaddress, zipcode, city, state, password from [User] where userid = '" + userId + "'";
                    command = new SqlCommand(sqlSelectString, connection);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {                        
                        user.FirstName = reader[0].ToString();
                        user.LastName = reader[1].ToString();
                        user.UserID = reader[2].ToString();
                        user.Phone = reader[3].ToString();
                        user.StreetAddress = reader[4].ToString();
                        user.ZipCode = reader[5].ToString();
                        user.City = reader[6].ToString();
                        user.State = reader[7].ToString();
                        user.Password = reader[8].ToString();
                    }
                    command.Connection.Close();
                    return user;
                }
            }
            catch (Exception ex)
            {
                // err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        /// <summary>
        /// Method - Get list of all users
        /// </summary>
        /// <returns>Employee</returns>
        private List<User> GetUsers()
        {
            try
            {
                using (connection)
                {
                    userList = new List<User>();

                    connection = new SqlConnection(DAL.ConnectionString);

                    string sqlSelectString = "SELECT firstname, lastname, userid, phone from [User]";
                    command = new SqlCommand(sqlSelectString, connection);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.FirstName = reader[0].ToString();
                        user.LastName = reader[1].ToString();
                        user.UserID = reader[2].ToString();
                        user.Phone = reader[3].ToString();
                        userList.Add(user);
                    }
                    command.Connection.Close();
                    return userList;
                }
            }
            catch (Exception ex)
            {
               // err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public bool insert(User user)
        {
            bool isInserted;

            try
            {
                using (connection)
                {
                    userList = new List<User>();

                    connection = new SqlConnection(DAL.ConnectionString);

                    string sqlSelectString = "INSERT into [User] (firstname, lastname, userid, password, phone, streetaddress, city, zipcode, state) values('"
                                                + user.FirstName + "','"
                                                + user.LastName + "','"
                                                + user.UserID + "','"
                                                + user.Password + "','"
                                                + user.Phone + "','"
                                                + user.StreetAddress + "','"
                                                + user.City + "','"
                                                + user.ZipCode + "','"
                                                + user.State+ "')";

                    command = new SqlCommand(sqlSelectString, connection);
                    command.Connection.Open();
                    int totalRowsAffected = command.ExecuteNonQuery();
       
                    command.Connection.Close();
                    isInserted = totalRowsAffected > 0;

                    return isInserted;
                }
            }
            catch (Exception ex)
            {
                // err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }


        /*public string GetException()
        {
            return err.ErrorMessage.ToString();
        }*/
    }
}
