//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using DAL.Models; 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace orm.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PromptsController : ControllerBase
//    {
//        private readonly DALManager _context;
//        private readonly IConfiguration _configuration;

//        public PromptsController(DatabaseManager context, IConfiguration configuration)
//        {
//            _context = context;
//            _configuration = configuration;
//        }

//        // GET: api/prompts/user/5
//        [HttpGet("user/{userId}")]
//        public async Task<ActionResult<IEnumerable<Prompt>>> GetUserPrompts(int userId)
//        {
//            return await _context.Prompts
//                .Where(p => p.UserId == userId)
//                .OrderByDescending(p => p.CreatedAt)
//                .ToListAsync();
//        }

//        // POST: api/prompts
//        [HttpPost]
//        public async Task<ActionResult<Prompt>> CreatePrompt(Prompt promptRequest)
//        {
//            // במקרה הזה הקוד לתקשורת עם OpenAI הוסר כי לא שלחת את המחלקות הרלוונטיות
//            // תוכל להחזיר אותו אם תוודא שהספריה OpenAI.GPT3 מותקנת ו-using רלוונטיים קיימים

//            // סימולציה של תגובת GPT
//            promptRequest.Response = "זוהי תגובה לדוגמה ממערכת הבינה המלאכותית.";
//            promptRequest.CreatedAt = DateTime.UtcNow;

//            _context.Prompts.Add(promptRequest);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetUserPrompts), new { userId = promptRequest.UserId }, promptRequest);
//        }
//    }
//}
