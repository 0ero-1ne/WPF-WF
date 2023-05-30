using Puzrain.Stores;
using Puzrain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Puzrain.Commands
{
    public class NavigateCommand : Command
    {
        private readonly NavigationStore? _navigationStore;

        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore!.CurrentViewModel = (_navigationStore.CurrentViewModel is CatalogViewModel) ? new AddProductViewModel(_navigationStore) : new CatalogViewModel(_navigationStore);
        }
    }
}
