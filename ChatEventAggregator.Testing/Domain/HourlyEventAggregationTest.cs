using ChatEventAggregator.Common.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace ChatEventAggregator.Testing.Domain;

[TestFixture]
public class HourlyEventAggregationTest
{
    [Test]
    public void TestHourlyEventAggregation_RendersProperly()
    {
        // arrange
        const int hour = 5;
        const int roomEntersCount = 1;
        const int roomLeavesCount = 2;
        const int commentsCount = 3;
        const int highFivesFromCount = 4;
        const int highFivesToCount = 5;

        var chatEventStats = new ChatEventStats(roomEntersCount, roomLeavesCount, commentsCount, highFivesFromCount, highFivesToCount);
        var hourlyEventAggregation = new HourlyEventAggregation(hour, chatEventStats);

        var expectedRender = $"""
                              {DateTime.Today.AddHours(hour).ToString("htt").ToLower()} :
                              {roomEntersCount} person entered
                              {roomLeavesCount} left
                              {highFivesFromCount} people high-fived {highFivesToCount} other people
                              {commentsCount} comments
                              """;
        // act
        var render = hourlyEventAggregation.Render();
        
        // assert
        render.Should().Be(expectedRender);
    }
}