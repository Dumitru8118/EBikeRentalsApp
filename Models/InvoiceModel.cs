namespace EBikeRentalsApp.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal VAT { get; set; }

        public decimal NetAmount { get; set; }

        public bool Paid { get; set; }
    }
}
