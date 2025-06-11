using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class Prompt : IPrompt
    {
        DatabaseManager db;
        public Prompt(DatabaseManager db)
        {
            this.db = db;
        }
        public Task Create(Models.Prompt item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Models.Prompt item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Prompt>> Read()
        {
            throw new NotImplementedException();
        }

        public Task UpDate(Models.Prompt item)
        {
            throw new NotImplementedException();
        }
    }
}
