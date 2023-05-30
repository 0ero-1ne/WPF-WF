using System;
using System.Collections.Generic;
using Puzrain.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Input;
using System.Globalization;
using System.Windows;
using Puzrain.Stores;
using Puzrain.Commands;

namespace Puzrain.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        private readonly AppLanguageStore _appLanguageStore;
        public string AppLanguageStore => _appLanguageStore.AppLanguage;

        public string? _theme;
        public string? Theme
        {
            get => _theme!;
            set
            {
                _theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }

        private string? _currentViewModelString;
        public string? CurrentViewModelString
        {
            get => _currentViewModelString;
            set
            {
                _currentViewModelString = value!;
                OnPropertyChanged(nameof(CurrentViewModelString));
            }
        }

        public ICommand ChangeAppLanguage { get; }
        public ICommand MainCatalogOrAddProduct { get; }
        public ICommand ChangeTheme { get; }

        public MainWindowViewModel(NavigationStore navigationStore, AppLanguageStore appLanguageStore, string theme)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _appLanguageStore = appLanguageStore;
            _appLanguageStore.AppLanguageChanged += OnAppLanguageChanged;

            CurrentViewModelString = CurrentViewModel.ToString()!;
            Theme = theme;

            ChangeAppLanguage = new ChangeAppLanguageCommand(_appLanguageStore);
            MainCatalogOrAddProduct = new NavigateCommand(_navigationStore);
            ChangeTheme = new ChangeThemeCommand(this);
        }

        private void OnAppLanguageChanged()
        {
            OnPropertyChanged(nameof(AppLanguageStore));
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelString = CurrentViewModel.ToString()!;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
