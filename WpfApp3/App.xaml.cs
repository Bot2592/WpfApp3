using System;
using System.Windows;

namespace StationeryInventory
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Ініціалізація бази даних
            DatabaseInitializer.Initialize();
        }
    }
}
