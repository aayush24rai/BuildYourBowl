using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Bowl Unit Tests
    /// </summary>
    public class BowlUnitTests
    {
        /// <summary>
        /// default test
        /// </summary>
        [Fact]
        public void DefaultBowlTests()
        {
            Bowl bowl = new();
            Assert.Equal(Ingredient.Rice, bowl.BaseIngredient.IngredientType);
            //Assert.Equal(Salsa.Medium, bowl.SalsaChoice);
        }
        /// <summary>
        /// additional ingredient test
        /// </summary>
        [Fact]
        public void AdditonalIngredientBowlTests()
        {
            Bowl bowl = new();

            /*
            bowl.AdditionalIngredients = new();
            bowl.AdditionalIngredients.Add(Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans));
            bowl.AdditionalIngredients.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans));
            bowl.AdditionalIngredients.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            bowl.AdditionalIngredients.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            bowl.AdditionalIngredients.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));
            bowl.AdditionalIngredients.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            bowl.AdditionalIngredients.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken));
            */

            Assert.Equal(9, bowl.AdditionalIngredients.Count);
        }
        /// <summary>
        /// remove ingredient
        /// </summary>
        [Fact]
        public void RemoveAdditionalIngredient()
        {
            Bowl bowl = new();
            /*
            bowl.AdditionalIngredients = new();
            bowl.AdditionalIngredients.Add(Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans));
            bowl.AdditionalIngredients.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans));
            bowl.AdditionalIngredients.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            bowl.AdditionalIngredients.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            bowl.AdditionalIngredients.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));
            bowl.AdditionalIngredients.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            bowl.AdditionalIngredients.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken));
            //bowl.AdditionalIngredients.Remove(bowl.AdditionalIngredients.Count - 1);
            */
            bowl.AdditionalIngredients.Remove(Ingredient.Chicken);
            Assert.Equal(8, bowl.AdditionalIngredients.Count);
        }
        
        /*
        /// <summary>
        /// update base ingredient
        /// </summary>
        [Fact]
        public void UpdateBaseIngredient()
        {
            Bowl bowl = new();
            bowl.BaseIngredient = new IngredientItem(Ingredient.Chips);
            Assert.Equal(Ingredient.Chips, bowl.BaseIngredient);
        }
        */

        /// <summary>
        /// Update salsa choiuce
        /// </summary>
        [Fact]
        public void UpdateSalsaChoice()
        {
            Bowl bowl = new Bowl();
            bowl.SalsaType = Salsa.Mild;
            Assert.Equal(Salsa.Mild, bowl.SalsaType);
        }
    }
}