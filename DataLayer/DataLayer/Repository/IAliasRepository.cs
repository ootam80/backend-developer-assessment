using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IAliasRepository
    {
        IEnumerable<Alias> GetAll();
        Alias GetById(int aliasID);
        void Insert(Alias alias);
        void Update(Alias alias);
        void Delete(int aliasID);
        void Save();
    }
}
