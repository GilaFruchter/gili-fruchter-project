using System.Threading.Tasks;

namespace MyProject.Core.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GenerateLessonAsync(string prompt, string categoryName, string subCategoryName);
    }
}