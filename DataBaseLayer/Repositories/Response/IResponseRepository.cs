using Azure;
using DataBaseLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLayer.Repositories.Response
{
    public interface IResponseRepository
    {
        Task<AIResponse> GetByIdAsync(string id);
        Task<IEnumerable<AIResponse>> GetAllAsync();
        Task AddAsync(AIResponse response);
        Task DeleteAsync(string id);
    }
}
