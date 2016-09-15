using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiCore1.Repository
{
    using DiplomskiCore1.Data;

    public class UserRpository
    {
        private ApplicationDbContext _dbContext;

        public UserRpository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Data> GetAll()
        {
            return _dbContext.User;
        }

        public Data Get(int id)
        {
            return _dbContext.User.FirstOrDefault(item => item.Id == id);
        }

        public void Add(Data item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public Data Edit(Data item)
        {
            _dbContext.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Data item)
        {
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
        }

        public Data GetByAspNetUserId(string id)
        {
            return _dbContext.User.FirstOrDefault(item => item.AspNetUserId == id);
        }
    }
}
