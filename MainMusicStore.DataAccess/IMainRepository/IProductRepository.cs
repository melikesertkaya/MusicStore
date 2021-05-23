using MainMusicStore.DataAccess.IRepository;
using MainMusicStore.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainMusicStore.DataAccess.IMainRepository
{
    public interface IProductRepository :IRepository<Product>
    {
        void Update(Product product); 
    }
}
