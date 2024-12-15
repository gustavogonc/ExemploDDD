using ExemploDDD.Domain.Repositories;
using ExemploDDD.Domain.Repositories.User;
using ExemploDDD.Domain.Security.Cryptography;
using ExemploDDD.Domain.Security.Tokens;
using ExemploDDD.Infraestructure.DataAccess;
using ExemploDDD.Infraestructure.DataAccess.Repositories;
using ExemploDDD.Infraestructure.Extensions;
using ExemploDDD.Infraestructure.Security.Cryptography;
using ExemploDDD.Infraestructure.Security.Tokens.Access.Generator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ExemploDDD.Infraestructure;
public static class DependencyInjectionExtensions
{
    public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddPasswordEncrypter(services);
        AddRepositories(services);
        AddSwagger(services);
        AddTokens(services, configuration);
    }


    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();
        services.AddDbContext<ExemploDDDDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
    }

    private static void AddPasswordEncrypter(IServiceCollection services)
    {
        services.AddScoped<IPasswordEncrypter, CryptographyPassword>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }

    private static void AddSwagger(IServiceCollection services)
    {
        const string AUTHENTICATION_TYPE = "Bearer";

        services.AddSwaggerGen(options =>
        {

            options.AddSecurityDefinition(AUTHENTICATION_TYPE, new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme.
                        Enter 'Bearer' [space] and then your token in the text input below.
                        Example: 'Bearer 123456abdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = AUTHENTICATION_TYPE
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = AUTHENTICATION_TYPE
                        },
                        Scheme = "oauth2",
                        Name = AUTHENTICATION_TYPE,
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });
    }

    private static void AddTokens(IServiceCollection services, IConfiguration configuration)
    {
        uint expirationTimeHours = configuration.GetValue<uint>("JwtConfiguration:ValidHours");
        string issuer = configuration.GetValue<string>("JwtConfiguration:Issuer")!;

        services.AddScoped<IAccessTokenGenerator>(option => new JwtTokenGenerator(expirationTimeHours, issuer));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetValue<string>("JwtConfiguration:Issuer"),
                ValidAudience = configuration.GetValue<string>("JwtConfiguration:Audience"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtConfiguration:Issuer")!)),
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}

