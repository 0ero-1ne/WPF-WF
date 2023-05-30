using System;
using Puzrain.ViewModel;
using Puzrain.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puzrain.Model;

namespace Puzrain.Commands
{
    public class OpenEditProductCommand : Command
    {
        private readonly NavigationStore _navigationStore;
        private readonly Product _product;

        public OpenEditProductCommand(NavigationStore navigationStore, Product product)
        {
            _navigationStore = navigationStore;
            _product = product;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new EditProductViewModel(_navigationStore, _product);
        }
    }
}
