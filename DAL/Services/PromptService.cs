using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PromptService : IPrompt
    {
        DatabaseManager db;
        public PromptService(DatabaseManager db)
        {
            this.db = db;
        }

        public async Task Create(Prompt prompt)
        {
            if (prompt == null)
            {
                throw new ArgumentNullException(nameof(prompt), "The prompts object is null.");
            }
            await db.AddAsync(prompt);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Prompt item)
        {
            var existingPrompt = await db.Prompts.FindAsync(item.Id);
            if (existingPrompt == null)
            {
                throw new Exception($"User with ID {item.Id} not found.");
            }
            db.Prompts.Remove(existingPrompt);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving changes: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }
        public async Task<List<Prompt>> Read()
        {
            return await db.Prompts.ToListAsync();
        }
        public Task UpDate(Prompt item)
        {
            throw new NotImplementedException();
        }

    }
}
