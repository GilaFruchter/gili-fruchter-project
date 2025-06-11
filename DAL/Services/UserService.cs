
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Service
{
    public class UserService : IUser
    {
        DatabaseManager db;
        public UserService(DatabaseManager db)
        {
            this.db = db;
        }
        public async Task Create(User user)
        {
            await db.AddAsync(user);
            await db.SaveChangesAsync();
        }
        public async Task Delete(User item)
        {
            var existingUser = await db.Users.FindAsync(item.Id);
            if (existingUser == null)
            {
                throw new Exception($"User with ID {item.Id} not found.");
            }
            db.Users.Remove(existingUser);
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
                throw; // חשוב לזרוק את השגיאה כדי לטפל בה ברמה גבוהה יותר
            }
        }
        public async Task<List<User>> Read()
        {
            return await db.Users.ToListAsync();
        }
        public Task UpDate(User item)
        {
            throw new NotImplementedException();
        }
    }
}
