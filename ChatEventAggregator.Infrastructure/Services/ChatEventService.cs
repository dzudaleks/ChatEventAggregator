using ChatEventAggregator.Common;
using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Enums;
using ChatEventAggregator.Common.Services;

namespace ChatEventAggregator.Infrastructure.Services;
public class ChatEventService : IChatEventService
{
    private readonly IChatEventAggregateServiceFactory _eventAggregateServiceFactory;

    public ChatEventService(IChatEventAggregateServiceFactory eventAggregateServiceFactory)
    {
        _eventAggregateServiceFactory = eventAggregateServiceFactory;
    }

    public async Task<IEnumerable<IRenderable>> Aggregate(EventGranularity granularity)
    {
        var chatEventAggregateService = _eventAggregateServiceFactory.CreateAggregateService(granularity);
        return await chatEventAggregateService.Aggregate();
    }
}