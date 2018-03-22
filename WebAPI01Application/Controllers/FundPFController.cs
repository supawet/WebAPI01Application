using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;

using System.Collections;
using WebAPI01Application.Models;

namespace WebAPI01Application.Controllers
{
    //[AuthenticationFilter]

    [RoutePrefix("api/FundPF")]
    public class FundPFController : ApiController
    {
        // GET: api/NAV
        /* old
        public IEnumerable<string> Get()
        {
            return new string[] { "fundcode1", "1" };
        }
        */
        /// <summary>
        /// Get all NAV
        /// </summary>
        /// <returns></returns>
 
        [Route("")]
        public ArrayList Get()
        {
            FundPFPersistance fp = new FundPFPersistance();
            if (fp == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return fp.getFundPFs();
        }

        /// <summary>
        /// Get specific NAV by date
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET: api/NAV/5
        /*
        public NAV Get(int id)
        {
            NAV nav = new NAV();
            nav.Id = id;
            nav.PORTCODE = "BFIX";
            //nav.TRAN_DATE = DateTime.Parse("06/12/1977").ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("en-US"));
            nav.TRAN_DATE = DateTime.Parse("06/12/1977");
            nav.NAV_BF_FEE = 2.3;
            nav.NAV_AMOUNT = 2.4;
            nav.NAV_PER_UNIT = 2.5;
            nav.UNIT_AMOUNT = 2.6;
            nav.OFFER_PRICE = 2.7;
            nav.BID_PRICE = 2.8;
            nav.Flag = 1;
            return nav;
        }
        */

        [Route("{navDate}")]
        public ArrayList Get(string navDate)
        {
            FundPFPersistance fp = new FundPFPersistance();
            if (fp == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return fp.getFundPFDate(navDate);
        }

        // POST: api/NAV
        //public HttpResponseMessage Post([FromBody]NAV value)
        public void Post([FromBody]FundPF value)
        {
            /*
            NAVPersistance np = new NAVPersistance();
            long id;
            id = np.saveNAV(value); 
            value.Id = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri,string.Format("nav/{0}",id));
            return response;
            */
        }

        // PUT: api/FundPF/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FundPF/5
        public void Delete(int id)
        {
        }
    }
}
