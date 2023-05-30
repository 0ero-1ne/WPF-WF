using Microsoft.Win32;
using Puzrain.Commands;
using Puzrain.Model;
using Puzrain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Puzrain.ViewModel
{
    public class EditProductViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public readonly Product _product;

        private string? _title;
        public string Title
        {
            get => _title!;
            set
            {
                _title = value.Trim();
                OnPropertyChanged(nameof(Title));
            }
        }

        private string? _description;
        public string Description
        {
            get => _description!;
            set
            {
                _description = value.Trim();
                OnPropertyChanged(nameof(Description));
            }
        }

        private string? _category;
        public string Category
        {
            get => _category!;
            set
            {
                _category = value.Trim();
                OnPropertyChanged(nameof(Category));
            }
        }

        private string? _price;
        public string Price
        {
            get => _price!;
            set
            {
                _price = value.Trim();
                OnPropertyChanged(nameof(Price));
            }
        }

        private string? _stock;
        public string Stock
        {
            get => _stock!;
            set
            {
                _stock = value.Trim();
                OnPropertyChanged(nameof(Stock));
            }
        }

        private string? _image;
        public string Image
        {
            get => _image!;
            set
            {
                _image = value.Trim();
                OnPropertyChanged(nameof(Image));
            }
        }

        private string? _imagePath;
        public string ImagePath
        {
            get => _imagePath!;
            set
            {
                _imagePath = value.Trim();
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public ICommand EditProduct { get; }
        public ICommand OpenFileDialog { get; }

        public EditProductViewModel(NavigationStore navigationStore, Product product)
        {
            _navigationStore = navigationStore;
            _product = product;

            _title = product.Title;
            _description = product.Description;
            _price = product.Price.ToString();
            _stock = product.Stock.ToString();
            _category = product.Category;
            _imagePath = product.Image;
            _image = product.Image.Substring(product.Image.LastIndexOf('\\') + 1);

            EditProduct = new EditProductCommand(_navigationStore, this);

            OpenFileDialog = new OpenFileDialogCommand()
            {
                _executeMethod = OpenFileDialogExecute
            };
        }

        private void OpenFileDialogExecute()
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Portable Network Graphic (*.png)|*.png";

            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                ImagePath = ofd.FileName;
                Image = ImagePath.Substring(ImagePath.LastIndexOf('\\') + 1);
            }
        }
    }
}
