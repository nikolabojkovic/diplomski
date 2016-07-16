using System.Collections.Generic;

namespace DiplomskiCore1.Services
{
    using Repository;
    public interface IRepository
    {
        IEnumerable<Data> GetAll();
        Data Get(int id);
        void Add(Data item);
        Data Edit(Data item);

        void Delete(Data item);
    }
}
