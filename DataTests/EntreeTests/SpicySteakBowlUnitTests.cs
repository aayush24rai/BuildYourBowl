using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.EntreeTests
{
    /// <summary>
    /// Class to check unit tests for the spicy steak bowl class
    /// </summary>
    public class SpicySteakBowlUnitTests
    {
        /// <summary>
        /// Test to check if all the toppings have the correct default values
        /// </summary>
        [Fact]
        public void DefaultToppingsTest()
        {
            SpicySteakBowl bowl = new();
            Assert.True(bowl.AdditionalIngredients[Ingredient.Steak].Included);
            Assert.False(bowl.AdditionalIngredients[Ingredient.Veggies].Included);
            Assert.True(bowl.AdditionalIngredients[Ingredient.Queso].Included);
            Assert.Equal(Salsa.Hot, bowl.SalsaType);
            Assert.False(bowl.AdditionalIngredients[Ingredient.Guacamole].Included);
            Assert.True(bowl.AdditionalIngredients[Ingredient.SourCream].Included);
        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            SpicySteakBowl bowl = new();
            Assert.Equal(10.99m, bowl.Price);
        }

        /// <summary>
        /// Checking whether the default calories are correct or not
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            SpicySteakBowl bowl = new();
            Assert.Equal((uint)620, bowl.Calories);
        }

        /// <summary>
        /// Test to check if the Preparation instructions for this bowl are changing according to toppings selected
        /// </summary>
        /// <param name="steak">whether the bowl contains carnitas</param>
        /// <param name="veggies">whether the bowl contains veggies</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="prepInfo">the preparation info for the bowl</param>
        [Theory]
        [InlineData(true, false, true, Salsa.Hot, false, true, new string[] { })]
        [InlineData(false, true, false, Salsa.Medium, true, true, new string[] { "Hold Steak", "Add Veggies", "Hold Queso", "Swap Medium Salsa", "Add Guacamole" })]
        [InlineData(true, true, false, Salsa.Mild, false, false, new string[] { "Add Veggies", "Hold Queso", "Swap Mild Salsa", "Hold Sour Cream" })]
        [InlineData(true, true, true, Salsa.Hot, false, false, new string[] { "Add Veggies", "Hold Sour Cream" })]
        [InlineData(false, false, true, Salsa.Green, true, true, new string[] { "Hold Steak", "Swap Green Salsa", "Add Guacamole" })]
        [InlineData(false, true, false, Salsa.None, true, true, new string[] { "Hold Steak", "Add Veggies", "Hold Queso", "Hold Salsa", "Add Guacamole" })]
        [InlineData(false, false, false, Salsa.None, true, true, new string[] { "Hold Steak", "Hold Queso", "Hold Salsa", "Add Guacamole" })]
        [InlineData(false, false, false, Salsa.None, true, false, new string[] { "Hold Steak", "Hold Queso", "Hold Salsa", "Add Guacamole", "Hold Sour Cream"})]


        public void checkingPreparationInfoTest(bool steak, bool veggies, bool queso, Salsa salsa, bool guacamole, bool sourcream, string[] prepInfo)
        {
            SpicySteakBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Steak].Included = steak;
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
        /// <param name="steak">whether the bowl contains carnitas</param>
        /// <param name="veggies">whether the bowl contains queso</param>
        /// <param name="queso">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="price">the the price of the bowl</param>
        [Theory]
        [InlineData(true, false, true, Salsa.Hot, false, true, 10.99)]
        [InlineData(false, true, false, Salsa.Medium, true, true, 11.99)]
        [InlineData(true, true, false, Salsa.Mild, false, false, 10.99)]
        [InlineData(true, true, true, Salsa.Hot, false, true, 10.99)]
        [InlineData(false, false, true, Salsa.Green, true, true, 11.99)]
        [InlineData(false, true, false, Salsa.None, true, true, 11.99)]
        [InlineData(false, false, false, Salsa.None, true, true, 11.99)]
        [InlineData(false, false, false, Salsa.None, false, true, 10.99)]

        public void checkingPriceTest(bool steak, bool veggies, bool queso, Salsa salsa, bool guacamole, bool sourcream, decimal price)
        {
            SpicySteakBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Steak].Included = steak;
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
        /// <param name="steak">whether the bowl contains carnitas</param>
        /// <param name="veggies">whether the bowl contains queso</param>
        /// <param name="queso">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="cals">the cals for the bowl</param>
        [Theory]
        [InlineData(true, false, true, Salsa.Hot, false, true, 620)]
        [InlineData(false, true, false, Salsa.Medium, true, true, 500)]
        [InlineData(true, true, false, Salsa.Mild, false, false, 430)]
        [InlineData(true, true, true, Salsa.Hot, false, true, 640)]
        [InlineData(false, false, true, Salsa.Green, true, true, 590)]
        [InlineData(false, true, false, Salsa.None, true, true, 480)]
        [InlineData(false, false, false, Salsa.None, true, true, 460)]
        [InlineData(false, false, false, Salsa.None, true, false, 360)]


        public void checkingCaloriesTest(bool steak, bool veggies, bool queso, Salsa salsa, bool guacamole, bool sourcream, uint cals)
        {
            SpicySteakBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Steak].Included = steak;
            bowl.AdditionalIngredients[Ingredient.Veggies].Included = veggies;
            bowl.AdditionalIngredients[Ingredient.Queso].Included = queso;
            bowl.SalsaType = salsa;
            bowl.AdditionalIngredients[Ingredient.Guacamole].Included = guacamole;
            bowl.AdditionalIngredients[Ingredient.SourCream].Included = sourcream;

            Assert.Equal(cals, bowl.Calories);
        }

        /// <summary>
        /// Checking if the override ToString method is working properly
        /// </summary>
        [Fact]
        public void TestToString()
        {
            SpicySteakBowl bowl = new();
            Assert.Equal("Spicy steak bowl", bowl.ToString());
        }

        [Theory]
        [InlineData(Salsa.Mild, "Instructions", "Calories")]
        [InlineData(Salsa.Medium, "Instructions", "Calories")]
        [InlineData(Salsa.Hot, "Instructions", "Calories")]
        [InlineData(Salsa.Green, "Instructions", "Calories")]
        [InlineData(Salsa.None, "Instructions", "Calories")]
        public void ChangingSalsaShouldNotifyOfPropertyChanges(Salsa salsa, string propertyName, string propertyName2)
        {
            SpicySteakBowl bowl = new();
            Assert.PropertyChanged(bowl, propertyName, () => { bowl.SalsaType = salsa; });
            Assert.PropertyChanged(bowl, propertyName2, () => { bowl.SalsaType = salsa; });
        }

        [Theory]
        [InlineData(Ingredient.Steak, true, "Instructions", "Calories")]
        [InlineData(Ingredient.Steak, false, "Instructions", "Calories")]
        [InlineData(Ingredient.Veggies, true, "Instructions", "Calories")]
        [InlineData(Ingredient.Veggies, false, "Instructions", "Calories")]
        [InlineData(Ingredient.Queso, true, "Instructions", "Calories")]
        [InlineData(Ingredient.Queso, false, "Instructions", "Calories")]
        [InlineData(Ingredient.PintoBeans, true, "Instructions", "Calories")]
        [InlineData(Ingredient.PintoBeans, false, "Instructions", "Calories")]
        [InlineData(Ingredient.Guacamole, true, "Instructions", "Calories")]
        [InlineData(Ingredient.Guacamole, false, "Instructions", "Calories")]
        [InlineData(Ingredient.SourCream, true, "Instructions", "Calories")]
        [InlineData(Ingredient.SourCream, false, "Instructions", "Calories")]
        public void ChangingIngredientsShouldNotifyOfPropertyChanges(Ingredient ing, bool included, string propertyName, string propertyName2)
        {
            SpicySteakBowl bowl = new();
            Assert.PropertyChanged(bowl, propertyName, () => { bowl.AdditionalIngredients[ing].Included = included; });
        }

        [Theory]
        [InlineData(Ingredient.Guacamole, true, "Price")]
        [InlineData(Ingredient.Guacamole, false, "Price")]
        public void ChangingGuacamoleShouldNotifyOfPropertyChanges(Ingredient ing, bool included, string propertyName)
        {
            SpicySteakBowl bowl = new();
            Assert.PropertyChanged(bowl, propertyName, () => { bowl.AdditionalIngredients[ing].Included = included; });
        }
    }
}
