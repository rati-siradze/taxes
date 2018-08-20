using System;
using Taxes.Data.Entities;

namespace Taxes.Api.Models
{
    public class AddTaxRequest
    {
        public string City { get; set; }
        public TaxType Type { get; set; }
        public float Rate { get; set; }
    }
}