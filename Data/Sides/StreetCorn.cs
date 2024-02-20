using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Sides
{
    /// <summary>
    /// The definition of the street corn class
    /// </summary>
    public class StreetCorn : Side
    {
        /// <summary>
        /// The name of the street corn instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Street Corn";

        /// <summary>
        /// The description of this
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "The zestiest corn out there";

        /// <summary>
        /// Constructor for this side
        /// </summary>
        public StreetCorn()
        {
            AdditionalIngredients = new Dictionary<Ingredient, IngredientItem>();
            AdditionalIngredients.Add(Ingredient.CotijaCheese, new IngredientItem(Ingredient.CotijaCheese));
            AdditionalIngredients.Add(Ingredient.Cilantro, new IngredientItem(Ingredient.Cilantro));

            AdditionalIngredients[Ingredient.CotijaCheese].Included = true;
            AdditionalIngredients[Ingredient.Cilantro].Included = true;

            _sizeDefault = Size.Medium;
            SizeChoice = Size.Medium;

            Price = 4.50m;

            if (!AdditionalIngredients[Ingredient.CotijaCheese].Included) Calories -= 80;
            if (!AdditionalIngredients[Ingredient.Cilantro].Included) Calories -= 5;
        }

        //Old size price cals and prep info
        /*
        /// <summary>
        /// Propoerty holding the selected size of fries
        /// </summary>
        public Size SizeSelection { get; set; } = Size.Medium;

        /// <summary>
        /// Whether this contains cotija cheese
        /// </summary>
        public bool CotijaCheese { get; set; } = true;

        /// <summary>
        /// Whether this contains cilantro
        /// </summary>
        public bool Cilantro { get; set; } = true;

        */
        /// <summary>
        /// price of this bowl
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 4.50m;

                if (SizeChoice == Size.Kids) cost -= 1.25m;
                if (SizeChoice == Size.Small) cost -= 0.75m;
                if (SizeChoice == Size.Large) cost += 1.00m;

                return cost;
            }
        }
        
        /// <summary>
        /// the total number of calories in this bowl
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 300;

                if (!AdditionalIngredients[Ingredient.CotijaCheese].Included) cals -= 80;
                if (!AdditionalIngredients[Ingredient.Cilantro].Included) cals -= 5;

                if (SizeChoice == Size.Kids) cals = (uint)(0.60 * cals);
                if (SizeChoice == Size.Small) cals = (uint)(0.75 * cals);
                if (SizeChoice == Size.Large) cals = (uint)(1.50 * cals);

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

                instructions.Add($"{SizeChoice}");

                if (!AdditionalIngredients[Ingredient.CotijaCheese].Included) instructions.Add("Hold Cotija Cheese");
                if (!AdditionalIngredients[Ingredient.Cilantro].Included) instructions.Add("Hold Cilantro");

                return instructions;
            }
        }
        
    }
}
