using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.KidsMealTests
{
    /// <summary>
    /// Class to check tests for the sliders meal class
    /// </summary>
    public class SlidersMealUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            SlidersMeal meal = new();
            Assert.True(meal.AmericanCheese);
            Assert.Equal((uint)2, meal.Count);
            Assert.False(meal.DrinkChoice.Chocolate);
            Assert.False(meal.SideChoice.Curly);
            Assert.Equal(Size.Kids, meal.SideChoice.SizeSelection);

        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            SlidersMeal meal = new();
            Assert.Equal(5.99m, meal.Price);
        }

        /// <summary>
        /// Test to check if the preparation information for the meal is changing according to toppings selected
        /// </summary>
        /// <param name="count">number of sliders in the meal</param>
        /// <param name="cheese">whether the sliders contains american cheese or not</param>
        /// <param name="prepInfo">the price of the meal</param>
        [Theory]
        [InlineData(2, true, new string[] { })]
        [InlineData(3, false, new string[] { "3 Sliders", "Hold American Cheese"})]
        [InlineData(4, true, new string[] { "4 Sliders" })]
        [InlineData(2, false, new string[] { "Hold American Cheese" })]

        public void checkingPreparationInfoTest(uint count, bool cheese, string[] prepInfo)
        {
            SlidersMeal meal = new();
            meal.AmericanCheese = cheese;
            meal.Count = count;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, meal.PreparationInformation);
            }

            Assert.Equal(prepInfo.Length, meal.PreparationInformation.Count());
        }


        /// <summary>
        /// Test to check if the Price for the meal is changing according to sizes selected
        /// </summary>
        /// <param name="count">number of sliders in the meal</param>
        /// <param name="cheese">whether the meal contains american cheese or not</param>
        /// <param name="side">size of the side</param>
        /// <param name="price">the price of the fries</param>
        [Theory]
        [InlineData(2, true, Size.Kids, 5.99)]
        [InlineData(3, false, Size.Kids, 5.99 + (2.00 * (3-2)))]
        [InlineData(4, true, Size.Kids, 5.99 + (2.00 * (4 - 2)))]
        [InlineData(2, false, Size.Large, 5.99 + 1.50)]
        [InlineData(3, true, Size.Small, 5.99 + (2.00 * (3 - 2)) + 0.50)]
        [InlineData(4, false, Size.Medium, 5.99 + (2.00 * (4 - 2)) + 1.00)]
        [InlineData(4, true, Size.Large, 5.99 + (2.00 * (4 - 2)) + 1.50)]

        public void checkingPriceTest(uint count, bool cheese, Size side, decimal price)
        {
            SlidersMeal meal = new();
            meal.AmericanCheese = cheese;
            meal.Count = count;
            meal.SideChoice.SizeSelection = side;

            Assert.Equal(price, meal.Price);
        }

        /// <summary>
        /// Test to check if the calories for the meal is changing according to toppings selected
        /// </summary>
        /// <param name="count">number of bites in the meal</param>
        /// <param name="cheese">whether the meal contains american cheese or not</param>
        /// <param name="size">size of the side</param>
        /// <param name="cals">the price of the meal</param>
        [Theory]
        [InlineData(2, true, Size.Kids, (150 * 2) + 200 + (0.60 * 350))]
        [InlineData (3, false, Size.Kids, (110 * 3) + 200 + (0.60 * 350))]
        [InlineData(4, true, Size.Kids, (150 * 4) + 200 + (0.60 * 350))]
        [InlineData(2, false, Size.Small, (110 * 2) + 200 + (0.75 * 350))]
        [InlineData(3, false, Size.Medium, (110 * 3) + 200 + 350)]
        [InlineData(4, true, Size.Large, (150 * 4) + 200 + (1.50 * 350))]

        public void checkingCaloriesTest(uint count, bool cheese, Size size, uint cals)
        {
            SlidersMeal meal = new();
            meal.AmericanCheese = cheese;
            meal.Count = count;
            meal.SideChoice.SizeSelection = size;

            Assert.Equal(cals, meal.Calories);
        }
    }
}
