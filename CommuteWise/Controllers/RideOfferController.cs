using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommuteWise.Model;
using CommuteWise.DAL;

namespace CommuteWise.Controllers
{
    public class RideOfferController : ApiController
    {
        // API to get all Active offers associated with the request
        public List<RideOffer> Get(Int64 requestRecID)
        {
            return new RideOfferDAL().GetActiveOffers(requestRecID);
        }

        // API to create a ride request.
        public HttpResponseMessage PostAcceptOffer([FromBody]RideOffer rideOffer)
        {
            RideOfferDAL rideOfferDal = new RideOfferDAL();
            //rideOfferDal.acceptOffer(rideOffer);
            HttpResponseMessage response; 
           
            if (rideOfferDal.AcceptOffer(rideOffer))
            {
                response = Request.CreateResponse<RideOffer>(HttpStatusCode.Accepted, rideOffer);        
            }else
            {
                response = Request.CreateResponse<RideOffer>(HttpStatusCode.Conflict, rideOffer);        
            }
            

            //string uri = Url.Link("DefaultApi", new { id = item.Id });
            //response.Headers.Location = new Uri(uri);
            return response;
        }

        // API to create a ride Offer.
        public HttpResponseMessage PostCreateOffer(Int64 requestRecID, string driverID, string notes)
        {
            RideOfferDAL rideOfferDal = new RideOfferDAL();            
            HttpResponseMessage response;

            if (rideOfferDal.MakeOffer(requestRecID, driverID, notes))
            {
                response = Request.CreateResponse(HttpStatusCode.Accepted, requestRecID);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Conflict, requestRecID);
            }

            //string uri = Url.Link("DefaultApi", new { id = item.Id });
            //response.Headers.Location = new Uri(uri);
            return response;
        }
    
    }
}
