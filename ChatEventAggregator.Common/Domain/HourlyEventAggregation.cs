namespace ChatEventAggregator.Common.Domain;

public record HourlyEventAggregation(int Hour, ChatEventStats ChatEventStats) : IRenderable
{
    public string Render()
    {
        var hourLabel = DateTime.Today.AddHours(Hour).ToString("htt").ToLower();
        return $"""
                {hourLabel} :
                {ChatEventStats.RoomEntersCount} {GetPersonLabel(ChatEventStats.RoomEntersCount)} entered
                {ChatEventStats.RoomLeavesCount} left
                {ChatEventStats.HighFivesFromCount} {GetPersonLabel(ChatEventStats.HighFivesFromCount)} high-fived {ChatEventStats.HighFivesToCount} other {GetPersonLabel(ChatEventStats.HighFivesToCount)}
                {ChatEventStats.CommentsCount} comments
                """;
    }

    private static string GetPersonLabel(int count)
    {
        return count == 1 ? "person" : "people";
    }
}