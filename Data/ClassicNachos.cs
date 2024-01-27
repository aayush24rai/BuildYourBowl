using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the classic nachos class
    /// </summary>
    public class ClassicNachos
    {
        /// <summary>
        /// The name of the classic nachos instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Classic nachos";

        /// <summary>
        /// The description of this 
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Standard nachos with steak, chicken, and cheese";
        /// <summary>
        /// Whether this contains steak
        /// </summary>
        public bool Steak { get; set; } = true;
        /// <summary>
        /// Whether this  contains chicken
        /// </summary>
        public bool Chicken { get; set; } = true;
        /// <summary>
        /// Whether this  contains queso
        /// </summary>
        public bool Queso { get; set; } = true;
        /// <summary>
        /// Whether this  contains medium salsa
        /// </summary>
        public bool MediumSalsa { get; set; } = true;

        /// <summary>
        /// Whether this contains guacamole
        /// </summary>
        public bool Guacamole { get; set; } = false;
        /// <summary>
        /// Whether this  contains sour cream
        /// </summary>
        public bool SourCream { get; set; } = false;
        /// <summary>
        /// price of this 
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 12.99m;
                if (Guacamole) cost += 1.00m;

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
                uint cals = 710;

                if (!Steak) cals -= 180;
                if (!Queso) cals -= 110;
                if (!Chicken) cals -= 150;
                if (SourCream) cals += 100;
                if (!MediumSalsa) cals -= 20;
                if (Guacamole) cals += 150;

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

                if (!Steak) instructions.Add("Hold Steak");
                if (!Queso) instructions.Add("Hold Queso");
                if (!Chicken) instructions.Add("Hold Chicken");
                if (SourCream) instructions.Add("Add Sour Cream");
                if (!MediumSalsa) instructions.Add("Hold Medium Salsa");
                if (Guacamole) instructions.Add("Add Guacamole");

                return instructions;
            }
        }
    }
}
