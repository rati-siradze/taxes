namespace Taxes.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Taxes.Data.TaxesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Taxes.Data.TaxesContext context)
        {
        }
    }
}
