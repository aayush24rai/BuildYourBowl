namespace BuildYourBowl.Data
{
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
        public bool Veggies { get; set; } = false;

        /// <summary>
        /// Whether this bowl contains queso
        /// </summary>
        public bool Queso { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains green salsa
        /// </summary>
        public bool GreenSalsa { get; set; } = true;

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

                return instructions;
            }
        }
    }
}