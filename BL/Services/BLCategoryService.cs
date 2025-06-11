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
    public class BLCategoryService: IBLCategory
    {
        ICategory cat;
        public BLCategoryService(IDal dal)
        {
            cat = dal.category ?? throw new ArgumentNullException(nameof(dal.category));
        }

        public void Create(Category category)
        {
            cat.Create(category);
        }

        public async Task<List<Category>> GetAll()
        {
            return await cat.Read();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var customers = await cat.Read();
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new Exception("Customer is not found");
            }

            return customer;
        }
        public async Task DeleteCategory(int id)
        {
            var users = await cat.Read();
            var userToDelete = users.FirstOrDefault(ca => ca.Id == id);

            if (userToDelete != null)
            {
                await cat.Delete(userToDelete);
            }
            else
            {
                throw new Exception($"User with ID {id} not found.");
            }
        }

    }
}

