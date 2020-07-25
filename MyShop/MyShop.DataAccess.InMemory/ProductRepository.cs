using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        //,,,,Start

        ObjectCache cashe = MemoryCache.Default;
        List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products = cashe["products"] as List<Product>;
            products = new List<Product>();


        }

        public void Commit()
        {
            cashe["product"] = products;


        }

        public void Insert(Product p)
        {
            products.Add(p);



        }

        public void Update(Product product)
        {

            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;


            }
            else
            {
                throw new Exception("Product not Found");


            }


        }

        public Product Find(string Id)
        {

            Product product = products.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;


            }
            else
            {
                throw new Exception("Product not Found");


            }

        }



        public IQueryable<Product> Collection   ()
        {

            return products.AsQueryable();

            }


public void Delete(string id )
        {
            Product productToDelete = products.Find(p => p.Id == id);
            if (productToDelete!=null)
            {
                products.Remove(productToDelete);


            }
            else
            {

                throw new Exception("Product NOt Found");

            }





        }





        //.............End...

    }
}
