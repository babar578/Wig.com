using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModel
{
   public abstract class BaseEntity
    {

        public string Id { get; set; }
        public DateTimeOffset Createdt { get; set; } 

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Createdt = DateTime.Now;


        }

    }
}
