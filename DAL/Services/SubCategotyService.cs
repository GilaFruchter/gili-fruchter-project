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
    public class SubCategotyService : ISubCategory
    {
        DatabaseManager db;
        public SubCategotyService(DatabaseManager db)
        {
            this.db = db;
        }
       
        public async Task Create(SubCategory subCategory)
        {
            await db.AddAsync(subCategory);
            await db.SaveChangesAsync();
        }
        public async Task Delete(SubCategory subCategory)
        {
            var existingSubCategory = await db.SubCategories.FindAsync(subCategory.Id);
            if (existingSubCategory == null)
            {
                throw new Exception($"User with ID {subCategory.Id} not found.");
            }
            db.SubCategories.Remove(existingSubCategory);
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
        public async Task<List<SubCategory>> Read()
        {
            return await db.SubCategories.ToListAsync();
        }
        public Task UpDate(SubCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
