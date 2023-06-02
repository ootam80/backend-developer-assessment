using Microsoft.EntityFrameworkCore;
using MusicBrainz.Core.Persistence.Entities;

namespace MusicBrainz.Core.Persistence
{
    public class MusicBrainzDbContext : DbContext
    {
        public MusicBrainzDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Artist> Artist { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<FeaturingArtist> FeaturingArtist { get; set; }

        public DbSet<Aliases> Aliases { get; set; }
    }
}
