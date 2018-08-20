using System.Data.Entity;
using Taxes.Data.Entities;

namespace Taxes.Data
{
    public class TaxesContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TaxesContext>(null);
        }

        public DbSet<Tax> Taxes { get; set; }
    }
}
