using DataBaseLayer.Entities;

namespace DataBaseLayer.Repositories
{
    public interface ISessionRepository
    {
        Task CreateSessionAsync(Session session);
        Task DeleteAsync(string id);
        Task<IEnumerable<Session>> GetAllAsync();
        Task<Session> GetSessionByIdAsync(string id);
    }
}