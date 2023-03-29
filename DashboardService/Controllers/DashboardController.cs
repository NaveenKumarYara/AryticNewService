using DashboardService.Contracts;
using Microsoft.AspNetCore.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DashboardService.Controllers
{
    [ApiController]
    [Route("api")]
    public class DashboardController : ControllerBase
    {

        private readonly IDashboardRepository _noteRepo;

        public DashboardController(IDashboardRepository noteRepo)
        {
            _noteRepo = noteRepo;
        }



        [HttpGet("GetProfileNotes")]
        public async Task<IActionResult> GetProfileNote(long? ProfileId, int currentPageNumber, int pageSize)
        {
            try
            {


                var notes = await _noteRepo.GetProfileNote(ProfileId, currentPageNumber, pageSize);
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

        [HttpGet("GetProfileFeedback")]
        public async Task<IActionResult> GetProfileFeedback(long? ProfileId, int currentPageNumber, int pageSize)
        {
            try
            {
                var feedbacks = await _noteRepo.GetProfileFeedback(ProfileId, currentPageNumber, pageSize);
                if (feedbacks == null)
                    return NotFound();

                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCandidateDocuments")]
        public async Task<IActionResult> GetCandidateDocuments(long? ProfileId, int currentPageNumber, int pageSize)
        {
            try
            {
                var documents = await _noteRepo.GetCandidateDocuments(ProfileId, currentPageNumber, pageSize);
                if (documents == null)
                    return NotFound();

                return Ok(documents);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
