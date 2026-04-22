using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepStack.Data;
using PrepStack.Models;

namespace PrepStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        // This is Dependency Injection! 
        // We aren't creating a new database connection; we are "Injecting" the one we registered.
        public QuestionsController(AppDbContext context)
        {
            _context = context;
        }

        // This is a "GET" request - it fetches data
        [HttpGet]
        public ActionResult<IEnumerable<Question>> GetQuestions()
        {
            return _context.Questions.ToList();
        }

        // This is a "POST" request - it receives data to save it
        [HttpPost]
        public ActionResult<Question> CreateQuestion(Question newQuestion)
        {
            // 1. Tell the Librarian to add the new question to the pile
            _context.Questions.Add(newQuestion);

            // 2. Tell the Librarian to actually go to the warehouse and save it
            _context.SaveChanges();

            // 3. Return the new question so we can see it was saved
            return Ok(newQuestion);
        }

        [HttpDelete("{id}")] // This tells the API to expect an ID in the URL, like api/questions/1
        public ActionResult DeleteQuestion(int id)
        {
            // 1. Tell the Librarian to find the specific book by its ID
            var question = _context.Questions.Find(id);

            // 2. If the book doesn't exist, tell the customer "Not Found"
            if (question == null)
            {
                return NotFound();
            }

            // 3. Put it in the "Trash" pile
            _context.Questions.Remove(question);

            // 4. Empty the trash (Save changes to SQL)
            _context.SaveChanges();
         
            return Ok("Question deleted successfully.");
        }
    }
}
