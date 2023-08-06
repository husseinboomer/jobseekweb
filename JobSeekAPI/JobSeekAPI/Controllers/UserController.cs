using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobSeekAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public db_a8b602_jobseekContext _context { get; set; }

        public DbService _dbs;

        public UserController(db_a8b602_jobseekContext Context, DbService dbs)

        {
            _context = Context;
            _dbs = dbs;
        }

        // GET <www.site.com>/Users

        [HttpGet("/Users")]
        public async Task<ActionResult> Get()
        {
            var users = await _context.Users.ToListAsync();
            if (users.Count == 0)
                return BadRequest($"There are no Users in the Database !!!...");
            else
                return Ok(users);
        }

        // GET <www.site.com>/Users/5

        [HttpGet("/Users/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
                return BadRequest($"There are no Users in the Database !!!...");
            else
                return Ok(users);
        }

        // GET <www.site.com>/Users/LogIn

        [HttpGet("/Users/LogIn/{Email}/{Password}")]
        public async Task<ActionResult> LogIn(string Email, string Password)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => (u.Email == Email)).FirstAsync();
                if (user.Password == Password)
                    return Ok(user);
                else
                    return BadRequest($" The Password is Wrong !!...");
            }
            catch (Exception)
            {
                return BadRequest($"  This User is not existed !!!... ");
            }
        }

        // POST <www.site.com>/Users/SignUp

        [HttpPost("/Users/SignUp")]
        public async Task<ActionResult> SignUp([FromForm] UserSignUpDto dto)
        {
            try
            {
                User user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password,
                    CityId = dto.CityId,
                    Age = dto.Age,
                    Gender = dto.Gender,
                    CertificationId = dto.CertificationId,
                };
                if (await _context.Users.ContainsAsync(user) == false)
                {
                    await _context.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return Ok(user);
                }
                else
                {
                    return BadRequest($"This User is already existed !!!...");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
           
        }

        // PUT <www.site.com>/User/ProfilEdit/5

        [HttpPut("/User/ProfilEdit/{id}")]
        public async Task<ActionResult> ProfilEdit(int id, [FromForm] UserProfileDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest($"There are no user with same ID in the database !!!...");
            user.Name = dto.Name;
            user.Gender = dto.Gender;
            user.Status = dto.Status;
            user.Address = dto.Address;
            user.CertificationId = dto.CertificationId;
            user.CityId = dto.CityId;
            user.EducationId = dto.EducationId;
            user.YearsOfExpieriance = dto.YearsOfExpieriance;

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // PUT <www.site.com>/User/AccountEdit/5

        [HttpPut("/User/AccountEdit/{id}")]
        public async Task<ActionResult> AccountEdit(int id, [FromForm] UserAccountDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest($"There are no user with same ID in the database !!!...");
            user.Email = dto.Email;
            user.Password = dto.Password;

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE <www.site.com>/User/Delete/5

        [HttpDelete("/User/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest($"No User Was Found With ID={id}");
            _context.Remove(user);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
