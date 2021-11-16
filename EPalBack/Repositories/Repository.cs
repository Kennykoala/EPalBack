using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EPalBack.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EPalContext _context;

        public Repository(EPalContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Create(T value)
        {
            _context.Entry(value).State = EntityState.Added;
        }

        public void Update(T value)
        {
            _context.Entry(value).State = EntityState.Modified;
        }

        public void Delete(T value)
        {
            _context.Entry(value).State = EntityState.Deleted;

        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        //public T Get(int id)
        //{
        //    return _context.Set<T>().FirstOrDefault();
        //}
    }
}
