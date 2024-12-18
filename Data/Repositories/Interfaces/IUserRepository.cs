using LojinhaDaPaulinha.Data.Identity;
using LojinhaDaPaulinha.Models.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojinhaDaPaulinha.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(AppUser user, string password);
        Task<IdentityResult> CreateInRoleAsync(AppUser user, string password, string roleName);
        Task<IdentityResult> DeleteAsync(string id);
        Task<AppUser> FindByIdAsync(string id);
        IQueryable<AppUser> GetAllAsNoTracking();
        Task<IEnumerable<UserViewModel>> GetAllOrderByPropertiesAsync(params string[] propertiesNames);
        Task<IEnumerable<SelectListItem>> GetComboRolesAsync();
        Task<UserViewModel> GetUserViewModelAsync(string id);
        Task<IdentityResult> SetNewPasswordAsync(AppUser user, string newPassword);
        Task<IdentityResult> SetRoleAsync(AppUser user, string roleName);
        Task<IdentityResult> UpdateAsync(AppUser user);
    }
}
