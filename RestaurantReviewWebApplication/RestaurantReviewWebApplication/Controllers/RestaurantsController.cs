using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.DAL;
using RestaurantReviewWebApplication.DAL.DBO;
using RestaurantReviewWebApplication.DAL.Repositories;
using RestaurantReviewWebApplication.Models;

namespace RestaurantReviewWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRepository<Restaurant> _restaurantRepo;

        public RestaurantsController(IRepository<Restaurant> restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
         
            return await _restaurantRepo.GetAll();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantRepo.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

           

            try
            {
                await _restaurantRepo.Update(restaurant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_restaurantRepo.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _restaurantRepo.Create(restaurant);

            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
        {
            var restaurant = await _restaurantRepo.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }


            await _restaurantRepo.Delete(id);

            return NoContent();
        }

        
    }
}
