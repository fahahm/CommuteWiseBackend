using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CommuteWise.Model;

namespace CommuteWise.DAL
{
    public class RideRequestDAL
    {
        private SqlConnection   connection;
        private SqlCommand      command;
        private static List<RideRequest> requestList;

        // DAL objects
        UserDAL userDAL = new UserDAL();

        public RideRequestDAL()
        { }

        /// <summary>
        /// Method - Get list of all users
        /// </summary>
        /// <returns>Employee</returns>
        public List<RideRequest> GetActiveRideRequests()
        {
            try
            {
                using (connection)
                {
                    requestList = new List<RideRequest>();
                    connection = new SqlConnection(DAL.ConnectionString);

                    string sqlSelectString = "SELECT userid, fromAddress, toAddress, pickupDate, pickupTime, status, recID from [RideRequests] where status = 1";
                    command = new SqlCommand(sqlSelectString, connection);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RideRequest rideRequest = new RideRequest();
                        User user = new User();   
                        rideRequest.UserID = reader[0].ToString();
                        rideRequest.OriginAddress = reader[1].ToString();
                        rideRequest.DestinationAddress = reader[2].ToString();
                        rideRequest.PickupDate = Convert.ToString(reader[3]);
                        rideRequest.PickupTime = Convert.ToString(reader[4]);
                        rideRequest.Status = Convert.ToInt32(reader[5].ToString());
                        rideRequest.RecID = Convert.ToInt64(reader[6]);
                        
                        user = userDAL.GetUser(rideRequest.UserID);
                        rideRequest.Requestor = user;                            
                        
                        requestList.Add(rideRequest);
                    }
                    
                    command.Connection.Close();
                    return requestList;
                }
            }
            catch (Exception ex)
            {
                // err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public RideRequest GetRequestDetails(Int64 requestRecID)
        {
            RideRequest rideRequest = new RideRequest();
            User user = new User();                       
            try
            {
                using (connection)
                {                    
                    connection = new SqlConnection(DAL.ConnectionString);

                    string sqlSelectString = "SELECT userid, fromAddress, toAddress, pickupDate, pickupTime, status, recID from [RideRequests] where recID = "+ requestRecID;
                    command = new SqlCommand(sqlSelectString, connection);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {                        
                        rideRequest.UserID = reader[0].ToString();
                        rideRequest.OriginAddress = reader[1].ToString();
                        rideRequest.DestinationAddress = reader[2].ToString();
                        rideRequest.PickupDate = Convert.ToString(reader[3]);
                        rideRequest.PickupTime = Convert.ToString(reader[4]);
                        rideRequest.Status = Convert.ToInt32(reader[5].ToString());
                        rideRequest.RecID = Convert.ToInt64(reader[6]);
                    }

                    user = userDAL.GetUser(rideRequest.UserID);
                    rideRequest.Requestor = user;
                    command.Connection.Close();
                    return rideRequest;
                }
            }
            catch (Exception ex)    
            {
                // err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public bool insert(RideRequest rideRequest)
        {
            bool  isInserted;            

            try
            {
                using (connection)
                {                    
                    connection = new SqlConnection(DAL.ConnectionString);
                    Int64 nextRecID = getNextRecID();

                    string sqlSelectString = "INSERT into [RideRequests] (Userid, FromAddress, ToAddress, PickupDate, PickupTime, Status, RecID) values('"
                                                + rideRequest.UserID + "','"
                                                + rideRequest.OriginAddress + "','"
                                                + rideRequest.DestinationAddress + "','"
                                                + rideRequest.PickupDate + "','"
                                                + rideRequest.PickupTime + "', 1, "+nextRecID+")";
                                                                                              

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

        private Int64 getNextRecID()
        {
            Int64 nextRecID = 0;

            try
            {
                using (connection)
                {
                    connection = new SqlConnection(DAL.ConnectionString);

                    string sqlSelectString = "SELECT max(recID) from [RideRequests]";
                    command = new SqlCommand(sqlSelectString, connection);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        nextRecID = Convert.ToInt64(reader[0]) + 1;                      
                    }
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                // err.ErrorMessage = ex.Message.ToString();
                throw;
            }

            return nextRecID;
        }
    }

}