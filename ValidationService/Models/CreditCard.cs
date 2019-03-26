namespace ValidationService.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Index(IsUnique = true)]
        public long Number { get; set; }

        public System.DateTime ExpiryDate { get; set; }
    }
}