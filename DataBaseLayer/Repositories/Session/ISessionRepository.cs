using DataBaseLayer.Entities;

namespace DataBaseLayer.Repositories
{
    public interface ISessionRepository
    {
        Task AddAsync(Session session);
        Task DeleteAsync(string id);
        Task<IEnumerable<Session>> GetAllAsync();
        Task<Session> GetByIdAsync(string id);
    }
}