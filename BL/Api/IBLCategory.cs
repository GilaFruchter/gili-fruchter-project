using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLCategory
    {
        public Task<List<Category>> GetAll();
        public void Create(Category user);
        public Task<Category> GetCategoryById(int id);
        public Task DeleteCategory(int id);
    }
}
