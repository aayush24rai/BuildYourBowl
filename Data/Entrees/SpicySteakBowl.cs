using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the Spicy steak bowl class
    /// </summary>
    public class SpicySteakBowl : Bowl
    {
        /// <summary>
        /// The name of the spicy steak bowl instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Spicy steak bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "Spicy rice bowl with steak and fajita toppings";

        /// <summary>
        /// Constructor for this bowl
        /// </summary>
        public SpicySteakBowl()
        {
            AdditionalIngredients.Clear();
            //AdditionalIngredients = new Dictionary<Ingredient, IngredientItem>();
            AdditionalIngredients.Add(Ingredient.Steak, new IngredientItem(Ingredient.Steak));
            AdditionalIngredients.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            AdditionalIngredients.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            AdditionalIngredients.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans));
            AdditionalIngredients.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            AdditionalIngredients.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));

            AdditionalIngredients[Ingredient.Steak].Included = true;
            AdditionalIngredients[Ingredient.Veggies].Included = false;
            AdditionalIngredients[Ingredient.Queso].Included = true;
            AdditionalIngredients[Ingredient.PintoBeans].Included = true;
            AdditionalIngredients[Ingredient.Guacamole].Included = false;
            AdditionalIngredients[Ingredient.SourCream].Included = true;

            _salsaDefault = Salsa.Hot;
            SalsaType = Salsa.Hot;

            foreach (IngredientItem ingredientItem in AdditionalIngredients.Values)
            {
                ingredientItem.PropertyChanged += HandleItemPropertyChanged;
            }
        }

        /*
        /// <summary>
        /// Property holding the selected salsa in this bowl
        /// </summary>
        public Salsa SalsaSelection { get; set; } = Salsa.Hot;
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
        
        //Calories and Prep info here
        
        /// <summary>
        /// the total number of calories in this bowl
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 620;

                if (!AdditionalIngredients[Ingredient.Steak].Included) cals -= 180;
                if (!AdditionalIngredients[Ingredient.Queso].Included) cals -= 110;
                if (AdditionalIngredients[Ingredient.Veggies].Included) cals += 20;
                if (!AdditionalIngredients[Ingredient.SourCream].Included) cals -= 100;
                if (SalsaType == Salsa.None) cals -= 20;
                if (AdditionalIngredients[Ingredient.Guacamole].Included) cals += 150;

                return cals;
            }
        }
        

        /// <summary>
        /// Information for the preparation of this bowl
        /// </summary>
        public override IEnumerable<string> Instructions
        {
            get
            {
                List<string> instructions = new();

                if (!AdditionalIngredients[Ingredient.Steak].Included) instructions.Add("Hold Steak");
                if (!AdditionalIngredients[Ingredient.Queso].Included) instructions.Add("Hold Queso");
                if (AdditionalIngredients[Ingredient.Veggies].Included) instructions.Add("Add Veggies");
                if (!AdditionalIngredients[Ingredient.SourCream].Included) instructions.Add("Hold Sour Cream");
                if (SalsaType == Salsa.None) instructions.Add("Hold Salsa");
                else if (SalsaType != Salsa.Hot) instructions.Add($"Swap {SalsaType} Salsa");
                if (AdditionalIngredients[Ingredient.Guacamole].Included) instructions.Add("Add Guacamole");

                return instructions;
            }
        }
        
    }
}
