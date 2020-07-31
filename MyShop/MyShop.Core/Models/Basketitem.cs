using MyShop.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
   public  class Basketitem:BaseEntity
    {
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quntity { get; set; }




    }
}
