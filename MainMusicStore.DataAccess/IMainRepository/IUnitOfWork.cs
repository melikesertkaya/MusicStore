using System;
using System.Collections.Generic;
using System.Text;

namespace MainMusicStore.DataAccess.IMainRepository
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICoverTypeRepository CoverType { get; }
        ISPCallRepository sp_call { get; }
        void Save();
    }
}
 