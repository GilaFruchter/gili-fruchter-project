// File: Controllers/PromptsController.cs
// (Place this file in the 'Controllers' folder of your API project, e.g., in the 'CS' project)

using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BL.Api; // ייבוא ממשקי ה-BL (כעת נזריק את IBLPrompt)
using DAL.Models;
using BL.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromptsController : ControllerBase
    {
        private readonly IBLPrompt _blPromptService;

        public PromptsController(IBLPrompt blPromptService)
        {
            _blPromptService = blPromptService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrompt([FromBody] PromptRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Prompt newPrompt = await _blPromptService.AddPrompt(
                    request.UserId,
                    request.CategoryId,
                    request.SubCategoryId,
                    request.Prompt1
                );

                return Ok(newPrompt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding prompt: {ex.Message}");
                return StatusCode(500, $"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}

