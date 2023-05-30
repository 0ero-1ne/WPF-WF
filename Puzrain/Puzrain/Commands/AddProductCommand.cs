using Puzrain.Stores;
using Puzrain.ViewModel;
using Puzrain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Puzrain.Model;
using System.Runtime.Serialization.Json;
using System.ComponentModel.DataAnnotations;

namespace Puzrain.Commands
{
    class AddProductCommand : Command
    {
        private readonly NavigationStore _navigationStore;
        private readonly AddProductViewModel _addProductViewModel;

        private List<Product>? products = new();
        private readonly DataContractJsonSerializer jsonSerializer = new(typeof(List<Product>));

        public AddProductCommand(NavigationStore navigationStore, AddProductViewModel addProductViewModel)
        {
            _navigationStore = navigationStore;
            _addProductViewModel = addProductViewModel;
        }

        public override void Execute(object? parameter)
        {
            products = Product.DeserializeProducts().ToList();

            if (!Regex.IsMatch(_addProductViewModel.Stock, @"^0$|^[1-9][0-9]*$"))
            {
                GetErrorMessage("Неверно указано количество товара / Wrong product stock format");
                return;
            }

            if (!Regex.IsMatch(_addProductViewModel.Price, @"^(0*[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*)$"))
            {
                GetErrorMessage("Неверно указана цена товара / Wrong product price format");
                return;
            }

            if (_addProductViewModel.ImagePath is null)
            {
                GetErrorMessage("Выберите изображение товара / No product image");
                return;
            }

            Product product = new
            (
                _addProductViewModel.Title,
                _addProductViewModel.Description,
                _addProductViewModel.Category,
                Convert.ToDouble(_addProductViewModel.Price),
                Convert.ToInt32(_addProductViewModel.Stock),
                @"D:\ООП_Мущук\Puzrain\Puzrain\Images\" + _addProductViewModel.Image
            );

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(product);

            if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
            {
                GetErrorMessage(validationResults[0].ErrorMessage!);
                return;
            }

            if (File.Exists(@"D:\ООП_Мущук\Puzrain\Puzrain\Images\" + _addProductViewModel.Image))
            {
                GetErrorMessage("Выберите другое изображение товара / Choose another product image");
                return;
            }

            Repository.Repository.AddProduct(product);

            //products!.Add(product);
            //Product.SerializeProducts(products!);

            File.Copy(_addProductViewModel.ImagePath, @"D:\ООП_Мущук\Puzrain\Puzrain\Images\" + _addProductViewModel.Image);
            MessageBox.Show("Товар добавлен / Product was added", "Puzrain", MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationStore.CurrentViewModel = new CatalogViewModel(_navigationStore);
        }

        private void GetErrorMessage(string message)
        {
            MessageBox.Show(message, "Puzrain", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
