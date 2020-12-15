using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarNS;
using System;

namespace CarTests
{
    [TestClass]
    public class CarTests
    {
        Car test_car;

        [TestInitialize]
        public void CreateCarObject()
        {
            test_car = new Car("Toyota", "Prius", 10, 50);
        }

        [TestMethod]
        public void TestInitialGasTank()
        {
            var expected = 10;
            var actual = test_car.GasTankLevel;

            Assert.AreEqual(expected, actual, .001);
            Assert.IsFalse(test_car.GasTankLevel == 0);
        }

        [TestMethod]
        public void TestGasTankAfterDriving()
        {
            var expected = 9;
            var actual = test_car.GasTankLevel;

            test_car.Drive(50);

            Assert.AreEqual(expected, actual, .001);
        }

        [TestMethod]
        public void TestGasTankAfterExceedingTankRange()
        {
            var expected = 0;
            var actual = test_car.GasTankLevel;

            test_car.Drive(500);

            Assert.AreEqual(expected, actual, .001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGasOverfillException()
        {
            test_car.AddGas(5);

            Assert.Fail("Shouldn't get here, car cannot have more gas in tank than the size of the tank");
        }
    }
}
