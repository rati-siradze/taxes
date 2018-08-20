using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Taxes.Api
{
    public class InternalErrorResult : IHttpActionResult
    {
        private string message;

        public InternalErrorResult(string message)
        {
            this.message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content  = new ObjectContent<string>(message, new JsonMediaTypeFormatter(), "application/json")
            };

            return Task.FromResult(response);
        }
    }
}