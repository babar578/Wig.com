﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;


namespace MyShop.WebUI.Controllers
{
    public class ProductController : Controller
    {



        ProductRepository context;
        public ProductController()
        {
            context = new ProductRepository();

        }


        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();

            return View(products);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product product)
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
            Product product = context.Find(id);
            if (product==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
           }
       }

        [HttpPost]
        public ActionResult Edit(Product product, string id)
        {
            Product productToEdit = context.Find(id);
            
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
                productToEdit.Name = product.Name;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Price = product.Price;
                productToEdit.Catagory = product.Catagory;
                context.Commit();
                return RedirectToAction("Index");

            }


        }


       public ActionResult Delete(string Id)
        {
            Product productTODelete = context.Find(Id);
            if(productTODelete == null){

                return HttpNotFound();

            }
            else{

                return View (productTODelete);

            }




        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfimDelete(string Id)
        {
            Product productTODelete = context.Find(Id);
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