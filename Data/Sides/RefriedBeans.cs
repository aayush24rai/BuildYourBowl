using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Sides
{
    /// <summary>
    /// The definition of the Refried Beans class
    /// </summary>
    public class RefriedBeans : Side
    {
        /// <summary>
        /// The name of the refried beans instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Refried Beans";

        /// <summary>
        /// The description of this 
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "Beans fried not just once but twice";

        /// <summary>
        /// Constructor for this side
        /// </summary>
        public RefriedBeans()
        {
            AdditionalIngredients = new Dictionary<Ingredient, IngredientItem>();
            AdditionalIngredients.Add(Ingredient.Onions, new IngredientItem(Ingredient.Onions));
            AdditionalIngredients.Add(Ingredient.CheddarCheese, new IngredientItem(Ingredient.CheddarCheese));

            AdditionalIngredients[Ingredient.Onions].Included = true;
            AdditionalIngredients[Ingredient.CheddarCheese].Included = true;

            _sizeDefault = Size.Medium;
            SizeChoice = Size.Medium;

            ///Price = 3.75m;


            ///if (!AdditionalIngredients[Ingredient.Onions].Included) _calories -= 5;
            ///if (!AdditionalIngredients[Ingredient.CheddarCheese].Included) _calories -= 90;
        }

        /// <summary>
        /// price of this bowl
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 3.75m;

                if (SizeChoice == Size.Kids) cost -= 1.00m;
                if (SizeChoice == Size.Small) cost -= 0.50m;
                if (SizeChoice == Size.Large) cost += 0.75m;

                return cost;
            }
        }

        //Old size selection price cals and prep info
        /*
        
        /// <summary>
        /// Propoerty holding the selected size of beans
        /// </summary>
        public Size SizeSelection { get; set; } = Size.Medium;
        
        
        */
        /// <summary>
        /// the total number of calories in this
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 300;

                if (!AdditionalIngredients[Ingredient.Onions].Included) cals -= 5;
                if (!AdditionalIngredients[Ingredient.CheddarCheese].Included) cals -= 90;

                if (SizeChoice == Size.Kids) cals = (uint)(0.60 * cals);
                if (SizeChoice == Size.Small) cals = (uint)(0.75 * cals);
                if (SizeChoice == Size.Large) cals = (uint)(1.50 * cals);

                return cals;
            }
        }
        

        /// <summary>
        /// Information for the preparation of this
        /// </summary>
        public override IEnumerable<string> Instructions
        {
            get
            {
                List<string> instructions = new();

                instructions.Add($"{SizeChoice}");


                if (!AdditionalIngredients[Ingredient.Onions].Included) instructions.Add("Hold Onions");
                if (!AdditionalIngredients[Ingredient.CheddarCheese].Included) instructions.Add("Hold Cheddar Cheese");

                return instructions;
            }
        }
        
    }
}
