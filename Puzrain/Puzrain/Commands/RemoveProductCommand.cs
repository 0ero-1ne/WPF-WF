using System;
using Puzrain.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puzrain.ViewModel;
using Puzrain.Model;
using System.Windows;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;
using Puzrain.DB;

namespace Puzrain.Commands
{
    class RemoveProductCommand : Command
    {
        private readonly NavigationStore _navigationStore;
        private readonly Product _product;

        public RemoveProductCommand(NavigationStore navigationStore, Product product)
        {
            _navigationStore = navigationStore;
            _product = product;
        }


        public override void Execute(object? parameter)
        {
            Repository.Repository.DeleteProduct(_product);

            MessageBox.Show("Товар удалён / Product was removed", "Puzrain", MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationStore.CurrentViewModel = new CatalogViewModel(_navigationStore);
        }
    }
}
