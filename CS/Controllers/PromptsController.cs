using BL.Api;
using BL.Services;
using DAL.Models;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
                //Prompt newPrompt = await _blPromptService.AddPrompt(
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

        [HttpGet]
        public async Task<IActionResult> GetAllPrompts()
        {
            var allSubCategories = await _blPromptService.GetAll();
            if (allSubCategories == null || allSubCategories.Count == 0)
            {
                return NotFound("ERROR!! there are no available users!!");
            }
            return Ok(allSubCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromptById(int id)
        {
            try
            {
                List<Prompt> prompt = await _blPromptService.GetAllPromptByID(id);
                if (prompt == null || !prompt.Any()) 
                {
                    Console.WriteLine($"Prompt with ID {id} not found.");
                }
                return Ok(prompt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving prompt: {ex.Message}");
                return StatusCode(500, $"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}

