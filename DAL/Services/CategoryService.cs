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
    public class CategoryService : ICategory
    {
        DatabaseManager db;
        public CategoryService(DatabaseManager db)
        {
            this.db = db;
        }
        public async Task Create(Category category)
        {
            await db.AddAsync(category);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Category item)
        {
            var existingCategory = await db.Categories.FindAsync(item.Id);
            if (existingCategory == null)
            {
                throw new Exception($"User with ID {item.Id} not found.");
            }
            db.Categories.Remove(existingCategory);
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
        public async Task<List<Category>> Read()
        {
            return await db.Categories.ToListAsync();
        }
        public Task UpDate(Category item)
        {
            throw new NotImplementedException();
        }

    }
}
