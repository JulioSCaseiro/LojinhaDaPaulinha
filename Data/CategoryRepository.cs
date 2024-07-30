using LojinhaDaPaulinha.Data.Entities;

namespace LojinhaDaPaulinha.Data
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
