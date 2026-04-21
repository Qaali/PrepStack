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
    }
}
