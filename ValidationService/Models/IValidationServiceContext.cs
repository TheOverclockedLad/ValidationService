namespace ValidationService.Models
{
    public interface IValidationServiceContext : System.IDisposable
    {
        System.Data.Entity.DbSet<CreditCard> CreditCards { get; }
        int SaveChanges();
        void MarkAsModified(CreditCard creditCard);
    }
}