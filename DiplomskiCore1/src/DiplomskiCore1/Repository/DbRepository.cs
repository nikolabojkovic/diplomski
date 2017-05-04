using DiplomskiCore1.Data;
using DiplomskiCore1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiCore1.Repository
{
    public abstract class DbRepository : IRepository
    {
        protected ApplicationDbContext _dbContext;

        public DbRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract void Add(Data item);
        public abstract void Delete(Data item);
        public abstract Data Edit(Data item);
        public abstract Data Get(int id);
        public abstract IEnumerable<Data> GetAll();
    }
}
