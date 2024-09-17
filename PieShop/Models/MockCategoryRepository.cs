namespace PieShop.Models
{
    public class MockCategoryRepository: ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId = 1, CategoryName="Fruit pies", Description="All-fruity pies"},
                new Category{CategoryId = 2, CategoryName="Cheese cakes", Description="Cheesy all the way"},
                new Category{CategoryId = 3, CategoryName="Sesonalpies", Description="Get in mood for a sesonal pie"}
            };
    }
}
