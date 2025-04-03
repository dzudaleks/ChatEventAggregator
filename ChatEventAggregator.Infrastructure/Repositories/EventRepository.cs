using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Repositories;

namespace ChatEventAggregator.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    public async Task<IEnumerable<ChatEvent>> GetAll()
    {
        var entities = GetTestData();
        return await Task.FromResult(entities);
    }

    /// <summary>
    /// This method mocks the real time data
    /// </summary>
    private static IEnumerable<ChatEvent> GetTestData()
    {
        var baseTime = DateTime.Today.AddHours(17);
        return new List<ChatEvent>
        {
            new EnterRoomEvent(baseTime.AddMinutes(0), "Bob"),
            new EnterRoomEvent(baseTime.AddMinutes(5), "Kate"),
            new CommentEvent("Hey, Kate - high five?", baseTime.AddMinutes(15), "Bob"),
            new HighFiveEvent("Bob", baseTime.AddMinutes(17), "Kate"),
            new LeaveRoomEvent(baseTime.AddMinutes(18), "Bob"),
            new CommentEvent("Oh, typical", baseTime.AddMinutes(20), "Kate"),
            new LeaveRoomEvent(baseTime.AddMinutes(21), "Kate"),
            new EnterRoomEvent(baseTime.AddMinutes(65), "Alice"),
            new EnterRoomEvent(baseTime.AddMinutes(66), "Charlie"),
            new CommentEvent("Welcome everyone!", baseTime.AddMinutes(70), "Alice"),
            new HighFiveEvent("Alice", baseTime.AddMinutes(72), "Charlie"),
            new EnterRoomEvent(baseTime.AddMinutes(75), "Eve"),
            new CommentEvent("Glad to be here.", baseTime.AddMinutes(76), "Eve"),
            new CommentEvent("Let's get started!", baseTime.AddMinutes(80), "Alice"),
            new LeaveRoomEvent(baseTime.AddMinutes(85), "Charlie"),
            new HighFiveEvent("Alice", baseTime.AddMinutes(87), "Eve"),
            new CommentEvent("See you soon!", baseTime.AddMinutes(90), "Alice"),
            new LeaveRoomEvent(baseTime.AddMinutes(91), "Alice"),
            new LeaveRoomEvent(baseTime.AddMinutes(92), "Eve"),
            new EnterRoomEvent(baseTime.AddMinutes(110), "Frank")
        };
    }
}