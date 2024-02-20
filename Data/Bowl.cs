using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Base class for implementation of speciality bowl 
    /// </summary>
    public class Bowl : Entree
    {
        /// <summary>
        /// Name of the speciality bowl
        /// </summary>
        public override string Name => "Build-Your-Own Bowl";

        /// <summary>
        /// Descirption of the speciality bowl class
        /// </summary>
        public override string Description => "A bowl you get to build";

        /// <summary>
        /// The base ingredient used in this bowl
        /// </summary>
        public override IngredientItem BaseIngredient => new IngredientItem(Ingredient.Rice);
    }
}
