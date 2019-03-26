namespace ValidationService.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ValidationServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ValidationServiceContext context)
        {
            context.CreditCards.AddOrUpdate(new Models.CreditCard[] {
                new Models.CreditCard() { Number = 345981456357981, ExpiryDate = new System.DateTime(2019, 12, 01) },
                new Models.CreditCard() { Number = 3456789000001234, ExpiryDate = new System.DateTime(2019, 12, 01) },
                new Models.CreditCard() { Number = 4444999910102345, ExpiryDate = new System.DateTime(2016, 10, 01) },
                new Models.CreditCard() { Number = 5105999912200110, ExpiryDate = new System.DateTime(2017, 02, 01) }
            });
        }
    }
}