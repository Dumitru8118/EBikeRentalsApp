using System;

namespace EBikeRentalsApp.Models
{
    public class BikeModel
    {
        public int BikeId { get; set; }
        public BikeTypesModel BykeType { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
