using ExemploDDD.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploDDD.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
}

