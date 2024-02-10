﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Drinks
{
    /// <summary>
    /// The defintion of the Agua fresca class
    /// </summary>
    public class AguaFresca
    {
        /// <summary>
        /// The name of the agua fresca instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Agua Fresca";

        /// <summary>
        /// The description of the drink
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Refreshing lightly sweetened fruit drink";

        /// <summary>
        /// Propoerty holding the current selection for the flavor of the agua fresca
        /// </summary>
        public Flavor DrinkFlavor { get; set; } = Flavor.Limonada;

        /// <summary>
        /// Propoerty holding the current selection of size for the agua fresca
        /// </summary>
        public Size DrinkSize { get; set; } = Size.Medium;

        /// <summary>
        /// Whether the agua fresca contains ice or not
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// the price of the agua fresca drink
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 0.00m;

                if (DrinkSize == Size.Kids) cost = 2.00m;
                if (DrinkSize == Size.Small) cost = 2.50m;
                if (DrinkSize == Size.Medium) cost = 3.00m;
                if (DrinkSize == Size.Large) cost = 3.75m;
                if (DrinkFlavor == Flavor.Tamarind) cost += 0.50m;

                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in the agua fresca
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 0;

                if (DrinkFlavor == Flavor.Limonada || DrinkFlavor == Flavor.Lime) cals = 125;
                if (DrinkFlavor == Flavor.Tamarind || DrinkFlavor == Flavor.Strawberry) cals = 150;
                if (DrinkFlavor == Flavor.Cucumber) cals = 75;

                if (!Ice) cals += 10;

                if (DrinkSize == Size.Kids) cals = (uint)(cals * 0.60);
                if (DrinkSize == Size.Small) cals = (uint)(cals * 0.75);
                if (DrinkSize == Size.Large) cals = (uint)(cals * 1.50);

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of the agua fresca
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                instructions.Add($"{DrinkSize}");
                instructions.Add($"{DrinkFlavor}");
                if (!Ice) instructions.Add("Hold Ice");

                return instructions;

            }
        }
    }
}
