using ChatEventAggregator.Common;
using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Enums;
using ChatEventAggregator.Common.Services;
using ChatEventAggregator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChatEventAggregator.Infrastructure;

public class ChatEventAggregateServiceFactory : IChatEventAggregateServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ChatEventAggregateServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IChatEventAggregateService<IRenderable> CreateAggregateService(EventGranularity granularity)
    {
        return granularity switch
        {
            EventGranularity.Chronologically => _serviceProvider.GetRequiredService<ChronologicalEventAggregateService>(),
            EventGranularity.Hourly => _serviceProvider.GetRequiredService<HourlyEventAggregateService>(),
            _ => throw new ArgumentOutOfRangeException(nameof(granularity), $"Unsupported granularity: {granularity}")
        };
    }
}