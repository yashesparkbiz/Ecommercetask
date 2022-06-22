using Microsoft.EntityFrameworkCore;
using Ecommercetask.Data.Data;
using MediatR;
using Ecommercetask.Core.Helper.CarsHelper.Queries.GetAllCars;
using Microsoft.AspNetCore.Identity;
using Ecommercetask.Data.Model;
using Ecommercetask.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ecommercetask.Core.Handlers.UsersHandler.Command.SignInUser;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddLog4Net();

// Add services to the container.
builder.Services.AddMediatR(typeof(GetAllCarsQuery).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
    {
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
        Reference = new Microsoft.OpenApi.Models.OpenApiReference {
            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    },
    new string[] {}
    }
    });
}); ;

builder.Services.AddDbContext<EcommerceSiteContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("default"), x => x.MigrationsAssembly("Ecommercetask.Data")));
//builder.Services.Configure<IdentityOptions>(options => options.SignIn.RequireConfirmedAccount = false);
builder.Services.AddIdentity<UserModel, IdentityRole<int>>().AddEntityFrameworkStores<EcommerceSiteContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<JwtHandler>();
builder.Services.AddCors();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["JWTSettings:validIssuer"],
        ValidAudience = builder.Configuration["JWTSettings:validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:securityKey"]))
    };
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();