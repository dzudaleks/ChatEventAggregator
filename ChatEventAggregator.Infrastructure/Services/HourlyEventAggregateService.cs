using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Enums;
using ChatEventAggregator.Common.Repositories;
using ChatEventAggregator.Common.Services;

namespace ChatEventAggregator.Infrastructure.Services;

public class HourlyEventAggregateService : IChatEventAggregateService<IRenderable>
{
    private readonly IEventRepository _eventRepository;
    public static EventGranularity EventGranularity => EventGranularity.Hourly;

    public HourlyEventAggregateService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public async Task<IEnumerable<IRenderable>> Aggregate()
    {
        var chatEvents = await _eventRepository.GetAll();
        return chatEvents
            .GroupBy(x => x.Timestamp.Hour)
            .OrderBy(g => g.Key)
            .Select(g =>
                new HourlyEventAggregation(g.Key,
                    new ChatEventStats
                    (
                        g.Count(g => g.EventType == EventType.EnterRoom),
                        g.Count(g => g.EventType == EventType.LeaveRoom),
                        g.Count(g => g.EventType == EventType.Comment),
                        g.Where(g => g.EventType == EventType.HighFive).Select(e => e.UserName).Distinct().Count(),
                        g.OfType<HighFiveEvent>().Select(e => e.TargetUserName).Distinct().Count()
                    )));
    }
}