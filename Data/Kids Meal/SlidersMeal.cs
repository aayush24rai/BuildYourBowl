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
    /// The definition of the Sliders Meal instance
    /// </summary>
    public class SlidersMeal
    {
        /// <summary>
        /// The name of the Sliders Meal instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Sliders Kids Meal";

        /// <summary>
        /// The description of this meal
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Sliders with side and drink";

        /// <summary>
        /// Private backing field for the count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// Number of sliders in the meal
        /// </summary>
        public uint Count
        {
            get => _count;

            set
            {
                if (value <= 2) _count = 2;
                else if (value >= 4) _count = 4;
                else _count = value;
            }
        }

        /// <summary>
        /// Whether the slider contains american cheese or not
        /// </summary>
        public bool AmericanCheese { get; set; } = true;

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
        private Fries _sideChoice = new Fries { SizeSelection = Size.Kids };

        /// <summary>
        /// the side choice of the sliders meal
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

                if (Count > 2) cost += 2.00m * (Count - 2);

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
                uint cals = 150 * Count;

                if (!AmericanCheese) cals -= 40;

                cals += DrinkChoice.Calories;
                cals += SideChoice.Calories;

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of the sliders Meal
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Count != 2) instructions.Add($"{Count} Sliders");
                if (!AmericanCheese) instructions.Add($"Hold American Cheese");

                return instructions;
            }
        }

    }
}
