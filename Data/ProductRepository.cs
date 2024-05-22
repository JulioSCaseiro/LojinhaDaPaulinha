using LojinhaDaPaulinha.Data.Entities;

namespace LojinhaDaPaulinha.Data
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
