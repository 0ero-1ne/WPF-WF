using Puzrain.Stores;
using Puzrain.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Puzrain.DB;
using Microsoft.EntityFrameworkCore;

namespace Puzrain
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly AppLanguageStore _appLanguageStore;
        private static List<CultureInfo> m_Languages = new List<CultureInfo>();

        public static List<CultureInfo> Languages
        {
            get
            {
                return m_Languages;
            }
        }

        public App()
        {
            _navigationStore = new();
            _appLanguageStore = new();
            m_Languages.Clear();
            m_Languages.Add(new CultureInfo("ru-RU")); //Нейтральная культура для этого проекта
            m_Languages.Add(new CultureInfo("en-EN"));

            using (var db = new ProductContext())
            {
                db.Database.Migrate();
            }
        }

        public static CultureInfo Language
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "en-EN":
                        dict.Source = new Uri(String.Format("Locale/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri("Locale/lang.xaml", UriKind.Relative);
                        break;
                }

                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries[0].MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith("Locale/lang.")
                                              select d).First();
                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(dict);
                }
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new CatalogViewModel(_navigationStore);
            _appLanguageStore.AppLanguage = "RU";
            string? _theme = "Purple";

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore, _appLanguageStore, _theme)
            };
            MainWindow.Show();

            Language = new CultureInfo("ru-RU");

            base.OnStartup(e);
        }
    }
}
