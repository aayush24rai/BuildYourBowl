using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Sides
{
    /// <summary>
    /// The definition of the Chicken Fajita Nachos class
    /// </summary>
    public class ChickenFajitaNachos
    {
        /// <summary>
        /// The name of the chicken fajita nachos instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Chicken fajita nachos";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Chicken fajitas but with chips";
        /// <summary>
        /// Whether this contains veggies
        /// </summary>
        public bool Veggies { get; set; } = true;
        /// <summary>
        /// Whether this contains chicken
        /// </summary>
        public bool Chicken { get; set; } = true;
        /// <summary>
        /// Whether this contains queso
        /// </summary>
        public bool Queso { get; set; } = true;

        /// <summary>
        /// Property holding the selected salsa type for nachos
        /// </summary>
        public Salsa SalsaSelection { get; set; } = Salsa.Medium;

        /// <summary>
        /// Whether this contains guacamole
        /// </summary>
        public bool Guacamole { get; set; } = false;
        /// <summary>
        /// Whether this contains sour cream
        /// </summary>
        public bool SourCream { get; set; } = true;
        /// <summary>
        /// price of this bowl
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 10.99m;
                if (Guacamole) cost += 1.00m;

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
                uint cals = 650;

                if (!Veggies) cals -= 20;
                if (!Queso) cals -= 110;
                if (!Chicken) cals -= 150;
                if (!SourCream) cals -= 100;
                if (SalsaSelection == Salsa.None) cals -= 20;
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

                if (!Veggies) instructions.Add("Hold Veggies");
                if (!Queso) instructions.Add("Hold Queso");
                if (!Chicken) instructions.Add("Hold Chicken");
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (SalsaSelection == Salsa.None) instructions.Add("Hold Salsa");
                else if (SalsaSelection != Salsa.Medium) instructions.Add($"Swap {SalsaSelection} Salsa");
                if (Guacamole) instructions.Add("Add Guacamole");

                return instructions;
            }
        }
    }
}
