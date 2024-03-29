using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the Carnitas class
    /// </summary>
    public class CarnitasBowl : Bowl
    {
        
        /// <summary>
        /// The name of the carnitas bowl instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Carnitas Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "Rice bowl with carnitas and extras";
        
        /// <summary>
        /// Constructor for this bowl
        /// </summary>
        public CarnitasBowl() 
        {
            AdditionalIngredients.Clear();
            //AdditionalIngredients = new Dictionary<Ingredient, IngredientItem>();
            AdditionalIngredients.Add(Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas));
            AdditionalIngredients.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            AdditionalIngredients.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            AdditionalIngredients.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans));
            AdditionalIngredients.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            AdditionalIngredients.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));

            AdditionalIngredients[Ingredient.Carnitas].Included = true;
            AdditionalIngredients[Ingredient.Veggies].Included = false;
            AdditionalIngredients[Ingredient.Queso].Included = true;
            AdditionalIngredients[Ingredient.PintoBeans].Included = true;
            AdditionalIngredients[Ingredient.Guacamole].Included = false;
            AdditionalIngredients[Ingredient.SourCream].Included = false;

            _salsaDefault = Salsa.Medium;
            SalsaType = Salsa.Medium;

            foreach (IngredientItem ingredientItem in AdditionalIngredients.Values)
            {
                ingredientItem.PropertyChanged += HandleItemPropertyChanged;
            }
        }

        //Salsa here
        /*        
        /// <summary>
        /// Property giving the type of salsa currently in menu selection for the bowl
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
                decimal cost = 9.99m;
                if (AdditionalIngredients[Ingredient.Guacamole].Included) cost += 1.00m;

                return cost;
            }
        }
        
        //Calories here
        /*
        /// <summary>
        /// the total number of calories in this bowl
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 680;

                if (!Carnitas) cals -= 210;
                if (!Queso) cals -= 110;
                if (Veggies) cals += 20;
                if (SourCream) cals += 100;
                if (SalsaSelection == Salsa.None) cals -= 20;
                if (!PintoBeans) cals -= 130;
                if (Guacamole) cals += 150;

                return cals;
            }
        }
        */

        //Preparation Info here
        
        /// <summary>
        /// Information for the preparation of this bowl
        /// </summary>
        public override IEnumerable<string> Instructions
        {
            get
            {
                List<string> instructions = new();

                if (!AdditionalIngredients[Ingredient.Carnitas].Included) instructions.Add("Hold Carnitas");
                if (!AdditionalIngredients[Ingredient.Queso].Included) instructions.Add("Hold Queso");
                if (AdditionalIngredients[Ingredient.Veggies].Included) instructions.Add("Add Veggies");
                if (AdditionalIngredients[Ingredient.SourCream].Included) instructions.Add("Add Sour Cream");
                if (SalsaType == Salsa.None) instructions.Add("Hold Salsa");
                else if (SalsaType != Salsa.Medium) instructions.Add($"Swap {SalsaType} Salsa");
                if (!AdditionalIngredients[Ingredient.PintoBeans].Included) instructions.Add("Hold Pinto Beans");
                if (AdditionalIngredients[Ingredient.Guacamole].Included) instructions.Add("Add Guacamole");

                return instructions;
            }
        }
        

    }
}
