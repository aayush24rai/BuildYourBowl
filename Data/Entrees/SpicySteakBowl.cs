using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the Spicy steak bowl class
    /// </summary>
    public class SpicySteakBowl
    {
        /// <summary>
        /// The name of the spicy steak bowl instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Spicy steak Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Spicy rice bowl with steak and fajita toppings";
        /// <summary>
        /// Whether this bowl contains steak
        /// </summary>
        public bool Steak { get; set; } = true;
        /// <summary>
        /// Whether this bowl contains veggies
        /// </summary>
        public bool Veggies { get; set; } = false;
        /// <summary>
        /// Whether this bowl contains queso
        /// </summary>
        public bool Queso { get; set; } = true;
        /// <summary>
        /// Property holding the selected salsa in this bowl
        /// </summary>
        public Salsa SalsaSelection { get; set; } = Salsa.Hot;

        /// <summary>
        /// Whether this bowl contains guacamole
        /// </summary>
        public bool Guacamole { get; set; } = false;
        /// <summary>
        /// Whether this bowl contains sour cream
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
        /// the total number of calories in this bowl
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 620;

                if (!Steak) cals -= 180;
                if (!Queso) cals -= 110;
                if (Veggies) cals += 20;
                if (!SourCream) cals -= 100;
                if (SalsaSelection == Salsa.None) cals -= 20;
                if (Guacamole) cals += 150;

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

                if (!Steak) instructions.Add("Hold Steak");
                if (!Queso) instructions.Add("Hold Queso");
                if (Veggies) instructions.Add("Add Veggies");
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (SalsaSelection != Salsa.Hot) instructions.Add($"Swap {SalsaSelection} Salsa");
                else if (SalsaSelection == Salsa.None) instructions.Add("Hold Salsa");
                if (Guacamole) instructions.Add("Add Guacamole");

                return instructions;
            }
        }


    }
}
