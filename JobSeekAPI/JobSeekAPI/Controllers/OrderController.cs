using Microsoft.AspNetCore.Mvc;

namespace JobSeekAPI.Controllers
{
    [Route("Controller")]
    [ApiController]
    public class OrderController : Controller
    {
        public db_a8b602_jobseekContext _context { get; set; }

        public DbService _dbs;

        public OrderController(db_a8b602_jobseekContext Context, DbService dbs)

        {
            _context = Context;
            _dbs = dbs;
        }

        List<Order> nullOrder = new List<Order>();

        // GET <www.site.com>/Orders

        [HttpGet("/Orders")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var orders = await _context.Orders
                    .Where (o => o.Acceptance == 1 || o.Acceptance == 0)
                    .OrderByDescending(o => o.RateGrade).ToListAsync();

                if (orders.Count == 0)
                    return BadRequest($"There are no Orders in the Database !!!...");
                else
                    return Ok(orders);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET <www.site.com>/Jobs/5

        [HttpGet("/Orders/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var JobId = await _context.Orders
                .Where(o => o.Id == id)
                .Select(o => o.JobId).FirstAsync();
            var jobsTitle = await _context.Jobs
                .Where(j => j.Id == JobId)
                .Select(j => j.Title).FirstAsync();
            var jobsDesc = await _context.Jobs
                .Where(j => j.Id == JobId)
                .Select(j => j.Description).FirstAsync();
            var userName = await _context.Orders
                .Where(o => o.Id == id)
                .Select(o => o.User)
                .Select(u => u.Name).FirstAsync();
            OrderDto Order = new OrderDto
            {
                JobTitle = jobsTitle,
                JobDescription = jobsDesc,
                UserName = userName
            };

            if (Order == null)
                return BadRequest(nullOrder);
            else
                return Ok(Order);
        }

        [HttpGet("/{UserId}/Order")] // Get all the orders for this user .. 
        public async Task<ActionResult> GetUserOrders(int UserId)
        {
            try
            {
                List<OrderUserDetailDto> Os = new List<OrderUserDetailDto>();
                var orders = await _context.Orders
                    .Where(o => o.UserId == UserId )
                    .Select(o => o.Id).ToListAsync();

                foreach(var order in orders)
                {
                    var Title = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.Job)
                        .Select(j => j.Title).First();
                    var acceptance = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.Acceptance).First();
                    var createdDate = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.CreatedDate).First();
                    var Note = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.Notes).First();
                    OrderUserDetailDto o = new OrderUserDetailDto
                    {
                        JobTitle = Title,
                        Acceptance = acceptance,
                        CreatedDate = createdDate,
                        Notes = Note,
                        Id = order
                    };
                    Os.Add(o);
                }
                if (Os.Count == 0)
                    return BadRequest(nullOrder);
                else
                    return Ok(Os);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("/{UserId}/Orders/Apllaied")] //Get only the apllaied orders ..
        public async Task<ActionResult> GetUserOrdersApllaied(int UserId)
        {
            try
            {
                List<OrderUserDetailDto> Os = new List<OrderUserDetailDto>();
                var orders = await _context.Orders
                    .Where(o => o.UserId == UserId && o.Acceptance == 1)
                    .Select(o => o.Id).ToListAsync();

                foreach (var order in orders)
                {
                    var Title = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.Job)
                        .Select(j => j.Title).First();
                    var acceptance = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.Acceptance).First();
                    var createdDate = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.CreatedDate).First();
                    var Note = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.Notes).First();
                    OrderUserDetailDto o = new OrderUserDetailDto
                    {
                        JobTitle = Title,
                        Acceptance = acceptance,
                        CreatedDate = createdDate,
                        Notes = Note,
                        Id = order
                    };
                    Os.Add(o);
                }
                if (Os.Count == 0)
                    return BadRequest(nullOrder);
                else
                    return Ok(Os);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("/{UserId}/Orders/Holded")] //Get only the Holded orders ..
        public async Task<ActionResult> GetUserOrdersHolded(int UserId)
        {
            try
            {
                List<OrderUserDetailDto> Os = new List<OrderUserDetailDto>();
                var orders = await _context.Orders
                    .Where(o => o.UserId == UserId && o.Acceptance == 0)
                    .Select(o => o.Id).ToListAsync();

                foreach (var order in orders)
                {
                    var Title = _context.Orders
                       .Where(o => o.Id == order)
                       .Select(o => o.Job)
                       .Select(j => j.Title).First();
                    var acceptance = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.Acceptance).First();
                    var createdDate = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.CreatedDate).First();
                    var Note = _context.Orders
                        .Where(o => o.Id == order)
                        .Select(o => o.Notes).First();
                    OrderUserDetailDto o = new OrderUserDetailDto
                    {
                        JobTitle = Title,
                        Acceptance = acceptance,
                        CreatedDate = createdDate,
                        Notes = Note,
                        Id = order
                    };
                    Os.Add(o);
                }
                if (Os.Count == 0)
                    return BadRequest(nullOrder);
                else
                    return Ok(Os);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("/{HrId}/Orders")] //Get all orders for this HR in (RateGrad) order ..
        public async Task<ActionResult> GetHROrders(int HrId)
        {
            try
            {
                List<OrderDto> Orders = new();
                var jobs = await _context.Jobs
                    .Where(j => j.EmployeerId == HrId)
                    .Select(j => j.Id).ToListAsync();

                foreach (var job in jobs)
                {
                    var orders =  _context.Orders
                        .Where(o => o.JobId == job )
                        .OrderBy(o => o.RateGrade)
                        .Select(o => o.Id).ToList();

                    if (orders.Count > 0)
                        foreach (var order in orders)
                        {
                            var jobsTitle =  _context.Jobs
                                  .Where(j => j.Id == job)
                                  .Select(j => j.Title).First();
                            var jobsDesc =  _context.Jobs
                                .Where(j => j.Id == job)
                                .Select(j => j.Description).First();
                            var userName =  _context.Orders
                                .Where(o => o.Id == order)
                                .Select(o => o.User)
                                .Select(u => u.Name).First();
                            var acceptance = _context.Orders
                                .Where(o => o.Id == order)
                                .Select(o => o.Acceptance).First();

                            OrderDto Order = new OrderDto
                            {
                                JobTitle = jobsTitle,
                                JobDescription = jobsDesc,
                                UserName = userName,
                                Acceptance = acceptance,
                                Id = order
                            };
                            Orders.Add(Order);
                        }   
                }

                if (Orders.Count == 0)
                    return BadRequest(nullOrder);
                else
                    return Ok(Orders);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{JobId}/Orders")] //Get all orders for this job only 
        public async Task<ActionResult> GetOrdersJob(int JobId)
        {
            try
            {
                var orders = await _context.Orders
                    .Where(o => o.JobId == JobId).OrderBy(o => o.RateGrade).ToListAsync();

                if (orders.Count == 0)
                    return BadRequest(nullOrder);
                else
                    return Ok(orders);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Post <www.site.com>/Order/Add

        [HttpPost("/Order/Add")]
        public async Task<ActionResult> AddOrder ([FromForm]UserOrderDto dto)
        {
            int? YearsOfExpierianceJob, YearsOfExpierianceUser, AgeJob, AgeUser;
            string? GenderJob, GenderUser, CertificationJob, CertificationUser;
            double Rate = 0.0,count = 0.0;

            try
            {
                Order order = new Order
                {
                    UserId = dto.UserId,
                    JobId = dto.JobId,
                    DocumentId = dto.DocumentId,
                };

                int? jobCertificationId = await _context.Jobs
                    .Where(j => j.Id == dto.JobId)
                    .Select(j => j.CertificationId).FirstAsync();
                int? userCertificationId = await _context.Users
                    .Where(u => u.Id == dto.UserId)
                    .Select(j => j.CertificationId).FirstAsync();
                YearsOfExpierianceJob = await _context.Jobs
                    .Where(j => j.Id == dto.JobId)
                    .Select(j => j.YearsOfExpieriance).FirstAsync(); ;
                YearsOfExpierianceUser = await _context.Users
                    .Where(u => u.Id == dto.UserId)
                    .Select(j => j.YearsOfExpieriance).FirstAsync();
                AgeJob = await _context.Jobs
                    .Where(j => j.Id == dto.JobId)
                    .Select(j => j.AgeRequired).FirstAsync();
                AgeUser = await _context.Users
                    .Where(j => j.Id == dto.UserId)
                    .Select(j => j.Age).FirstAsync();
                GenderJob = await _context.Jobs
                    .Where(j => j.Id == dto.JobId)
                    .Select(j => j.GenderRequired).FirstAsync();
                GenderUser = await _context.Users
                    .Where(j => j.Id == dto.UserId)
                    .Select(j => j.Gender).FirstAsync();
                CertificationJob = _context.Certifications
                    .Where(c => c.Id == jobCertificationId).Select(c => c.Name).First();
                CertificationUser = _context.Certifications
                    .Where(c => c.Id == userCertificationId).Select(c => c.Name).First();

                if (AgeJob == AgeUser)
                    count += 50.0;
                else if (AgeUser > AgeJob)
                    count += 15.5;
                else
                    count += 5.0;

                if (YearsOfExpierianceJob == YearsOfExpierianceUser)
                    count += 25.0;
                else if (YearsOfExpierianceUser > YearsOfExpierianceJob)
                    count += 50.0;
                else
                    count += 5.0;

                if (GenderJob == GenderUser)
                    count++;
                else if (GenderUser != GenderJob && count > 1)
                    count--;

                if (CertificationJob == CertificationUser)
                    count += 50.0;
                else if (CertificationJob != CertificationUser && count > 50)
                    count -= 50.0;

                Rate = count / 4;
                order.RateGrade = Rate;

                if (!_context.Orders.Contains(order))
                {
                    await _context.AddAsync(order);
                    await _context.SaveChangesAsync();
                    return Ok(order);
                }
                else
                {
                    return BadRequest($"This Order is already existed !!!...");
                }
            }
            catch (Exception)
            {
                return BadRequest(nullOrder);
            }
        }

        // Put <www.site.com>/Order/Edite/5

        [HttpPut("/Order/Edit/{OrderId}")]
        public async Task<ActionResult> EditeOrder([FromForm]CompnayOrderDto dto, int OrderId)
        {
            try
            {
                var order = await _context.Orders
                                .Where(o => o.Id == OrderId).FirstAsync();
                if (order == null)
                    return BadRequest($"there are no order with this Id {OrderId}");

                order.Notes = dto.Notes;
                order.Acceptance = dto.Acceptance;

                await _context.SaveChangesAsync();
                return Ok(order);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Put <www.site.com>/Order/Delete/5

        [HttpPut("/Order/Delete/{OrderId}")]
        public async Task<ActionResult> DeleteOrder(int OrderId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == OrderId).FirstAsync();
            if (order == null)
                return BadRequest($"there are no order with this Id {OrderId}");
            
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
