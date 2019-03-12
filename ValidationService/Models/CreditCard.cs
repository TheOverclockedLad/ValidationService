namespace ValidationService.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Range(15, 16, ErrorMessage = "The number must contain either 15 or 16 digits")]
        public long Number { get; set; }
        public System.DateTime ExpiryDate { get; set; }
    }
}