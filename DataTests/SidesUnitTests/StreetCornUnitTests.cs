﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.SidesUnitTests
{
    /// <summary>
    /// Class to check tests for the corn class
    /// </summary>
    public class StreetCornUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultToppingsTest()
        {
            StreetCorn side = new();
            Assert.True(side.AdditionalIngredients[Ingredient.CotijaCheese].Included);
            Assert.True(side.AdditionalIngredients[Ingredient.Cilantro].Included);
            Assert.Equal(Size.Medium, side.SizeChoice);

        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            StreetCorn side = new();
            Assert.Equal(4.50m, side.Price);
        }

        /// <summary>
        /// Checking whether the default calories are correct or not
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            StreetCorn side = new();
            Assert.Equal((uint)300, side.Calories);
        }

        /// <summary>
        /// Test to check if the preparation information for corn is changing according to toppings selected
        /// </summary>
        /// <param name="cilantro">whether corn contains cilantro</param>
        /// <param name="cheese">whether corn contains cotija cheese</param>
        /// <param name="size">size of corn</param>
        /// <param name="prepInfo">the preparation info of the corn</param>
        [Theory]
        [InlineData(true, true, Size.Medium, new string[] { "Medium" })]
        [InlineData(false, true, Size.Kids, new string[] { "Kids", "Hold Cilantro" })]
        [InlineData(true, false, Size.Kids, new string[] { "Kids", "Hold Cotija Cheese" })]
        //Specific required test case
        [InlineData(false, false, Size.Small, new string[] { "Small", "Hold Cilantro", "Hold Cotija Cheese" })]
        [InlineData(false, false, Size.Medium, new string[] { "Medium", "Hold Cilantro", "Hold Cotija Cheese" })]
        [InlineData(true, true, Size.Large, new string[] { "Large" })]

        public void checkingPreparationInfoTest(bool cilantro, bool cheese, Size size, string[] prepInfo)
        {
            StreetCorn side = new();
            side.AdditionalIngredients[Ingredient.Cilantro].Included = cilantro;
            side.AdditionalIngredients[Ingredient.CotijaCheese].Included = cheese;
            side.SizeChoice = size;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, side.Instructions);
            }

            Assert.Equal(prepInfo.Length, side.Instructions.Count());
        }


        /// <summary>
        /// Test to check if the preparation information for corn is changing according to toppings selected
        /// </summary>
        /// <param name="cilantro">whether corn contains cilantro</param>
        /// <param name="cheese">whether corn contains cotija cheese</param>
        /// <param name="size">size of corn</param>
        /// <param name="price">the price of the corn</param>
        [Theory]
        [InlineData(true, true, Size.Medium, 4.50)]
        [InlineData(false, true, Size.Kids, 3.25)]
        [InlineData(true, false, Size.Kids, 3.25)]
        //Specific required test case
        [InlineData(false, false, Size.Small, 3.75)]
        [InlineData(false, false, Size.Medium, 4.50)]
        [InlineData(true, true, Size.Large, 5.50)]

        public void checkingPriceTest(bool cilantro, bool cheese, Size size, decimal price)
        {
            StreetCorn side = new();
            side.AdditionalIngredients[Ingredient.Cilantro].Included = cilantro;
            side.AdditionalIngredients[Ingredient.CotijaCheese].Included = cheese;
            side.SizeChoice = size;

            Assert.Equal(price, side.Price);
        }

        /// <summary>
        /// Test to check if the preparation information for corn is changing according to toppings selected
        /// </summary>
        /// <param name="cilantro">whether corn contains cilantro</param>
        /// <param name="cheese">whether corn contains cotija cheese</param>
        /// <param name="size">size of corn</param>
        /// <param name="cals">the calories of the corn</param>
        [Theory]
        [InlineData(true, true, Size.Medium, (uint)300)]
        [InlineData(false, true, Size.Kids, (uint)(0.60 * 295))]
        [InlineData(true, false, Size.Kids, (uint)(0.60 * 220))]
        //Specific required test case
        [InlineData(false, true, Size.Small, (uint)(0.75 * 295))]
        [InlineData(false, false, Size.Medium, (uint)215)]
        [InlineData(true, true, Size.Large, (uint)(1.50 * 300))]

        public void checkingCaloriesTest(bool cilantro, bool cheese, Size size, uint cals)
        {
            StreetCorn side = new();
            side.AdditionalIngredients[Ingredient.Cilantro].Included = cilantro;
            side.AdditionalIngredients[Ingredient.CotijaCheese].Included = cheese;
            side.SizeChoice = size;

            Assert.Equal(cals, side.Calories);
        }

        /// <summary>
        /// Checking if the override ToString method is working properly
        /// </summary>
        [Fact]
        public void TestToString()
        {
            StreetCorn side = new();
            Assert.Equal("Street Corn", side.ToString());
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
            StreetCorn sc = new();
            Assert.PropertyChanged(sc, propertyName, () => { sc.SizeChoice = size; });
        }
    }
}
