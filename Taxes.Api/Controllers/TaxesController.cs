using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Taxes.Api.Models;
using Taxes.Data.Entities;
using Taxes.Engine;

namespace Taxes.Api.Controllers
{
    public class TaxesController : ApiController
    {
        private readonly ITaxWorker worker;

        public TaxesController(ITaxWorker worker)
        {
            this.worker = worker;
        }

        [HttpGet]
        [Route("Taxes/GetRate")]
        public HttpResponseMessage GetRate([FromUri]GetTaxRateRequest request)
        {
            if (request == null || !request.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK,  worker.GetRate(request.City, request.Date.Value));
        }

        [HttpPut]
        [Route("Taxes/Add")]
        public HttpResponseMessage Add([FromBody]AddTaxRequest request)
        {
            worker.Add(new Tax(request.City, request.Type, request.Rate));
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("Taxes/Edit")]
        public float Edit([FromBody]GetTaxRateRequest request)
        {
            return worker.GetRate(request.City, request.Date.Value);
        }

        [HttpPut]
        [Route("Taxes/Import")]
        public HttpResponseMessage Import()
        {
            HttpResponseMessage result = null;

            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];

                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }

                worker.Import(fileData);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
