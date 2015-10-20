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

                    string sqlSelectString = "SELECT userid, fromAddress, toAddress, pickupDate, pickupTime, status, rideGroup from [RideRequests] where status = 1";
                    command = new SqlCommand(sqlSelectString, connection);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RideRequest rideRequest = new RideRequest();
                        rideRequest.UserID = reader[0].ToString();
                        rideRequest.OriginAddress = reader[1].ToString();
                        rideRequest.DestinationAddress = reader[2].ToString();
                        rideRequest.PickupDate = Convert.ToString(reader[3]);
                        rideRequest.PickupTime = Convert.ToString(reader[4]);
                        rideRequest.Status = Convert.ToInt32(reader[5].ToString());
                        //rideRequest.RideGroup = Convert.ToInt32(reader[6]);

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
    }
}