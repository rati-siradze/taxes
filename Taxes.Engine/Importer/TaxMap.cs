using CsvHelper.Configuration;
using Taxes.Data.Entities;

namespace Taxes.Engine.Importer
{
    public sealed class TaxMap : CsvClassMap<Tax>
    {
        public TaxMap()
        {
            Map(x => x.City).Index(1);
            Map(x => x.Type).Index(2);
            Map(x => x.Rate).Index(3);
        }
    }
}
