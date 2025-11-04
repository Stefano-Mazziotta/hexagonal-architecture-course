using DomainComponent.Entities;

namespace ApplicationComponent
{
    // entry port
    public interface IService
    {
        Task<IEnumerable<Item>> GetAsync();
        Task AddAsync(string title);
    }
}
