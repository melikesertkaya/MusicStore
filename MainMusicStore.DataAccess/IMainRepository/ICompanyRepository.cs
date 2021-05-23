using MainMusicStore.DataAccess.IRepository;
using MainMusicStore.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainMusicStore.DataAccess.IMainRepository
{
    public interface ICompanyRepository :IRepository<Company>
    {
        void Update(Company company); 
    }
}
