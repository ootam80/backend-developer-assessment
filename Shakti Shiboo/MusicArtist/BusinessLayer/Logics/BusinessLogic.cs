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
    public class BusinessLogic : IBusinessLogic
    {
        ArtistBusiness artistBusiness = new ArtistBusiness();
        public SearchArtistReturnType GetArtists(SearchArtistDto searchParams)
        {
            return artistBusiness.Search(searchParams);
        }

        public String GetArtistNameById(Guid artistId)
        {
            return artistBusiness.ArtistNameById(artistId);
        }
    }
}