using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.Repositories
{
    public interface IRepository<T> where T : class
    {
        void SaveChanges();

        void Create(T value);

        void Update(T value);

        void Delete(T value);

        public IQueryable<T> GetAll();

    }
}
