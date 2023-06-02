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
using Album = MusicBrainz.Core.Persistence.Entities.Album;
using Xunit;

namespace MusicBrainz.Core.Tests.Persistence
{
    public class AlbumRepositoryTests
    {
        private readonly AlbumSearchRequest _request = new AlbumSearchRequest();

        private readonly AlbumRepository _sut;

        private readonly ILogger _loggerMock = Substitute.For<ILogger>();

        private readonly  DbContextOptions<MusicBrainzDbContext> _dbContextOptions = new DbContextOptionsBuilder<MusicBrainzDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        private readonly MusicBrainzDbContext _brainzDbContextMock;

        // result
        private OneOf<AlbumSearchResponse, NotFound, Error<string>> _result;

        public AlbumRepositoryTests()
        {
            _loggerMock.ForContext<AlbumRepository>().Returns(_loggerMock);
            _brainzDbContextMock = Create.MockedDbContextFor<MusicBrainzDbContext>(_dbContextOptions);
            _sut = new AlbumRepository(_brainzDbContextMock, _loggerMock);
        }

        private async Task ActAsync() => _result = await _sut.GetAlbumsAsync(_request, CancellationToken.None);

        [Fact]
        private async Task GivenDbContextThrowsExceptionThenShouldReturnErrorWithMessage()
        {
            // Arrange
            // No need to arrange anything since by default the db context mock is bare-metal and is prone to errors

            // Act
            await ActAsync();

            // Assert
            _result.AsT2.ShouldBeOfType<Error<string>>();
            _result.IsT2.ShouldBeTrue();
            _result.AsT2.Value.ShouldBe("Value cannot be null. (Parameter 'source')");
        }

        [Fact(Skip = "Limitation with library used for mocking low-level entity framework calls: https://stackoverflow.com/questions/62773112/nsubstitute-and-dbcontext-settentity-could-not-find-a-call-to-return-from")]
        private async Task GivenDbContextDoesNotHaveDataThenShouldReturnNotFound()
        {
            // Arrange
            _brainzDbContextMock.Set<Album>();

            // Act
            await ActAsync();

            // Assert
            _result.AsT1.ShouldBeOfType<NotFound>();
            _result.IsT1.ShouldBeTrue();
        }
    }
}
