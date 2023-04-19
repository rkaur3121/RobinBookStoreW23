using RobinBooks.DataAccess.Repository.IRepository;
using RobinBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Robinbooks.Models;
using System.Threading.Tasks;

namespace RobinBooks.DataAccess.Repository
{
    class CategoryRespository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            //use .NET LinQ to Retrive the first or default category object,
            //then pass the id as a generic entity which matches the category ID

            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (objFromDb != null)//Save changes if not null
            {
                objFromDb.Name = category.Name;
                
            }

        }
    }
}