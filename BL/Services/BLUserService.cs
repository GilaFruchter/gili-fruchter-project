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
    }
}
