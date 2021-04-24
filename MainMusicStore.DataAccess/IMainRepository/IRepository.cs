using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MainMusicStore.DataAccess.IRepository
{
   public interface IRepository<T> where T:class
    {
        T Get(int id);
        //IEnumerable birden fazla kayıt girdiğimiz için yazdık ,Expression da Filtereleme de kullanıyoruz 
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy=null, //sıralama 
            string includeProperties=null );

        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, //bulduğun ilk kaydı getir
           string includeProperties = null);
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
