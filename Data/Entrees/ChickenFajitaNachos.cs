using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the Chicken Fajita Nachos class
    /// </summary>
    public class ChickenFajitaNachos : Nachos
    {
        /// <summary>
        /// The name of the chicken fajita nachos instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Chicken fajita nachos";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "Chicken fajitas but with chips";

        /// <summary>
        /// Constructor for nachos
        /// </summary>
        public ChickenFajitaNachos()
        {
            AdditionalIngredients = new Dictionary<Ingredient, IngredientItem>();
            AdditionalIngredients.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken));
            AdditionalIngredients.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            AdditionalIngredients.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            AdditionalIngredients.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            AdditionalIngredients.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));

            AdditionalIngredients[Ingredient.Chicken].Included = true;
            AdditionalIngredients[Ingredient.Veggies].Included = true;
            AdditionalIngredients[Ingredient.Queso].Included = true;
            AdditionalIngredients[Ingredient.Guacamole].Included = false;
            AdditionalIngredients[Ingredient.SourCream].Included = true;

            _salsaDefault = Salsa.Medium;
            SalsaType = Salsa.Medium;
        }

        /*
        /// <summary>
        /// Property holding the selected salsa type for nachos
        /// </summary>
        public Salsa SalsaSelection { get; set; } = Salsa.Medium;
        */

        
        /// <summary>
        /// price of this bowl
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 10.99m;
                if (AdditionalIngredients[Ingredient.Guacamole].Included) cost += 1.00m;

                return cost;
            }
        }
        
        //Calories and prep info here
        /*
        /// <summary>
        /// the total number of calories in this 
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 650;

                if (!Veggies) cals -= 20;
                if (!Queso) cals -= 110;
                if (!Chicken) cals -= 150;
                if (!SourCream) cals -= 100;
                if (SalsaSelection == Salsa.None) cals -= 20;
                if (Guacamole) cals += 150;

                return cals;
            }
        }
        */
        /// <summary>
        /// Information for the preparation of this
        /// </summary>
        public override IEnumerable<string> Instructions
        {
            get
            {
                List<string> instructions = new();

                if (!AdditionalIngredients[Ingredient.Veggies].Included) instructions.Add("Hold Veggies");
                if (!AdditionalIngredients[Ingredient.Queso].Included) instructions.Add("Hold Queso");
                if (!AdditionalIngredients[Ingredient.Chicken].Included) instructions.Add("Hold Chicken");
                if (!AdditionalIngredients[Ingredient.SourCream].Included) instructions.Add("Hold Sour Cream");
                if (SalsaType == Salsa.None) instructions.Add("Hold Salsa");
                else if (SalsaType != Salsa.Medium) instructions.Add($"Swap {SalsaType} Salsa");
                if (AdditionalIngredients[Ingredient.Guacamole].Included) instructions.Add("Add Guacamole");

                return instructions;
            }
        }
        
    }
}
