 using System.Linq;
using MyShop.Core.ViewModel;

namespace MyShop.Core.Contract 
{
    public interface IRespoitory<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}