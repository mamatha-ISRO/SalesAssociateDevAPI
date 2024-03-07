using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAssociate.Services.Services.Interfaces;
using SalesAssociate.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SalesAssociate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // Create a new car
        [HttpPost]
        public async Task<ActionResult<CarVM>> Create([FromBody] CarAddVM data)
        {
            try
            {
                // Have the service create the new car
                var result = await _carService.Create(data);

                // Return a 200 response with the CarVM
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get a specific car by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<CarVM>> Get([FromRoute] Guid id)
        {
            try
            {
                // Get the requested car entity from the service
                var result = await _carService.GetById(id);

                // Return a 200 response with the CarVM
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Unable to retrieve the requested car" });
            }
        }
        // Get All cars in the listing
        [HttpGet]
        public async Task<ActionResult<List<CarVM>>> GetAll()
        {
            try
            {
                //Get the requested Car entity from the service
                var result = await _carService.GetAll();
                return Ok(result);
            }
            catch
            {;
                return BadRequest(new { message = "Unable to retrieve the request car" });
            }
        }
        //get by make 
        //[HttpGet("{Make}")]
        //public async Task<ActionResult<List<CarVM>>> GetbyMake(string make)
        //{
        //    try
        //    {
        //        //Get the requested Car entity from the service
        //        var result = await _carService.GetCarsByMake(make);
        //        return Ok(result);
        //    }
        //    catch
        //    {
        //        ;
        //        return BadRequest(new { message = "Unable to retrieve the request car" });
        //    }
        //}

        // Update a Car
        [HttpPut]
        public async Task<ActionResult<CarVM>> Update([FromBody] CarUpdateVM data)
        {
            try
            {
                // Update Car entity from the service
                var result = await _carService.Update(data);

                // Return a 200 response with the CarVM
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a Car
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                // Tell the repository to delete the requested car entity
                await _carService.Delete(id);

                // Return a 200 response
                return Ok();
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch
            {
                return BadRequest(new { message = "Unable to delete the requested car" });
            }
        }
    }
}
