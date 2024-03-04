using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Base class for implementation of speciality nachos 
    /// </summary>
    public class Nachos : Entree
    {
        /// <summary>
        /// Name of the speciality nachos
        /// </summary>
        public override string Name => "Build-Your-Own Nachos";

        /// <summary>
        /// Descirption of the speciality nachos class
        /// </summary>
        public override string Description => "Nachos you get to build";

        /// <summary>
        /// The base ingredient used in nachos
        /// </summary>
        public override IngredientItem BaseIngredient => new IngredientItem(Ingredient.Chips);

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
