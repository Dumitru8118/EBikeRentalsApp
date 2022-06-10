using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBikeRentalsApp.Models
{
    public class BikeModel
    {
    
        public int id { get; set; }
     
        public int bikeTypes { get; set; }
  
        public DateTime register_date { get; set; }

    }
}
