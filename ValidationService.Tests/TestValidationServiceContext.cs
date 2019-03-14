namespace ValidationService.Tests
{
    class TestStoreAppContext : Models.IValidationServiceContext
    {
        public System.Data.Entity.DbSet<Models.CreditCard> CreditCards { get; set; }

        public TestStoreAppContext() { this.CreditCards = new TestCreditCardDbSet(); }

        public int SaveChanges() { return 0; }

        public void MarkAsModified(Models.CreditCard creditCard) { }

        public void Dispose() { }
    }
}