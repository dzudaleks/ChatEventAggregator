using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Repositories;
using ChatEventAggregator.Infrastructure.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace ChatEventAggregator.Testing.Services;

[TestFixture]
public class ChronologicalEventAggregateServiceTest
{
    private IEventRepository _eventRepository;
    private ChronologicalEventAggregateService _service;

    [SetUp]
    public void Setup()
    {
        _eventRepository = A.Fake<IEventRepository>();
        _service = new ChronologicalEventAggregateService(_eventRepository);
    }
    
    [Test]
    public async Task TestAggregate()
    {
        // arrange
        var events = TestData.GetEvents();
        A.CallTo(() => _eventRepository.GetAll()).Returns(events);
        
        // act
        var aggregatedEvents = await _service.Aggregate();

        // assert
        var chatEvents = aggregatedEvents as IEnumerable<ChatEvent>;
        Assert.That(chatEvents, Is.Not.Null, "Cannot cast to expected value");
        chatEvents.Select(x => x.Timestamp).Should().BeInAscendingOrder();
    }
}