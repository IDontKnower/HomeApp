using HomeApp.WebApi.Contexts;
using HomeApp.WebApi.Contexts.ShoppingList;

namespace HomeApp.WebApi.Services
{
    public class SampleDataService
    {
        private readonly HomeAppContext _dbContext;

        public SampleDataService(HomeAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSampleData()
        {
            _dbContext.Categories.AddRange(GetSampleCategory());
            _dbContext.Products.AddRange(GetSampleProducts());
            _dbContext.SaveChanges();
        }
        
        private Product[] GetSampleProducts()
        {
            return new[]
            {
                new Product {Name = "Пылесос", Amount = 1, IsBought = false, CategoryId = 3},
                new Product {Name = "Хлеб", Amount = 2, IsBought = true, CategoryId = 2},
                new Product {Name = "Ватные палочки", Amount = 1, IsBought = false, CategoryId = 1}
            };
        }
        
        private Category[] GetSampleCategory()
        {
            return new[]
            {
                new Category {Name = "Нет категории" },
                new Category {Name = "Продукты"},
                new Category {Name = "Техника"}
            };
        }
    }
}