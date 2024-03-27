using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Drinks
{
    /// <summary>
    /// The definition of the horchata class
    /// </summary>
    public class Horchata : Drink
    {
        /// <summary>
        /// The name of the horchata instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Horchata";

        /// <summary>
        /// The description of this drink
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description { get; } = "Milky drink with cinnamon";

        /// <summary>
        /// Constructor for the Horchata class
        /// </summary>
        public Horchata() 
        {
            _sizeDefault = Size.Medium;
            SizeChoice = Size.Medium;
        }

        /*
        /// <summary>
        /// Propoerty holding the selected size of fries
        /// </summary>
        public Size SizeSelection { get; set; } = Size.Medium;
        */

        private bool _ice = true;

        /// <summary>
        /// Whether there is ice or not
        /// </summary>
        public bool Ice
        {
            get => _ice;
            set
            {
                _ice = value;
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Instructions));
            }
        }

        /// <summary>
        /// price of this drink
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 3.50m;

                if (SizeChoice == Size.Kids) cost -= 1.00m;
                if (SizeChoice == Size.Small) cost -= 0.50m;
                if (SizeChoice == Size.Large) cost += 0.75m;

                return cost;
            }
        }

        /// <summary>
        /// the total number of calories in this drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 280;

                if (!Ice) cals -= 30;

                if (SizeChoice == Size.Kids) cals = (uint)(0.60 * cals);
                if (SizeChoice == Size.Small) cals = (uint)(0.75 * cals);
                if (SizeChoice == Size.Large) cals = (uint)(1.50 * cals);

                return cals;
            }
        }
        /// <summary>
        /// Information for the preparation of this drink
        /// </summary>
        public override IEnumerable<string> Instructions
        {
            get
            {
                List<string> instructions = new();

                instructions.Add($"{SizeChoice}");

                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }

    }
}
