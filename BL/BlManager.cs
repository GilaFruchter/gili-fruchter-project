using BL.Api;
using BL.Services;
using DAL;
using DAL.Api;
using Microsoft.Extensions.DependencyInjection;

public class BlManager : IBLManager
{
//check
    public IBLUser BLUser { get; }
    public IBLCategory BLCategory { get; }
    public IBLSubCategory BLSubCategory { get; }
    public IBLPrompt BLPrompt { get; }

    public BlManager()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<IDal, DalManager>();
        services.AddSingleton<IBLUser, BLUserService>();
        services.AddSingleton<IBLCategory, BLCategoryService>();
        services.AddSingleton<IBLSubCategory, BLSubCategoryService>();
        services.AddSingleton<IBLPrompt, BlPromptService>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        BLUser = serviceProvider.GetService<IBLUser>();
        BLCategory = serviceProvider.GetService<IBLCategory>();
        BLSubCategory = serviceProvider.GetService<IBLSubCategory>();
        BLPrompt = serviceProvider.GetService<IBLPrompt>();
    }
}
