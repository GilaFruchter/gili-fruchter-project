using BL.Api;
using DAL.Api;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        IBLSubCategory subCategoryActions;
        public SubCategoryController(IBLManager bl)
        {
            subCategoryActions = bl.BLSubCategory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var allSubCategories = await subCategoryActions.GetAll();
            if (allSubCategories == null || allSubCategories.Count == 0)
            {
                return NotFound("ERROR!! there are no available users!!");
            }
            return Ok(allSubCategories);
        }

        [HttpPost]
        public ActionResult<SubCategory> CreateNewSubCategory([FromBody] SubCategory sub)
        {
            subCategoryActions.Create(sub);
            return sub;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            var customer = await subCategoryActions.GetSubCategoryByIdAsync(id);
            return Ok(customer);
        }

        [HttpGet("subs/{id}")]
        public async Task<IActionResult> GetAllSubCategoryById(int id)
        {
            try
            {
                var customers = await subCategoryActions.GetAllSubCategoryByIdAsync(id);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            await subCategoryActions.DeleteSubCategory(id);
            return Ok();
        }
    }
}

