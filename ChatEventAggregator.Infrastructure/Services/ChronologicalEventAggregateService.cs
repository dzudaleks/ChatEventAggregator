using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Enums;
using ChatEventAggregator.Common.Repositories;
using ChatEventAggregator.Common.Services;

namespace ChatEventAggregator.Infrastructure.Services;

public class ChronologicalEventAggregateService : IChatEventAggregateService<IRenderable>
{
    private readonly IEventRepository _eventRepository;
    public static EventGranularity EventGranularity => EventGranularity.Chronologically;

    public ChronologicalEventAggregateService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public async Task<IEnumerable<IRenderable>> Aggregate()
    {
        var chatEvents = await _eventRepository.GetAll();
        return chatEvents.OrderBy(x => x.Timestamp);
    }
}

