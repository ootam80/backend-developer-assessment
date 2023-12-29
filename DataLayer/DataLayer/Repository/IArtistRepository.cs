using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAll();
        Artist GetById(int artistID);
        void Insert(Artist artist);
        void Update(Artist artist);
        void Delete(int artistID);
        void Save();
    }
}
