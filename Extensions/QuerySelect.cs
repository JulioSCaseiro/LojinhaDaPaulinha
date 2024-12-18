using LojinhaDaPaulinha.Data.Identity;
using LojinhaDaPaulinha.Models.Entities.User;

namespace LojinhaDaPaulinha.Extensions
{
    public static class QuerySelect
    {
        public static IQueryable<UserViewModel> SelectUserViewModel(this IQueryable<AppUser> query)
        {
            return query.Select(user => new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role
            });
        }
    }
}
