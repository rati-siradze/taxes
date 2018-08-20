using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Taxes.Data;
using Taxes.Data.Entities;

namespace Taxes.Engine.Importer
{
    public class TaxImporter
    {
        private readonly TaxesContext db;
        private readonly CsvConfiguration csvConfiguration;

        public TaxImporter(TaxesContext taxes)
        {
            this.db = taxes;

            csvConfiguration = new CsvConfiguration();
            csvConfiguration.RegisterClassMap<TaxMap>();
            csvConfiguration.HasHeaderRecord = true;
            csvConfiguration.TrimFields = true;
            csvConfiguration.Delimiter = ";";
            csvConfiguration.SkipEmptyRecords = true;
            TypeConverterFactory.AddConverter<double>(new DoubleConverter());

        }

        public void Import(byte[] data)
        {
            var stream = new MemoryStream(data);
            
            var taxes = new List<Tax>();

            using (var csv = new CsvReader(new StreamReader(stream), csvConfiguration))
            {
                while (csv.Read())
                {
                    taxes.Add(csv.GetRecord<Tax>());
                }
            }

            SaveToDatabase(taxes);
        }

        private void SaveToDatabase(List<Tax> taxes)
        {
            db.Taxes.AddRange(taxes);
            db.SaveChanges();
        }
    }
}
