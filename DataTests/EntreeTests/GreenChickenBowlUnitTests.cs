using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.EntreeTests
{
    /// <summary>
    /// Class to check unit tests for the green chicken bowl class
    /// </summary>
    public class GreenChickenBowlUnitTests
    {
        /// <summary>
        /// Test to check if all the toppings have the correct default values
        /// </summary>
        [Fact]
        public void DefaultToppingsTest()
        {
            GreenChickenBowl bowl = new();
            Assert.True(bowl.AdditionalIngredients[Ingredient.Chicken].Included);
            Assert.True(bowl.AdditionalIngredients[Ingredient.BlackBeans].Included);
            Assert.True(bowl.AdditionalIngredients[Ingredient.Veggies].Included);
            Assert.True(bowl.AdditionalIngredients[Ingredient.Queso].Included);
            Assert.Equal(Salsa.Green, bowl.SalsaType);
            Assert.True(bowl.AdditionalIngredients[Ingredient.Guacamole].Included);
            Assert.True(bowl.AdditionalIngredients[Ingredient.SourCream].Included);
        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            GreenChickenBowl bowl = new();
            Assert.Equal(9.99m, bowl.Price);
        }

        /// <summary>
        /// Checking whether the default calories are correct or not
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            GreenChickenBowl bowl = new();
            Assert.Equal((uint)890, bowl.Calories);
        }

        /// <summary>
        /// Test to check if the Preparation instructions for this bowl are changing according to toppings selected
        /// </summary>
        /// <param name="chicken">whether the bowl contains carnitas</param>
        /// <param name="blackbeans">whether the bowl contains veggies</param>
        /// <param name="veggies">whether the bowl contains queso</param>
        /// <param name="queso">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="prepInfo">the preparation info for the bowl</param>
        [Theory]
        [InlineData(true, true, true, true, Salsa.Green, true, true, new string[] { })]
        [InlineData(false, true, false, false, Salsa.Medium, true, true, new string[] { "Hold Chicken", "Hold Veggies", "Hold Queso", "Swap Medium Salsa"})]
        [InlineData(true, true, false, true, Salsa.Mild, false, false, new string[] { "Hold Veggies", "Swap Mild Salsa", "Hold Guacamole", "Hold Sour Cream" })]
        [InlineData(true, true, true, true, Salsa.Hot, false, true, new string[] { "Swap Hot Salsa", "Hold Guacamole" })]
        [InlineData(false, false, true, false, Salsa.Green, true, true, new string[] { "Hold Chicken", "Hold Black Beans", "Hold Queso"})]
        [InlineData(false, true, false, false, Salsa.None, true, true, new string[] { "Hold Chicken", "Hold Veggies", "Hold Queso", "Hold Salsa" })]
        [InlineData(false, false, false, false, Salsa.None, true, true, new string[] { "Hold Chicken", "Hold Black Beans", "Hold Veggies", "Hold Queso", "Hold Salsa" })]
        [InlineData(false, false, false, false, Salsa.None, true, false, new string[] { "Hold Chicken", "Hold Black Beans", "Hold Veggies", "Hold Queso", "Hold Salsa", "Hold Sour Cream" })]

        public void checkingPreparationInfoTest(bool chicken, bool blackbeans, bool veggies, bool queso, Salsa salsa, bool guacamole, bool sourcream, string[] prepInfo)
        {
            GreenChickenBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Chicken].Included = chicken;
            bowl.AdditionalIngredients[Ingredient.BlackBeans].Included = blackbeans;
            bowl.AdditionalIngredients[Ingredient.Veggies].Included = veggies;
            bowl.AdditionalIngredients[Ingredient.Queso].Included = queso;
            bowl.SalsaType = salsa;
            bowl.AdditionalIngredients[Ingredient.Guacamole].Included = guacamole;
            bowl.AdditionalIngredients[Ingredient.SourCream].Included = sourcream;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, bowl.Instructions);
            }

            Assert.Equal(prepInfo.Length, bowl.Instructions.Count());
        }


        /// <summary>
        /// Test to check if the Price for this bowl is changing according to toppings selected
        /// </summary>
        /// <param name="chicken">whether the bowl contains carnitas</param>
        /// <param name="blackbeans">whether the bowl contains veggies</param>
        /// <param name="veggies">whether the bowl contains queso</param>
        /// <param name="queso">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="price">the price of the bowl</param>
        [Theory]
        [InlineData(true, true, true, true, Salsa.Green, true, true, 9.99)]
        [InlineData(false, true, false, false, Salsa.Medium, true, true, 9.99)]
        [InlineData(true, true, false, true, Salsa.Mild, false, false, 9.99)]
        [InlineData(true, true, true, true, Salsa.Hot, false, true, 9.99)]
        [InlineData(false, false, true, false, Salsa.Green, true, true, 9.99)]
        [InlineData(false, true, false, false, Salsa.None, true, true, 9.99)]
        [InlineData(false, false, false, false, Salsa.None, true, true, 9.99)]
        [InlineData(false, false, false, false, Salsa.None, true, false, 9.99)]

        public void checkingPriceTest(bool chicken, bool blackbeans, bool veggies, bool queso, Salsa salsa, bool guacamole, bool sourcream, decimal price)
        {
            GreenChickenBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Chicken].Included = chicken;
            bowl.AdditionalIngredients[Ingredient.BlackBeans].Included = blackbeans;
            bowl.AdditionalIngredients[Ingredient.Veggies].Included = veggies;
            bowl.AdditionalIngredients[Ingredient.Queso].Included = queso;
            bowl.SalsaType = salsa;
            bowl.AdditionalIngredients[Ingredient.Guacamole].Included = guacamole;
            bowl.AdditionalIngredients[Ingredient.SourCream].Included = sourcream;

            Assert.Equal(price, bowl.Price);
        }

        /// <summary>
        /// Test to check if the Price for this bowl is changing according to toppings selected
        /// </summary>
        /// <param name="chicken">whether the bowl contains carnitas</param>
        /// <param name="blackbeans">whether the bowl contains veggies</param>
        /// <param name="veggies">whether the bowl contains queso</param>
        /// <param name="queso">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="cals">the cals for the bowl</param>
        [Theory]
        [InlineData(true, true, true, true, Salsa.Green, true, true, 890)]
        [InlineData(false, true, false, false, Salsa.Medium, true, true, 610)]
        [InlineData(true, true, false, true, Salsa.Mild, false, false, 620)]
        [InlineData(true, true, true, true, Salsa.Hot, false, true, 740)]
        [InlineData(false, false, true, false, Salsa.Green, true, true, 500)]
        [InlineData(false, true, false, false, Salsa.None, true, true, 590)]
        [InlineData(false, false, false, false, Salsa.None, true, true, 460)]
        [InlineData(false, false, false, false, Salsa.None, true, false, 360)]

        public void checkingCaloriesTest(bool chicken, bool blackbeans, bool veggies, bool queso, Salsa salsa, bool guacamole, bool sourcream, uint cals)
        {
            GreenChickenBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Chicken].Included = chicken;
            bowl.AdditionalIngredients[Ingredient.BlackBeans].Included = blackbeans;
            bowl.AdditionalIngredients[Ingredient.Veggies].Included = veggies;
            bowl.AdditionalIngredients[Ingredient.Queso].Included = queso;
            bowl.SalsaType = salsa;
            bowl.AdditionalIngredients[Ingredient.Guacamole].Included = guacamole;
            bowl.AdditionalIngredients[Ingredient.SourCream].Included = sourcream;

            Assert.Equal(cals, bowl.Calories);
        }
    }
}
