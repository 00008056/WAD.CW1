using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.DAL;
using RestaurantReviewWebApplication.DAL.DBO;
using RestaurantReviewWebApplication.DAL.Repos;
using RestaurantReviewWebApplication.Models;

namespace RestaurantReviewWebApplication.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IRepo<Review> _reviewRepo;
        private readonly IRepo<Author> _authorRepo;

        public ReviewsController(IRepo<Review> reviewRepo, IRepo<Author> authorRepo)
        {
            _reviewRepo = reviewRepo;
            _authorRepo = authorRepo;
        }
        // GET: Reviews
        public async Task<IActionResult> Index()
        {          
            return View(await _reviewRepo.GetAll());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviewRepo.GetById(id.Value);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AuthorId"] = new SelectList(await _authorRepo.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rating,Content,AuthorId,WouldRecommend,DateAdded")] Review review)
        {
            if (ModelState.IsValid)
            {
                await _reviewRepo.Create(review);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(await _authorRepo.GetAll(), "Id", "FirstName", review.AuthorId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviewRepo.GetById(id.Value);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(await _authorRepo.GetAll(), "Id", "FirstName", review.AuthorId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rating,Content,AuthorId,WouldRecommend,DateAdded")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _reviewRepo.Update(review);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_reviewRepo.Exists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(await _authorRepo.GetAll(), "Id", "FirstName", review.AuthorId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviewRepo.GetById(id.Value);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _reviewRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
