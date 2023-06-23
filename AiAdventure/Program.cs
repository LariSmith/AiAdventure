using Microsoft.EntityFrameworkCore;

using AiAdventure.Data;
using AiAdventure.Interfaces;
using AiAdventure.Services;
using AiAdventure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AiAdventureContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var _config = builder.Configuration;
var host = _config["ApplicationSettings:Host"];
var key = _config["JWT:Secret"];

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = host,
        ValidAudience = host,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IPasswordHandler, PasswordHandler>();
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Demo API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


using (var app = builder.Build())
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseAuthentication();

    app.MapControllers();

    app.Run();
}
