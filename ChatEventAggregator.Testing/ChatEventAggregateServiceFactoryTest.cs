using ChatEventAggregator.Common.Enums;
using ChatEventAggregator.Infrastructure;
using ChatEventAggregator.Infrastructure.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ChatEventAggregator.Testing;

[TestFixture]
public class ChatEventAggregateServiceFactoryTest
{
    private ServiceProvider _serviceProvider;
    private ChatEventAggregateServiceFactory _serviceFactory;
    private ChronologicalEventAggregateService _chronologicalEventAggregateService;
    private HourlyEventAggregateService _hourlyEventAggregateService;

    [SetUp]
    public void Setup()
    {
        _chronologicalEventAggregateService = A.Fake<ChronologicalEventAggregateService>();
        _hourlyEventAggregateService = A.Fake<HourlyEventAggregateService>();
        
        var services = new ServiceCollection();
        services.AddSingleton(_ => _chronologicalEventAggregateService);
        services.AddSingleton(_ => _hourlyEventAggregateService);
        _serviceProvider = services.BuildServiceProvider();
        
        _serviceFactory = new ChatEventAggregateServiceFactory(_serviceProvider);
    }

    [Test]
    public void TestCreateService_WhenGranularityIsChronologically_ShouldReturnProperService()
    {
        // act
        var aggregateService = _serviceFactory.CreateAggregateService(EventGranularity.Chronologically);
        
        // assert
        aggregateService.Should().BeSameAs(_chronologicalEventAggregateService);
    }
    
    [Test]
    public void TestCreateService_WhenGranularityIsHourly_ShouldReturnProperService()
    {
        // act
        var aggregateService = _serviceFactory.CreateAggregateService(EventGranularity.Hourly);
        
        // assert
        aggregateService.Should().BeSameAs(_hourlyEventAggregateService);
    }
    
    [Test]
    public void CreateAggregateService_WithUnsupportedGranularity_ShouldThrowException()
    {
        // act
        Action act = () => _serviceFactory.CreateAggregateService((EventGranularity)123);

        // assert
        act.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("*Unsupported granularity*");
    }
}