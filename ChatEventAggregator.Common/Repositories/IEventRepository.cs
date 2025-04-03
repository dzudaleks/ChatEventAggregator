using ChatEventAggregator.Common.Domain;

namespace ChatEventAggregator.Common.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<ChatEvent>> GetAll();
}