using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.DrinksTests
{
    /// <summary>
    /// Class to check tests for the agua fresca class
    /// </summary>
    public class AguaFrescaUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            AguaFresca drink = new();
            Assert.Equal(Flavor.Limonada, drink.DrinkFlavor);
            Assert.Equal(Size.Medium, drink.DrinkSize);
            Assert.True(drink.Ice);

        }

        /// <summary>
        /// Test to check if the preparation information for the drink is changing according to size and flavor selected
        /// </summary>
        /// <param name="ice">if there is ice in the drink</param>
        /// <param name="drinkFlavor">flavor of the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="prepInfo">the price of the meal</param>
        [Theory]
        [InlineData(true, Flavor.Limonada, Size.Medium, new string[] {"Limonada", "Medium" })]
        [InlineData(true, Flavor.Lime, Size.Kids, new string[] { "Lime", "Kids" })]
        //Specific required test case
        [InlineData(false, Flavor.Tamarind, Size.Large, new string[] { "Tamarind", "Large", "Hold Ice" })]
        [InlineData(true, Flavor.Cucumber, Size.Small, new string[] { "Cucumber", "Small" })]
        [InlineData(true, Flavor.Strawberry, Size.Large, new string[] { "Strawberry", "Large" })]
        [InlineData(false, Flavor.Limonada, Size.Medium, new string[] { "Limonada", "Medium", "Hold Ice" })]

        public void checkingPreparationInfoTest(bool ice, Flavor drinkFlavor, Size drinkSize, string[] prepInfo)
        {
            AguaFresca drink = new();
            drink.Ice = ice;
            drink.DrinkFlavor = drinkFlavor;
            drink.DrinkSize = drinkSize;

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
        /// <param name="drinkFlavor">Flavor of the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="price">the price of the drink</param>
        [Theory]
        [InlineData(true, Flavor.Limonada, Size.Medium, 3.00)]
        [InlineData(true, Flavor.Lime, Size.Kids, 2.00)]
        //Specific required test case
        [InlineData(false, Flavor.Tamarind, Size.Large, 4.25)]
        [InlineData(true, Flavor.Cucumber, Size.Small, 2.50)]
        [InlineData(true, Flavor.Strawberry, Size.Large, 3.75)]
        [InlineData(false, Flavor.Limonada, Size.Medium, 3.00)]


        public void checkingPriceTest(bool ice, Flavor drinkFlavor, Size drinkSize, decimal price)
        {
            AguaFresca drink = new();
            drink.Ice = ice;
            drink.DrinkFlavor = drinkFlavor;
            drink.DrinkSize = drinkSize;

            Assert.Equal(price, drink.Price);
        }

        /// <summary>
        /// Test to check if the price for the drink is changing according to size selected
        /// </summary>
        /// <param name="ice">if there is ice in the drink</param>
        /// <param name="drinkFlavor">flavor of the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="cals">the cals of the drink</param>

        [Theory]
        [InlineData(true, Flavor.Limonada, Size.Medium, (uint)(125))]
        [InlineData(true, Flavor.Lime, Size.Kids, (uint)(125 * 0.60))]
        //Specific required test case
        [InlineData(false, Flavor.Tamarind, Size.Large, (uint)(160 * 1.50))]
        [InlineData(true, Flavor.Cucumber, Size.Small, (uint)(75 * 0.75))]
        [InlineData(true, Flavor.Strawberry, Size.Large, (uint)(150 * 1.50))]
        [InlineData(false, Flavor.Limonada, Size.Medium, (uint)(135))]
        public void checkingCaloriesTest(bool ice, Flavor drinkFlavor, Size drinkSize, uint cals)
        {
            AguaFresca drink = new();
            drink.Ice = ice;
            drink.DrinkFlavor = drinkFlavor;
            drink.DrinkSize = drinkSize;

            Assert.Equal(cals, drink.Calories);
        }
    }
}
