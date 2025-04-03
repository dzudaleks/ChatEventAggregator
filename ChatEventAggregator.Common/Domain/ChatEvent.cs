using ChatEventAggregator.Common.Enums;

namespace ChatEventAggregator.Common.Domain;

public abstract record ChatEvent(DateTime Timestamp, string UserName, EventType EventType) : IRenderable
{
    public abstract string Render();
}