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
           // err = new ErrorHandler.ErrorHandler();            
        }

        /// <summary>
        /// Database SELECT - Get an employee
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public User GetUser(string userId)
        {
            try
            {
                if (userList == null)
                {
                    userList = GetUsers();
                }
                // enumerate through all employee list
                // and select the concerned employee
                foreach (User user in userList)
                {
                    if (user.UserID == userId)
                    {
                        return user;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                //err.ErrorMessage = ex.Message.ToString();
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

        /*public string GetException()
        {
            return err.ErrorMessage.ToString();
        }*/
    }
}
