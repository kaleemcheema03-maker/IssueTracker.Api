using IssueTracker.Api.Dtos;
using IssueTracker.Api.Models;

namespace IssueTracker.Api.Interfaces
{
    public interface  IIssueService
    {

       Task <List<Issue>> GetAllAsync();
     Task<Issue?> GetByIdAsync(int id);
      Task<Issue?> CreateAsync(IssueDto dto);
       Task<Issue?> DeleteAsync(int id);
        Task<Issue?> UpdateAsync(int id, IssueDto dto);



    }
}
