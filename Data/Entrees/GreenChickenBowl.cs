using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the GreenChickenBowl class
    /// </summary>
    public class GreenChickenBowl
    {
        /// <summary>
        /// The name of the green chicken bowl instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Green Chicken Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description => "Rice bowl with chicken and green things";

        /// <summary>
        /// Whether this bowl contains chicken
        /// </summary>
        public bool Chicken { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains black beans 
        /// </summary>
        public bool BlackBeans { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains fajita veggies
        /// </summary>
        public bool Veggies { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains queso
        /// </summary>
        public bool Queso { get; set; } = true;

        /// <summary>
        /// Property holding the type of salsa used
        /// </summary>
        public Salsa SalsaSelection { get; set; } = Salsa.Green;

        /// <summary>
        /// Whether this bowl contains guacamole
        /// </summary>
        public bool Guacamole { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains sour cream
        /// </summary>
        public bool SourCream { get; set; } = true;

        /// <summary>
        /// The price of this bowl
        /// </summary>
        public decimal Price => 9.99m;

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

        /// <summary>
        /// Information for the preparation of this bowl
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                //YOU DO THIS: take customizations into account
                if (!Chicken) instructions.Add("Hold Chicken");
                if (!BlackBeans) instructions.Add("Hold Black Beans");
                if (!Queso) instructions.Add("Hold Queso");
                if (!Veggies) instructions.Add("Hold Veggies");
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (SalsaSelection == Salsa.None) instructions.Add("Hold Salsa");
                else if (SalsaSelection != Salsa.Green) instructions.Add($"Swap {SalsaSelection} Salsa");
                if (!Guacamole) instructions.Add("Hold Guacamole");

                return instructions;
            }
        }
    }
}