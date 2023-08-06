using Microsoft.AspNetCore.Mvc;

namespace JobSeekAPI.Controllers
{
    [Route("controller")]
    [ApiController]
    public class CompanyController : Controller
    {
        public db_a8b602_jobseekContext _context { get; set; }

        public DbService _dbs;

        public CompanyController(db_a8b602_jobseekContext Context, DbService dbs)

        {
            _context = Context;
            _dbs = dbs;
        }

        [HttpGet("/LogIn/HR/{Email}/{PassCode}")]
        public async Task<ActionResult> HRLogin(string Email, int PassCode)
        {
            try
            {
                var companyId = await _context.Companies
                    .Where(u => (u.Email == Email))
                    .Select(u => u.Id)
                    .FirstAsync();

                var companyPassCode = await _context.Companies
                    .Where(u => (u.Email == Email))
                    .Select(u => u.PassCode)
                    .FirstAsync();

                var hr = _context.Employeers
                    .Where(e => e.CompanyId == companyId)
                    .First();

                if (companyPassCode == PassCode)
                {
                    if (hr != null)
                        return Ok(hr);
                    else
                        return BadRequest($"There are no HRs in this Company !!..");
                }
                else
                    return BadRequest($" The Password is Wrong !!...");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpGet("/{HrId}/Job/AllCities")]
        public async Task<ActionResult> GetAllCities(int HrId)
        {
            try
            {
                List<City> cities = new();
                var HRId = await _context.Employeers
                    .Where(e => e.Id == HrId)
                    .Select(e => e.Id).FirstAsync();
                var companyId = await _context.Companies
                    .Where(c => c.Id == HRId)
                    .Select(c => c.Id).FirstAsync();
                var branches = await _context.Branches
                    .Where(b => b.CompanyId == companyId)
                    .Select(b => b.CityId).ToListAsync();

                foreach (var branch in branches)
                {
                    var cities1 = await _context.Cities
                       .Where(c => c.Id == branch).ToListAsync();
                    foreach (var city in cities1)
                    {
                        if (!cities.Contains(city))
                        cities.Add(city);
                    }
                }

                if (cities.Count == 0)
                    return BadRequest($"There Are No Branches in your Company");
                else
                    return Ok(cities);
            }
            catch (Exception)
            {
                throw ;
            }
        }
    }
}
