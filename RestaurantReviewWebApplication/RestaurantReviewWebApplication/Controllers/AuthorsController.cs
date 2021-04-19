using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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
    public class AuthorsController : ControllerBase
    {
       
        private readonly IRepository<Author> _authorRepo;
        
       
        public AuthorsController(IRepository<Author> authorRepo)
        {          
            _authorRepo = authorRepo;
                
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            //return await _context.Authors.ToListAsync();
            var authors =  await _authorRepo.GetAll();
            return Ok(authors.Select(a => new AuthorDTO
            {
               
                FullName = a.FullName,
                Email = a.Email,
                BriefInfo = a.BriefInfo
            }));


        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            //var author = await _context.Authors.FindAsync(id);

            //if (author == null)
            //{
            //    return NotFound();
            //}

            //return author;
            var author = await _authorRepo.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            //_context.Entry(author).State = EntityState.Modified;
           
            
            try
            {
                //await _context.SaveChangesAsync();
                await _authorRepo.Update(author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_authorRepo.Exists(id))//!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            //_context.Authors.Add(author);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authorRepo.Create(author);

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            //var author = await _context.Authors.FindAsync(id);
            //if (author == null)
            //{
            //    return NotFound();
            //}

            //_context.Authors.Remove(author);
            //await _context.SaveChangesAsync();

            //return author;
            var author = await _authorRepo.GetById(id);
            if (author == null)
            {
                return NotFound();
            }


            await _authorRepo.Delete(id);

            return NoContent();
        }

        
    }

    internal interface IMapper
    {
    }
}
