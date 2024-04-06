using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Class to check tests for the IngredientItem class
    /// </summary>
    public class IngredientItemUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Theory]
        [InlineData(Ingredient.BlackBeans)]
        [InlineData(Ingredient.PintoBeans)]
        [InlineData(Ingredient.Queso)]
        [InlineData(Ingredient.Veggies)]
        [InlineData(Ingredient.SourCream)]
        [InlineData(Ingredient.Guacamole)]
        [InlineData(Ingredient.Chicken)]
        [InlineData(Ingredient.Steak)]
        [InlineData(Ingredient.Carnitas)]
        [InlineData(Ingredient.Rice)]
        [InlineData(Ingredient.Chips)]
        public void IngredientsTest(Ingredient ingredient)
        {
            IngredientItem ing = new(ingredient);
            string name = "";
            decimal cost = 0;
            uint calories = 0;

            switch (ingredient)
            {
                case Ingredient.BlackBeans:
                    name = "Black Beans";
                    cost = 1.00m;
                    calories = 130;
                    break;
                case Ingredient.PintoBeans:
                    name = "Pinto Beans";
                    cost = 1.00m;
                    calories = 130;
                    break;
                case Ingredient.Queso:
                    name = "Queso";
                    cost = 1.00m;
                    calories = 110;
                    break;
                case Ingredient.Veggies:
                    name = "Veggies";
                    cost = 0.00m;
                    calories = 20;
                    break;
                case Ingredient.SourCream:
                    name = "Sour Cream";
                    cost = 0.00m;
                    calories = 100;
                    break;
                case Ingredient.Guacamole:
                    name = "Guacamole";
                    cost = 1.00m;
                    calories = 150;
                    break;
                case Ingredient.Chicken:
                    name = "Chicken";
                    cost = 2.00m;
                    calories = 150;
                    break;
                case Ingredient.Steak:
                    name = "Steak";
                    cost = 2.00m;
                    calories = 180;
                    break;
                case Ingredient.Carnitas:
                    name = "Carnitas";
                    cost = 2.00m;
                    calories = 210;
                    break;
                case Ingredient.Rice:
                    name = "Rice";
                    cost = 0.00m;
                    calories = 210;
                    break;
                case Ingredient.Chips:
                    name = "Chips";
                    cost = 0.00m;
                    calories = 250;
                    break;
            }

            Assert.Equal(name, ing.Name);
            Assert.Equal(cost, ing.UnitCost);
            Assert.Equal(calories, ing.Calories);
            Assert.False(ing.Included);
            Assert.False(ing.Default);
        }


    }
}
