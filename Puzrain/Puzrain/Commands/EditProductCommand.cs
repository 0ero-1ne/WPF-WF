using System;
using Puzrain.ViewModel;
using Puzrain.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Puzrain.Model;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Runtime.Serialization.Json;
using System.ComponentModel.DataAnnotations;
using Puzrain.DB;

namespace Puzrain.Commands
{
    public class EditProductCommand : Command
    {
        private readonly NavigationStore _navigationStore;
        private readonly EditProductViewModel _editProductViewModel;

        Product product;

        public EditProductCommand(NavigationStore navigationStore, EditProductViewModel editProductViewModel)
        {
            _navigationStore = navigationStore;
            _editProductViewModel = editProductViewModel;

            using (var db = new ProductContext())
            {
                product = db.Products.FirstOrDefault(p => p.Id == editProductViewModel._product.Id)!;
            }
        }

        public override void Execute(object? parameter)
        {
            if (!Regex.IsMatch(_editProductViewModel.Stock, @"^0$|^[1-9][0-9]*$"))
            {
                GetErrorMessage("Неверно указано количество товара / Wrong product stock format");
                return;
            }

            if (!Regex.IsMatch(_editProductViewModel.Price, @"^(0*[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*)$"))
            {
                GetErrorMessage("Неверно указана цена товара / Wrong product price format");
                return;
            }

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(product);

            product.Title = _editProductViewModel.Title;
            product.Description = _editProductViewModel.Description;
            product.Category = _editProductViewModel.Category;
            product.Price = Convert.ToDouble(_editProductViewModel.Price);
            product.Stock = Convert.ToInt32(_editProductViewModel.Stock);
            product.InStock = Convert.ToInt32(_editProductViewModel.Stock) > 0 ? true : false;
            product.Image = @"D:\ООП_Мущук\Puzrain\Puzrain\Images\" + _editProductViewModel.Image;

            if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
            {
                GetErrorMessage(validationResults[0].ErrorMessage!);
                return;
            }

            if (_editProductViewModel.ImagePath is null)
            {
                GetErrorMessage("Выберите изображение товара / No product image");
                return;
            }

            Repository.Repository.UpdateProduct(product);

            if (_editProductViewModel.ImagePath != _editProductViewModel._product.Image)
            {
                File.Copy(_editProductViewModel.ImagePath, @"D:\ООП_Мущук\Puzrain\Puzrain\Images\" + _editProductViewModel.Image);
            }

            MessageBox.Show("Товар изменён / Product was edited", "Puzrain", MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationStore.CurrentViewModel = new ProductViewModel(product, _navigationStore);
        }

        private void GetErrorMessage(string message)
        {
            MessageBox.Show(message, "Puzrain", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
