using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Sides
{
    /// <summary>
    /// The definition of the fries class
    /// </summary>
    public class Fries
    {
        /// <summary>
        /// The name of the fries instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Fries";

        /// <summary>
        /// The description of this
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Crispy salty sticks of deliciousness";

        /// <summary>
        /// Propoerty holding the selected size of fries
        /// </summary>
        public Size SizeSelection { get; set; } = Size.Medium;

        /// <summary>
        /// Whether fries are curly or not
        /// </summary>
        public bool Curly { get; set; } = false;

        /// <summary>
        /// price of this bowl
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 3.50m;

                if (SizeSelection == Size.Kids) cost -= 1.00m;
                if (SizeSelection == Size.Small) cost -= 0.50m;
                if (SizeSelection == Size.Large) cost += 0.75m;

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
                uint cals = 350;

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

                if (Curly) instructions.Add("Add Curly");

                return instructions;
            }
        }
    }
}
