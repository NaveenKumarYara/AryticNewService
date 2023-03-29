using JobService.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
    [Route("api")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _noteRepo;

        public JobController(IJobRepository noteRepo)
        {
            _noteRepo = noteRepo;
        }



        [HttpGet("GetCustomerJobs")]
        public async Task<IActionResult> GetCustomerJobs(long? CustomerId, long? UserId, int currentPageNumber, int pageSize)
        {
            try
            {


                var notes = await _noteRepo.GetCustomerJobs(CustomerId,UserId, currentPageNumber, pageSize);
                if (notes == null)
                    return NotFound();

                return Ok(notes);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
