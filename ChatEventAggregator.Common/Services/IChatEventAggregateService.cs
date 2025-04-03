namespace ChatEventAggregator.Common.Services;

public interface IChatEventAggregateService<T> where T : class
{
    Task<IEnumerable<T>> Aggregate();
}