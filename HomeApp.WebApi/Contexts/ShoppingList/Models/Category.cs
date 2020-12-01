using System.Collections.Generic;

namespace HomeApp.WebApi.Contexts.ShoppingList.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}