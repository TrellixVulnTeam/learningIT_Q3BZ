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
    public class ExamsController : ControllerBase
    {
        private readonly MyContext _context;

        public ExamsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            return await _context.Exams.ToListAsync();
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
        
            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }


        [HttpGet("QuestionsExam/{ExamId}")]
        public ActionResult<List<Question>> GetQuestionsExam (int ExamId)
        {
            List<Question> questionsList = new List<Question>();


            foreach(var questionExam in _context.QuestionExams)
            {
                if (questionExam.ExamId == ExamId)
                {
                    foreach(var questionItem in _context.Questions)
                    {
                        if (questionItem.Id == questionExam.QuestionId)
                        {
                            questionsList.Add(questionItem);
                            break;
                        }
                    }
                }
            }

            return questionsList;
        }


        [HttpGet("Course/{CourseId}")]
        public ActionResult<Exam> GetExamCourse(int CourseId)
        {
            Exam exam = new Exam();
            int idCourse = 0;
            foreach (var course in _context.Courses)
            {
                if (course.Id == CourseId)
                {
                    idCourse = course.Id;
                    break;
                }
            }
            foreach (var examItem in _context.Exams)
            {
                if (examItem.CourseId == idCourse)
                {
                    exam = examItem;
                    break;
                }
            }

            return exam;

        }

        // GET: api/Exams/Title
        [HttpGet("Title/{Title}")]
        public ActionResult<Exam> GetExamByCourseName(string Title)
        {
            Exam exam = new Exam();
            int idChapter = 0;
            foreach (var item in _context.Chapters)
            {
                if (item.Title == Title)
                {
                    idChapter = item.Id;
                }
            }
            foreach (var item in _context.Exams)
            {
                //if (item.ChapterId.Equals(idChapter))
                //{
                //    exam = item;
                //}
            }
            return exam;
        }
        
        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
            if (id != exam.Id)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExam", new { id = exam.Id }, exam);
        }

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.Id == id);
        }
    }
}
