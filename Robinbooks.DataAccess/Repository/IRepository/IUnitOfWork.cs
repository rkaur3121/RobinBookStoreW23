using System;
using System.Collections.Generic;
using System.Text;

namespace RobinBooks.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository Cover { get; }
        IProductRepository Product { get; }


        ISP_Call SP_Call { get; }
      

        void Save();
    }
}