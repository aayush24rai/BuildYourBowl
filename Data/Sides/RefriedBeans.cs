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
    public class RefriedBeans
    {
        /// <summary>
        /// The name of the refried beans instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Refried Beans";

        /// <summary>
        /// The description of this 
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Beans fried not just once but twice";
        /// <summary>
        /// Propoerty holding the selected size of beans
        /// </summary>
        public Size SizeSelection { get; set; } = Size.Medium;
        /// <summary>
        /// Whether this contains onions
        /// </summary>
        public bool Onions { get; set; } = true;
        /// <summary>
        /// Whether this contains cheddar cheese
        /// </summary>
        public bool CheddarCheese { get; set; } = true;


        /// <summary>
        /// price of this bowl
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 3.75m;

                if (SizeSelection == Size.Kids) cost -= 1.00m;
                if (SizeSelection == Size.Small) cost -= 0.50m;
                if (SizeSelection == Size.Large) cost += 0.75m;

                return cost;
            }
        }
        /// <summary>
        /// the total number of calories in this
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 300;

                if (!Onions) cals -= 5;
                if (!CheddarCheese) cals -= 90;

                if (SizeSelection == Size.Kids) cals = (uint)(0.60 * cals);
                if (SizeSelection == Size.Small) cals = (uint)(0.75 * cals);
                if (SizeSelection == Size.Large) cals = (uint)(1.50 * cals);

                return cals;
            }
        }
        /// <summary>
        /// Information for the preparation of this
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                instructions.Add($"{SizeSelection}");


                if (!Onions) instructions.Add("Hold Onions");
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");

                return instructions;
            }
        }
    }
}
