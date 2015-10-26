using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommuteWise.Model
{
    public class RideOffer
    {
        private Int64 rideRequestRecID; 
        private string driverUserID;
        private string notes;
        private int status;     

        // User information
        private User driver;

        public RideOffer() { }

        /// <summary>
        /// Property User ID
        /// </summary>
        public Int64 RideRequestRecID
        {
            get { return rideRequestRecID; }
            set { rideRequestRecID = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public string DriverUserID
        {
            get { return driverUserID; }
            set { driverUserID = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public User Driver
        {
            get { return driver; }
            set { driver = value; }
        }
    }
}