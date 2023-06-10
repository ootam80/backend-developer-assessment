using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class DataRepositoryFactory
    {
        public static IDataRepository Create()
        {
            var dbContext = new MusicArtistEntities();
            return new EfDataRepository(dbContext);
        }
    }

}
