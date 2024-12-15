using System;
using StationeryInventory.Data;
using StationeryInventory.Models;

namespace StationeryInventory
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var context = new StationeryContext())
            {
                // Переконатися, що база даних створена
                context.Database.EnsureDeleted(); // Видалити, якщо база вже є (опційно)
                context.Database.EnsureCreated();

                // Додати постачальників
                var supplier1 = new Supplier { Name = "Office Supplies Co.", Address = "123 Main St" };
                var supplier2 = new Supplier { Name = "Paper Goods Inc.", Address = "456 Elm St" };

                context.Suppliers.AddRange(supplier1, supplier2);

                // Додати товари
                var product1 = new Product { Name = "Pen", Color = "Blue", Quantity = 100, Price = 2.5m };
                var product2 = new Product { Name = "Paper", Color = "White", Quantity = 500, Price = 0.10m };
                var product3 = new Product { Name = "Cizors", Color = "White", Quantity = 500, Price = 0.10m };


                context.Products.AddRange(product1, product2, product3);

                // Додати поставки
                var supply1 = new Supply { ProductId = 1, SupplierId = 1, SupplyDate = DateTime.Now, Quantity = 50 };
                var supply2 = new Supply { ProductId = 2, SupplierId = 2, SupplyDate = DateTime.Now, Quantity = 200 };
                var supply3 = new Supply { ProductId = 3, SupplierId = 2, SupplyDate = DateTime.Now, Quantity = 200 };
                context.Supplies.AddRange(supply1, supply2, supply3);

                // Зберегти зміни
                context.SaveChanges();
            }
        }
    }
}
