using WebApiTemplate.Api.Data;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Api.Services;

var builder = WebApplication.CreateBuilder(args);


// here we setup the instructions to entity framework conncet to our database and communicate with it
// this line is required to .Net recognize the sensitive information in the .env file
DotNetEnv.Env.Load();

//conncetion string that will be use to connect to our database
var connectionString = $"Server={Environment.GetEnvironmentVariable("SERVER")}, {Environment.GetEnvironmentVariable("DATABASE_PORT")}; Initial Catalog={Environment.GetEnvironmentVariable("DATABASE_NAME")};User ID={Environment.GetEnvironmentVariable("DATABASE_USER")}; Password={Environment.GetEnvironmentVariable("DATABASE_PASSWORD")}";

//add the connection string to our AppDbContext so can be used in the migration file
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AppDbContext>();

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// we are telling to our program to add the controllers files that we are using in the controllers folder.
builder.Services.AddControllers();

//here the app will take all instructions above and build everything together to make our application work
var app = builder.Build();



//this is the code that execute the migrations auto update
DataBaseManagementService.MigrationInitialisation(app);

// during the run time the app will check all the controller our code thet receive the ControllerBase field
// and make the routs to our app send and receive the requests thrue the controllers
app.MapControllers();

//here our application will starts so we can use it
app.Run();