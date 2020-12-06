using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeApp.WebApi.Contexts.ShoppingList
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}