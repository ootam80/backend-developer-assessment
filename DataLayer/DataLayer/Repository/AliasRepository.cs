using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class AliasRepository : IAliasRepository
    {
        //The following variable is going to hold the AliasDBContext instance
        private readonly MusicBrainzEntities _context;
        //Initialzing the AliasDBContext instance
        public AliasRepository()
        {
            _context = new MusicBrainzEntities();
        }
        //Initializing the AliasDBContext instance which it received as an argument
        public AliasRepository(MusicBrainzEntities context)
        {
            _context = context;
        }
        //This method will return all the Aliass from the Alias table
        public IEnumerable<Alias> GetAll()
        {
            return _context.Aliases.ToList();
        }
        //This method will return one Alias's information from the Alias table
        //based on the AliasID which it received as an argument
        public Alias GetById(int AliasID)
        {
            return _context.Aliases.Find(AliasID);
        }
        //This method will Insert one Alias object into the Alias table
        //It will receive the Alias object as an argument which needs to be inserted into the database
        public void Insert(Alias alias)
        {
            //The State of the Entity is going to be Added State
            _context.Aliases.Add(alias);
        }
        //This method is going to update the Alias data in the database
        //It will receive the Alias object as an argument
        public void Update(Alias alias)
        {
            //It will mark the Entity State as Modified
            _context.Entry(alias).State = EntityState.Modified;
        }
        //This method is going to remove the Alias Information from the Database
        //It will receive the AliasID as an argument whose information needs to be removed from the database
        public void Delete(int AliasID)
        {
            //First, fetch the Alias details based on the AliasID id
            Alias alias = _context.Aliases.Find(AliasID);
            //If the alias object is not null, then remove the alias
            if (alias != null)
            {
                //This will mark the Entity State as Deleted
                _context.Aliases.Remove(alias);
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
