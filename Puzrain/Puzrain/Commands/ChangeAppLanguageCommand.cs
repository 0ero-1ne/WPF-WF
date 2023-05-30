using Puzrain.Stores;
using Puzrain.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Puzrain.Commands
{
    public class ChangeAppLanguageCommand : Command
    {
        private readonly AppLanguageStore _appLanguageStore;

        public ChangeAppLanguageCommand(AppLanguageStore appLanguageStore)
        {
            _appLanguageStore = appLanguageStore;
        }

        public override void Execute(object? parameter)
        {
            if (_appLanguageStore.AppLanguage == "RU")
            {
                App.Language = new CultureInfo("en-EN");
                _appLanguageStore.AppLanguage = "EN";
            }
            else
            {
                App.Language = new CultureInfo("ru-RU");
                _appLanguageStore.AppLanguage = "RU";
            }
        }
    }
}
