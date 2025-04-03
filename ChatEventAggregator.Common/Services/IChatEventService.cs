using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Enums;

namespace ChatEventAggregator.Common.Services;

public interface IChatEventService
{
    Task<IEnumerable<IRenderable>> Aggregate(EventGranularity granularity);
}