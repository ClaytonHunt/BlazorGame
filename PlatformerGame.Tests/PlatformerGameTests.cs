using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlatformerGame.Tests
{
    [TestClass]
    public class PlatformerGameTests
    {
        [TestMethod]
        public void ItExists()
        {
            var game = new BlazorGame.Client.Shared.PlatformerGame();

            Assert.IsNotNull(game);
        }
    }
}
