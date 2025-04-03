using ChatEventAggregator.Common.Enums;

namespace ChatEventAggregator.Common.Domain;

public record CommentEvent(string Comment, DateTime Timestamp, string UserName) 
    : ChatEvent(Timestamp, UserName, EventType.Comment)
{
    public override string Render()
    {
        return $"{Timestamp:t}: {UserName} comments: \"{Comment}\"";
    }
}