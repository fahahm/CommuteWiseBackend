using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CommuteWise.Model;

namespace CommuteWise.DAL
{
    public class RideOfferDAL
    {
        List<RideOffer> rideOffersList;
        private SqlConnection connection;
        private SqlCommand command;


        // DAL objects
        UserDAL userDAL = new UserDAL();

        public RideOfferDAL() { }
        
        public List<RideOffer> GetActiveOffers(Int64 requestRecID)
        {
            try
            {
                using (connection)
                {
                    rideOffersList = new List<RideOffer>();
                    connection = new SqlConnection(DAL.ConnectionString);

                    string sqlSelectString = "SELECT RideRequestRecID, DriverUserID, Notes, Status from [RideOffers] where Status in (1, 2) and RideRequestRecID = " + requestRecID;
                    command = new SqlCommand(sqlSelectString, connection);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RideOffer rideOffer = new RideOffer();
                        User user = new User();
                        rideOffer.RideRequestRecID = Convert.ToInt64(reader[0]);
                        rideOffer.DriverUserID = reader[1].ToString();
                        rideOffer.Notes = reader[2].ToString();
                        rideOffer.Status = Convert.ToInt32(reader[3]);

                        user = userDAL.GetUser(rideOffer.DriverUserID);
                        rideOffer.Driver = user;

                        rideOffersList.Add(rideOffer);
                    }

                    command.Connection.Close();
                    return rideOffersList;
                }
            }
            catch (Exception ex)
            {
                // err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public bool MakeOffer(Int64 requestRecID, string driverID, string notes)
        {
            bool isInserted;

            try
            {
                using (connection)
                {
                    connection = new SqlConnection(DAL.ConnectionString);
                    Int64 nextRecID = getNextRecID();

                    string sqlSelectString = "INSERT into [RideOffers] (RideRequestRecID, DriverUserID, Notes, Status) values("
                                                 + requestRecID + ",'"
                                                 + driverID + "','"
                                                 + notes + "',"
                                                 + nextRecID+")";
                                                 
                                                                                              

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

        public bool AcceptOffer(RideOffer rideOffer)
        {
            bool isAccepted = false;

            return isAccepted;
        }

        private Int64 getNextRecID()
        {
            Int64 nextRecID = 0;

            try
            {
                using (connection)
                {
                    connection = new SqlConnection(DAL.ConnectionString);

                    string sqlSelectString = "SELECT count(RideRequestRecID) from [RideOffers]";
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