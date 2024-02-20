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
    public class SlidersMeal : KidsMeal
    {
        /// <summary>
        /// The name of the Sliders Meal instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Sliders Kids Meal";

        /// <summary>
        /// The description of this meal
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "Sliders with side and drink";

        /// <summary>
        /// Whether the slider contains american cheese or not
        /// </summary>
        public bool AmericanCheese { get; set; } = true;

        /// <summary>
        /// Constructor for the sliders meal class
        /// </summary>
        public SlidersMeal() 
        {
            _count = 2;

            _drinkDefault.SizeChoice = Size.Kids;
            DrinkChoice.SizeChoice = Size.Kids;
            SideChoice.SizeChoice = Size.Kids;
        }


        /*
        /// <summary>
        /// Private backing field for the count property
        /// </summary>
        private uint _count = 2;
        */

        /// <summary>
        /// Number of sliders in the meal
        /// </summary>
        public override uint Count
        {
            get => _count;

            set
            {
                if (value <= 2) _count = 2;
                else if (value >= 4) _count = 4;
                else _count = value;
            }
        }

        /*
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
        */

        /// <summary>
        /// The price of this meal
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 5.99m;

                if (Count > 2) cost += 2.00m * (Count - 2);

                if (DrinkChoice.SizeChoice == Size.Small) cost += 0.50m;
                if (DrinkChoice.SizeChoice == Size.Medium) cost += 1.00m;
                if (DrinkChoice.SizeChoice == Size.Large) cost += 1.50m;

                if (SideChoice.SizeChoice == Size.Small) cost += 0.50m;
                if (SideChoice.SizeChoice == Size.Medium) cost += 1.00m;
                if (SideChoice.SizeChoice == Size.Large) cost += 1.50m;

                return cost;
            }
        }

        /// <summary>
        /// Calories in the meal
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (AmericanCheese) _defaultUnitCalories = 150 * Count;
                else _defaultUnitCalories = 110 * Count;

                _defaultUnitCalories += DrinkChoice.Calories;
                _defaultUnitCalories += SideChoice.Calories;

                return _defaultUnitCalories;
            }
        }

        /// <summary>
        /// Information for the preparation of the sliders Meal
        /// </summary>
        public override IEnumerable<string> Instructions
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
