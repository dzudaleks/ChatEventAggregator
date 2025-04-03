using ChatEventAggregator.Common.Enums;

namespace ChatEventAggregator.Common.Domain;

public record HighFiveEvent(string TargetUserName, DateTime Timestamp, string UserName) 
    : ChatEvent(Timestamp, UserName, EventType.HighFive)
{
    public override string Render()
    {
        return $"{Timestamp:t}: {UserName} high-fives {TargetUserName}";
    }
}
