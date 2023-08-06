using Microsoft.AspNetCore.Mvc;

namespace JobSeekAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        public db_a8b602_jobseekContext _context { get; set; }

        public DbService _dbs;

        public JobController(db_a8b602_jobseekContext Context, DbService dbs)

        {
            _context = Context;
            _dbs = dbs;
        }

        List<Job> nullJob = new List<Job>();

        // GET <www.site.com>/Jobs

        [HttpGet("/Jobs")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var jobs = await _context.Jobs.ToListAsync();
                if (jobs.Count == 0)
                    return BadRequest($"There are no Jobs in the Database !!!...");
                else
                    return Ok(jobs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET <www.site.com>/Jobs/5

        [HttpGet("/Jobs/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var jobs = await _context.Jobs.FindAsync(id);
            if (jobs == null)
                return BadRequest($"There are no Jobs in the Database !!!...");
            else
                return Ok(jobs);
        }

        // GET <www.site.com>/Jobs/Title

        [HttpGet("/Search/Jobs/{JobTitle}")]
        public async Task<ActionResult> Get(string JobTitle)
        {
            var jobs = await _context.Jobs
                .Where(j => j.Title == JobTitle).ToListAsync();
            if (jobs.Count == 0)
                return BadRequest($"There are no Jobs in the Database !!!...");
            else
                return Ok(jobs);
        }

        // GET <www.site.com>/Jobs/Aleppo

        [HttpGet("/Jobs/City/{CityName}")]                                 // Filters Jobs By City Name .
        public async Task<ActionResult> JobsInCity(string CityName)
        {
            List<Job> Jobs = new();
            var cityId = _dbs.SelectCityId(CityName);
            var BranchesId = await _context.Branches
                .Where(b => b.CityId == cityId)
                .Select(b => b.Id).ToListAsync();
            foreach (var branch in BranchesId)
            {
                var branchsectionsId = await _context.BranchSections
                    .Where(bs => bs.BranchId == branch)
                    .Select(bs => bs.Id).ToListAsync();
                foreach(var branchsection in branchsectionsId)
                {
                    var jobs = await _context.Jobs
                        .Where(j => j.BranchSectionId == branchsection)
                        .ToListAsync();
                    foreach (var job in jobs)
                    {
                        if (!Jobs.Contains(job))
                            Jobs.Add(job);
                    }
                   
                }
            }


            if (Jobs.Count == 0)
                return BadRequest($"There are no users in this City !...");
            else
                return Ok(Jobs);
        }

        // GET <www.site.com>/Jobs/City

        [HttpGet("/Jobs/CityName/{JobId}")]
        public async Task<string> City(int JobId)
        {
            var BranchSectionId = await _context.Jobs
                .Where(j => j.Id == JobId)
                .Select(j => j.BranchSectionId).FirstAsync();
            var BranchId = await _context.BranchSections
                .Where(bs => bs.Id == BranchSectionId)
                .Select(bs => bs.BranchId).FirstAsync();
            var CityId = await _context.Branches
                .Where(b => b.Id == BranchId)
                .Select(b => b.CityId).FirstAsync();
            var CityName =await _context.Cities
                .Where(c => c.Id == CityId)
                .Select(c => c.Name).FirstAsync(); 
            
            if (CityName == null)
                return "this branchsection wasn't found !!..";
            else
                return CityName;
        }

        // GET <www.site.com>/2/Jobs/FetauredByCity

        [HttpGet("/{UserId}/Jobs/FetauredByCity")]                    //Filters Jobs By City Of Users .
        public async Task<ActionResult> FetauredByCity(int UserId)
        {
            var jobs = await _context.Cities
                .SelectMany(c => c.Branches)
                .Where(b => b.CityId == _dbs.SelectCityId(UserId))
                .SelectMany(b => b.BranchSections)
                .SelectMany(bs => bs.Jobs).ToListAsync();

            if (jobs.Count() == 0)
                return BadRequest($"there are no jobs for you !!!..");
            else
                return Ok(jobs);
        }

        // GET <www.site.com>/Jobs/Recent

        [HttpGet("/Jobs/Recent")]                                     //Filters Jobs By Latest Date .
        public async Task<ActionResult> JobsByDate()
        {

            int TimeRange = 7;
            var Jobs = await _context.Jobs
                .Where(j => TimeRange >= Convert
                .ToInt32(DateTime.Now.DayOfYear - j.CreatedDate.Value.DayOfYear))
                .OrderBy(j => j.CreatedDate).ToListAsync();

            if (Jobs.Count() == 0)
                return BadRequest($"there are no jobs for you !!!..");
            else
                return Ok(Jobs);
        }

        // GET <www.site.com>/Jobs/Recommended

        [HttpGet("/Jobs/Recommended")]                                     //Filters Jobs By CertificationId .
        public async Task<ActionResult> Recommended()
        {

            var Jobs = await _context.Jobs
                .Where(j => j.CertificationId == null).ToListAsync();

            if (Jobs.Count() == 0)
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                return BadRequest(nullJob);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            else
                return Ok(Jobs);
        }

        // GET <www.site.com>/Jobs/Recommended

        [HttpGet("/{HrId}/Job")]                                     //Filters Jobs By CertificationId .
        public async Task<ActionResult> HrJobs(int HrId)
        {
            var jobs = await _context.Jobs
                     .Where(j => j.EmployeerId == HrId)
                     .ToListAsync();

            if (jobs.Count() == 0)
                return BadRequest(nullJob);
            else
                return Ok(jobs);
        }

        // POST <www.site.com>/Jobs/AddNewJob

        [HttpPost("/Job/AddNewJob")]
        public async Task<ActionResult> AddNewJob([FromForm] JobDto dto, string CityName)
        {
            Job job = new Job
            {
                YearsOfExpieriance = dto.YearsOfExpieriance,
                AgeRequired = dto.AgeRequired,
                GenderRequired = dto.GenderRequired,
                Salary = dto.Salary,
                JobType = dto.JobType,
                CertificationId = dto.CertificationId,
                BranchSectionId =await _dbs.SelectBranchSectionId(CityName),
                EmployeerId = dto.EmployeerId,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                Title = dto.Title,
                PersonsNumRequired = dto.PersonsNumRequired,
            };

            if (await _context.Jobs.ContainsAsync(job) == true)
            {
                return BadRequest($"This Job is already existed !!!...");
            }
            else
            {
                await _context.AddAsync(job);
                await _context.SaveChangesAsync();
                return Ok(job);
            }
        }

        // DELETE <www.site.com>/Job/Delete/5

        [HttpDelete("/Job/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var jobs = await _context.Jobs.FindAsync(id);
            if (jobs == null)
                return BadRequest($"No Job Was Found With ID={id}");
            _context.Remove(jobs);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("/Job/AllCategoreis")]
        public async Task<ActionResult> GetAllCategoreis()
        {
            try
            {
                var categoreis = await _context.Categories.ToListAsync();


                if (categoreis.Count == 0)
                    return BadRequest($"There are no Categoreis in the Database !!!...");
                else
                    return Ok(categoreis);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
