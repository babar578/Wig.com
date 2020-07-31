using MyShop.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
     public class Basket:BaseEntity

    {

        public virtual ICollection<Basketitem> Basketitems { get; set; } 
        public Basket()
        {

            this.Basketitems = new List<Basketitem>();
        }


    }
}
