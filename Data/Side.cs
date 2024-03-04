using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Abstract class instance representing all 'Side' menu items
    /// </summary>
    public abstract class Side : IMenuItem
    {
        /// <summary>
        /// Abstract property that tracks the name of the side
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Abstract property that tracks the description of the side
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Protected field for the default size of side
        /// </summary>
        protected Size _sizeDefault = Size.Kids;

        public Size SizeChoice { get; set; } = Size.Kids;

        /// <summary>
        /// Private backing field of the Price property
        /// </summary>
        private decimal _price = 3.50m;

        /// <summary>
        /// Virtual Property that traccjs the price of the side menu item
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                if (SizeChoice == Size.Kids) _price -= 1.00m;
                if (SizeChoice == Size.Small) _price -= 0.50m;
                if (SizeChoice == Size.Large) _price += 0.75m;

                return _price;
            }

            set => _price = value;
        }

        /// <summary>
        /// Private backing field of the calories in the side
        /// </summary>
        protected uint _calories = 300;

        /// <summary>
        /// Property that tracks the calories of the side menu item
        /// </summary>
        public virtual uint Calories
        {
            get
            {
                if (SizeChoice == Size.Kids) _calories = (uint)(0.60 * _calories);
                if (SizeChoice == Size.Small) _calories = (uint)(0.75 * _calories);
                if (SizeChoice == Size.Large) _calories = (uint)(1.50 * _calories);

                return _calories;
            }

            set => _calories = value;
        }

        /// <summary>
        /// Abstract property that tracks the additional ingredients in the side menu item
        /// </summary>
        public virtual Dictionary<Ingredient, IngredientItem> AdditionalIngredients { get; set; } = new();

        /// <summary>
        /// Virtual property that tracks the preparation instructions of the side menu items
        /// </summary>
        public virtual IEnumerable<string> Instructions
        {
            get
            {

                List<string> instructions = new();

                instructions.Add($"{SizeChoice}");

                foreach (IngredientItem ingredient in AdditionalIngredients.Values)
                {
                    if (ingredient.Included) instructions.Add($"Add {ingredient.Name}");
                }

                return instructions;
            }
        }

        /// <summary>
        /// Method to override the default ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
