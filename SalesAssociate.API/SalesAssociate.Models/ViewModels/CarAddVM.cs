using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesAssociate.Models.ViewModels
{
    public class CarAddVM
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public string Make { get; set; } = string.Empty;

        [Required]
        public decimal Cost { get; set; }
        [Required]
        public decimal MSRP { get; set; }
        [Required]
        public string Color { get; set; } = string.Empty;

        [Required]
        public string CarType { get; set; } = string.Empty;
    }
}
