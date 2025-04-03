using ChatEventAggregator.Common.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace ChatEventAggregator.Testing.Domain;

[TestFixture]
public class ChatEventTests
{
    private const string User = "Test user";
    private readonly DateTime _timestamp = DateTime.Now;
    
    [Test]
    public void TestCommentEvent_RendersProperly()
    {
        // arrange
        const string comment = "Some comment";
        var commentEvent = new CommentEvent(comment, _timestamp, User);
        var expectedRender = $"{_timestamp:t}: {User} comments: \"{comment}\"";
        
        // act
        var render = commentEvent.Render();
        
        // assert
        render.Should().Be(expectedRender);
    }
    
    [Test]
    public void TestHighFiveEvent_RendersProperly()
    {
        // arrange
        const string targetUser = "Some user";
        var commentEvent = new HighFiveEvent(targetUser, _timestamp, User);
        var expectedRender = $"{_timestamp:t}: {User} high-fives {targetUser}";
        
        // act
        var render = commentEvent.Render();
        
        // assert
        render.Should().Be(expectedRender);
    }
    
    [Test]
    public void TestEnterRoomEvent_RendersProperly()
    {
        // arrange
        var commentEvent = new EnterRoomEvent(_timestamp, User);
        var expectedRender = $"{_timestamp:t}: {User} enters the room";
        
        // act
        var render = commentEvent.Render();
        
        // assert
        render.Should().Be(expectedRender);
    }
    
    [Test]
    public void TestLeaveRoomEvent_RendersProperly()
    {
        // arrange
        var commentEvent = new LeaveRoomEvent(_timestamp, User);
        var expectedRender = $"{_timestamp:t}: {User} leaves the room";
        
        // act
        var render = commentEvent.Render();
        
        // assert
        render.Should().Be(expectedRender);
    }
}