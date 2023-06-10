using BusinessLayer.Models.Dto;
using BusinessLayer.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class ArtistBusiness
    {
        private readonly IDataRepository _dataRepository;

        public ArtistBusiness() {
            _dataRepository = DataRepositoryFactory.Create();
        }

        public SearchArtistReturnType Search(SearchArtistDto searchParams)
        {
            List<DataLayer.Artist> artists = _dataRepository.GetAllEntities().Where(a => a.Name.ToLower().Contains(searchParams.SearchCriteria.ToLower())).ToList();

            SearchArtistReturnType artistReturnType= new SearchArtistReturnType();
            artistReturnType.SetFromData(artists.Skip(searchParams.PageSize.Value * (searchParams.PageNumber.Value - 1)).Take(searchParams.PageSize.Value).ToList());
            artistReturnType.Page = searchParams.PageNumber.Value;
            artistReturnType.PageSize = searchParams.PageSize.Value;
            artistReturnType.NumberOfSearchResults = artists.Count;
            artistReturnType.NumberOfPages = artists.Count / searchParams.PageSize.Value;

            return artistReturnType;
        }

        public String ArtistNameById(Guid ArtistId)
        {
            return _dataRepository.GetNameById(ArtistId);
        }
    }
}
