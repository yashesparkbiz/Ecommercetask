using Microsoft.EntityFrameworkCore;
using Ecommercetask.Data.Data;
using MediatR;
using Ecommercetask.Core.Helper.CarsHelper.Queries.GetAllCars;
using Microsoft.AspNetCore.Identity;
using Ecommercetask.Data.Model;
using Ecommercetask.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddLog4Net();

// Add services to the container.
builder.Services.AddMediatR(typeof(GetAllCarsQuery).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcommerceSiteContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("default"), x => x.MigrationsAssembly("Ecommercetask.Data")));
builder.Services.AddIdentity<UserModel, IdentityRole<int>>().AddEntityFrameworkStores<EcommerceSiteContext>().AddDefaultTokenProviders();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();