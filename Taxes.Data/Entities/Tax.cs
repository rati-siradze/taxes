using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxes.Data.Entities
{
    public class Tax
    {
        public Tax()
        {

        }

        public Tax(string city, TaxType type, float rate)
        {
            City = city;
            Type = type;
            Rate = rate;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public TaxType Type { get; set; }
        public string City { get; set; }
        public float Rate { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTill { get; set; }
        public DateTime Created { get; set; }
    }
}
