using BattleShip_guestline_I;
using NUnit.Framework;

namespace BattleShip_Tests
{
    public class GameTests
    {
        private static string _testPlayerName = "testPlayer";
        Game game = new Game("testPlayer");

        [Test]
        public void playerNameTest_ShouldBe_testPlayerName()
        {
            Assert.AreEqual(_testPlayerName, game.Player.Name);
        }

        [Test]
        public void computerNameTest_ShouldEqualComputer()
        {
            Assert.AreEqual("Computer", game.Computer.Name);
        }

        [Test]
        public void charToIntTranslateTest()
        {

            Assert.AreEqual(2, game.charToIntTranslate('B'));

            Assert.AreEqual(3, game.charToIntTranslate('C'));

            Assert.AreEqual(4, game.charToIntTranslate('D'));

            Assert.AreEqual(5, game.charToIntTranslate('E'));

            Assert.AreEqual(6, game.charToIntTranslate('F'));

            Assert.AreEqual(7, game.charToIntTranslate('G'));
        }
        [Test]
        public void isColumnNameInRangeTest()
        {
            Assert.IsFalse(game.isColumnNameInRange('L'));
            Assert.IsTrue(game.isColumnNameInRange('A'));
            Assert.IsTrue(game.isColumnNameInRange('B'));
            Assert.IsFalse(game.isColumnNameInRange('Z'));
        }
    }
}
