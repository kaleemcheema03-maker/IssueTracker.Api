using IssueTracker.Api.Dtos;
using IssueTracker.Api.Interfaces;
using IssueTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers
{
    [ApiController]
    [Route("/api/issues")]
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }


        [HttpGet("{id}")]
        public async Task< IActionResult> GetByIdIssueAsync(int id)
        {
            var issue =  await _issueService.GetByIdAsync(id);
            if (issue == null)
            {
                return NotFound();
            }


            return Ok(issue);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssueAsync([FromBody] IssueDto dto)
        {
            
            
            var createdIssue = await _issueService.CreateAsync(dto);

            if (createdIssue == null)
            {
                return StatusCode(500,"A problem occurred while creating!" );
            }


            return CreatedAtAction ("GetByIdIssue" , new {id = createdIssue.Id} , createdIssue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssueAsync(int id, IssueDto dto)
        {


            var UpdatedIssue = await _issueService.UpdateAsync(id, dto);

            if (UpdatedIssue == null)
            {
                return StatusCode(500, "A problem occurred while updating!");
            }


            return Ok(UpdatedIssue);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssueAsync(int id)
        {


            var DeletedIssue = await _issueService.DeleteAsync(id);

            if (DeletedIssue == null)
            {
                return StatusCode(500, "A problem occurred while deleting!");
            }
            return Ok(DeletedIssue);
        }

    }
}
