using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RobinBooks.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id); //Retrive a category from the database by id
        //List of Cateogories based on requirements

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includePropeties = null //useful for foreign key refernces
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );


        void Add(T entity); //to add an entity

        void Remove(int id);//to remove an object or category

        void Remove(T entity); //another way to remove an object

        void RemoveRange(IEnumerable<T> entity);//remove a complete range of entities
    }
}