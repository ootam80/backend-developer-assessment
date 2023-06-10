using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EfDataRepository : IDataRepository
    {
        private readonly MusicArtistEntities _dbContext;

        public EfDataRepository(MusicArtistEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Artist> GetAllEntities()
        {
            return _dbContext.Artists.ToList();
        }

        public String GetNameById(Guid ArtistId)
        {
            return _dbContext.Artists.Where(a => a.ArtistId == ArtistId).Select(ar => ar.Name).FirstOrDefault();
        }
    }

}
