﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.SidesUnitTests
{
    /// <summary>
    /// Class to check tests for the refried beans class
    /// </summary>
    public class RefriedBeansUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultToppingsTest()
        {
            RefriedBeans side = new();
            Assert.True(side.Onions);
            Assert.True(side.CheddarCheese);
            Assert.Equal(Size.Medium, side.SizeSelection);

        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            RefriedBeans side = new();
            Assert.Equal(3.75m, side.Price);
        }

        /// <summary>
        /// Checking whether the default calories are correct or not
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            RefriedBeans side = new();
            Assert.Equal((uint)300, side.Calories);
        }

        /// <summary>
        /// Test to check if the preparation information for refried beans is changing according to toppings selected
        /// </summary>
        /// <param name="onions">whether refried beans contains onions</param>
        /// <param name="cheese">whether refried beans contains cheddar cheese</param>
        /// <param name="size">size of refried beans</param>
        /// <param name="prepInfo">the preparation info of the refried beans</param>
        [Theory]
        [InlineData(true, true, Size.Medium, new string[] { "Medium" })]
        [InlineData(false, true, Size.Kids, new string[] { "Kids", "Hold Onions" })]
        [InlineData(true, false, Size.Kids, new string[] { "Kids", "Hold Cheddar Cheese" })]
        [InlineData(true, false, Size.Small, new string[] { "Small", "Hold Cheddar Cheese" })]
        [InlineData(false, false, Size.Medium, new string[] { "Medium", "Hold Onions", "Hold Cheddar Cheese" })]
        [InlineData(true, true, Size.Large, new string[] { "Large" })]

        public void checkingPreparationInfoTest(bool onions, bool cheese, Size size, string[] prepInfo)
        {
            RefriedBeans side = new();
            side.Onions = onions;
            side.CheddarCheese = cheese;
            side.SizeSelection = size;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, side.PreparationInformation);
            }

            Assert.Equal(prepInfo.Length, side.PreparationInformation.Count());
        }


        /// <summary>
        /// Test to check if the preparation information for refried beans is changing according to toppings selected
        /// </summary>
        /// <param name="onions">whether refried beans contains onions</param>
        /// <param name="cheese">whether refried beans contains cheddar cheese</param>
        /// <param name="size">size of refried beans</param>
        /// <param name="price">the price of the refried beans</param>
        [Theory]
        [InlineData(true, true, Size.Medium, 3.75)]
        [InlineData(false, true, Size.Kids, 2.75)]
        [InlineData(true, false, Size.Kids, 2.75)]
        [InlineData(true, false, Size.Small, 3.25)]
        [InlineData(false, false, Size.Medium, 3.75)]
        [InlineData(true, true, Size.Large, 4.50)]

        public void checkingPriceTest(bool onions, bool cheese, Size size, decimal price)
        {
            RefriedBeans side = new();
            side.Onions = onions;
            side.CheddarCheese = cheese;
            side.SizeSelection = size;

            Assert.Equal(price, side.Price);
        }
        
        /// <summary>
        /// Test to check if the preparation information for refried beans is changing according to toppings selected
        /// </summary>
        /// <param name="onions">whether refried beans contains onions</param>
        /// <param name="cheese">whether refried beans contains cheddar cheese</param>
        /// <param name="size">size of refried beans</param>
        /// <param name="cals">the calories of the refried beans</param>
        [Theory]
        [InlineData(true, true, Size.Medium, (uint)300)]
        [InlineData(false, true, Size.Kids, (uint)(0.60 * 295))]
        [InlineData(true, false, Size.Kids, (uint)(0.60 * 210))]
        [InlineData(true, false, Size.Small, (uint)(0.75 * 210))]
        [InlineData(false, false, Size.Medium, (uint)205)]
        [InlineData(true, true, Size.Large, (uint)(1.50 * 300))]

        public void checkingCaloriesTest(bool onions, bool cheese, Size size, uint cals)
        {
            RefriedBeans side = new();
            side.Onions= onions;
            side.CheddarCheese = cheese;
            side.SizeSelection = size;

            Assert.Equal(cals, side.Calories);
        }
    }
}
