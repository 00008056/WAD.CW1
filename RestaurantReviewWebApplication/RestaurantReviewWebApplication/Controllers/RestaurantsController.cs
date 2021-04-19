using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.DAL;
using RestaurantReviewWebApplication.DAL.DBO;
using RestaurantReviewWebApplication.DAL.Repositories;
using RestaurantReviewWebApplication.DTO;
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
        public async Task<ActionResult<IEnumerable<RestaurantListDTO>>> GetRestaurants()
        {
            //return await _context.Restaurants.ToListAsync();
            var restaurants = await _restaurantRepo.GetAll();
            return Ok(restaurants.Select(r => new RestaurantListDTO
            {           
                Name = r.Name,
                Image = r.Image
            })); 
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            //var restaurant = await _context.Restaurants.FindAsync(id);
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

           // _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                await _restaurantRepo.Update(restaurant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_restaurantRepo.Exists(id))//!RestaurantExists(id))
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
            //_context.Restaurants.Add(restaurant);
            //await _context.SaveChangesAsync();
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
            //var restaurant = await _context.Restaurants.FindAsync(id);
            //if (restaurant == null)
            //{
            //    return NotFound();
            //}

            //_context.Restaurants.Remove(restaurant);
            //await _context.SaveChangesAsync();
            var restaurant = await _restaurantRepo.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }


            await _restaurantRepo.Delete(id);

            return restaurant;
        }

       




    }
        

    }

