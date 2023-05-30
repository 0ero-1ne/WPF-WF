using Puzrain.Stores;
using Puzrain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Puzrain.Model;

namespace Puzrain.ViewModel
{
    public class AddProductViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;

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

        public ICommand AddProduct { get; }
        public ICommand OpenFileDialog { get; }

        public AddProductViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            AddProduct = new AddProductCommand(_navigationStore, this);

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
