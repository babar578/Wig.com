using MyShop.Core.Contract;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.UI.Controllers
{
    public class ProductCategoryController : Controller
    {


        IRespoitory<ProductCategory> context;
        public ProductCategoryController(IRespoitory<ProductCategory> context)
        {
          this.context = context;

        }


        // GET: Product
        public ActionResult Index()
        {
            List<ProductCategory> products = context.Collection().ToList();

            return View(products);
        }

        public ActionResult Create()
        {
            ProductCategory product = new ProductCategory();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");

            }

        }

        public ActionResult Edit(string id)
        {
            ProductCategory product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory product, string id)
        {
            ProductCategory productToEdit = context.Find(id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {

                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productToEdit.Category = product.Category;
               
                context.Commit();
                return RedirectToAction("Index");

            }


        }


        public ActionResult Delete(string Id)
        {
            ProductCategory productTODelete = context.Find(Id);
            if (productTODelete == null)
            {

                return HttpNotFound();

            }
            else
            {

                return View(productTODelete);

            }




        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfimDelete(string Id)
        {
            ProductCategory productTODelete = context.Find(Id);
            if (productTODelete == null)
            {

                return HttpNotFound();

            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");

            };



        }
























    }
}