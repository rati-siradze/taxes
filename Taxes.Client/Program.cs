using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using Taxes.Client.Properties;

namespace Taxes.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread.Sleep(3000);

            Console.WriteLine("Taxes service examples..");

            var client = new RestClient(WebConfigurationManager.AppSettings.Get("ServiceUrl"));


            Console.WriteLine("Importing taxes from batch files");

            var importBatchRequest = new RestRequest("/taxes/import", Method.PUT);

            importBatchRequest.AddParameter("application/text", File.ReadAllBytes(Resources.taxes), ParameterType.RequestBody);

            //importBatchRequest.AddFile("taxes", File.ReadAllBytes(Resources.taxes), "taxes");

            client.Execute(importBatchRequest);


            Console.WriteLine("Imported");
            Console.ReadKey();
        }
    }
}
