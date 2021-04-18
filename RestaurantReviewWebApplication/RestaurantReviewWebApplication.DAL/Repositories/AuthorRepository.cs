using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL.Repositories
{
    class AuthorRepository : BaseRepository, IRepository<Author>
    {

        public AuthorRepository(RestaurantReviewWebApplicationDbContext context) : base(context)
        {

        }
        public async Task Create(Author entity)
        {
            _context.Authors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }

        public async Task<List<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task Update(Author entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
