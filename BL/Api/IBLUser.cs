using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models; 

namespace BL.Api
{
    public interface IBLUser
    {
        public Task<List<User>> GetAll();
        public void Create(User user);
        public Task<User> GetUserByIdAsync(int id);
        public Task DeleteUser(int id);
    }
}
