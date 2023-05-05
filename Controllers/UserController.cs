using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharmacy.Model;

namespace pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PharmacyDbContext _userDbContext;

        public UserController(PharmacyDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        [HttpGet]
        [Route("Getuser")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userDbContext.Users.ToListAsync();
        }





        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(User objUser)
        {
            var dbuser = _userDbContext.Users.Where(u => u.Email == objUser.Email).FirstOrDefault();
            if (dbuser != null)
            {
                return BadRequest("Email already exists");
            }


            // Generate salt and hash password using bcrypt algorithm
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(objUser.Password, salt);

            objUser.Password = hashedPassword; // Save hashed password in the database
            _userDbContext.Users.Add(objUser);
            await _userDbContext.SaveChangesAsync();
            return Ok("regjistrimi u bo me sukses");

        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login(Login user)
        {

            //    // Find the user with the specified email address
            var userInDb = await _userDbContext.Users.SingleOrDefaultAsync(u => u.Email == user.Email);


            // If the user is not found or the password is incorrect, return an error message
            if (userInDb == null || !BCrypt.Net.BCrypt.Verify(user.Password, userInDb.Password))
            {
                return BadRequest("Invalid email or password.");
            }

            return Ok(userInDb);
        }
    }
}
