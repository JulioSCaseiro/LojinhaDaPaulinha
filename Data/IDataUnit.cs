using LojinhaDaPaulinha.Data.Repositories.Interfaces;

namespace LojinhaDaPaulinha.Data
{
    public interface IDataUnit
    {
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
