using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.SidesUnitTests
{
    /// <summary>
    /// Class to check tests for the fries class
    /// </summary>
    public class FriesUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultToppingsTest()
        {
            Fries side = new();
            Assert.False(side.Curly);
            Assert.Equal(Size.Medium, side.SizeChoice);
        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            Fries side = new();
            Assert.Equal(3.50m, side.Price);
        }

        /// <summary>
        /// Checking whether the default calories are correct or not
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            Fries side = new();
            Assert.Equal((uint)350, side.Calories);
        }

        /// <summary>
        /// Test to check if the preparation information for fries is changing according to toppings selected
        /// </summary>
        /// <param name="curly">whether fries are curly</param>
        /// <param name="size">size of fries</param>
        /// <param name="prepInfo">the price of the fries</param>
        [Theory]
        [InlineData(true, Size.Medium, new string[] {"Medium", "Add Curly"})]
        [InlineData(false, Size.Kids, new string[] { "Kids"  })]
        [InlineData(true, Size.Kids, new string[] { "Kids", "Add Curly" })]
        [InlineData(true, Size.Small, new string[] { "Small", "Add Curly" })]
        [InlineData(false, Size.Medium, new string[] { "Medium" })]
        [InlineData(true, Size.Large, new string[] { "Large", "Add Curly" })]

        public void checkingPreparationInfoTest(bool curly, Size size, string[] prepInfo)
        {
            Fries side = new();
            side.Curly = curly;
            side.SizeChoice = size;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, side.Instructions);
            }

            Assert.Equal(prepInfo.Length, side.Instructions.Count());
        }


        /// <summary>
        /// Test to check if the Price for fries is changing according to toppings selected
        /// </summary>
        /// <param name="curly">whether fries are curly</param>
        /// <param name="size">size of fries</param>
        /// <param name="price">the price of the fries</param>
        [Theory]
        [InlineData(true, Size.Medium, 3.50)]
        [InlineData(false, Size.Kids, 2.50)]
        [InlineData(true, Size.Kids, 2.50)]
        [InlineData(true, Size.Small, 3.00)]
        [InlineData(false, Size.Medium, 3.50)]
        [InlineData(true, Size.Large, 4.25)]

        public void checkingPriceTest(bool curly, Size size, decimal price)
        {
            Fries side = new();
            side.Curly = curly;
            side.SizeChoice = size;

            Assert.Equal(price, side.Price);
        }

        /// <summary>
        /// Test to check if the calories for fries is changing according to toppings selected
        /// </summary>
        /// <param name="curly">whether fries are curly</param>
        /// <param name="size">size of fries</param>
        /// <param name="price">the price of the fries</param>
        [Theory]
        [InlineData(true, Size.Medium, 350)]
        [InlineData(false, Size.Kids, 0.60 * 350)]
        [InlineData(true, Size.Kids, 0.60 * 350)]
        [InlineData(true, Size.Small, 0.75 * 350)]
        [InlineData(false, Size.Medium, 350)]
        [InlineData(true, Size.Large, 1.50 * 350)]

        public void checkingCaloriesTest(bool curly, Size size, uint cals)
        {
            Fries side = new();
            side.Curly = curly;
            side.SizeChoice = size;

            Assert.Equal(cals, side.Calories);
        }
    }
}
