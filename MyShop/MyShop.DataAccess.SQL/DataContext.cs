using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext:DbContext

    {
        public DataContext() : base("MyShop")
        {

        
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> ProductCategoryes { get; set; }







    }
}
