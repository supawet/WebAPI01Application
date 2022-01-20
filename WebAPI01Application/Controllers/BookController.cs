using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Collections;
using WebAPI01Application.Models;

namespace WebAPI01Application.Controllers
{
    //[AuthenticationFilter]
    //[Authorize]

    [RoutePrefix("api/Book")]

    public class BookController : ApiController
    {
        [HttpGet]
        [ActionName("1")]
        public string GetFF(string id)
        {
            FundBookPersistence fb = new FundBookPersistence();
            if (fb == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return fb.getFundFactSheet(id);
        }

        [ActionName("2")]
        public string GetMU(string id)
        {
            FundBookPersistence fb = new FundBookPersistence();
            if (fb == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return fb.getMonthlyUpdate(id);
        }
    }
}
