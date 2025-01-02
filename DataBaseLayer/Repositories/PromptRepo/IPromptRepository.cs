using DataBaseLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLayer.Repositories.PromptRepo
{
    public interface IPromptRepository
    {
        Task<Prompt> GetByIdAsync(string id);
        Task<IEnumerable<Prompt>> GetAllAsync();
        Task AddAsync(Prompt prompt);
        Task DeleteAsync(string id);
    }
}
