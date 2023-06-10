using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataRepository
    {
        List<Artist> GetAllEntities();
        String GetNameById(Guid ArtistId);
    }

}
