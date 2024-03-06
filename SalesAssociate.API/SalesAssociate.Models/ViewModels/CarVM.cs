using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssociate.Models.ViewModels
{
    public class CarVM
    {
        public CarVM() { }

        // Constructor for populating a new ListingVM from a Listing entity
        public CarVM(Entities.Car src)
        {
            Id = src.Id;
            Make = src.Make;
            Model = src.Model;
            Cost = src.Cost;
            MSRP = src.MSRP;
            Color = src.Color;
            CarType = src.CarType;
        }

        public Guid Id { get; set; }

        public string Make { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public string CarType { get; set; } = string.Empty;

        //public DateTime Created { get; set; }

        public decimal Cost { get; set; }
        public decimal MSRP { get; set; }
    }
}
