using KitapCache;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KitapUIElements
{
    public partial class App : Application
    {
        //for app work it is commented out
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Instantiate CacheManager
            CacheManager cacheManager = CacheManager.Instance;

            // Make CacheManager accessible globally if needed
            Application.Current.Properties["CacheManager"] = cacheManager;
        }

    }
}
