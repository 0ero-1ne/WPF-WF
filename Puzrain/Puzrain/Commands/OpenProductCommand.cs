using Puzrain.Model;
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
    class OpenProductCommand : Command
    {
        private readonly NavigationStore _navigationStore;
        private readonly CatalogViewModel _catalogViewModel;

        public OpenProductCommand(NavigationStore navigationStore, CatalogViewModel catalogViewModel)
        {
            _navigationStore = navigationStore;
            _catalogViewModel = catalogViewModel;
        }

        public override void Execute(object? parameter)
        {
            string parameterValue = parameter!.ToString()!;
            string productTitle = parameterValue.Substring(parameterValue.IndexOf(' ') + 1);

            Product product = _catalogViewModel.Products.First(p => p.Title == productTitle);

            _navigationStore.CurrentViewModel = new ProductViewModel(product, _navigationStore);
        }
    }
}
