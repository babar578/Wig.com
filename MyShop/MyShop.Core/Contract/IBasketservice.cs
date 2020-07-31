using MyShop.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.Core.Contract
{
   public interface IBasketservice
    {

        void AddBasket(HttpContextBase contextBase, string productId);
        void RemoveBasket(HttpContextBase httpContext, string itemId);
        List<BasketitemViewModel> GetBasketitem(HttpContextBase httpContext);
        BasketViewSummaryViewModel GetBasketSummary(HttpContextBase httpContext);







    }
}
