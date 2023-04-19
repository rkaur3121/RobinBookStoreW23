using System.Linq;
using RobinBookStore.DataAccess.Data;
using RobinBooks.DataAccess.Repository.IRepository;
using RobinBooks.Models;
using System.Collections.Generic;
using System;
using System.Text;
using System.Threading.Tasks;
using RobinBooks.DataAccess.Repository;

namespace RobinBookStore.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType coverType)
        {
            var objFromDb = _db.CoverTypes.FirstOrDefault(s => s.Id == coverType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = coverType.Name;
            }
        }
    }
}