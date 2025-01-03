using DataBaseLayer.Entities;
using DataBaseLayer.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLayer.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly MyDbContext _context;

        // Constructor to inject the DbContext
        public SessionRepository(MyDbContext context)
        {
            _context = context;
        }

        // Get a response by Id
        public async Task<Session> GetSessionByIdAsync(string id)
        {
            return await _context.Sessions.FindAsync(id);
        }

        // Get all responses
        public async Task<IEnumerable<Session>> GetAllAsync()
        {
            return await _context.Sessions.ToListAsync();
        }

        // Add a new prompt
        public async Task CreateSessionAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        // Delete a response by Id
        public async Task DeleteAsync(string id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}

