/*
    This file is what makes a Web API what it is.
*/
using System;
using System.Linq;
using System.Net;
using System.Web.Http; // RoutePrefixAttribute(), ApiController
using System.Net.Http;
using IdeallyConnectedWebApi_pureNetFramework.Models;
//using System.Web.Mvc;  // Controller
using System.Collections.Generic;

namespace IdeallyConnectedWebApi_pureNetFramework.API
{
    [System.Web.Http.RoutePrefix("api")]
    public class DataApiController : ApiController 
    {
    
        [HttpGet]
        [Route("users")]
        public HttpResponseMessage GetUsers(HttpRequestMessage request)
        {
            var users = DataFactory.GetUsers();

            return request.CreateResponse<ApplicationUser[]>(HttpStatusCode.OK, users.ToArray());
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