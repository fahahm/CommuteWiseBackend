
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommuteWise.DAL;
using CommuteWise.Model;

namespace CommuteWise.Controllers
{
    public class RideRequestController : ApiController
    {
        public List<RideRequest> Get()
        {
            return new RideRequestDAL().GetActiveRideRequests();
        }
    }
}
