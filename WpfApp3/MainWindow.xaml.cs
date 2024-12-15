using System.Linq;
using System.Windows;
using StationeryInventory.Data;
using System.Globalization;

namespace StationeryInventory
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new StationeryContext())
            {
                // Завантаження постачальників
                SuppliersGrid.ItemsSource = context.Suppliers.ToList();

                // Завантаження товарів
                ProductsGrid.ItemsSource = context.Products.ToList();

                // Завантаження поставок
                SuppliesGrid.ItemsSource = context.Supplies.ToList();
            }
        }

        private void CalculateCosts_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new StationeryContext())
            {
                var supplierCosts = context.Supplies
                    .GroupBy(s => s.SupplierId)
                    .Select(g => new
                    {
                        SupplierId = g.Key,
                        TotalCost = g.Sum(s => s.Quantity *
                            context.Products
                                .Where(p => p.ProductId == s.ProductId)
                                .Select(p => p.Price)
                                .FirstOrDefault())
                    })
                    .ToList();

                string message = "";
                var usCulture = new CultureInfo("en-US");
                foreach (var supplierCost in supplierCosts)
                {
                    var supplier = context.Suppliers.Find(supplierCost.SupplierId);
                    message += $"Supplier: {supplier.Name}, Total Cost: {supplierCost.TotalCost.ToString("C", usCulture)}\n";
                }

                MessageBox.Show(message, "Total Costs per Supplier");
            }
        }
    }
}
