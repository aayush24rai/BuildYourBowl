namespace BuildYourBowl.DataTests.EntreeTests
{
    /// <summary>
    /// Class to check tests for the carnitas bowl class
    /// </summary>
    public class CarnitasBowlUnitTests
    {
        
        /// <summary>
        /// Test to check if all the toppings have the correct default values
        /// </summary>
        [Fact]
        public void DefaultToppingsTest()
        {
            CarnitasBowl bowl = new();
            Assert.True(bowl.AdditionalIngredients[Ingredient.Carnitas].Included);
            Assert.False(bowl.AdditionalIngredients[Ingredient.Veggies].Included);
            Assert.True(bowl.AdditionalIngredients[Ingredient.Queso].Included);
            Assert.True(bowl.AdditionalIngredients[Ingredient.PintoBeans].Included);
            Assert.Equal(Salsa.Medium, bowl.SalsaType);
            Assert.False(bowl.AdditionalIngredients[Ingredient.Guacamole].Included);
            Assert.False(bowl.AdditionalIngredients[Ingredient.SourCream].Included);
        }
             
        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            CarnitasBowl bowl = new();
            Assert.Equal(9.99m, bowl.Price);
        }

        /// <summary>
        /// Checking whether the default calories are correct or not
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            CarnitasBowl bowl = new();
            Assert.Equal((uint)680, bowl.Calories);
        }

        /// <summary>
        /// Test to check if the Preparation instructions for this bowl are changing according to toppings selected
        /// </summary>
        /// <param name="carnitas">whether the bowl contains carnitas</param>
        /// <param name="veggies">whether the bowl contains veggies</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="pintobeans">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="prepInfo">the preparation info for the bowl</param>
        [Theory]
        //Specific required test case
        [InlineData(true, false, true, true, Salsa.Medium, false, false, new string[] { } )]
        [InlineData(false, true, false, false, Salsa.Medium, true, true, new string[] { "Hold Carnitas", "Hold Queso", "Hold Pinto Beans", "Add Guacamole", "Add Sour Cream", "Add Veggies" })]
        [InlineData(true, true, false, true, Salsa.Mild, false, false, new string[] {"Add Veggies", "Hold Queso", "Swap Mild Salsa"})]
        [InlineData(true, true, true, true, Salsa.Hot, false, true, new string[] { "Add Veggies", "Swap Hot Salsa", "Add Sour Cream" })]
        [InlineData(false, false, true, false, Salsa.Green, true, true, new string[] { "Hold Carnitas", "Hold Pinto Beans", "Swap Green Salsa", "Add Guacamole", "Add Sour Cream" })]
        [InlineData(false, true, false, false, Salsa.None, true, true, new string[] { "Hold Carnitas", "Add Veggies", "Hold Queso", "Hold Pinto Beans", "Hold Salsa", "Add Guacamole", "Add Sour Cream"})]
        [InlineData(false, false, false, false, Salsa.None, true, true, new string[] { "Hold Carnitas", "Hold Queso", "Hold Pinto Beans", "Hold Salsa", "Add Guacamole", "Add Sour Cream" })]
        [InlineData(false, false, false, false, Salsa.None, true, false, new string[] { "Hold Carnitas", "Hold Queso", "Hold Pinto Beans", "Hold Salsa", "Add Guacamole" })]

        public void checkingPreparationInfoTest(bool carnitas, bool veggies, bool queso, bool pintobeans, Salsa salsa, bool guacamole, bool sourcream, string[] prepInfo)
        {
            CarnitasBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Carnitas].Included = carnitas;
            bowl.AdditionalIngredients[Ingredient.Veggies].Included = veggies;
            bowl.AdditionalIngredients[Ingredient.Queso].Included = queso;
            bowl.AdditionalIngredients[Ingredient.PintoBeans].Included = pintobeans;
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
        /// <param name="carnitas">whether the bowl contains carnitas</param>
        /// <param name="veggies">whether the bowl contains veggies</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="pintobeans">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="price">the price of the bowl</param>
        [Theory]
        //Specific required test case
        [InlineData(true, false, true, true, Salsa.Medium, false, false, 9.99)]
        [InlineData(false, true, false, false, Salsa.Medium, true, true, 10.99)]
        [InlineData(true, true, false, true, Salsa.Mild, false, false, 9.99)]
        [InlineData(true, true, true, true, Salsa.Hot, false, true, 9.99)]
        [InlineData(false, false, true, false, Salsa.Green, true, true, 10.99)]
        [InlineData(false, true, false, false, Salsa.None, true, true, 10.99)]
        [InlineData(false, false, false, false, Salsa.None, true, true, 10.99)]
        [InlineData(false, false, false, false, Salsa.None, true, false, 10.99)]

        public void checkingPriceTest(bool carnitas, bool veggies, bool queso, bool pintobeans, Salsa salsa, bool guacamole, bool sourcream, decimal price)
        {
            CarnitasBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Carnitas].Included = carnitas;
            bowl.AdditionalIngredients[Ingredient.Veggies].Included = veggies;
            bowl.AdditionalIngredients[Ingredient.Queso].Included = queso;
            bowl.AdditionalIngredients[Ingredient.PintoBeans].Included = pintobeans;
            bowl.SalsaType = salsa;
            bowl.AdditionalIngredients[Ingredient.Guacamole].Included = guacamole;
            bowl.AdditionalIngredients[Ingredient.SourCream].Included = sourcream;

            Assert.Equal(price, bowl.Price);
        }

        /// <summary>
        /// Test to check if the Price for this bowl is changing according to toppings selected
        /// </summary>
        /// <param name="carnitas">whether the bowl contains carnitas</param>
        /// <param name="veggies">whether the bowl contains veggies</param>
        /// <param name="queso">whether the bowl contains queso</param>
        /// <param name="pintobeans">whether the bowl contains pinto beans</param>
        /// <param name="salsa">type of salsa in the bowl</param>
        /// <param name="guacamole">whether the bowl contains guacamole</param>
        /// <param name="sourcream">whether the bowl contains sour cream</param>
        /// <param name="cals">the cals for the bowl</param>
        [Theory]
        //Specific required test cases
        [InlineData(true, false, true, true, Salsa.Medium, false, false, 680)]
        [InlineData(false, true, false, false, Salsa.Medium, true, true, 500)]
        [InlineData(true, true, false, true, Salsa.Mild, false, false, 590)]
        [InlineData(true, true, true, true, Salsa.Hot, false, true, 800)]
        [InlineData(false, false, true, false, Salsa.Green, true, true, 590)]
        [InlineData(false, true, false, false, Salsa.None, true, true, 480)]
        [InlineData(false, false, false, false, Salsa.None, true, true, 460)]
        [InlineData(false, false, false, false, Salsa.None, true, false, 360)]

        public void checkingCaloriesTest(bool carnitas, bool veggies, bool queso, bool pintobeans, Salsa salsa, bool guacamole, bool sourcream, uint cals)
        {
            CarnitasBowl bowl = new();
            bowl.AdditionalIngredients[Ingredient.Carnitas].Included = carnitas;
            bowl.AdditionalIngredients[Ingredient.Veggies].Included = veggies;
            bowl.AdditionalIngredients[Ingredient.Queso].Included = queso;
            bowl.AdditionalIngredients[Ingredient.PintoBeans].Included = pintobeans;
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
            CarnitasBowl bowl = new();
            Assert.Equal("Carnitas Bowl", bowl.ToString());
        }

    }
}