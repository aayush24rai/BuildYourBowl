using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Sides;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the chicken nuggets meal instance
    /// </summary>
    public class ChickenNuggetsMeal
    {
        /// <summary>
        /// The name of the chicken nuggets meal
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Chicken Nuggets Kids Meal";

        /// <summary>
        /// The description of the nuggets meal
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Chicken nuggets with side and drink";

        /// <summary>
        /// Private backing field for the count property
        /// </summary>
        private uint _count = 5;
        
        /// <summary>
        /// Number of chicken nuggets in the meal
        /// </summary>
        public uint Count
        {
            get => _count;

            set
            {
                if (value <= 5) _count = 5;
                else if (value >= 8) _count = 8;
                else _count = value;
            }
        }

        /// <summary>
        /// Private backing field for the choice of drink propeorty
        /// </summary>
        private Milk _drinkChoice = new Milk();

        /// <summary>
        /// The choice of drink (milk)
        /// </summary>
        public Milk DrinkChoice
        {
            get => _drinkChoice;
            set => _drinkChoice = value;
        }

        /// <summary>
        /// private backing field for the side choice property
        /// </summary>
        private Fries _sideChoice = new Fries { SizeSelection = Size.Kids};        

        /// <summary>
        /// the side choice of the chicken nuggets meal
        /// </summary>  
        public Fries SideChoice
        {
            get => _sideChoice;
            set => _sideChoice = value;
        }

        /// <summary>
        /// The price of this meal
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 5.99m;

                if (Count > 5) cost += (0.75m * (Count - 5));

                if (DrinkChoice.SizeSelection == Size.Small) cost += 0.50m;
                if (DrinkChoice.SizeSelection == Size.Medium) cost += 1.00m;
                if (DrinkChoice.SizeSelection == Size.Large) cost += 1.50m;

                if (SideChoice.SizeSelection == Size.Small) cost += 0.50m;
                if (SideChoice.SizeSelection == Size.Medium) cost += 1.00m;
                if (SideChoice.SizeSelection == Size.Large) cost += 1.50m;

                return cost;
            }
        }

        /// <summary>
        /// Calories in the meal
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 60 * Count;

                cals += DrinkChoice.Calories;
                cals += SideChoice.Calories;

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of the Chicken Nuggets Meal
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Count != 5) instructions.Add($"{Count} Nuggets");

                return instructions;
            }
        }
    }
}
