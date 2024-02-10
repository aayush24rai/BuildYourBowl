using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.DrinksTests
{
    /// <summary>
    /// Class to check tests for the horchata class
    /// </summary>
    public class HorchataUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            Horchata drink = new();
            Assert.Equal(Size.Medium, drink.SizeSelection);
            Assert.True(drink.Ice);

        }

        /// <summary>
        /// Test to check if the preparation information for the drink is changing according to size and flavor selected
        /// </summary>
        /// <param name="ice">if there is ice in the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="prepInfo">the price of the meal</param>
        [Theory]
        [InlineData(true, Size.Medium, new string[] { "Medium" })]
        [InlineData(true, Size.Kids, new string[] { "Kids" })]
        [InlineData(false, Size.Large, new string[] { "Large", "Hold Ice" })]
        [InlineData(true, Size.Small, new string[] { "Small" })]
        [InlineData(true, Size.Large, new string[] { "Large" })]
        [InlineData(false, Size.Medium, new string[] { "Medium", "Hold Ice" })]

        public void checkingPreparationInfoTest(bool ice,  Size drinkSize, string[] prepInfo)
        {
            Horchata drink = new();
            drink.Ice = ice;
            drink.SizeSelection = drinkSize;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, drink.PreparationInformation);
            }

            Assert.Equal(prepInfo.Length, drink.PreparationInformation.Count());
        }


        /// <summary>
        /// Test to check if the price for the drink is changing according to size selected
        /// </summary>
        /// <param name="ice">if there is ice in the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="price">the price of the drink</param>
        [Theory]
        [InlineData(true, Size.Medium, 3.50)]
        [InlineData(true, Size.Kids, 2.50)]
        [InlineData(false, Size.Large, 4.25)]
        [InlineData(true, Size.Small, 3.00)]
        [InlineData(true, Size.Large, 4.25)]
        [InlineData(false, Size.Medium, 3.50)]
        public void checkingPriceTest(bool ice, Size drinkSize, decimal price)
        {
            Horchata drink = new();
            drink.Ice = ice;
            drink.SizeSelection = drinkSize;

            Assert.Equal(price, drink.Price);
        }

        /// <summary>
        /// Test to check if the price for the drink is changing according to size selected
        /// </summary>
        /// <param name="ice">if there is ice in the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="cals">the cals of the drink</param>

        [Theory]
        [InlineData(true, Size.Medium, (uint)(280))]
        [InlineData(true, Size.Kids, (uint)(280 * 0.60))]
        [InlineData(false, Size.Large, (uint)(250 * 1.50))]
        [InlineData(true, Size.Small, (uint)(280 * 0.75))]
        [InlineData(true, Size.Large, (uint)(280 * 1.50))]
        [InlineData(false, Size.Medium, (uint)(250))]
        public void checkingCaloriesTest(bool ice, Size drinkSize, uint cals)
        {
            Horchata drink = new();
            drink.Ice = ice;
            drink.SizeSelection = drinkSize;

            Assert.Equal(cals, drink.Calories);
        }
    }
}
