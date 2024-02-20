using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class to implement Ingredient items present in the menu items
    /// </summary>
    public class IngredientItem
    {
        /// <summary>
        /// The type of the ingredient
        /// </summary>
        public Ingredient IngredientType { get; }

        /// <summary>
        /// Name of the ingredient
        /// </summary>
        public string Name
        {
            get
            {
                if (IngredientType == Ingredient.BlackBeans) return "Black Beans";
                else if (IngredientType == Ingredient.PintoBeans) return "Pinto Beans";
                else if (IngredientType == Ingredient.Queso) return "Queso";
                else if (IngredientType == Ingredient.Veggies) return "Veggies";
                else if (IngredientType == Ingredient.SourCream) return "Sour Cream";
                else if (IngredientType == Ingredient.Guacamole) return "Guacamole";
                else if (IngredientType == Ingredient.Chicken) return "Chicken";
                else if (IngredientType == Ingredient.Steak) return "Steak";
                else if (IngredientType == Ingredient.Carnitas) return "Carnitas";
                else if (IngredientType == Ingredient.Rice) return "Rice";
                else return "Chips";
            }
        }

        /// <summary>
        /// Calories of the menu item
        /// </summary>
        public uint Calories
        {
            get
            {
                if (IngredientType == Ingredient.BlackBeans) return 130;
                else if (IngredientType == Ingredient.PintoBeans) return 130;
                else if (IngredientType == Ingredient.Queso) return 110;
                else if (IngredientType == Ingredient.Veggies) return 20;
                else if (IngredientType == Ingredient.SourCream) return 100;
                else if (IngredientType == Ingredient.Guacamole) return 150;
                else if (IngredientType == Ingredient.Chicken) return 150;
                else if (IngredientType == Ingredient.Steak) return 180;
                else if (IngredientType == Ingredient.Carnitas) return 210;
                else if (IngredientType == Ingredient.Rice) return 210;
                else return 250;
            }
        }

        /// <summary>
        /// The cost per unit of ingredient
        /// </summary>
        public decimal UnitCost
        {
            get
            {
                if (IngredientType == Ingredient.BlackBeans) return 1.00m;
                else if (IngredientType == Ingredient.PintoBeans) return 1.00m;
                else if (IngredientType == Ingredient.Queso) return 1.00m;
                else if (IngredientType == Ingredient.Veggies) return 0.00m;
                else if (IngredientType == Ingredient.SourCream) return 0.00m;
                else if (IngredientType == Ingredient.Guacamole) return 1.00m;
                else if (IngredientType == Ingredient.Chicken) return 2.00m;
                else if (IngredientType == Ingredient.Steak) return 2.00m;
                else if (IngredientType == Ingredient.Carnitas) return 2.00m;
                else if (IngredientType == Ingredient.Rice) return 0.00m;
                else return 0.00m;
            }
        }

        /// <summary>
        /// private backing field of the Included property
        /// </summary>
        private bool _included = false;

        /// <summary>
        /// Whether this ingredient is currently included in a containing menu item
        /// </summary>
        public bool Included
        {
            get => _included;
            set => _included = value;
        }

        /// <summary>
        /// Private backing field of the default property
        /// </summary>
        private bool _default = false;

        /// <summary>
        /// Whether this ingredient is included in its containing menu item by default
        /// </summary>
        public bool Defualt
        {
            get => _default;
            set => _default = value;
        }

        /// <summary>
        /// Constructor initializing all the properties for Ingredient item class instance
        /// </summary>
        /// <param name="ingredient">the type of the ingredient</param>
        public IngredientItem(Ingredient ingredient)
        {
            IngredientType = ingredient;
        }
    }
}
