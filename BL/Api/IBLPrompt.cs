using System.Threading.Tasks;
using DAL.Models;

namespace BL.Api
{
    public interface IBLPrompt
    {
       public Task<Prompt> AddPrompt(int userId, int categoryId, int subCategoryId, string userPrompt);
        public Task<List<Prompt>> GetAll();
        public Task<List<Prompt>> GetAllPromptByID(int id);
    }
}
