using DiplomskiCore1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiCore1.Repository
{
    public abstract class FilesRepository : IRepository
    {
        public abstract void Add(Data item);
        public abstract void Delete(Data item);
        public abstract Data Edit(Data item);
        public abstract Data Get(int id);
        public abstract IEnumerable<Data> GetAll();
    }
}
