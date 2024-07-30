namespace LojinhaDaPaulinha.Data
{
    using LojinhaDaPaulinha.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Newsletter> Newsletters { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
