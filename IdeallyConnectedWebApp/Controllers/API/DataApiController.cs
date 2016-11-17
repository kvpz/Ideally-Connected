using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeallyConnectedWebApp.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http; // HttpResponseMessage
//using System.Web.Mvc;
// RoutePrefix defines the initial URI segments for all the methods in the controller

namespace IdeallyConnectedWebApp.Controllers.API
{
    //[Route("api")]
    public class DataApiController : Controller
    {
        [HttpGet]
        [Route("analysis/list")]
        public HttpRequestMessage GetAnalysis () //HttpRequestMessage request)
        {
            
            List<int> temp = new List<int>()
            {
                1,2,3
            };
            HttpResponseMessage message = new HttpResponseMessage();
            HttpRequestMessage reqmessage = new HttpRequestMessage();
            //PartialViewResult result;
            JsonResult res = new JsonResult(temp);
            reqmessage.Properties.Add("teststring", 2);
            return reqmessage;
            //return message.Content(res);
            //return res;

        }

 
    }
}
