﻿using MyShop.Core.Contract;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.Services
{
  public   class BasketService
    {
        IRespoitory<Product> productContext;
        IRespoitory<Basket> basketContext;


        public const string BasketSeddionName = "eCommerceBasket";
        public BasketService(IRespoitory<Product> ProductContext, IRespoitory<Basket> BasketContext)
        {
            this.basketContext = BasketContext;
            this.productContext = ProductContext;
        }
        private Basket GetBasket(HttpContextBase  httpContext ,bool ClearIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSeddionName);
            Basket basket = new Basket();
            if (cookie!=null)
            {
                string BasketId = cookie.Value;
                if (!string.IsNullOrEmpty(BasketId))
                {
                    basket = basketContext.Find(BasketId);

                }

            }
            else
            {
                if (ClearIfNull)
                {
                    basket = CreateNewBasket(httpContext); 

                }
            }
            return basket;


        }
       

      private Basket CreateNewBasket( HttpContextBase httpContext)
        {
            Basket basket = new Basket();
            basketContext.Insert(basket);
            basketContext.Commit();
            HttpCookie cookie = new HttpCookie(BasketSeddionName);
            cookie.Value = basket.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);
            return basket;

        }
public void AddBasket(HttpContextBase contextBase , string productId)
        {
            Basket basket = GetBasket(contextBase, true);
            Basketitem item = basket.Basketitems.FirstOrDefault(p => p.ProductId == productId);

            if (item == null)
            {
                item = new Basketitem()
                {
                    BasketId = basket.Id,
                    ProductId = productId,
                    Quntity = 1


                };
                basket.Basketitems.Add(item);
               

            }

            else
            {
                item.Quntity = item.Quntity + 1;
            }
            basketContext.Commit();

        }
        public void RemoveBasket( HttpContextBase httpContext,string itemId)
        {
            Basket basket = GetBasket(httpContext, true);
            Basketitem item = basket.Basketitems.FirstOrDefault(i => i.Id == itemId);
            if (item!=null )
            {
                basket.Basketitems.Remove(item);
                basketContext.Commit();
                    
            }




        }






































    }
}
