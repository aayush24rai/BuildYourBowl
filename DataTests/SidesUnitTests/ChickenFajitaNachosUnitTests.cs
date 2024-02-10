using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.SidesUnitTests
{
    /// <summary>
    /// Class to check tests for the chicken fajita nachos class
    /// </summary>
    public class ChickenFajitaNachosUnitTests
    {
        /// <summary>
        /// Test to check if all the toppings have the correct default values
        /// </summary>
        [Fact]
        public void DefaultToppingsTest()
        {
            ChickenFajitaNachos nachos = new();
            Assert.True(nachos.Veggies);
            Assert.True(nachos.Chicken);
            Assert.True(nachos.Queso);
            Assert.Equal(Salsa.Medium, nachos.SalsaSelection);
            Assert.False(nachos.Guacamole);
            Assert.True(nachos.SourCream);
        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            ChickenFajitaNachos nachos = new();
            Assert.Equal(10.99m, nachos.Price);
        }

        /// <summary>
        /// Checking whether the default calories are correct or not
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            ChickenFajitaNachos nachos = new();
            Assert.Equal((uint)650, nachos.Calories);
        }

        /// <summary>
        /// Test to check if the Preparation instructions for chicken fajita nachos are changing according to toppings selected
        /// </summary>
        /// <param name="veggies">whether the bowl contains veggies</param>
        /// <param name="chicken">whether the bowl contains pinto beans</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="prepInfo">the preparation info for the bowl</param>
        [Theory]
        [InlineData(true, true, true, Salsa.Medium, false, true, new string[] { })]
        [InlineData(false, true, false, Salsa.Medium, true, true, new string[] { "Hold Veggies", "Hold Queso", "Add Guacamole" })]
        [InlineData(true, true, false, Salsa.Mild, false, false, new string[] { "Hold Queso", "Swap Mild Salsa", "Hold Sour Cream" })]
        //Specific required test case
        [InlineData(false, false, true, Salsa.Hot, false, false, new string[] { "Hold Chicken", "Hold Veggies","Swap Hot Salsa", "Hold Sour Cream" })]
        [InlineData(false, false, true, Salsa.Green, true, true, new string[] { "Hold Veggies", "Hold Chicken", "Swap Green Salsa", "Add Guacamole" })]
        [InlineData(false, true, false, Salsa.None, true, true, new string[] { "Hold Veggies", "Hold Queso", "Hold Salsa", "Add Guacamole" })]
        [InlineData(false, false, false, Salsa.None, true, false, new string[] { "Hold Veggies", "Hold Chicken", "Hold Queso", "Hold Salsa", "Add Guacamole", "Hold Sour Cream" })]
        [InlineData(true, false, false, Salsa.None, true, false, new string[] { "Hold Chicken", "Hold Queso", "Hold Salsa", "Add Guacamole", "Hold Sour Cream" })]

        public void checkingPreparationInfoTest(bool veggies, bool chicken, bool queso, Salsa salsa, bool guacamole, bool sourcream, string[] prepInfo)
        {
            ChickenFajitaNachos nachos = new();
            nachos.Veggies = veggies;
            nachos.Queso = queso;
            nachos.Chicken = chicken;
            nachos.SalsaSelection = salsa;
            nachos.Guacamole = guacamole;
            nachos.SourCream = sourcream;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, nachos.PreparationInformation);
            }

            Assert.Equal(prepInfo.Length, nachos.PreparationInformation.Count());
        }


        /// <summary>
        /// Test to check if the Price for chicken fajita nachos is changing according to toppings selected
        /// </summary>
        /// <param name="veggies">whether the bowl contains veggies</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="chicken">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="price">the price of the bowl</param>
        [Theory]
        [InlineData(true, false, true, Salsa.Medium, false, false, 10.99)]
        [InlineData(false, true, false, Salsa.Medium, true, true, 11.99)]
        [InlineData(true, true, false, Salsa.Mild, false, false, 10.99)]
        //Specific required test case
        [InlineData(false, false, true, Salsa.Hot, false, false, 10.99)]
        [InlineData(false, false, true, Salsa.Green, true, true, 11.99)]
        [InlineData(false, true, false, Salsa.None, true, true, 11.99)]
        [InlineData(false, false, false, Salsa.None, true, true, 11.99)]
        [InlineData(true, false, false, Salsa.None, true, true, 11.99)]

        public void checkingPriceTest( bool veggies, bool chicken, bool queso, Salsa salsa, bool guacamole, bool sourcream, decimal price)
        {
            ChickenFajitaNachos nachos = new();
            nachos.Veggies = veggies;
            nachos.Queso = queso;
            nachos.Chicken = chicken;
            nachos.SalsaSelection = salsa;
            nachos.Guacamole = guacamole;
            nachos.SourCream = sourcream;

            Assert.Equal(price, nachos.Price);
        }

        /// <summary>
        /// Test to check if the Price for chicken fajita nachos is changing according to toppings selected
        /// </summary>
        /// <param name="veggies">whether the bowl contains veggies</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="chicken">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="cals">the cals for the bowl</param>
        [Theory]
        [InlineData(true, true, true, Salsa.Medium, false, true, 650)]
        [InlineData(false, true, false, Salsa.Medium, true, true, 670)]
        [InlineData(true, true, false, Salsa.Mild, false, false, 440)]
        //Specific required test case
        [InlineData(false, false, true, Salsa.Hot, false, false, 380)]
        [InlineData(false, false, true, Salsa.Green, true, true, 630)]
        [InlineData(false, true, false, Salsa.None, true, true, 650)]
        [InlineData(false, false, false, Salsa.None, true, true, 500)]
        [InlineData(false, false, false, Salsa.None, true, false, 400)]

        public void checkingCaloriesTest(bool veggies, bool chicken, bool queso, Salsa salsa, bool guacamole, bool sourcream, uint cals)
        {
            ChickenFajitaNachos nachos = new();
            nachos.Veggies = veggies;
            nachos.Queso = queso;
            nachos.Chicken = chicken;
            nachos.SalsaSelection = salsa;
            nachos.Guacamole = guacamole;
            nachos.SourCream = sourcream;

            Assert.Equal(cals, nachos.Calories);
        }
    }
}
