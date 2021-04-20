using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL.Repositories
{
    public class ReviewRepository : BaseRepository, IRepository<Review>
    {
        public ReviewRepository(RestaurantReviewWebApplicationDbContext context) : base(context)
        {

        }

        public async Task Create(Review entity)
        {
            _context.Reviews.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }

        public async Task<List<Review>> GetAll()
        {
            return await _context.Reviews.Include(a => a.Author).Include(r => r.Restaurant).ToListAsync();
        }

        public async Task<Review> GetById(int id)
        {
            return await _context.Reviews
                .Include(c => c.Author)
                .Include(d => d.Restaurant)
                .FirstOrDefaultAsync(c => c.Id == id);       
        }

        public async Task Update(Review entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
