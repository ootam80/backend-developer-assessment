using Microsoft.EntityFrameworkCore;
using MusicBrainz.Api.Models;

namespace MusicBrainz.Core.Persistence
{
    public class MusicBrainzDbContext : DbContext
    {
        public MusicBrainzDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
    }
}
