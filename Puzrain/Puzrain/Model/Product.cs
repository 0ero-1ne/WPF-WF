using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Puzrain.Model
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Укажите название товара / No product title")]
        public string? Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Укажите описание товара / No product description")]
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Укажите категорию товара / No product category")]
        public string? Category { get; set; }

        public double Price { get; set; }
        public int Stock { get; set; }

        public bool InStock { get; set; }
        public string Image { get; set; }

        public Product
        (
            string title,
            string description,
            string category,
            double price,
            int stock,
            string image
        )
        {
            Title = title;
            Description = description;
            Category = category;
            Price = price;
            Stock = stock;
            InStock = Stock > 0 ? true : false;
            Image = image;
            Id = GetHashCode();
        }

        public static IEnumerable<Product> DeserializeProducts()
        {
            IEnumerable<Product>? products;
            DataContractJsonSerializer jsonSerializer = new(typeof(List<Product>));

            using (FileStream fs = new(@"../../../Products.json", FileMode.OpenOrCreate))
            {
                products = jsonSerializer.ReadObject(fs) as List<Product>;
            }

            return products!;
        }

        public static void SerializeProducts(IEnumerable<Product>? products)
        {
            DataContractJsonSerializer jsonSerializer = new(typeof(List<Product>));

            using (FileStream fs = new(@"../../../Products.json", FileMode.Create))
            {
                jsonSerializer.WriteObject(fs, products!);
            }
        }
    }
}
