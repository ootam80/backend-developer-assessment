using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        //The following variable is going to hold the ArtistDBContext instance
        private readonly MusicBrainzEntities _context;
        //Initialzing the ArtistDBContext instance
        public ArtistRepository()
        {
            _context = new MusicBrainzEntities();
        }
        //Initializing the ArtistDBContext instance which it received as an argument
        public ArtistRepository(MusicBrainzEntities context)
        {
            _context = context;
        }
        //This method will return all the Artists from the Artist table
        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }
        //This method will return one Artist's information from the Artist table
        //based on the ArtistID which it received as an argument
        public Artist GetById(int ArtistID)
        {
            return _context.Artists.Find(ArtistID);
        }
        //This method will Insert one Artist object into the Artist table
        //It will receive the Artist object as an argument which needs to be inserted into the database
        public void Insert(Artist artist)
        {
            //The State of the Entity is going to be Added State
            _context.Artists.Add(artist);
        }
        //This method is going to update the Artist data in the database
        //It will receive the Artist object as an argument
        public void Update(Artist artist)
        {
            //It will mark the Entity State as Modified
            _context.Entry(artist).State = EntityState.Modified;
        }
        //This method is going to remove the Artist Information from the Database
        //It will receive the ArtistID as an argument whose information needs to be removed from the database
        public void Delete(int ArtistID)
        {
            //First, fetch the Artist details based on the ArtistID id
            Artist artist = _context.Artists.Find(ArtistID);
            //If the artist object is not null, then remove the artist
            if (artist != null)
            {
                //This will mark the Entity State as Deleted
                _context.Artists.Remove(artist);
            }

        }
        
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
