using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    //DD
using Learning_IT.Models;

namespace Learning_IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerQuestionsController : ControllerBase
    {
        private readonly MyContext _context;

        public AnswerQuestionsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/AnswerQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerQuestion>>> GetAnswerQuestions()
        {
            return await _context.AnswerQuestions.ToListAsync();
        }

        // GET: api/AnswerQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerQuestion>> GetAnswerQuestion(int id)
        {
            var answerQuestion = await _context.AnswerQuestions.FindAsync(id);

            if (answerQuestion == null)
            {
                return NotFound();
            }

            return answerQuestion;
        }

        // PUT: api/AnswerQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerQuestion(int id, AnswerQuestion answerQuestion)
        {
            if (id != answerQuestion.AnswerId)
            {
                return BadRequest();
            }

            _context.Entry(answerQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerQuestionExists(id))
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

        // POST: api/AnswerQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnswerQuestion>> PostAnswerQuestion(AnswerQuestion answerQuestion)
        {
            _context.AnswerQuestions.Add(answerQuestion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnswerQuestionExists(answerQuestion.AnswerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnswerQuestion", new { id = answerQuestion.AnswerId }, answerQuestion);
        }

        // DELETE: api/AnswerQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerQuestion(int id)
        {
            var answerQuestion = await _context.AnswerQuestions.FindAsync(id);
            if (answerQuestion == null)
            {
                return NotFound();
            }

            _context.AnswerQuestions.Remove(answerQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerQuestionExists(int id)
        {
            return _context.AnswerQuestions.Any(e => e.AnswerId == id);
        }
    }
}
