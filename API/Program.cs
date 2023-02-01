using API.Data;
using API.Error;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);

// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("https://localhost:4200"));

app.UseAuthentication(); // do you have valid token 
app.UseAuthorization(); // you have valid token but what you allow to do 
app.MapControllers();

//Seed Database

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
} 
catch(Exception ex)
{
    var loggger = services.GetService<ILogger<Program>>();
    loggger.LogError(ex, "An error occured during migration");
}  


app.Run();
