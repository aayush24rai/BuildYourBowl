using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Drinks;

namespace BuildYourBowl.Data
{
    public static class Menu
    {
        public static IEnumerable<IMenuItem> Entrees
        {
            get
            {
                List<IMenuItem> entrees = new();
                entrees.Add(new Bowl());
                entrees.Add(new CarnitasBowl());
                entrees.Add(new GreenChickenBowl());
                entrees.Add(new SpicySteakBowl());
                entrees.Add(new Nachos());
                entrees.Add(new ChickenFajitaNachos());
                entrees.Add(new ClassicNachos());

                return entrees;
            }
        }

        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<IMenuItem> sides = new();
                sides.Add(new Fries() { SizeChoice = Size.Kids, Curly = true});
                sides.Add(new Fries() { SizeChoice = Size.Small, Curly = true });
                sides.Add(new Fries() { SizeChoice = Size.Medium, Curly = true });
                sides.Add(new Fries() { SizeChoice = Size.Large, Curly = true });
                sides.Add(new Fries() { SizeChoice = Size.Kids, Curly = false });
                sides.Add(new Fries() { SizeChoice = Size.Small, Curly = false });
                sides.Add(new Fries() { SizeChoice = Size.Medium, Curly = false });
                sides.Add(new Fries() { SizeChoice = Size.Large, Curly = false });

                /*
                RefriedBeans r1 = new RefriedBeans();
                r1.AdditionalIngredients[Ingredient.Onions].Included = true;
                r1.AdditionalIngredients[Ingredient.CheddarCheese].Included = true;
                r1.SizeChoice = Size.Kids;
                sides.Add(r1);

                RefriedBeans r2 = new RefriedBeans();
                r2.AdditionalIngredients[Ingredient.Onions].Included = true;
                r2.AdditionalIngredients[Ingredient.CheddarCheese].Included = true;
                r2.SizeChoice = Size.Small;
                sides.Add(r2);

                RefriedBeans r3 = new RefriedBeans();
                r3.AdditionalIngredients[Ingredient.Onions].Included = true;
                r3.AdditionalIngredients[Ingredient.CheddarCheese].Included = true;
                r3.SizeChoice = Size.Medium;
                sides.Add(r3);

                RefriedBeans r4 = new RefriedBeans();
                r4.AdditionalIngredients[Ingredient.Onions].Included = true;
                r4.AdditionalIngredients[Ingredient.CheddarCheese].Included = true;
                r4.SizeChoice = Size.Large;
                sides.Add(r4);
                */

                List<bool> list = new List<bool>() { true, false };

                foreach (Size size in Enum.GetValues(typeof(Size)))
                {
                    foreach (bool val1 in list)
                    {
                        foreach (bool val2 in list)
                        {
                            RefriedBeans rf = new RefriedBeans() { SizeChoice = size };
                            rf.AdditionalIngredients[Ingredient.Onions].Included = val1;
                            rf.AdditionalIngredients[Ingredient.CheddarCheese].Included = val2;
                            sides.Add(rf);
                        }
                    }
                }

                foreach (Size size in Enum.GetValues(typeof(Size)))
                {
                    foreach (bool val1 in list)
                    {
                        foreach (bool val2 in list)
                        {
                            StreetCorn sc = new StreetCorn() { SizeChoice = size };
                            sc.AdditionalIngredients[Ingredient.CotijaCheese].Included = val1;
                            sc.AdditionalIngredients[Ingredient.Cilantro].Included = val2;
                            sides.Add(sc);
                        }
                    }
                }

                return sides;
            }
        }

        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List<IMenuItem> drinks = new();

                List<bool> list = new List<bool>() { true, false };


                foreach (Size size in Enum.GetValues(typeof(Size)))
                {
                    foreach (bool chocolate in list)
                    {
                        Milk milk = new Milk() { SizeChoice = size };
                        milk.Chocolate = chocolate;
                        drinks.Add(milk);
                    }
                }

                foreach (Size size in Enum.GetValues(typeof(Size)))
                {
                    Horchata h = new Horchata() { SizeChoice = size };
                    drinks.Add(h);
                }

                foreach (Size size in Enum.GetValues(typeof(Size)))
                {
                    foreach (Flavor flavor in Enum.GetValues(typeof(Flavor)))
                    {
                        AguaFresca af = new AguaFresca() { SizeChoice = size };
                        af.DrinkFlavor = flavor;
                        drinks.Add(af);
                    }
                }

                return drinks;
            }
        }

        public static IEnumerable<IMenuItem> KidsMeals
        {
            get
            {
                List<IMenuItem> meals = new();
                List<bool> list = new List<bool>() { true, false };
                List<Side> sideslist = new List<Side>() { new Fries(), new RefriedBeans(), new StreetCorn() };
                List<Drink> drinkslist = new List<Drink>() { new Milk(), new Horchata(), new AguaFresca() };

                foreach (Drink drink in drinkslist)
                {
                    foreach (Side side in sideslist)
                    {
                        for (int count = 5; count <= 8; count++)
                        {
                            ChickenNuggetsMeal meal = new ChickenNuggetsMeal();
                            meal.SideChoice = side;
                            meal.DrinkChoice = drink;
                            meal.Count = (uint)count;
                            meals.Add(meal);
                        }
                    }
                }

                foreach (Drink drink in drinkslist)
                {
                    foreach (Side side in sideslist)
                    {
                        for (int count = 5; count <= 8; count++)
                        {
                            CornDogBitesMeal meal = new CornDogBitesMeal();
                            meal.SideChoice = side;
                            meal.DrinkChoice = drink;
                            meal.Count = (uint)count;
                            meals.Add(meal);
                        }
                    }
                }

                

                foreach (Drink drink in drinkslist)
                {
                    foreach (Side side in sideslist)
                    {
                        for (int count = 2; count <= 4; count++)
                        {
                            foreach (bool cheese in list)
                            {
                                SlidersMeal meal = new SlidersMeal();
                                meal.SideChoice = side;
                                meal.DrinkChoice = drink;
                                meal.AmericanCheese = cheese;
                                meal.Count = (uint)count;
                                meals.Add(meal);
                            } 
                        }
                    }
                }

                return meals;
            }
        }

        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> menu = new();

                foreach (IMenuItem item in Entrees)
                {
                    menu.Add(item);
                }
                foreach (IMenuItem item in Sides)
                {
                    menu.Add(item);
                }
                foreach (IMenuItem item in Drinks)
                {
                    menu.Add(item);
                }
                foreach (IMenuItem item in KidsMeals)
                {
                    menu.Add(item);
                }
                return menu;
            }
        }

        public static IEnumerable<IngredientItem> Ingredients
        {
            get
            {
                List<IngredientItem> ingredients = new();

                ingredients.Add(new IngredientItem(Ingredient.BlackBeans));
                ingredients.Add(new IngredientItem(Ingredient.PintoBeans));
                ingredients.Add(new IngredientItem(Ingredient.Queso));
                ingredients.Add(new IngredientItem(Ingredient.Veggies));
                ingredients.Add(new IngredientItem(Ingredient.SourCream));
                ingredients.Add(new IngredientItem(Ingredient.Guacamole));
                ingredients.Add(new IngredientItem(Ingredient.Chicken));
                ingredients.Add(new IngredientItem(Ingredient.Steak));
                ingredients.Add(new IngredientItem(Ingredient.Carnitas));

                return ingredients;
            }
        }

        public static IEnumerable<Salsa> Salsas
        {
            get
            {
                List<Salsa> salsas = new();
                salsas.Add(Salsa.Mild);
                salsas.Add(Salsa.Medium);
                salsas.Add(Salsa.Hot);
                salsas.Add(Salsa.Green);
                salsas.Add(Salsa.None);

                return salsas;
            }
        }

        public static IEnumerable<IMenuItem> All => FullMenu;

        public static IEnumerable<IMenuItem> EntreeSearch(string termsList)
        {
            if (string.IsNullOrEmpty(termsList)) return Entrees;

            string[] terms = termsList.ToLower().Split();

            return Entrees.Where(menuItem =>
                terms.All(term =>
                    menuItem.Name.ToLower().Contains(term) ||
                    menuItem.Instructions.Any(instruction => instruction.ToLower().Contains(term)) ||
                    (menuItem is Entree entreeItem &&
                     entreeItem.AdditionalIngredients.Any(ing => ing.Key.ToString().ToLower().Contains(term)))
                ));
        }



        /*
        public static IEnumerable<IMenuItem> EntreeSearch (string? termsList)
        {
            if (termsList == null) return Entrees;

            List<IMenuItem> result = new List<IMenuItem>();

            foreach (string term in termsList.Split())
            {
                foreach (IMenuItem menuItem in Entrees)
                {
                    //SEARCH AND FILTER FOR NAME
                    if (menuItem.Name.ToLower().Split().Contains(term.ToLower())) result.Add(menuItem);

                    //SEARCH AND FILTER FOR INSTRUCTIONS
                    List<string> prepInfo = new();
                    foreach (string info in menuItem.Instructions)
                    {
                        string[] infoSplit = info.ToLower().Split();
                        foreach (string check in infoSplit) prepInfo.Add(check);
                    }

                    if (prepInfo.Contains(term.ToLower())) result.Add(menuItem);

                    //SEARCH AND FILTER FOR ADDITIONAL INGREDIENTS
                    if (menuItem is Entree entreeItem)
                    {
                        if ("Black Beans".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.BlackBeans)) result.Add(entreeItem);
                        if ("Pinto Beans".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.PintoBeans)) result.Add(entreeItem);
                        if ("Queso".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Queso)) result.Add(entreeItem);
                        if ("Veggies".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Veggies)) result.Add(entreeItem);
                        if ("Sour Cream".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.SourCream)) result.Add(entreeItem);
                        if ("Guacamole".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Guacamole)) result.Add(entreeItem);
                        if ("Chicken".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Chicken)) result.Add(entreeItem);
                        if ("Steak".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Steak)) result.Add(entreeItem);
                        if ("Carnitas".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Carnitas)) result.Add(entreeItem);
                    }
                }
            }

            return result;
        }
        */


        public static IEnumerable<IMenuItem> SideSearch(string termsList)
        {
            if (termsList == null) return Sides;

            List<IMenuItem> result = new List<IMenuItem>();

            foreach (IMenuItem menuItem in Sides)
            {
                bool isValidSearch = false;

                foreach (string term in termsList.Split())
                {

                    List<string> prepInfo = new ();
                    foreach (string info in menuItem.Instructions)
                    {
                        string[] infoSplit = info.ToLower().Split();
                        foreach (string check in infoSplit) prepInfo.Add(check);
                    }

                    if ((menuItem.Name.ToLower().Split().Contains(term.ToLower())) && (prepInfo.Contains(term.ToLower()))) isValidSearch = true;

                    //prepInfo.Add(info.ToLower().Split());

                    //TO USE
                    /*
                    if (menuItem.Name.ToLower().Split().Contains(term.ToLower())) result.Add(menuItem);

                    if (prepInfo.Contains(term.ToLower())) result.Add(menuItem);
                    */

                    //if (Enumerable.Contains<string>(prepInfo, term.ToLower())) result.Add(menuItem);

                    //if (Enumerable.Contains<string>(menuItem.Instructions, char.ToUpper(term[0]) + term.Substring(1).ToLower())) result.Add(menuItem);
                }

                if (isValidSearch) result.Add(menuItem);
            }

            return result;
        }
        public static IEnumerable<IMenuItem> DrinkSearch(string termsList)
        {
            if (termsList == null) return Drinks;

            List<IMenuItem> result = new List<IMenuItem>();

            foreach (string term in termsList.Split())
            {
                foreach (IMenuItem menuItem in Drinks)
                {
                    //SEARCH AND FILTER FOR NAME
                    if (menuItem.Name.ToLower().Split().Contains(term.ToLower())) result.Add(menuItem);

                    //SEARCH AND FILTER FOR INSTRUCTIONS
                    List<string> prepInfo = new();
                    foreach (string info in menuItem.Instructions)
                    {
                        string[] infoSplit = info.ToLower().Split();
                        foreach (string check in infoSplit) prepInfo.Add(check);
                    }

                    if (prepInfo.Contains(term.ToLower())) result.Add(menuItem);

                    //SEARCH AND FILTER FOR ADDITIONAL INGREDIENTS
                    if (menuItem is Entree entreeItem)
                    {
                        if ("Black Beans".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.BlackBeans)) result.Add(entreeItem);
                        if ("Pinto Beans".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.PintoBeans)) result.Add(entreeItem);
                        if ("Queso".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Queso)) result.Add(entreeItem);
                        if ("Veggies".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Veggies)) result.Add(entreeItem);
                        if ("Sour Cream".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.SourCream)) result.Add(entreeItem);
                        if ("Guacamole".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Guacamole)) result.Add(entreeItem);
                        if ("Chicken".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Chicken)) result.Add(entreeItem);
                        if ("Steak".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Steak)) result.Add(entreeItem);
                        if ("Carnitas".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Carnitas)) result.Add(entreeItem);
                    }
                }
            }

            return result;
        }
        public static IEnumerable<IMenuItem> KidsMealSearch(string termsList)
        {
            if (termsList == null) return KidsMeals;

            List<IMenuItem> result = new List<IMenuItem>();

            foreach (string term in termsList.Split())
            {
                foreach (IMenuItem menuItem in KidsMeals)
                {
                    //SEARCH AND FILTER FOR NAME
                    if (menuItem.Name.ToLower().Split().Contains(term.ToLower())) result.Add(menuItem);

                    //SEARCH AND FILTER FOR INSTRUCTIONS
                    List<string> prepInfo = new();
                    foreach (string info in menuItem.Instructions)
                    {
                        string[] infoSplit = info.ToLower().Split();
                        foreach (string check in infoSplit) prepInfo.Add(check);
                    }

                    if (prepInfo.Contains(term.ToLower())) result.Add(menuItem);

                    //SEARCH AND FILTER FOR ADDITIONAL INGREDIENTS
                    if (menuItem is Entree entreeItem)
                    {
                        if ("Black Beans".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.BlackBeans)) result.Add(entreeItem);
                        if ("Pinto Beans".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.PintoBeans)) result.Add(entreeItem);
                        if ("Queso".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Queso)) result.Add(entreeItem);
                        if ("Veggies".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Veggies)) result.Add(entreeItem);
                        if ("Sour Cream".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.SourCream)) result.Add(entreeItem);
                        if ("Guacamole".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Guacamole)) result.Add(entreeItem);
                        if ("Chicken".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Chicken)) result.Add(entreeItem);
                        if ("Steak".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Steak)) result.Add(entreeItem);
                        if ("Carnitas".ToLower().Split().Contains(term.ToLower()) && entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Carnitas)) result.Add(entreeItem);
                    }
                }
            }

            return result;
        }

        public static IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem> menuItems, double? min, double? max)
        {
            if (min == null && max == null) return menuItems;

            if (min == null) return menuItems.Where(entreeItem => entreeItem.Calories <= max);
            if (max == null) return menuItems.Where(entreeItem => entreeItem.Calories >= min);

            return menuItems.Where(entreeItem => entreeItem.Calories >= min && entreeItem.Calories <= max);
        }

        public static IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> menuItems, decimal? min, decimal? max)
        {
            if (min == null && max == null) return menuItems;

            if (min == null) return menuItems.Where(entreeItem => entreeItem.Price <= max);
            if (max == null) return menuItems.Where(entreeItem => entreeItem.Price >= min);

            return menuItems.Where(entreeItem => entreeItem.Price >= min && entreeItem.Price <= max);
        }


        //IngredientSearch
        /*
        public static IEnumerable<IngredientItem> IngredientSearch(string termsList)
        {
            if (termsList == null) return Ingredients;

            List<IngredientItem> result = new List<IngredientItem>();

            foreach (string term in termsList.Split())
            {
                foreach (IngredientItem ingItem in Ingredients)
                {
                    if (menuItem.Name.ToLower().Split().Contains(term.ToLower())) result.Add(menuItem);

                    if (Enumerable.Contains<string>(menuItem.Instructions, char.ToUpper(term[0]) + term.Substring(1).ToLower())) result.Add(menuItem);

                }
            }

            return result;
        }
        */

        
        public static IEnumerable<IMenuItem> Search (string termsList)
        {
            
            if (termsList == null) return All;

            List<IMenuItem> result = new List<IMenuItem>();

            foreach (string term in termsList.Split())
            {
                foreach (IMenuItem menuItem in All)
                {
                    if (menuItem.Name.ToLower().Split().Contains(term.ToLower())) result.Add(menuItem);

                    if (Enumerable.Contains<string>(menuItem.Instructions, char.ToUpper(term[0]) + term.Substring(1).ToLower())) result.Add(menuItem);
                    
                    if (menuItem is Entree entreeItem)
                    {
                        if ("Black Beans".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.BlackBeans)) result.Add(entreeItem);
                        if ("Pinto Beans".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.PintoBeans)) result.Add(entreeItem);
                        if ("Queso".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Queso)) result.Add(entreeItem);
                        if ("Veggies".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Veggies)) result.Add(entreeItem);
                        if ("Sour Cream".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.SourCream)) result.Add(entreeItem);
                        if ("Guacamole".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Guacamole)) result.Add(entreeItem);
                        if ("Chicken".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Chicken)) result.Add(entreeItem);
                        if ("Steak".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Steak)) result.Add(entreeItem);
                        if ("Carnitas".ToLower().Split().Contains(term.ToLower()) || entreeItem.AdditionalIngredients.ContainsKey(Ingredient.Carnitas)) result.Add(entreeItem);
                    }
                }
            }

            return result;
            


            /*
            if (termsList != null)
            {
                foreach (string term in termsList.Split())
                {
                    foreach (IMenuItem menuItem in All)
                    {
                        if (menuItem is Entree entreeItem)
                        {
                            return All.Where(item => item.Name.ToLower().Split().Contains(term.ToLower()) || 
                            Enumerable.Contains<string>(item.Instructions, char.ToUpper(term[0]) + term.Substring(1).ToLower()) );
                        }
                        

                        return All.Where(item => item.Name.ToLower().Split().Contains(term.ToLower()) 
                        || Enumerable.Contains<string>(item.Instructions, char.ToUpper(term[0]) + term.Substring(1).ToLower()));


                    }
                }
            }
            
            return All;
            */
            

            
            /*
            foreach (IMenuItem item in All)
            {
                foreach (string instruction in item.Instructions)
                {
                    if (item is Entree entree) return All.Where(item => item.Name == terms || instruction == terms || entree.AdditionalIngredients.ContainsValue(new IngredientItem(terms)));
                    return All.Where(item => item.Name == terms || instruction == terms);
                }
            }
            return All.Where(item => item.Name == terms || item.Instructions);
            */

        }
        
    }
}
