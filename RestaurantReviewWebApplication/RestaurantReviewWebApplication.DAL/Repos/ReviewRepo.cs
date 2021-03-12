using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL.Repos
{
    public class ReviewRepo : BaseRepo, IRepo<Review>
    {
        public ReviewRepo(RestaurantReviewAppDbContext context) : base(context)
        {

        }

        public async Task Create(Review entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAll()
        {
            var restaurantReviewAppDbContext = _context.Reviews.Include(r => r.Author);
            return await restaurantReviewAppDbContext.ToListAsync();
        }

        public async Task<Review> GetById(int id)
        {
             return await _context.Reviews
               .Include(r => r.Author)
               .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(Review entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
