using Microsoft.AspNetCore.Mvc;
using wearhouse_back_end.Connection;
using wearhouse_back_end.Models.Request;
using wearhouse_back_end.Models.Response;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using wearhouse_back_end.Models.DatabaseModels;

namespace wearhouse_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public UserController(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpPost("Login")]
        [Produces("application/json")]
        public async Task<ActionResult<LoginResponse>> LoginUser([FromBody] LoginRequest userRequest)
        {
            var user = new LoginResponse();

            var dataUser = await _dbcontext.MsUser.FirstOrDefaultAsync(x => x.userEmail == userRequest.userEmail && x.userPassword == userRequest.userPassword);

            if (dataUser != null)
            {
                user.userName = dataUser.userName;
                user.UserID = dataUser.UserID;

                return Ok(user);
            }
            else
            {
                return NotFound("User not found");
            }
        }

        /*Register*/
        [HttpPost("Register")]
        [Produces("application/json")]
        public async Task<ActionResult<LoginResponse>> RegisterUser([FromBody] RegisterRequest userRequest)
        {
            var userData = new MsUser
            {
                UserID = Guid.NewGuid().ToString("D"),
                userName = userRequest.userName,
                userEmail = userRequest.userEmail,
                userPassword = userRequest.userPassword
            };

            try
            {
                _dbcontext.MsUser.Add(userData);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }catch (Exception ex) 
            {
                return BadRequest("Failed To Register");
            }
            
        }

    }
}
