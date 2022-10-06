using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// IoC Containers of the .NET6

// These resolvers were moved to the Business/DependencyResolvers/Autofac/AutofacBusinessModule.cs
// because of the Autofac software was wanted to use by us.

//builder.Services.AddScoped<ICarService, CarManager>();
//builder.Services.AddScoped<ICarDal, EfCarDal>();

//builder.Services.AddScoped<IColorService, ColorManager>();
//builder.Services.AddScoped<IColorDal, EfColorDal>();

//builder.Services.AddScoped<IBrandService, BrandManager>();
//builder.Services.AddScoped<IBrandDal, EfBrandDal>();

//builder.Services.AddScoped<IUserService, UserManager>();
//builder.Services.AddScoped<IUserDal, EfUserDal>();

//builder.Services.AddScoped<ICustomerService, CustomerManager>();
//builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();

//builder.Services.AddScoped<IRentalService, RentalManager>();
//builder.Services.AddScoped<IRentalDal, EfRentalDal>();

// IoC Containers of the .NET6

////////////////////////////////////////////////////////////////////////

// IoC Containers of the Autofac

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

// IoC Containers of the Autofac

// CORS Configuration 
builder.Services.AddCors();
// CORS Configuration 

// JWT Configuration
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

// JWT Configuration

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS Configuration → If 4200th port wants to request anything, give it.
app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
// CORS Configuration 

// Middlewares
app.UseHttpsRedirection();

// JWT Configuration
app.UseAuthentication();
// JWT Configuration

app.UseAuthorization();

app.MapControllers();

app.Run();
