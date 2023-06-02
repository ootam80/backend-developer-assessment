using EntityFrameworkCore.Testing.NSubstitute;
using Microsoft.EntityFrameworkCore;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using MusicBrainz.Core.Persistence;
using NSubstitute;
using OneOf.Types;
using OneOf;
using Serilog;
using Shouldly;
using Artist = MusicBrainz.Core.Persistence.Entities.Artist;
using Xunit;

namespace MusicBrainz.Core.Tests.Persistence
{
    public class ArtistRepositoryTests
    {
        private readonly ArtistSearchRequest _request = new ArtistSearchRequest();

        private readonly ArtistRepository _sut;

        private readonly ILogger _loggerMock = Substitute.For<ILogger>();

        private readonly DbContextOptions<MusicBrainzDbContext> _dbContextOptions = new DbContextOptionsBuilder<MusicBrainzDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        private readonly MusicBrainzDbContext _brainzDbContextMock;

        // result
        private OneOf<ArtistSearchResponse, NotFound, Error<string>> _result;

        public ArtistRepositoryTests()
        {
            _loggerMock.ForContext<ArtistRepository>().Returns(_loggerMock);
            _brainzDbContextMock = Create.MockedDbContextFor<MusicBrainzDbContext>(_dbContextOptions);
            _sut = new ArtistRepository(_brainzDbContextMock, _loggerMock);
        }

        private async Task ActAsync() => _result = await _sut.GetArtistAsync(_request, CancellationToken.None);

        [Fact]
        private async Task GivenDbContextThrowsExceptionThenShouldReturnErrorWithMessage()
        {

            // Act
            await ActAsync();

            // Assert
            _result.AsT2.ShouldBeOfType<Error<string>>();
            _result.IsT2.ShouldBeTrue();
            _result.AsT2.Value.ShouldBe("Value cannot be null. (Parameter 'outer')");
        }

    }
}
