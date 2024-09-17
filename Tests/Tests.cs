using MusicArtist.Controllers;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task DoesFetchReleaseGroupsCountReturn25ForMetallica()
        {
            // Arrange
            var controller = new ArtistController();

            // Act
            var result = await controller.FetchReleaseGroups("65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab");

            // Assert
            Assert.That(result.Count, Is.EqualTo(25));
        }
    }
}
