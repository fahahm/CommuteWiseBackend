using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommuteWise.Model
{
    public class RideRequest
    {    
        private string userId;
        private string originAddress;
        private string destinationAddress;
        private string pickupDate;
        private string pickupTime;
        private int status;
        private int rideGroup;

        public RideRequest() { }

        /// <summary>
        /// Property User ID
        /// </summary>
        public string UserID
        {
            get { return userId; }
            set { userId = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public string OriginAddress
        {
            get { return originAddress; }
            set { originAddress = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public string DestinationAddress
        {
            get { return destinationAddress; }
            set { destinationAddress = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public string PickupDate
        {
            get { return pickupDate; }
            set { pickupDate = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public string PickupTime
        {
            get { return pickupTime; }
            set { pickupTime = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Property 
        /// </summary>
        public int RideGroup
        {
            get { return rideGroup; }
            set { rideGroup = value; }
        }

    }
}