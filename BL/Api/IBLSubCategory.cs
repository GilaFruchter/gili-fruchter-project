using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLSubCategory
    {
        public Task<List<SubCategory>> GetAll();
        public void Create(SubCategory subCategory);
        public Task<SubCategory> GetSubCategoryById(int id);
        public Task<List<SubCategory>> GetAllSubCategoryById(int id);
        public Task DeleteSubCategory(int id);
    }
}
