using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Api;
using DAL.Models; 

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IBLUser userActions;
        public UserController(IBLManager bl)
        {
            userActions = bl.BLUser;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await userActions.GetAll();
            if (allUsers == null || allUsers.Count == 0)
            {
                return NotFound("ERROR!! there are no available users!!");
            }
            return Ok(allUsers);
        }

        [HttpPost]
        public ActionResult<User> CreateNewUser([FromBody] User user)
        {
            userActions.Create(user);
            return user;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await userActions.GetUserByIdAsync(id);
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvitation(int id)
        {
            await userActions.DeleteUser(id);
            return Ok();
        }
    }
}
