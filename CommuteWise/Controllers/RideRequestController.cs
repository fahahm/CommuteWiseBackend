
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
        // API to get all Active requests
        public List<RideRequest> Get()
        {
            return new RideRequestDAL().GetActiveRideRequests();
        }

        // API to get the Request details record from Request Rec ID.
        public RideRequest Get(Int64 requestRecID)
        {
            return new RideRequestDAL().GetRequestDetails(requestRecID);
        }

        // API to create a ride request.
        public HttpResponseMessage PostRideRequest([FromBody]RideRequest rideRequest)
        {
            RideRequestDAL rideRequestDal = new RideRequestDAL();
            rideRequestDal.insert(rideRequest);

            var response = Request.CreateResponse<RideRequest>(HttpStatusCode.Created, rideRequest);

            //string uri = Url.Link("DefaultApi", new { id = item.Id });
            //response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
