using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SalesAssociate.Models.ViewModels;

namespace SalesAssociate.Models.Entities
{
    public class Car
    {
        // Default constructor to allow creation of an empty Car entity
        public Car()
        {

        }

        // Constructor used to create a new car from a CarAddVM model
        public Car(CarAddVM src)
        {
            Id = src.Id;
            Make = src.Make;
            Model = src.Model;
            Cost = src.Cost;
            MSRP = src.MSRP;
            Color = src.Color;
            CarType = src.CarType;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Make { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public string Color { get; set; } = string.Empty;

        [Required]
        public string CarType { get; set; } = string.Empty;

        //  [Required]
        // public DateTime Created { get; set; }

        [Required]
        public decimal Cost { get; set; }
        public decimal MSRP { get; set; }
    }
}
