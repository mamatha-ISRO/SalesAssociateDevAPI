using SalesAssociate.Models.ViewModels;
using SalesAssociate.Models.Entities;
using SalesAssociate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SalesAssociate.Services.Services.Interfaces;


namespace SalesAssociate.Services.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _uow;

        public CarService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CarVM> Create(CarAddVM src)
        {
            // Create the new Car entity
            var newEntity = new Car(src);

            // Have the repository create the new game
            _uow.Cars.Create(newEntity);
            await _uow.SaveAsync();

            // Create the CarVM we want to return to the client
            var model = new CarVM(newEntity);

            // Return a CarVM
            return model;
        }

        public async Task<List<CarVM>> GetAll()
        {
            // Get the Car entities from the repository
            var results = await _uow.Cars.GetAll();

            // Build the CarVM view models to return to the client
            var models = results.Select(car => new CarVM(car)).ToList();

            // Return the carVMs
            return models;
        }
        //public async Task<List<CarVM>> GetCarsByMake(string make)
        //{
        //    var query = _uow.Cars;

        //    // IQueryable<CarVM> query = (IQueryable<CarVM>)await _uow.Cars.ToListAsync();
           


        //    if (make != null)
        //    {
               
        //        query = query.Where(car => car.Make == make);
        //    }
           

        //    }

        //    return (List<CarVM>)query;
        //}

        public async Task<CarVM> GetById(Guid id)
        {
            // Get the requested Game entity from the repository
            var result = await _uow.Cars.GetById(id);

            // Create the GameVM we want to return to the client
            var model = new CarVM(result);

            // Return a 200 response with the GameVM
            return model;
        }

        public async Task<CarVM> Update(CarUpdateVM src)
        {
            // Get the existing entity
            var entity = await _uow.Cars.GetById(src.Id);

            // Perform the update
            entity.Id = src.Id;
            entity.Make = src.Make;
            entity.Model = src.Model;
            entity.Cost = src.Cost;
            entity. MSRP = src.MSRP;
            entity.Color = src.Color;
            entity.CarType = src.CarType;

            // Have the repository update the Car
            _uow.Cars.Update(entity);
            await _uow.SaveAsync();

            // Create the CarVM we want to return to the client
            var model = new CarVM(entity);

            // Return a 200 response with the CarVM
            return model;
        }

        public async Task Delete(Guid id)
        {
            // Get the existing entity
            var entity = await _uow.Cars.GetById(id);

            // Tell the repository to delete the requested Car entity
            _uow.Cars.Delete(entity);
            await _uow.SaveAsync();
        }
    }

}

