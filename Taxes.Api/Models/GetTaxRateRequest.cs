using System;

namespace Taxes.Api.Models
{
    public class GetTaxRateRequest
    {
        public string City { get; set; }
        public DateTime? Date { get; set; }

        public bool IsValid
        {
            get { return !string.IsNullOrEmpty(City) && Date.HasValue; }
        }
    }
}