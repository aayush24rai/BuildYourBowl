using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the GreenChickenBowl class
    /// </summary>
    public class GreenChickenBowl : Bowl
    {
        /// <summary>
        /// The name of the green chicken bowl instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Green Chicken Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Rice bowl with chicken and green things";

        /// <summary>
        /// Constructor for this bowl
        /// </summary>
        public GreenChickenBowl()
        {
            AdditionalIngredients.Clear();
            //AdditionalIngredients = new Dictionary<Ingredient, IngredientItem>();
            AdditionalIngredients.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken));
            AdditionalIngredients.Add(Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans));
            AdditionalIngredients.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            AdditionalIngredients.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            AdditionalIngredients.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            AdditionalIngredients.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));

            AdditionalIngredients[Ingredient.Chicken].Included = true;
            AdditionalIngredients[Ingredient.BlackBeans].Included = true;
            AdditionalIngredients[Ingredient.Veggies].Included = true;
            AdditionalIngredients[Ingredient.Queso].Included = true;
            AdditionalIngredients[Ingredient.Guacamole].Included = true;
            AdditionalIngredients[Ingredient.SourCream].Included = true;

            _salsaDefault = Salsa.Green;
            SalsaType = Salsa.Green;

            foreach (IngredientItem ingredientItem in AdditionalIngredients.Values)
            {
                ingredientItem.PropertyChanged += HandleItemPropertyChanged;
            }
        }


        /*
        /// <summary>
        /// Property holding the type of salsa used
        /// </summary>
        public Salsa SalsaSelection { get; set; } = Salsa.Green;
        */

        /// <summary>
        /// The price of this bowl
        /// </summary>
        public override decimal Price => 9.99m;

        //Calories and preparation info here
        /*
        /// <summary>
        /// The total number of calories in this bowl
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 890;

                //YOU DO THIS: take customizations into account
                if (!Chicken) cals -= 150;
                if (!BlackBeans) cals -= 130;
                if (!Queso) cals -= 110;
                if (!Veggies) cals -= 20;
                if (!SourCream) cals -= 100;
                if (SalsaSelection == Salsa.None) cals -= 20;
                if (!Guacamole) cals -= 150;


                return cals;
            }
        }
        */
        /// <summary>
        /// Information for the preparation of this bowl
        /// </summary>
        public override IEnumerable<string> Instructions
        {
            get
            {
                List<string> instructions = new();

                //YOU DO THIS: take customizations into account
                if (!AdditionalIngredients[Ingredient.Chicken].Included) instructions.Add("Hold Chicken");
                if (!AdditionalIngredients[Ingredient.BlackBeans].Included) instructions.Add("Hold Black Beans");
                if (!AdditionalIngredients[Ingredient.Queso].Included) instructions.Add("Hold Queso");
                if (!AdditionalIngredients[Ingredient.Veggies].Included) instructions.Add("Hold Veggies");
                if (!AdditionalIngredients[Ingredient.SourCream].Included) instructions.Add("Hold Sour Cream");
                if (SalsaType == Salsa.None) instructions.Add("Hold Salsa");
                else if (SalsaType != Salsa.Green) instructions.Add($"Swap {SalsaType} Salsa");
                if (!AdditionalIngredients[Ingredient.Guacamole].Included) instructions.Add("Hold Guacamole");

                return instructions;
            }
        }
        
    }
}