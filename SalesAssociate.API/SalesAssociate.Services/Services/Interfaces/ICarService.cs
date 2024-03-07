using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAssociate.Models.ViewModels;
namespace SalesAssociate.Services.Services.Interfaces
{
    public interface ICarService 
    {
        
        Task<CarVM> Create(CarAddVM src);     // Create a new car
        Task<CarVM> GetById(Guid id);          // Get a single existing car by Id
        Task<List<CarVM>> GetAll();            // Get all of the cars
       // Task<List<CarVM>> GetCarsByMake(string make);            // Get all of the cars with make
        Task<CarVM> Update(CarUpdateVM src);  // Update an existing car
        Task Delete(Guid id);                   // Delete a car
    }
}

