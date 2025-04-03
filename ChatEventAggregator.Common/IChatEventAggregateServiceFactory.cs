using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Enums;
using ChatEventAggregator.Common.Services;

namespace ChatEventAggregator.Common;

public interface IChatEventAggregateServiceFactory
{
    IChatEventAggregateService<IRenderable> CreateAggregateService(EventGranularity granularity);
}