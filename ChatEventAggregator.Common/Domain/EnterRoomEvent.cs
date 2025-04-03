using ChatEventAggregator.Common.Enums;

namespace ChatEventAggregator.Common.Domain;

public record EnterRoomEvent(DateTime Timestamp, string UserName) 
    : ChatEvent(Timestamp, UserName, EventType.EnterRoom)
{
    public override string Render()
    {
        return $"{Timestamp:t}: {UserName} enters the room";
    }
}