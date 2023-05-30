using Puzrain.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzrain.Stores
{
    public class AppLanguageStore
    {
        public event Action? AppLanguageChanged;

        private string? _appLanguage;

        public string AppLanguage
        {
            get => _appLanguage!;
            set
            {
                _appLanguage = value;
                OnAppLanguageChanged();
            }
        }

        private void OnAppLanguageChanged()
        {
            AppLanguageChanged?.Invoke();
        }
    }
}
