using ChatEventAggregator.Common.Domain;
using ChatEventAggregator.Common.Repositories;
using ChatEventAggregator.Infrastructure.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace ChatEventAggregator.Testing.Services;

[TestFixture]
public class HourlyEventAggregateServiceTest
{
    private IEventRepository _eventRepository;
    private HourlyEventAggregateService _service;

    [SetUp]
    public void Setup()
    {
        _eventRepository = A.Fake<IEventRepository>();
        _service = new HourlyEventAggregateService(_eventRepository);
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
        var hourlyEventAggregations = aggregatedEvents as IEnumerable<HourlyEventAggregation>;
        Assert.That(hourlyEventAggregations, Is.Not.Null, "Cannot cast to expected value");
        hourlyEventAggregations.Select(x => x.Hour).Should().BeInAscendingOrder();
    }
}