using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Learning_IT.Models;
using Learning_IT.DTOs;
using Learning_IT.Utils;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace Learning_IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   

        private readonly MyContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager, MyContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        // GET: api/User/LeaderboardTop
        [HttpGet("LeaderboardTop")]
        public async Task<ActionResult<IEnumerable<UserRankDetail>>> GetLeaderboardTop()
        {

            List<UserRankDetail> userRankDetailList = new List<UserRankDetail>();

            var usersList = await _context.Users.ToListAsync();

            foreach (var user in usersList)
            {
                UserRankDetail userRankDetail = new UserRankDetail(
                    user.Id,
                    user.FirstName.ToString() + " " + user.LastName.ToString(),
                    user.Score);
                userRankDetailList.Add(userRankDetail);
            }

            return userRankDetailList.OrderByDescending(u => u.Score).Take((int)BrUtilis.Constante.TOP5).ToList() ;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
           
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        //UPLOAD IMAGE FOR USER
        [HttpPost("Image/{id}")]
        public ActionResult UploadImage(int id)
        {

            MemoryStream ms = new MemoryStream();
            return Ok();
        }

        //GET USER ID BY EMAIL
        [HttpGet("Email/{Email}")]
        public ActionResult<int> GetUserId(string Email)
        {
            string email = Email;
            string userIdentityId = "";
            int userId = 0;
            foreach(var item in _userManager.Users)
            {
                if(item.Email == email)
                {
                    userIdentityId = item.Id;
                }
            }

            foreach(var item in _context.Users)
            {
                if(item.IdentityId == userIdentityId)
                {
                    userId = item.Id;
                }
            }

            return userId;
        }
        [HttpGet("Badges/{UserId}")]
        public ActionResult<List<Badge>> GetBadgesByUser(int UserId)
        {
            List<Badge> badgesList = new List<Badge>();

            foreach (var userBadge in _context.UserBadges)
            {
                if ( userBadge.UserID == UserId)
                {
                    foreach( var badge in _context.Badges)
                    {
                        if (userBadge.BadgeId == badge.Id)
                        {
                            badgesList.Add(badge);
                        }
                    }
                }
            }

            return badgesList;
        }
        [HttpGet("Courses/{UserId}")]
        public bool GetCoursesByUser(int UserId)
        {
            List<Course> coursesList = new List<Course>();

            foreach (var userCourse in _context.UserCourses)
            {
                if (userCourse.UserId == UserId)
                {
                    foreach (var course in _context.Courses)
                    {
                        if (userCourse.CourseId == course.Id)
                        {
                            coursesList.Add(course);
                        }
                    }
                }
            }

            return false;
        }
    }
}
