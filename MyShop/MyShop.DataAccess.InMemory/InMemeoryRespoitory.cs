using MyShop.Core.Contract;
using MyShop.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
     public class InMemeoryRespoitory<T> : IRespoitory<T> where T: BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> Item;
        string className;
        public InMemeoryRespoitory()
        {
            className = typeof(T).Name;
            Item = cache[className] as List<T>;
            if (Item ==null)
            {
                Item = new List<T>();

            }

        }

 
        public void Commit()
        {
            cache[className] = Item;
        }

        public void Insert(T t)
        {
            Item.Add(t);
        }
        public void Update(T t)
        {
            T tToUpdate = Item.Find(i => i.Id == t.Id);
            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + "Not Found");
            }

        }

        public T Find(string Id)
        {
            T t = Item.Find(i => i.Id == Id);
            if(t != null)
            {
                return t;

            }
            else
            {
                throw new Exception(className + "Not Found");

            }


        }
        public IQueryable<T> Collection()
        {

            return Item.AsQueryable();


        }


        public void Delete (string Id)
        {
            T tToDelete = Item.Find(i => i.Id ==  Id);
            if (tToDelete!=null)
            {
                Item.Remove(tToDelete);

          

            }

            else
            {
                throw new Exception(className + "Not Found ");

            }



        }













    }
}
