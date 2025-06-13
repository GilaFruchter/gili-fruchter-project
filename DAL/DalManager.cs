using Dal.Service;
using DAL.Api;
using DAL.Models;
using DAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalManager : IDal
    {
        public IUser? user { get; set; }
        public ICategory? category { get; set; }
        public ISubCategory? subCategory { get; set; }
        public IPrompt? prompt { get; set; }

        public DalManager()
        {

            ServiceCollection service = new ServiceCollection();
            service.AddSingleton<DatabaseManager>();
            service.AddSingleton<IUser, UserService>();
            service.AddSingleton<ICategory, CategoryService>();
            service.AddSingleton<ISubCategory, SubCategotyService>();
            service.AddSingleton<IPrompt, PromptService>();



        ServiceProvider serviceProvider = service.BuildServiceProvider();
            user = serviceProvider.GetService<IUser>();
            category = serviceProvider.GetService<ICategory>();
            subCategory = serviceProvider.GetService<ISubCategory>();
            prompt = serviceProvider.GetService<IPrompt>();

        }
    }
}
