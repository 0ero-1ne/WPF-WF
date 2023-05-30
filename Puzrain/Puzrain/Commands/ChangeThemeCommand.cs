using Puzrain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Puzrain.Commands
{
    public class ChangeThemeCommand : Command
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public ChangeThemeCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            Application.Current.Resources.MergedDictionaries[1].Clear();

            if (_mainWindowViewModel.Theme == "Purple")
            {
                Uri newTheme = new Uri("../../../Style/NavyTheme/NavyTheme.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(new ResourceDictionary() { Source = newTheme });
                _mainWindowViewModel.Theme = "Navy";
            }
            else if (_mainWindowViewModel.Theme == "Navy")
            {
                Uri newTheme = new Uri("../../../Style/PurpleTheme/PurpleTheme.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(new ResourceDictionary() { Source = newTheme });
                _mainWindowViewModel.Theme = "Purple";
            }

            return;
        }
    }
}
