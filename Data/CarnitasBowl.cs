using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the Carnitas class
    /// </summary>
    public class CarnitasBowl
    {
        /// <summary>
        /// The name of the carnitas bowl instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Carnitas Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description { get; } = "Rice bowl with carnitas and extras";
        /// <summary>
        /// Whether this bowl contains carnitas
        /// </summary>
        public bool Carnitas { get; set; } = true;
        /// <summary>
        /// Whether this bowl contains veggies
        /// </summary>
        public bool Veggies { get; set; } = false;
        /// <summary>
        /// Whether this bowl contains queso
        /// </summary>
        public bool Queso { get; set; } = true;
        /// <summary>
        /// Whether this bowl contains pinto beans
        /// </summary>
        public bool PintoBeans { get; set; } = true;
        /// <summary>
        /// Whether this bowl contains medium salsa
        /// </summary>
        public bool MediumSalsa { get; set; } = true;
        /// <summary>
        /// Whether this bowl contains guacamole
        /// </summary>
        public bool Guacamole { get; set; } = false;
        /// <summary>
        /// Whether this bowl contains sour cream
        /// </summary>
        public bool SourCream { get; set; } = false;
        /// <summary>
        /// price of this bowl
        /// </summary>
        public decimal Price
        { 
            get
            {
                decimal cost = 9.99m;
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
                uint cals = 680;

                if (!Carnitas) cals -= 210;
                if (!Queso) cals -= 110;
                if (Veggies) cals += 20;
                if (SourCream) cals += 100;
                if (!MediumSalsa) cals -= 20;
                if (!PintoBeans) cals -= 130;
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

                if (!Carnitas) instructions.Add("Hold Carnitas");
                if (!Queso) instructions.Add("Hold Queso");
                if (Veggies) instructions.Add("Add Veggies");
                if (SourCream) instructions.Add("Add Sour Cream");
                if (!MediumSalsa) instructions.Add("Hold Medium Salsa");
                if (!PintoBeans) instructions.Add("Hold Pinto Beans");
                if (Guacamole) instructions.Add("Add Guacamole");

                return instructions;
            }
        }


    }
}
