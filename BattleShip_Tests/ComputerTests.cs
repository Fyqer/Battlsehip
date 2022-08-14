using BattleShip_guestline_I;
using NUnit.Framework;
using System.Linq;

namespace BattleShip_Tests
{
    public class computerTests
    {

        public static string _testName = "testName";
        Computer computer = new Computer(_testName);

        [Test]
        public void computerNameTest_ShouldEqual_testname()
        {
            Assert.AreEqual(_testName, computer.Name);
        }

        [Test]
        public void shipsNumberTest_ShoulEqual3_2_1()
        {
            Assert.AreEqual(3, computer.Ships.Count);
            Assert.AreEqual(2, computer.Ships.Where(x => x.OccupationType == OccupationType.Destroyer).ToList().Count);
            Assert.AreEqual(1, computer.Ships.Where(x => x.OccupationType == OccupationType.Battleship).ToList().Count);
        }


        [Test]
        public void getNameOfShipTest_NamesShouldEqualDestroyer()
        {
            computer.placeShips();
           Destroyer des1 = new Destroyer();
           Destroyer des2 = new Destroyer("Destroyer2");
           var Square = computer.GameBoard.Squares.First(x => x.OccupationType == OccupationType.Destroyer);
           Assert.IsTrue( des1.Name == computer.getShip(Square).Name || des2.Name==computer.getShip(Square).Name);

        }
        [Test]
        public void isRowAndColumnValidTest()
        {
            Assert.AreEqual(true, computer.isRowOrColumnBiggerThan10(11, 12));
            Assert.AreEqual(true, computer.isRowOrColumnBiggerThan10(5, 12));
            Assert.AreEqual(true, computer.isRowOrColumnBiggerThan10(11, 5));
            Assert.AreEqual(true, computer.isRowOrColumnBiggerThan10(-1, 12));
            Assert.AreEqual(false, computer.isRowOrColumnBiggerThan10(5, 5));
            Assert.AreEqual(false, computer.isRowOrColumnBiggerThan10(10, 10));
        }

        //arrane
        //act
        //assert
    }
}
