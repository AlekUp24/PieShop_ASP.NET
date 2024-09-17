namespace PieShop.Models
{
    public class CategoryReporsitory : ICategoryRepository
    {
        private readonly PieShopDbContext _pieShopDbContext;

        public CategoryReporsitory(PieShopDbContext pieShopDbContext)
        {
            _pieShopDbContext = pieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _pieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
