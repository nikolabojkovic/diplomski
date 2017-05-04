using DiplomskiCore1.Data;
using DiplomskiCore1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiCore1.RepositoryModels.RepositoryDbModels
{
    public class ActionDbRepostiroy : DbRepository
    {
        public ActionDbRepostiroy(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override void Add(Repository.Data item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Repository.Data item)
        {
            throw new NotImplementedException();
        }

        public override Repository.Data Edit(Repository.Data item)
        {
            throw new NotImplementedException();
        }

        public override Repository.Data Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Repository.Data> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
