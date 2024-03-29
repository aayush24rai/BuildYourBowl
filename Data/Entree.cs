using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    
    /// <summary>
    /// Abstract class instance representing all 'entree' menu items
    /// </summary>
    public abstract class Entree : IMenuItem
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void HandleItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Instructions)));
        }

        public Entree()
        {
            foreach (IngredientItem ingredientItem in AdditionalIngredients.Values)
            {
                ingredientItem.PropertyChanged += HandleItemPropertyChanged;
            }
        }

        /// <summary>
        /// Abstract property that tracks the name of the entree menu item
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Abstract property that tracks the description of the entree menu item
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// private backing field of the Price property
        /// </summary>
        private decimal _price = 7.99m;

        /// <summary>
        /// Virtual property that tracks the price of the entree menu item
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                decimal priceIngredients = 0.00m;
                foreach (IngredientItem ingredient in AdditionalIngredients.Values)
                {
                    if (ingredient.Included) priceIngredients += ingredient.UnitCost;
                }
                return _price + priceIngredients;
            }

            set => _price = value;
        }
        
        /// <summary>
        /// Property that tracks the calories of the entree menu item
        /// </summary>
        public virtual uint Calories
        {
            get
            {
                uint caloriesIngredients = 0;
                foreach (IngredientItem ingredient in AdditionalIngredients.Values)
                {
                    if (ingredient.Included) caloriesIngredients += ingredient.Calories;
                }
                if (SalsaType != Salsa.None) caloriesIngredients += 20;
                return BaseIngredient.Calories + caloriesIngredients;
            }
        }

        /// <summary>
        /// Property that tracks the preparation instructions of the entree menu item
        /// </summary>
        public virtual IEnumerable<string> Instructions
        {
            get
            {
                List<string> instructions = new();
                foreach (IngredientItem ingredient in AdditionalIngredients.Values)
                {
                    if (ingredient.Included) instructions.Add($"Add {ingredient.Name}");
                }
                if (SalsaType == Salsa.None) instructions.Add("Hold Salsa");
                else if (SalsaType != _salsaDefault) instructions.Add($"Swap {SalsaType}");

                return instructions;
            }
        }

        /// <summary>
        /// Protected field for the default salsa
        /// </summary>
        protected Salsa _salsaDefault = Salsa.Medium;

        private Salsa _salsa = Salsa.Medium;

        /// <summary>
        /// Abstract property that tracks the type of salsa in the entree menu item
        /// </summary>
        public Salsa SalsaType
        {
            get => _salsa;
            set
            {
                _salsa = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Instructions));
            }
        }

        /// <summary>
        /// Abstract property that tracks the base ingredient of the entree menu item
        /// </summary>
        public abstract IngredientItem BaseIngredient { get;  }

        /*
        /// <summary>
        /// Abstract property that tracks the additional ingredients in the entree menu item
        /// </summary>
        public virtual Dictionary<Ingredient, IngredientItem> AdditionalIngredients { get; set; } = new() { 
            {Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans)},
            {Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans)},
            {Ingredient.Queso, new IngredientItem(Ingredient.Queso)},
            {Ingredient.Veggies, new IngredientItem(Ingredient.Veggies)},
            {Ingredient.SourCream, new IngredientItem(Ingredient.SourCream)},
            {Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole)},
            {Ingredient.Chicken, new IngredientItem(Ingredient.Chicken)},
            {Ingredient.Steak, new IngredientItem(Ingredient.Steak)},
            {Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas)}
        };*/


        /// <summary>
        /// Abstract property that tracks the additional ingredients in the entree menu item
        /// </summary>
        public virtual Dictionary<Ingredient, IngredientItem> AdditionalIngredients { get; set; } = new() {
            {Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans)},
            {Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans)},
            {Ingredient.Queso, new IngredientItem(Ingredient.Queso)},
            {Ingredient.Veggies, new IngredientItem(Ingredient.Veggies)},
            {Ingredient.SourCream, new IngredientItem(Ingredient.SourCream)},
            {Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole)},
            {Ingredient.Chicken, new IngredientItem(Ingredient.Chicken)},
            {Ingredient.Steak, new IngredientItem(Ingredient.Steak)},
            {Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas)}
        };
    }
}
