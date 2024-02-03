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
    public class StreetCorn
    {
        /// <summary>
        /// The name of the street corn instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Street Corn";

        /// <summary>
        /// The description of this
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "The zestiest corn out there";

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


        /// <summary>
        /// price of this bowl
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 4.50m;

                if (SizeSelection == Size.Kids) cost -= 1.25m;
                if (SizeSelection == Size.Small) cost -= 0.75m;
                if (SizeSelection == Size.Large) cost += 1.00m;

                return cost;
            }
        }
        /// <summary>
        /// the total number of calories in this bowl
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 300;

                if (!CotijaCheese) cals -= 80;
                if (!Cilantro) cals -= 5;

                if (SizeSelection == Size.Kids) cals = (uint)(0.60 * cals);
                if (SizeSelection == Size.Small) cals = (uint)(0.75 * cals);
                if (SizeSelection == Size.Large) cals = (uint)(1.50 * cals);

                return cals;
            }
        }
        /// <summary>
        /// Information for the preparation of this bowl
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                instructions.Add($"{SizeSelection}");

                if (!CotijaCheese) instructions.Add("Hold Cotija Cheese");
                if (!Cilantro) instructions.Add("Hold Cilantro");

                return instructions;
            }
        }
    }
}
