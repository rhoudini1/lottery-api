using FluentValidation;
using LottoManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LottoManager.Application;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ILotteryService, LotteryService>();
        
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Scoped);
        
        return services;
    }
}

public interface IApplicationMarker {}