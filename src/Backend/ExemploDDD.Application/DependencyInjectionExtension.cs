using ExemploDDD.Application.Services.AutoMapper;
using ExemploDDD.Application.UseCases.User.ListActiveUsers;
using ExemploDDD.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploDDD.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IRecoverActiveUsersUseCase, RecoverActiveUsersUseCase>();
    }
}

