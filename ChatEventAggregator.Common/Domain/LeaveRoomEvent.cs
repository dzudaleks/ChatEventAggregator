using ChatEventAggregator.Common.Enums;

namespace ChatEventAggregator.Common.Domain;

public record LeaveRoomEvent(DateTime Timestamp, string UserName) 
    : ChatEvent(Timestamp, UserName, EventType.LeaveRoom)
{
    public override string Render()
    {
        return $"{Timestamp:t}: {UserName} leaves the room";
    }
}