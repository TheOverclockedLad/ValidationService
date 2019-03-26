namespace ValidationService.Models
{
    public class CreditCard
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.Column(Order = 0)]
        public long Number { get; set; }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.Column(Order = 1)]
        public System.DateTime ExpiryDate { get; set; }
    }
}