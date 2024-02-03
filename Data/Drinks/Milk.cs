using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Drinks
{
    /// <summary>
    /// The definition of the milk class
    /// </summary>
    public class Milk
    {
        /// <summary>
        /// The name of the milk instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Milk";

        /// <summary>
        /// The description of this 
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Creamy beverage in plain or chocolate";

        /// <summary>
        /// Propoerty holding the selected size of fries
        /// </summary>
        public Size SizeSelection { get; } = Size.Kids;

        /// <summary>
        /// Whether milk is in chocolate flavor or not
        /// </summary>
        public bool Chocolate { get; set; } = false;

        /// <summary>
        /// price of this bowl
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 2.50m;
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
                uint cals = 200;

                if (Chocolate) cals += 70;

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

                if (Chocolate) instructions.Add("Chocolate");

                return instructions;
            }
        }
    }
}
