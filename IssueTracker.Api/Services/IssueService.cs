using IssueTracker.Api.Data;
using IssueTracker.Api.Dtos;
using IssueTracker.Api.Interfaces;
using IssueTracker.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace IssueTracker.Api.Services
{
    public class IssueService : IIssueService
    {
        private readonly AppDbContext _context;
       

        public IssueService(AppDbContext context)
        {
            _context = context;
        }


        public async  Task<List<Issue>> GetAllAsync()
        {

            return await _context.Issues.ToListAsync();
        }

   

      public async  Task<Issue?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await _context.Issues.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Issue?> CreateAsync(IssueDto dto)
        {

            var issue = new Issue
            {
                // no need for this database will calculate automatically
                // Id = _context.Issues.Any() ? _context.Issues.Max(i => i.Id)+1 : 1
                
                Name = dto.Name,
                Description = dto.Description,
                Status = dto.Status

            }; 


            if (dto == null)
            {
                return null;
            }

            _context.Issues.Add(issue);

            await _context.SaveChangesAsync();
            return  issue;
        }
      
        public async Task<Issue?> UpdateAsync(int id , IssueDto dto)
        {

         
         var  UpdateIssue = await  _context.Issues.FirstOrDefaultAsync(i => i.Id == id);

            if (UpdateIssue == null)
            {
                return null;
            }

            UpdateIssue.Name = dto.Name;
            UpdateIssue.Description = dto.Description;
            UpdateIssue.Status = dto.Status;

            await _context.SaveChangesAsync();

            return UpdateIssue;

        }

        public async Task<Issue?> DeleteAsync(int id)
        {


            var DeleteIssue = await _context.Issues.FirstOrDefaultAsync(i => i.Id == id);

            if (DeleteIssue == null)
            {
                return null;
            }

            _context.Issues.Remove(DeleteIssue);

            await _context.SaveChangesAsync();

            return DeleteIssue;

        }


    }
}
