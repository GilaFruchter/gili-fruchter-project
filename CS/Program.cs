using BL;
using BL.Api;
using BL.Services;
using Dal;
using DAL;
using DAL.Api;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.MaxDepth = 64;
        });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IDal, DalManager>();
builder.Services.AddSingleton<IBLUser, BLUserService>();
builder.Services.AddSingleton<IBLCategory, BLCategoryService>();
builder.Services.AddSingleton<IBLSubCategory, BLSubCategoryService>();
builder.Services.AddSingleton<IBLPrompt, BlPromptService>();
builder.Services.AddSingleton<IBLManager, BlManager>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
