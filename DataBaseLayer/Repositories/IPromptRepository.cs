using DataBaseLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLayer.Repositories
{
    public interface IPromptRepository
    {
        Task<Prompt> GetByIdAsync(string id);
        Task<IEnumerable<Prompt>> GetAllAsync();
        Task AddAsync(Prompt prompt);
        Task UpdateAsync(Prompt prompt);
        Task DeleteAsync(string id);
    }
}
