
using BuildYourBowl.Data;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Nacho unit tests
    /// </summary>
    public class NachoUnitTests
    {
        /// <summary>
        /// defaykt tests
        /// </summary>
        [Fact]
        public void DefaultNachoTests()
        {
            Nachos nacho = new();
            Assert.Equal(Ingredient.Chips, nacho.BaseIngredient.IngredientType);
            //Assert.Equal(Salsa.Medium, nacho.SalsaChoice);
            //Assert.Empty(nacho.AdditionalIngredients);
        }
        /// <summary>
        /// additional ingredient test
        /// </summary>
        [Fact]
        public void AdditonalIngredientNachoTests()
        {
            Nachos nacho = new();
            /*
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.BlackBeans));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.PintoBeans));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.Queso));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.Veggies));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.SourCream));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.Guacamole));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.Chicken));
            */
            Assert.Equal(9, nacho.AdditionalIngredients.Count);
        }
        /// <summary>
        /// remove ingredient test
        /// </summary>
        [Fact]
        public void RemoveAdditionalIngredient()
        {
            Nachos nacho = new();
            /*
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.BlackBeans));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.PintoBeans));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.Queso));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.Veggies));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.SourCream));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.Guacamole));
            nacho.AdditionalIngredients.Add(new IngredientItem(Ingredient.Chicken));
            */
            nacho.AdditionalIngredients.Remove(Ingredient.Chicken);
            nacho.AdditionalIngredients.Remove(Ingredient.Steak);
            Assert.Equal(7, nacho.AdditionalIngredients.Count);
        }
        /*
        /// <summary>
        /// update base ingredient test
        /// </summary>
        [Fact]
        public void UpdateBaseIngredient()
        {
            Nachos nacho = new();
            nacho.BaseIngredient = new IngredientItem(Ingredient.Chips);
            Assert.Equal(Ingredient.Chips, nacho.BaseIngredient);
        }
        */
        /// <summary>
        /// update salsa choice
        /// </summary>
        [Fact]
        public void UpdateSalsaChoice()
        {
            Nachos nacho = new();
             nacho.SalsaType = Salsa.Mild;
            Assert.Equal(Salsa.Mild, nacho.SalsaType);
        }

        /// <summary>
        /// Checking if the override ToString method is working properly
        /// </summary>
        [Fact]
        public void TestToString()
        {
            Nachos nachos = new();
            Assert.Equal("Build-Your-Own Nachos", nachos.ToString());
        }
    }
}