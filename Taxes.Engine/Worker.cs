using System;
using System.Linq;
using Taxes.Data;
using Taxes.Data.Entities;
using Taxes.Engine.Importer;

namespace Taxes.Engine
{
    public class Worker : ITaxWorker
    {
        private readonly TaxesContext db;

        public Worker(TaxesContext taxes)
        {
            this.db = taxes;
        }

        public void Add(Tax tax)
        {
            db.Taxes.Add(tax);
            db.SaveChanges();
        }

        public float GetRate(string city, DateTime date)
        {
            var tax = db.Taxes.Where(x => x.City == city
                                             && x.EffectiveFrom <= date
                                             && (x.EffectiveTill == null || x.EffectiveTill >= date))
                                            .OrderBy(x => x.Type)
                                            .FirstOrDefault();
                
            if (tax != null)
                return tax.Rate;
            throw new TaxNotFoundException();
        }

        public void Import(byte[] taxesData)
        {
            var taxesImporter = new TaxImporter(db);
            taxesImporter.Import(taxesData);
        }
    }
}
