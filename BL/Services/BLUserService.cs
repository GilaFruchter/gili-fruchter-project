using BL.Api;
using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLUserService : IBLUser
    {
        IUser use;
        public BLUserService(IDal dal)
        {
            use = dal.user ?? throw new ArgumentNullException(nameof(dal.user));
        }

        public void Create(User user)
        {
            use.Create(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await use.Read();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var customers = await use.Read();
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new Exception("Customer is not found");
            }

            return customer;
        }
        public async Task DeleteUser(int id)
        {
            var users = await use.Read();
            var userToDelete = users.FirstOrDefault(us => us.Id == id);

            if (userToDelete != null)
            {
                await use.Delete(userToDelete);
            }
            else
            {
                throw new Exception($"User with ID {id} not found.");
            }
        }

    }

}

