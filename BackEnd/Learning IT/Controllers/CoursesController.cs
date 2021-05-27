using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Learning_IT.Models;

namespace Learning_IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly MyContext _context;

        public CoursesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        //GET: Cursuri dupa level
        [HttpGet("Level/{Level}")]
        public  ActionResult<IEnumerable<Course>> GetCourseByLevel(string Level)
        {
            List<Course> courses = new List<Course>();
            foreach (var item in _context.Courses)
            {
                if (item.Level == Level)
                {
                    courses.Add(item);
                }
            }
            return courses;
        }

        //GET: Badge dupa CourseId
        [HttpGet("Badge/{CourseId}")]
        public ActionResult<Badge> GetBadgeDupaCourse(int CourseId)
        {   
            Badge myBadge = new Badge();
            foreach (var badge in _context.Badges)
            {
                if ( badge.CourseId == CourseId)
                {
                    myBadge = badge;
                    break;
                }

            }
            return myBadge;
        }

        //GET: Cursuri dupa categorie
        [HttpGet("Categorie/{Categorie}")]
        public ActionResult<IEnumerable<Course>> GetCourseByCategorie(string Categorie)
        {
            List<Course> courses = new List<Course>();
            foreach (var item in _context.Courses)
            {
                if (item.Category == Categorie)
                {
                    courses.Add(item);
                }
            }
            return courses;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
        
            
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
