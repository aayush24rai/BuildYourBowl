using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.KidsMealTests
{
    /// <summary>
    /// Class to check tests for the corn dogs bites meal class
    /// </summary>
    public class CornDogBitesUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            CornDogBitesMeal meal = new();
            Assert.Equal((uint)5, meal.Count);
            Assert.False((meal.DrinkChoice as Milk).Chocolate);
            Assert.False((meal.SideChoice as Fries).Curly);
            Assert.Equal(Size.Kids, meal.DrinkChoice.SizeChoice);
            Assert.Equal(Size.Kids, meal.SideChoice.SizeChoice);

        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            ChickenNuggetsMeal meal = new();
            Assert.Equal(5.99m, meal.Price);
        }

        /// <summary>
        /// Test to check if the preparation information for the meal is changing according to toppings selected
        /// </summary>
        /// <param name="count">number of bites in the meal</param>
        /// <param name="prepInfo">the price of the meal</param>
        [Theory]
        [InlineData(5, new string[] { })]
        [InlineData(6, new string[] { "6 Bites" })]
        [InlineData(7, new string[] { "7 Bites" })]
        [InlineData(8, new string[] { "8 Bites" })]

        public void checkingPreparationInfoTest(uint count, string[] prepInfo)
        {
            CornDogBitesMeal meal = new();
            meal.Count = count;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, meal.Instructions);
            }

            Assert.Equal(prepInfo.Length, meal.Instructions.Count());
        }


        /// <summary>
        /// Test to check if the Price for the meal is changing according to sizes selected
        /// </summary>
        /// <param name="count">number of chicken nuggets in the meal</param>
        /// <param name="side">size of the side</param>
        /// <param name="price">the price of the fries</param>
        [Theory]
        [InlineData(5, Size.Kids, Size.Kids, 5.99)]
        [InlineData(6, Size.Kids, Size.Kids, 5.99 + (0.75 * (6 - 5)))]
        [InlineData(7, Size.Kids, Size.Kids, 5.99 + (0.75 * (7 - 5)))]
        [InlineData(8, Size.Kids, Size.Kids, 5.99 + (0.75 * (8 - 5)))]
        [InlineData(5, Size.Small, Size.Kids, 5.99 + 0.50)]
        [InlineData(6, Size.Medium, Size.Kids, 5.99 + (0.75 * (6 - 5)) + 1.00)]
        [InlineData(7, Size.Large, Size.Kids, 5.99 + (0.75 * (7 - 5)) + 1.50)]

        public void checkingPriceTest(uint count, Size side, Size drink, decimal price)
        {
            CornDogBitesMeal meal = new();
            meal.Count = count;
            meal.SideChoice.SizeChoice = side;
            meal.DrinkChoice.SizeChoice = drink;

            Assert.Equal(price, meal.Price);
        }

        /// <summary>
        /// Test to check if the calories for the meal is changing according to toppings selected
        /// </summary>
        /// <param name="count">number of bites in the meal</param>
        /// <param name="size">size of the side</param>
        /// <param name="cals">the price of the meal</param>
        [Theory]
        [InlineData(5, Size.Kids, Size.Kids, (50 * 5) + 200 + (0.60 * 350))]
        [InlineData(6, Size.Kids, Size.Kids, (50 * 6) + 200 + (0.60 * 350))]
        [InlineData(7, Size.Kids, Size.Kids, (50 * 7) + 200 + (0.60 * 350))]
        [InlineData(8, Size.Small, Size.Kids, (50 * 8) + 200 + (0.75 * 350))]
        [InlineData(5, Size.Medium, Size.Kids, (50 * 5) + 200 + 350)]
        [InlineData(6, Size.Large, Size.Kids, (50 * 6) + 200 + (1.50 * 350))]

        public void checkingCaloriesTest(uint count, Size size, Size drink, uint cals)
        {
            CornDogBitesMeal meal = new();
            meal.Count = count;
            meal.SideChoice.SizeChoice = size;
            meal.DrinkChoice.SizeChoice = drink;

            Assert.Equal(cals, meal.Calories);
        }

        /// <summary>
        /// Checking if the override ToString method is working properly
        /// </summary>
        [Fact]
        public void TestToString()
        {
            CornDogBitesMeal meal = new();
            Assert.Equal("Corn Dog Bites Kids Meal", meal.ToString());
        }
    }
}
