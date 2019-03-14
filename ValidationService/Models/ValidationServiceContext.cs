namespace ValidationService.Models
{
    public class ValidationServiceContext : System.Data.Entity.DbContext, IValidationServiceContext
    {
        public ValidationServiceContext() : base("name=ValidationServiceContext") { }

        public System.Data.Entity.DbSet<CreditCard> CreditCards { get; set; }

        public void MarkAsModified(CreditCard creditCard)
        {
            Entry(creditCard).State = System.Data.Entity.EntityState.Modified;
        }
    }
}