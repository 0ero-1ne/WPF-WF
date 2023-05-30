using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puzrain.DB;
using Puzrain.Model;

namespace Puzrain.Repository
{
    public static class Repository
    {
        public static void AddProduct(Product product)
        {
            using (var db = new ProductContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }

        }

        public static void DeleteProduct(Product product)
        {
            using (var db = new ProductContext())
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public static void UpdateProduct(Product product)
        {
            using (var db = new ProductContext())
            {
                db.Products.Update(product);
                db.SaveChanges();
            }
        }

        public static IEnumerable<Product> GetProducts()
        {
            using (var db = new ProductContext())
            {
                return db.Products.ToList();
            }
        }
    }
}
