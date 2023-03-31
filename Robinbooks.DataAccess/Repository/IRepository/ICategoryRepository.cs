using Robinbooks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinBooks.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

    }
}
