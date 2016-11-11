using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeallyConnectedWebApp.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http; // HttpResponseMessage
// RoutePrefix defines the initial URI segments for all the methods in the controller

namespace IdeallyConnectedWebApp.Controllers.API
{
    public class DataApiController
    {
        [HttpGet]
        [Route("list/analysis")]
        public ActionResult GetAnalysis () //HttpRequestMessage request)
        {
            List<int> temp = new List<int>()
            {
                1,2,3
            };
            
            JsonResult res = new JsonResult(temp);
            return res;


        }

 
    }
}
