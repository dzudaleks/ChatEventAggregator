using ChatEventAggregator.Common;
using ChatEventAggregator.Common.Repositories;
using ChatEventAggregator.Common.Services;
using ChatEventAggregator.Infrastructure.Repositories;
using ChatEventAggregator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChatEventAggregator.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IChatEventService, ChatEventService>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ChronologicalEventAggregateService>();
        services.AddScoped<HourlyEventAggregateService>();
        services.AddSingleton<IChatEventAggregateServiceFactory, ChatEventAggregateServiceFactory>();
        return services;
    }
}