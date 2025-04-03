using ChatEventAggregator.Common.Enums;
using ChatEventAggregator.Common.Services;
using ChatEventAggregator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = RegisterServices();

var isValidInput = false;
while (!isValidInput)
{
    Console.WriteLine("Select event granularity: (Chronologically / Hourly):");
    Console.WriteLine("0 - Chronologically");
    Console.WriteLine("1 - Hourly");

    var input = Console.ReadLine();

    if (Enum.TryParse<EventGranularity>(input, true, out var granularity))
    {
        Console.WriteLine($"You selected: {granularity}");
        isValidInput = true;

        var chatEventService = serviceProvider.GetRequiredService<IChatEventService>();
        var chatEvents = await chatEventService.Aggregate(granularity);
        foreach (var chatEvent in chatEvents)
        {
            Console.WriteLine(chatEvent.Render());
        }

        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Invalid input.");
    }
}

return;


ServiceProvider RegisterServices()
{
    var services = new ServiceCollection();
    services.AddServices();
    return services.BuildServiceProvider();
}