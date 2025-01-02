using DataBaseLayer.Entities;
using DataBaseLayer.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseLayer.Repositories.PromptRepo
{
    public class PromptRepository : IPromptRepository
    {
        private readonly MyDbContext _context;

        // Constructor to inject the DbContext
        public PromptRepository(MyDbContext context)
        {
            _context = context;
        }

        // Get a prompt by Id
        public async Task<Prompt> GetByIdAsync(string id)
        {
            return await _context.Prompts.FindAsync(id);
        }

        // Get all prompts
        public async Task<IEnumerable<Prompt>> GetAllAsync()
        {
            return await _context.Prompts.ToListAsync();
        }

        // Add a new prompt
        public async Task AddAsync(Prompt prompt)
        {
            await _context.Prompts.AddAsync(prompt);
            await _context.SaveChangesAsync();
        }


        // Delete a prompt by Id
        public async Task DeleteAsync(string id)
        {
            var prompt = await _context.Prompts.FindAsync(id);
            if (prompt != null)
            {
                _context.Prompts.Remove(prompt);
                await _context.SaveChangesAsync();
            }
        }
    }
}
