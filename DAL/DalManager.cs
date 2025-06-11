using Dal.Service;
using DAL.Api;
using DAL.Models;
using DAL.Services;
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

            // כאן אתה בונה את ה-Provider
            ServiceProvider serviceProvider = service.BuildServiceProvider();

            // וכאן אתה מאתחל את התכונות
            user = serviceProvider.GetService<IUser>();
        }


        //public DalManager()
        //{
        //    ServiceCollection service = new ServiceCollection();
        //    service.AddSingleton<DatabaseManager>();
        //    service.AddSingleton<IUser, UserService>();
        //    //service.AddSingleton<IInvitation, InvitationService>();
        //    //service.AddSingleton<IWorker, WorkerService>();
        //    //service.AddSingleton<IDish, DishService>();
        //    //ServiceProvider serviceProvider = service.BuildServiceProvider();
        //    //customers = serviceProvider.GetService<ICustomer>();
        //    //invitations = serviceProvider.GetService<IInvitation>();
        //    //workers = serviceProvider.GetService<IWorker>();
        //    //dish = serviceProvider.GetService<IDish>();
        //}
    }
}
