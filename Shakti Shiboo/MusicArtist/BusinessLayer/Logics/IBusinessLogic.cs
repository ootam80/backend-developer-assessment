using BusinessLayer.Models.Dto;
using BusinessLayer.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Logics
{
    public interface IBusinessLogic
    {
        SearchArtistReturnType GetArtists(SearchArtistDto searchParams);
        String GetArtistNameById(Guid artistId);
    }

}
