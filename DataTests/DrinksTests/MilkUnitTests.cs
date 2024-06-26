﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.DrinksTests
{
    /// <summary>
    /// Class to check tests for the milk class
    /// </summary>
    public class MilkUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            Milk drink = new();
            Assert.Equal(Size.Kids, drink.SizeChoice);
            Assert.False(drink.Chocolate);

        }

        /// <summary>
        /// Test to check if the preparation information for the drink is changing according to size and flavor selected
        /// </summary>
        /// <param name="chocolate">if there is chocolate in the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="prepInfo">the price of the meal</param>
        [Theory]
        [InlineData(false, Size.Medium, new string[] { })]
        [InlineData(true, Size.Kids, new string[] { "Chocolate" })]
        [InlineData(false, Size.Large, new string[] { })]
        [InlineData(true, Size.Small, new string[] { "Chocolate" })]
        [InlineData(true, Size.Large, new string[] { "Chocolate" })]
        [InlineData(true, Size.Medium, new string[] { "Chocolate" })]

        public void checkingPreparationInfoTest(bool chocolate, Size drinkSize, string[] prepInfo)
        {
            Milk drink = new();
            drink.Chocolate = chocolate;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, drink.Instructions);
            }

            Assert.Equal(prepInfo.Length, drink.Instructions.Count());
        }


        /// <summary>
        /// Test to check if the price for the drink is changing according to size selected
        /// </summary>
        /// <param name="chocolate">if there is chocolate in the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="price">the price of the drink</param>
        [Theory]
        [InlineData(true, Size.Medium, 2.50)]
        [InlineData(true, Size.Kids, 2.50)]
        [InlineData(false, Size.Large, 2.50)]
        [InlineData(true, Size.Small, 2.50)]
        [InlineData(true, Size.Large, 2.50)]
        [InlineData(false, Size.Medium, 2.50)]
        public void checkingPriceTest(bool chocolate, Size drinkSize, decimal price)
        {
            Milk drink = new();
            drink.Chocolate = chocolate;

            Assert.Equal(price, drink.Price);
        }

        /// <summary>
        /// Test to check if the price for the drink is changing according to size selected
        /// </summary>
        /// <param name="chocolate">if there is chocolate in the drink</param>
        /// <param name="drinkSize">size of the drink</param>
        /// <param name="cals">the cals of the drink</param>

        [Theory]
        [InlineData(false, Size.Medium, 200)]
        [InlineData(true, Size.Kids, 270)]
        [InlineData(false, Size.Large, 200)]
        [InlineData(true, Size.Small, 270)]
        [InlineData(true, Size.Large, 270)]
        [InlineData(true, Size.Medium, 270)]
        public void checkingCaloriesTest(bool chocolate, Size drinkSize, uint cals)
        {
            Milk drink = new();
            drink.Chocolate = chocolate;

            Assert.Equal(cals, drink.Calories);
        }
        
        /// <summary>
        /// Checking if the override ToString method is working properly
        /// </summary>
        [Fact]
        public void TestToString()
        {
            Milk milk = new();
            Assert.Equal("Milk", milk.ToString());
        }

        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "Instructions")]
        [InlineData(false, "Instructions")]
        public void ChangingChocolateShouldNotifyOfPropertyChanges(bool chocolate, string propertyName)
        {
            Milk drink = new();
            Assert.PropertyChanged(drink, propertyName, () => { drink.Chocolate = chocolate; });
        }

        [Theory]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Kids, "Calories")]
        [InlineData(Size.Small, "Calories")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Kids, "Instructions")]
        [InlineData(Size.Small, "Instructions")]
        [InlineData(Size.Medium, "Instructions")]
        [InlineData(Size.Large, "Instructions")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(Size size, string propertyName)
        {
            Milk drink = new();
            Assert.PropertyChanged(drink, propertyName, () => { drink.SizeChoice = size; });
        }
    }
}
