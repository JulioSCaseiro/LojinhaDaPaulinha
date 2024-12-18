namespace LojinhaDaPaulinha.Data
{
    using LojinhaDaPaulinha.Data.Entities;
    using LojinhaDaPaulinha.Data.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DbSet<Newsletter> Newsletters { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
