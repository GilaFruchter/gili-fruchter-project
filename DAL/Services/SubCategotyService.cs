using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    internal class SubCategotyService : ISubCategory
    {
        DatabaseManager db;
        public SubCategotyService(DatabaseManager db)
        {
            this.db = db;
        }
        public Task Create(SubCategory item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(SubCategory item)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategory>> Read()
        {
            throw new NotImplementedException();
        }

        public Task UpDate(SubCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
