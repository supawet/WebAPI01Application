using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace WebAPI01Application.MessageHandlers
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        // "123ABC489HUUAB724" from test
        // "654FIABQ92VYZW34K" from BBLAM
        // "161ACJPBNK4876531" for siam square and "545RGJKD12QAC974" for BLA , "256DVH4789EAXZQ6" for Banpod
        // "486SQL9462UTVXK5" from iBusiness
        private string[] APIKeyToCheck = { "123ABC489HUUAB724", "654FIABQ92VYZW34K", "161ACJPBNK4876531", "545RGJKD12QAC974", "256DVH4789EAXZQ6", "486SQL9462UTVXK5" };

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> requestHeader;
            var checkAPIKeyExists = httpRequestMessage.Headers.TryGetValues("APIKey",out requestHeader);
            if (checkAPIKeyExists)
            {
                //if (requestHeader.FirstOrDefault().Equals(APIKeyToCheck))
                if (Array.Exists(APIKeyToCheck, element => element == requestHeader.FirstOrDefault()))
                {
                    validKey = true;
                }
            }

            if (!validKey)
            {
                return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
            }

            var response = await base.SendAsync(httpRequestMessage, cancellationToken);
            return response;
        }
    }
}