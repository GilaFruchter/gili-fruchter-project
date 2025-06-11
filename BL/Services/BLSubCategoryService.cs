using BL.Api;
using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLSubCategoryService : IBLSubCategory
    {
        ISubCategory subCat;
        public BLSubCategoryService(IDal dal)
        {
            subCat = dal.subCategory ?? throw new ArgumentNullException(nameof(dal.subCategory));
        }

        public void Create(SubCategory subCategory)
        {
            subCat.Create(subCategory);
        }

        public async Task DeleteSubCategory(int id)
        {
            var users = await subCat.Read();
            var userToDelete = users.FirstOrDefault(us => us.Id == id);

            if (userToDelete != null)
            {
                await subCat.Delete(userToDelete);
            }
            else
            {
                throw new Exception($"User with ID {id} not found.");
            }
        }
        public async Task<List<SubCategory>> GetAll()
        {
            return await subCat.Read();
        }

        public async Task<List<SubCategory>> GetAllSubCategoryByIdAsync(int id)
        {
            var customers = await subCat.Read();
            var listCustomers = customers.Where(c => c.CategoryId == id).ToList();
            if (listCustomers == null || !listCustomers.Any())
            {
                throw new Exception("Customers not found");
            }

            return listCustomers;
        }


        public async Task<SubCategory> GetSubCategoryByIdAsync(int id)
        {
            var customers = await subCat.Read();
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new Exception("Customer is not found");
            }

            return customer;
        }
    }
}

        