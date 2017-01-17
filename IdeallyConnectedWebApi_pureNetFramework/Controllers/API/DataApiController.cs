/*
    This file is what makes a Web API what it is.
*/
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; // RoutePrefixAttribute(), ApiController
using IdeallyConnected.Models;
//using System.Web.Mvc;  // Controller
using System.Collections.Generic;

namespace IdeallyConnected.API
{
    [RoutePrefix("api")]
    public class DataApiController : ApiController 
    {
    
        [HttpGet]
        [Route("users")]
        public HttpResponseMessage GetUsers(HttpRequestMessage request)
        {
            var users = DataFactory.GetUsers();
            var context = new ApplicationDbContext();
            return request.CreateResponse<ApplicationUser[]>(HttpStatusCode.OK, context.Users.ToArray());
        }

        /*
        [Route("api/users")]
        public JsonResult GetPeople()
        {
            var people = new List<ApplicationUser>()
            {
                new ApplicationUser { UserName = "Kp13" }
            };
            return Json<List<ApplicationUser>>(people);
        }
        */
    }

    
}