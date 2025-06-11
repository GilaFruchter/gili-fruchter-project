using DAL.Api;
using DAL.Models;
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
        public Task Create(Category item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> Read()
        {
            throw new NotImplementedException();
        }

        public Task UpDate(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
