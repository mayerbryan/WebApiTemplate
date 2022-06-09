using WebApiTemplate.Api.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// here we setup the instructions to entity framework conncet to our database and communicate with it
// this line is required to .Net recognize the sensitive information in the .env file
DotNetEnv.Env.Load();

//conncetion string that will be use to connect to our database
var connectionString = $"Server={Environment.GetEnvironmentVariable("SERVER")}, {Environment.GetEnvironmentVariable("DATABASE_PORT")}; Initial Catalog={Environment.GetEnvironmentVariable("DATABASE_NAME")};User ID={Environment.GetEnvironmentVariable("DATABASE_USER")}; Password={Environment.GetEnvironmentVariable("DATABASE_PASSWORD")}";

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AppDbContext>();

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


var app = builder.Build();

app.MapControllers();

app.Run();