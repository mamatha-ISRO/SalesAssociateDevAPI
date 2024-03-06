using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAssociate.Models.Entities;
using SalesAssociate.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SalesAssociate.Repositories.Repositories
{
    public class CarRepository : ICarRepository

    {
        private readonly SAApplicationDbContext _context;

        public CarRepository(SAApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Car entity)
        {
            // Add the created date
           // entity.Created = DateTime.UtcNow;

            // Perform the add in memory
            _context.Add(entity);
        }

        public void Delete(Car entity)
        {
            // Delete the entity
            _context.Remove(entity);
        }

        public async Task<List<Car>> GetAll()
        {
            // Get all the entities
            var results = await _context.Cars.ToListAsync();

            // Return the retrieved entities
            return results;
            
        }

        public async Task<Car> GetById(Guid id)
        {
            // Get the entity
            var result = await _context.Cars.FirstAsync(car => car.Id == id);

            // Return the retrieved entity
            return result;
        }

        //public async Task<List<Car>> GetCarsByMake(string make)
        //{
        //    // Get all the entities
        //     var results = await _context.Cars.Where(car => car.Make.ToLower() == make).ToListAsync();

        //    // Return the retrieved entities
        //    return   results;
        //}

        public void Update(Car entity)
        {
            // Update the entity
            _context.Update(entity);
        }
    }
}
