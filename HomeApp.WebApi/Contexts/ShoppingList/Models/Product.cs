﻿namespace HomeApp.WebApi.Contexts.ShoppingList.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public bool IsBought { get; set; }
        public virtual Category Category { get; set; }
    }
}