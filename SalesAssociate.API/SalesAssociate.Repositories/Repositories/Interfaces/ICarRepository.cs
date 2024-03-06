using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAssociate.Models.Entities;


namespace SalesAssociate.Repositories.Repositories.Interfaces
{
    public interface ICarRepository
    {
        void Create(Car entity);         // Create a new car
        Task<Car> GetById(Guid id);      // Get a single existing car by Id
        Task<List<Car>> GetAll();        // Get all of the cars
        //Task<List<Car>> GetCarsByMake(string make);        // Get all cars by Make
        void Update(Car entity);         // Update an existing car
        void Delete(Car entity);         // Delete a car detail
    }
}
