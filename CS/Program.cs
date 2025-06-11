//using BL;
//using BL.Api;
//using BL.Services;
//using Microsoft.AspNetCore.Cors;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<IBLUser, BLUserService>();

//builder.Services.AddSingleton<IBLManager, BlManager>();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins",
//        builder => builder.AllowAnyOrigin()
//                            .AllowAnyMethod()
//                            .AllowAnyHeader());
//});

//var app = builder.Build();
//app.MapGet("/", () => "Hello World!");
//app.MapControllers();

//app.UseCors("AllowAllOrigins");

//app.Run();

using BL;
using BL.Api;
using BL.Services;
using Dal;
//using Dal.Api;
using DAL;
//using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            options.JsonSerializerOptions.MaxDepth = 64;
        });
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IBLManager, BlManager>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");
app.MapControllers();
app.Run();



