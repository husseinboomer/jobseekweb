using Microsoft.AspNetCore.Mvc;

namespace JobSeekAPI.Controllers
{
    [Route("controller")]
    [ApiController]
    public class SavedJobController : Controller
    {
        public db_a8b602_jobseekContext _context { get; set; }

        public DbService _dbs;
        public SavedJobController(db_a8b602_jobseekContext Context, DbService dbs)

        {
            _context = Context;
            _dbs = dbs;
        }

        List<Savedjob> nullSavedJobs = new List<Savedjob>();

        [HttpGet("/{UserId}/jobs")]
        public async Task<ActionResult> GetAllSaved(int UserId)
        {
            List<Job> jobs = new();
            var Sj = await _context.Savedjobs
                .Where(s => s.UserId == UserId)
                .Select(s => s.Id).ToListAsync();
            foreach (var s in Sj)
            {
                var jobId = _context.Savedjobs
                    .Where(sj => sj.Id == s)
                    .Select(sj => sj.JobId).First();
                var job = _context.Jobs
                    .Where(j => j.Id == jobId).First();
                jobs.Add(job);
            }
            if (jobs.Count > 0)
                return Ok(jobs);
            else
                return BadRequest(nullSavedJobs);
        }

        [HttpPost("/Job/Save")]
        public async Task<ActionResult> Save([FromForm] SavedJobDto dto)
        {
            Savedjob SJ = new Savedjob
            {
                UserId = dto.UserId,
                JobId = dto.JobId,
            };
            if (await _context.Savedjobs.ContainsAsync(SJ))
                return BadRequest($"This Job is Saved Before !!..");
            else
            {
                await _context.Savedjobs.AddAsync(SJ);
                await _context.SaveChangesAsync();
                return Ok(SJ);
            }
        }

        [HttpPost("/Job/UnSave")]
        public async Task<ActionResult> UnSave([FromForm] SavedJobDto dto)
        {
            var Sj = await _context.Savedjobs
                .Where(sj => sj.UserId == dto.UserId 
                       && sj.JobId == dto.JobId).FirstAsync();

            if (await _context.Savedjobs.ContainsAsync(Sj))
            {
                _context.Savedjobs.Remove(Sj);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest($"This Job wasn't Saved Before !!..");

        }
    }
}
