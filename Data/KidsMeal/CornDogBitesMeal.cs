﻿using System;
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
    /// The defintion if the corn dog bites meal instance
    /// </summary>
    public class CornDogBitesMeal : KidsMeal
    {
        /// <summary>
        /// The name of the corn dogs bites meal instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Corn Dog Bites Kids Meal";

        /// <summary>
        /// The description of this meal
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "Mini corn dogs with side and drink";

        /// <summary>
        /// Constructor for the chicken nuggets meal
        /// </summary>
        public CornDogBitesMeal()
        {
            _count = 5;
            Count = 5;
            _drinkDefault.SizeChoice = Size.Kids;
            DrinkChoice.SizeChoice = Size.Kids;
            SideChoice.SizeChoice = Size.Kids;
        }

        /*
        /// <summary>
        /// Private backing field for the count property
        /// </summary>
        private uint _count = 5;

        /// <summary>
        /// Number of corn dog bites in the meal
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
        private Fries _sideChoice = new Fries { SizeSelection = Size.Kids };

        /// <summary>
        /// the choice of side
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

                if (Count > 5) cost += 0.75m * (Count - 5);

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
                uint cals = 50 * Count;

                cals += DrinkChoice.Calories;
                cals += SideChoice.Calories;

                return cals;
            }
        }
        */

        /// <summary>
        /// Information for the preparation of the corn dog bites meal
        /// </summary>
        public override IEnumerable<string> Instructions
        {
            get
            {
                List<string> instructions = new();

                if (Count != 5) instructions.Add($"{Count} Bites");

                return instructions;
            }
        }
    }
}
