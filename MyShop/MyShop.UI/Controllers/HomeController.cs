using MyShop.Core.Contract;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.ViewModel;

namespace MyShop.UI.Controllers
{
    public class HomeController : Controller
    {

        IRespoitory<Product> context;

        IRespoitory<ProductCategory> ProductCatgory;



        public HomeController(IRespoitory<Product> ProdctContract, IRespoitory<ProductCategory> ProductCategoryContract)
        {
            context = ProdctContract;
            ProductCatgory = ProductCategoryContract;

        }


        public ActionResult Index( string  Catagory = null)
        {
            List<Product> products;
            List<ProductCategory> categories = ProductCatgory.Collection().ToList();
            if (Catagory==null)
            {
              products=  context.Collection().ToList();

            }
            else
            {
                products = context.Collection().Where(p => p.Catagory == Catagory).ToList();

            }
            ProductListViewModel model = new ProductListViewModel();
            model.Product = products;
            model.ProductCategories = categories;

            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
             if ( product==null)
            {
                return HttpNotFound();

            }
            else
            {
                return View (product);

            }           
           
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}