using System;

namespace EBikeRentalsApp.Models
{
    public class RentalModel
    {
        public int ID { get; set; }

        public BikeModel Bike { get; set; }

        public CustomerModel Customer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StopDate { get; set; }

        public InvoiceModel Invoice { get; set; }
    }
}
