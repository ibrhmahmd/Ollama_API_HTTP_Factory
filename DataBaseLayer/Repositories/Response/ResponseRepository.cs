using DataBaseLayer.Entities;
using DataBaseLayer.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLayer.Repositories.Response
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly MyDbContext _context;

        // Constructor to inject the DbContext
        public ResponseRepository(MyDbContext context)
        {
            _context = context;
        }

        // Get a response by Id
        public async Task<AIResponse> GetByIdAsync(string id)
        {
            return await _context.AiResponses.FindAsync(id);
        }

        // Get all responses
        public async Task<IEnumerable<AIResponse>> GetAllAsync()
        {
            return await _context.AiResponses.ToListAsync();
        }

        // Add a new prompt
        public async Task AddAsync(AIResponse response)
        {
            await _context.AiResponses.AddAsync(response);
            await _context.SaveChangesAsync();
        }


        // Delete a response by Id
        public async Task DeleteAsync(string id)
        {
            var response = await _context.AiResponses.FindAsync(id);
            if (response != null)
            {
                _context.AiResponses.Remove(response);
                await _context.SaveChangesAsync();
            }
        }
    }
}

