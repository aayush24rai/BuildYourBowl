using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Enums;


namespace BuildYourBowl.Data
{
    /// <summary>
    /// Abstract class instance of the 'kids meal' menu item
    /// </summary>
    public abstract class KidsMeal : IMenuItem
    {
        /// <summary>
        /// Abstract property that tracks the name of the meal
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Abstract property that tracks the description of the meal
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Private backing field of the Count 
        /// </summary>
        protected uint _count = 5;
        
        /// <summary>
        /// Virtual property tracking the count of items in the meal
        /// </summary>
        public virtual uint Count
        {
            get => _count;
            set
            {
                if (value <= 5) _count = 5;
                else if (value >= 8) _count = 8;
                else _count = value;
            }
        }

        /// <summary>
        /// Private backing field of the drink with the meal
        /// </summary>
        protected Drink _drinkDefault = new Milk();
        
        /// <summary>
        /// Choice of drink with the meal
        /// </summary>
        public Drink DrinkChoice
        {
            get => _drinkDefault;
            set => _drinkDefault = value;
        }

        /// <summary>
        /// Private backing field of the side with the meal
        /// </summary>
        private Side _sideDefault = new Fries();
        
        /// <summary>
        /// Choice of side with the meal
        /// </summary>
        public Side SideChoice
        {
            get => _sideDefault;
            set => _sideDefault = value;
        }

        /// <summary>
        /// Private backing field of the Price property
        /// </summary>
        private decimal _priceDefault = 5.99m;

        /// <summary>
        /// Virtual Property that tracKs the price of the meal
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                if (Count > 5) _priceDefault += (0.75m * (Count - 5));

                if (DrinkChoice.SizeChoice == Size.Small) _priceDefault += 0.50m;
                if (DrinkChoice.SizeChoice == Size.Medium) _priceDefault += 1.00m;
                if (DrinkChoice.SizeChoice == Size.Large) _priceDefault += 1.50m;

                if (SideChoice.SizeChoice == Size.Small) _priceDefault += 0.50m;
                if (SideChoice.SizeChoice == Size.Medium) _priceDefault += 1.00m;
                if (SideChoice.SizeChoice == Size.Large) _priceDefault += 1.50m;

                return _priceDefault;
            }
        }

        /// <summary>
        /// Private backing field of calories property
        /// </summary>
        protected uint _defaultUnitCalories = 50;
        
        /// <summary>
        /// Property tracking the calories in the meal
        /// </summary>
        public virtual uint Calories
        {
            get
            {
                _defaultUnitCalories *= Count;

                _defaultUnitCalories += DrinkChoice.Calories;
                _defaultUnitCalories += SideChoice.Calories;

                return _defaultUnitCalories;
            }
        }

        /// <summary>
        /// Abstract property that tracks the preparation instructions of the side menu items
        /// </summary>
        public abstract IEnumerable<string> Instructions { get; }

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
