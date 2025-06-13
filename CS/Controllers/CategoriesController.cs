using BL.Api;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IBLCategory categoryActions;
        public CategoriesController(IBLManager bl)
        {
            categoryActions = bl.BLCategory;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await categoryActions.GetAll();
            if (allUsers == null || allUsers.Count == 0)
            {
                return NotFound("ERROR!! there are no available users!!");
            }
            return Ok(allUsers);
        }

        [HttpPost]
        public ActionResult<Category> CreateNewUser([FromBody] Category cat)
        {
            categoryActions.Create(cat);
            return cat;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await categoryActions.GetCategoryById(id);
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvitation(int id)
        {
            await categoryActions.DeleteCategory(id);
            return Ok();
        }
    }
}
