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
    public class QuestionExamsController : ControllerBase
    {
        private readonly MyContext _context;

        public QuestionExamsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/QuestionExams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionExam>>> GetQuestionExams()
        {
            return await _context.QuestionExams.ToListAsync();
        }

        // GET: api/QuestionExams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionExam>> GetQuestionExam(int id)
        {
            var questionExam = await _context.QuestionExams.FindAsync(id);

            if (questionExam == null)
            {
                return NotFound();
            }

            return questionExam;
        }

        // PUT: api/QuestionExams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionExam(int id, QuestionExam questionExam)
        {
            if (id != questionExam.ExamId)
            {
                return BadRequest();
            }

            _context.Entry(questionExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExamExists(id))
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

        // POST: api/QuestionExams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionExam>> PostQuestionExam(QuestionExam questionExam)
        {
            _context.QuestionExams.Add(questionExam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuestionExamExists(questionExam.ExamId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuestionExam", new { id = questionExam.ExamId }, questionExam);
        }

        // DELETE: api/QuestionExams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionExam(int id)
        {
            var questionExam = await _context.QuestionExams.FindAsync(id);
            if (questionExam == null)
            {
                return NotFound();
            }

            _context.QuestionExams.Remove(questionExam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExamExists(int id)
        {
            return _context.QuestionExams.Any(e => e.ExamId == id);
        }
    }
}
