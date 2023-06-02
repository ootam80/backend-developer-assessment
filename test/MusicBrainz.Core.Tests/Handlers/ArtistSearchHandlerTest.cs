using MusicBrainz.Api.Models;
using MusicBrainz.Core.Handlers;
using MusicBrainz.Core.Models;
using MusicBrainz.Core.Persistence;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using OneOf;
using OneOf.Types;
using Serilog;
using Shouldly;
using Xunit;

namespace MusicBrainz.Core.Tests.Handlers
{
    public class ArtistSearchHandlerTest
    {
        private readonly ArtistSearchRequest _request = new ArtistSearchRequest();

        private ArtistSearchHandler _sut;

        //mocks
        private readonly ILogger _loggerMock = Substitute.For<ILogger>();
        private readonly IArtistsRepository _artistRepositoryMock = Substitute.For<IArtistsRepository>();

        // result
        private OneOf<ArtistSearchResponse, NotFound, Error<string>> _result;

        public ArtistSearchHandlerTest()
        {
            _sut = new ArtistSearchHandler(_loggerMock, _artistRepositoryMock);
        }

        private async Task ActAsync() => _result = await _sut.HandleAsync(_request, CancellationToken.None);


        [Fact]
        private async Task GivenRepositoryThrowsExceptionThenShouldReturnErrorWithMessage()
        {
            // Arrange
            _artistRepositoryMock.GetArtistAsync(Arg.Any<ArtistSearchRequest>(), Arg.Any<CancellationToken>())
                .Throws(new Exception("Repository error"));

            // Act
            await ActAsync();

            // Assert
            _result.IsT2.ShouldBeTrue();
            _result.AsT2.Value.ShouldBe("Repository error");
        }

        [Fact]
        private async Task GivenRepositoryReturnsNotFoundThenShouldReturnNotFound()
        {
            // Arrange
            // Arrange
            _artistRepositoryMock.GetArtistAsync(Arg.Any<ArtistSearchRequest>(), Arg.Any<CancellationToken>())
                .Returns(new NotFound());
            // Act
            await ActAsync();

            // Assert
            _result.IsT1.ShouldBeTrue();
            _result.AsT1.ShouldBeOfType<NotFound>();
        }

        [Fact]
        private async Task GivenRepositoryReturnsDataThenShouldReturnData()
        {
            // Arrange
            // Arrange
            _artistRepositoryMock.GetArtistAsync(Arg.Any<ArtistSearchRequest>(), Arg.Any<CancellationToken>())
                .Returns(new ArtistSearchResponse());
            // Act
            await ActAsync();

            // Assert
            _result.IsT0.ShouldBeTrue();
            _result.AsT0.ShouldBeOfType<ArtistSearchResponse>();
        }
    }
}
