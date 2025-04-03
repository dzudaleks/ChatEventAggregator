using ChatEventAggregator.Common.Domain;

namespace ChatEventAggregator.Testing;

public static class TestData
{
    public static List<ChatEvent> GetEvents()
    {
        var baseTime = DateTime.Now;
        var baseTimeNextHour = baseTime.AddHours(1);
        return
        [
            new EnterRoomEvent(baseTime.AddMinutes(1), "Bob"),
            new EnterRoomEvent(baseTime.AddMinutes(2), "Kate"),
            new CommentEvent("Some text", baseTime.AddMinutes(3), "Bob"),
            new HighFiveEvent("Some user", baseTime.AddMinutes(4), "Kate"),
            new LeaveRoomEvent(baseTime.AddMinutes(5), "Bob"),
    
            new EnterRoomEvent(baseTimeNextHour.AddMinutes(1), "Bob"),
            new EnterRoomEvent(baseTimeNextHour.AddMinutes(2), "Kate"),
            new CommentEvent("Some another text", baseTimeNextHour.AddMinutes(3), "Bob"),
            new HighFiveEvent("Some another user", baseTimeNextHour.AddMinutes(4), "Kate"),
            new LeaveRoomEvent(baseTimeNextHour.AddMinutes(5), "Bob")
        ];
    }
}