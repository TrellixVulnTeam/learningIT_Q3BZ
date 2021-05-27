using Learning_IT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learning_IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly MyContext _context;

        public BadgesController(MyContext context)
        {
            _context = context;
        }
        // GET: api/<BadgesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Badge>>> Get()
        {
            return await _context.Badges.ToListAsync();
        }

        // GET api/<BadgesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Badge>> Get(int id)
        {
            var badge = await _context.Badges.FindAsync(id);

            if (badge == null)
            {
                return NotFound();
            }

            return badge;
        }
        // GET api/<BadgesController>/Get badge by course id
        [HttpGet("Course/{id}")]
        public ActionResult<Badge> GetBadgeByCourseId(int id)
        {
            List<Badge> badgesList = new List<Badge>();
            foreach (var item in _context.Badges)
            {
                badgesList.Add(item);
            }

            var badge = badgesList.Where(x => x.CourseId == id).FirstOrDefault();

            if (badge == null)
            {
                return NotFound();
            }

            return badge;
        }

        // POST api/<BadgesController>
        [HttpPost]
        public async Task<ActionResult<Badge>> Post([FromBody] Badge badge)
        {
            _context.Badges.Add(badge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBadge", new { id = badge.Id }, badge);
        }

        [HttpPost("/create-badge-user/{userId}")]
        public IActionResult CreateUserBadge(int userId)
        {

            _context.UserBadges.Add(new UserBadge
            {
                UserID = userId,
                BadgeId = 1
            });
            return Ok();
        }

        // PUT api/<BadgesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Badge badge)
        {
            if (id != badge.Id)
            {
                return BadRequest();
            }

            _context.Entry(badge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadgeExists(id))
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

        // DELETE api/<BadgesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var badge = await _context.Badges.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }

            _context.Badges.Remove(badge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BadgeExists(int id)
        {
            return _context.Badges.Any(e => e.Id == id);
        }
    }
}
