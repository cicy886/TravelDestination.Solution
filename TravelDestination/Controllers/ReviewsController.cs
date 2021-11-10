using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDestination.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelDestination.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelDestinationContext _db;

    public ReviewsController(TravelDestinationContext db)
    {
      _db = db;
    }
    // GET api/reviews
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> Get(string destination, string country, string city, int rating)
    {
      var query = _db.Reviews.AsQueryable();

      if (destination != null)
      {
        query = query.Where(entry => entry.Destination == destination);
      }
      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }
      if (rating != 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      } 
      
      return await query.ToListAsync();
    }

    // // Get most popular destination
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Review>>> MostPopularDestination()
    // {
      
    // }

    // GET api/reviews
    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }
      return review;
    }

    // POST api/animals
    [HttpPost]
    public async Task<ActionResult<Review>> Post(Review review)
    {
      _db.Reviews.Add(review);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
    }
    // PUT: api/Animals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Review review)
    {
      if (id != review.ReviewId)
      {
        return BadRequest();
      }

      _db.Entry(review).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ReviewExists(id))
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
    private bool ReviewExists(int id)
    {
      return _db.Reviews.Any(e => e.ReviewId == id);
    }
    
    // DELETE: api/Reviews/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }

      _db.Reviews.Remove(review);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    //Get api/reviews/random
    [HttpGet("random")]
    public ActionResult<Review> Get()
    {
      int count = _db.Reviews.Count();
      int index = new Random().Next(count);
      return _db.Reviews.Skip(index).FirstOrDefault();
    } 
  }
}