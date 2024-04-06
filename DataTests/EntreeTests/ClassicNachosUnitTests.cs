using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.EntreeTests
{
    /// <summary>
    /// Class to check tests for the classic nachos class
    /// </summary>
    public class ClassicNachosUnitTests
    {
        /// <summary>
        /// Test to check if all the toppings have the correct default values
        /// </summary>
        [Fact]
        public void DefaultToppingsTest()
        {
            ClassicNachos nachos = new();
            Assert.True(nachos.AdditionalIngredients[Ingredient.Steak].Included);
            Assert.True(nachos.AdditionalIngredients[Ingredient.Chicken].Included);
            Assert.True(nachos.AdditionalIngredients[Ingredient.Queso].Included);
            Assert.Equal(Salsa.Medium, nachos.SalsaType);
            Assert.False(nachos.AdditionalIngredients[Ingredient.Guacamole].Included);
            Assert.False(nachos.AdditionalIngredients[Ingredient.SourCream].Included);
        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            ClassicNachos nachos = new();
            Assert.Equal(12.99m, nachos.Price);
        }

        /// <summary>
        /// Checking whether the default calories are correct or not
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            ClassicNachos nachos = new();
            Assert.Equal((uint)710, nachos.Calories);
        }

        /// <summary>
        /// Test to check if the Preparation instructions for classic nachos are changing according to toppings selected
        /// </summary>
        /// <param name="steak">whether nachos contains steak</param>
        /// <param name="chicken">whether nachos contains chicken</param>
        /// <param name="queso">whether nachos contains queso</param>
        /// <param name="salsa">type of salsa in nachos</param>
        /// <param name="guacamole">whether nachos contains guacamole</param>
        /// <param name="sourcream">whether nachos contains sour cream</param>
        /// <param name="prepInfo">the preparation info</param>
        [Theory]
        [InlineData(true, true, true, Salsa.Medium, false, false, new string[] { })]
        [InlineData(false, true, false, Salsa.Medium, true, true, new string[] { "Hold Steak", "Hold Queso", "Add Guacamole", "Add Sour Cream" })]
        [InlineData(true, true, false, Salsa.Mild, false, false, new string[] { "Hold Queso", "Swap Mild Salsa" })]
        [InlineData(true, true, true, Salsa.Hot, false, true, new string[] { "Swap Hot Salsa", "Add Sour Cream" })]
        [InlineData(false, false, true, Salsa.Green, true, true, new string[] { "Hold Steak", "Hold Chicken", "Swap Green Salsa", "Add Guacamole", "Add Sour Cream" })]
        [InlineData(false, true, false, Salsa.None, true, true, new string[] { "Hold Steak", "Hold Queso", "Hold Salsa", "Add Guacamole", "Add Sour Cream" })]
        [InlineData(false, false, false, Salsa.None, true, false, new string[] { "Hold Steak", "Hold Chicken", "Hold Queso", "Hold Salsa", "Add Guacamole" })]
        [InlineData(true, false, false, Salsa.None, true, false, new string[] { "Hold Chicken", "Hold Queso", "Hold Salsa", "Add Guacamole" })]

        public void checkingPreparationInfoTest(bool steak, bool chicken, bool queso, Salsa salsa, bool guacamole, bool sourcream, string[] prepInfo)
        {
            ClassicNachos nachos = new();
            nachos.AdditionalIngredients[Ingredient.Steak].Included = steak;
            nachos.AdditionalIngredients[Ingredient.Queso].Included = queso;
            nachos.AdditionalIngredients[Ingredient.Chicken].Included = chicken;
            nachos.SalsaType = salsa;
            nachos.AdditionalIngredients[Ingredient.Guacamole].Included = guacamole;
            nachos.AdditionalIngredients[Ingredient.SourCream].Included = sourcream;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, nachos.Instructions);
            }

            Assert.Equal(prepInfo.Length, nachos.Instructions.Count());
        }


        /// <summary>
        /// Test to check if the Price for classic nachos is changing according to toppings selected
        /// </summary>
        /// <param name="steak">whether the bowl contains veggies</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="chicken">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="price">the price of the bowl</param>
        [Theory]
        [InlineData(true, true, true, Salsa.Medium, false, false, 12.99)]
        [InlineData(false, true, false, Salsa.Medium, true, true, 13.99)]
        [InlineData(true, true, false, Salsa.Mild, false, false, 12.99)]
        [InlineData(true, true, true, Salsa.Hot, false, true, 12.99)]
        [InlineData(false, false, true, Salsa.Green, true, true, 13.99)]
        [InlineData(false, true, false, Salsa.None, true, true, 13.99)]
        [InlineData(false, false, false, Salsa.None, true, true, 13.99)]
        [InlineData(true, false, false, Salsa.None, true, true, 13.99)]

        public void checkingPriceTest(bool steak, bool chicken, bool queso, Salsa salsa, bool guacamole, bool sourcream, decimal price)
        {
            ClassicNachos nachos = new();
            nachos.AdditionalIngredients[Ingredient.Steak].Included = steak;
            nachos.AdditionalIngredients[Ingredient.Queso].Included = queso;
            nachos.AdditionalIngredients[Ingredient.Chicken].Included = chicken;
            nachos.SalsaType = salsa;
            nachos.AdditionalIngredients[Ingredient.Guacamole].Included = guacamole;
            nachos.AdditionalIngredients[Ingredient.SourCream].Included = sourcream;

            Assert.Equal(price, nachos.Price);
        }

        /// <summary>
        /// Test to check if the Price for classic nachos is changing according to toppings selected
        /// </summary>
        /// <param name="Steak">whether the bowl contains veggies</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="chicken">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="cals">the cals for the bowl</param>
        [Theory]
        [InlineData(true, true, true, Salsa.Medium, false, false, 710)]
        [InlineData(false, true, false, Salsa.Medium, true, true, 670)]
        [InlineData(true, true, false, Salsa.Mild, false, false, 600)]
        [InlineData(true, true, true, Salsa.Hot, false, true, 810)]
        [InlineData(false, false, true, Salsa.Green, true, true, 630)]
        [InlineData(false, true, false, Salsa.None, true, true, 650)]
        [InlineData(false, false, false, Salsa.None, true, true, 500)]
        [InlineData(false, false, false, Salsa.None, true, false, 400)]

        public void checkingCaloriesTest(bool Steak, bool chicken, bool queso, Salsa salsa, bool guacamole, bool sourcream, uint cals)
        {
            ClassicNachos nachos = new();
            nachos.AdditionalIngredients[Ingredient.Steak].Included = Steak;
            nachos.AdditionalIngredients[Ingredient.Queso].Included = queso;
            nachos.AdditionalIngredients[Ingredient.Chicken].Included = chicken;
            nachos.SalsaType = salsa;
            nachos.AdditionalIngredients[Ingredient.Guacamole].Included = guacamole;
            nachos.AdditionalIngredients[Ingredient.SourCream].Included = sourcream;

            Assert.Equal(cals, nachos.Calories);
        }

        /// <summary>
        /// Checking if the override ToString method is working properly
        /// </summary>
        [Fact]
        public void TestToString()
        {
            ClassicNachos nachos = new();
            Assert.Equal("Classic nachos", nachos.ToString());
        }

        [Theory]
        [InlineData(Salsa.Mild, "Instructions")]
        [InlineData(Salsa.Medium, "Instructions")]
        [InlineData(Salsa.Hot, "Instructions")]
        [InlineData(Salsa.Green, "Instructions")]
        [InlineData(Salsa.None, "Instructions")]
        public void ChangingSalsaShouldNotifyOfPropertyChanges(Salsa salsa, string propertyName)
        {
            ClassicNachos nachos = new();
            Assert.PropertyChanged(nachos, propertyName, () => { nachos.SalsaType = salsa; });
        }

        [Theory]
        [InlineData(Ingredient.Chicken, true, "Instructions")]
        [InlineData(Ingredient.Chicken, false, "Instructions")]
        [InlineData(Ingredient.Steak, true, "Instructions")]
        [InlineData(Ingredient.Steak, false, "Instructions")]
        [InlineData(Ingredient.Queso, true, "Instructions")]
        [InlineData(Ingredient.Queso, false, "Instructions")]
        [InlineData(Ingredient.Guacamole, true, "Instructions")]
        [InlineData(Ingredient.Guacamole, false, "Instructions")]
        [InlineData(Ingredient.SourCream, true, "Instructions")]
        [InlineData(Ingredient.SourCream, false, "Instructions")]
        public void ChangingIngredientsShouldNotifyOfPropertyChanges(Ingredient ing, bool included, string propertyName)
        {
            ClassicNachos nachos = new();
            Assert.PropertyChanged(nachos, propertyName, () => { nachos.AdditionalIngredients[ing].Included = included; });
        }

        [Theory]
        [InlineData(Ingredient.Guacamole, true, "Price")]
        [InlineData(Ingredient.Guacamole, false, "Price")]
        public void ChangingGuacamoleShouldNotifyOfPropertyChanges(Ingredient ing, bool included, string propertyName)
        {
            ClassicNachos nachos = new();
            Assert.PropertyChanged(nachos, propertyName, () => { nachos.AdditionalIngredients[ing].Included = included; });
        }
    }
}
