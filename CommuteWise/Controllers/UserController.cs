using CommuteWise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommuteWise.DAL;

namespace CommuteWise.Controllers
{
    public class UserController : ApiController
    {        
        public User Get(string userId)
        {
            return new UserDAL().GetUser(userId);            
        }
        
        public HttpResponseMessage PostUser([FromBody]User user)
        {
            UserDAL userDal = new UserDAL();
            userDal.insert(user);

            var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);

            //string uri = Url.Link("DefaultApi", new { id = item.Id });
            //response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
