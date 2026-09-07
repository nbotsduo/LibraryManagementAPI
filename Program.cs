using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Interface;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<LibraryDbContext>(opt => opt.UseSqlServer(connString));

builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
//    context.Database.Migrate();
//    DbInitializer.Seed(context);
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
