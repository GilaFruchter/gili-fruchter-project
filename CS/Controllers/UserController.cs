using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Api;
using DAL.Models;  // זהו ה-using הנדרש

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
    }
}
