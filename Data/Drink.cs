using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Abstract class instance representing all 'Drink' menu items
    /// </summary>
    public abstract class Drink : IMenuItem
    {
        /// <summary>
        /// Abstract property that tracks the name of the drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Abstract property that tracks the description of the drink
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Protected field for the default size of drink
        /// </summary>
        protected Size _sizeDefault = Size.Kids;

        public Size SizeChoice { get; set; } = Size.Kids;

        /// <summary>
        /// Private backing field of the Price property
        /// </summary>
        private decimal _price = 2.50m;

        /// <summary>
        /// Virtual Property that tracKs the price of the side menu item
        /// </summary>
        public virtual decimal Price
        {
            get => _price;
            set => _price = value;
        }

        /// <summary>
        /// Property that tracks the calories of the side menu item
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Abstract property that tracks the preparation instructions of the side menu items
        /// </summary>
        public abstract IEnumerable<string> Instructions { get; }
    }
}
