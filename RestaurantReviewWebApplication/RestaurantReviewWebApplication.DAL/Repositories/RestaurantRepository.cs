using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL.Repositories
{
    public class RestaurantRepository : BaseRepository, IRepository<Restaurant>
    {
        
        public RestaurantRepository(RestaurantReviewWebApplicationDbContext context) : base(context)
        {

        }

        public async Task Create(Restaurant entity)
        {
            _context.Restaurants.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }

        public async Task<List<Restaurant>> GetAll()
        {
            return await _context.Restaurants.ToListAsync();

        }

        public async Task<Restaurant> GetById(int id)
        {
                               
            return await _context.Restaurants.FindAsync(id);
        }

        public async Task Update(Restaurant entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    
    }
}
