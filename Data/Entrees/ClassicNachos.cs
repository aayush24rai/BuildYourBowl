using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the classic nachos class
    /// </summary>
    public class ClassicNachos : Nachos
    {
        /// <summary>
        /// The name of the classic nachos instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Classic nachos";

        /// <summary>
        /// The description of this 
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "Standard nachos with steak, chicken, and cheese";
        
        /// <summary>
        /// Constructor for nachos
        /// </summary>
        public ClassicNachos()
        {
            AdditionalIngredients.Clear();
            //AdditionalIngredients = new Dictionary<Ingredient, IngredientItem>();
            AdditionalIngredients.Add(Ingredient.Steak, new IngredientItem(Ingredient.Steak));
            AdditionalIngredients.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken));
            AdditionalIngredients.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            AdditionalIngredients.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            AdditionalIngredients.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));

            AdditionalIngredients[Ingredient.Steak].Included = true;
            AdditionalIngredients[Ingredient.Chicken].Included = true;
            AdditionalIngredients[Ingredient.Queso].Included = true;
            AdditionalIngredients[Ingredient.Guacamole].Included = false;
            AdditionalIngredients[Ingredient.SourCream].Included = false;

            _salsaDefault = Salsa.Medium;
            SalsaType = Salsa.Medium;

            foreach (IngredientItem ingredientItem in AdditionalIngredients.Values)
            {
                ingredientItem.PropertyChanged += HandleItemPropertyChanged;
            }
        }

        /*
        /// <summary>
        /// Propoerty holding the selected salsa for nachos
        /// </summary>
        public Salsa SalsaSelection { get; set; } = Salsa.Medium;
        */

 
        /// <summary>
        /// price of this 
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 12.99m;
                if (AdditionalIngredients[Ingredient.Guacamole].Included) cost += 1.00m;

                return cost;
            }
        }
        
        //Calories and Prep info here
        /*
        /// <summary>
        /// the total number of calories in this bowl
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 710;

                if (!Steak) cals -= 180;
                if (!Queso) cals -= 110;
                if (!Chicken) cals -= 150;
                if (SourCream) cals += 100;
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

                if (!AdditionalIngredients[Ingredient.Steak].Included) instructions.Add("Hold Steak");
                if (!AdditionalIngredients[Ingredient.Queso].Included) instructions.Add("Hold Queso");
                if (!AdditionalIngredients[Ingredient.Chicken].Included) instructions.Add("Hold Chicken");
                if (AdditionalIngredients[Ingredient.SourCream].Included) instructions.Add("Add Sour Cream");
                if (AdditionalIngredients[Ingredient.Guacamole].Included) instructions.Add("Add Guacamole");
                if (SalsaType == Salsa.None) instructions.Add("Hold Salsa");
                else if (SalsaType != Salsa.Medium) instructions.Add($"Swap {SalsaType} Salsa");
                return instructions;
            }
        }
        
    }
}
