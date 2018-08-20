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

            Console.WriteLine("Taxes service examples..");

            var client = new RestClient(WebConfigurationManager.AppSettings.Get("ServiceUrl"));

            Console.WriteLine("Add single tax");

            var request = new RestRequest("/taxes/add", Method.PUT);

            request.AddParameter("application/json", new { }, ParameterType.RequestBody);

            request.AddFile("taxes", File.ReadAllBytes(Resources.taxes), "taxes");

            client.Execute(request);
            Console.WriteLine("Imported");
            Console.ReadKey();
        }
    }
}
