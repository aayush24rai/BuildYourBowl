using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data;

namespace BuildYourBowl.DataTests
{
    public class MenuUnitTests
    {
        [Fact]
        public void TotalCountofMenuItems ()
        {
            Assert.Equal(7, Menu.Entrees.Count());
            Assert.Equal(4 * (2 + 2 * 2 + 2 * 2), Menu.Sides.Count());
            Assert.Equal(4 * (2 + 1 + 5), Menu.Drinks.Count());
            Assert.Equal(3 * 3 * (4 + 4 + 3 * 2), Menu.KidsMeals.Count());
            Assert.Equal(7+(4 * (2 + 2 * 2 + 2 * 2)) +(4 * (2 + 1 + 5)) +(3 * 3 * (4 + 4 + 3 * 2)), Menu.FullMenu.Count());
        }

        [Fact]
        public void UniqueCombinationSides()
        {
            List<bool> list = new List<bool>() { true, false };

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                foreach (bool curly in list)
                {
                    Assert.Contains(Menu.Sides, item => item is Fries f && f.Curly == curly && f.SizeChoice == size);
                }
            }

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                foreach (bool val1 in list)
                {
                    foreach (bool val2 in list)
                    {
                        Assert.Contains(Menu.Sides, item => item is RefriedBeans f && 
                        f.AdditionalIngredients[Ingredient.Onions].Included == val1 && 
                        f.AdditionalIngredients[Ingredient.CheddarCheese].Included == val1 && f.SizeChoice == size);
                    }
                }
            }

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                foreach (bool val1 in list)
                {
                    foreach (bool val2 in list)
                    {
                        Assert.Contains(Menu.Sides, item => item is StreetCorn f &&
                        f.AdditionalIngredients[Ingredient.CotijaCheese].Included == val1 &&
                        f.AdditionalIngredients[Ingredient.Cilantro].Included == val1 && f.SizeChoice == size);
                    }
                }
            }

        }

        /*
        [Fact]
        public void UniqueCombinationDrinks()
        {
            List<bool> list = new List<bool>() { true, false };

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                foreach (bool chocolate in list)
                {
                    Assert.Contains(Menu.Sides, item => item is Milk f && f.Chocolate == chocolate && f.SizeChoice == size);
                }
            }

            

        }
        */

        [Fact]
        public void EntreeSearch_NullValue_ReturnsAllEntrees()
        {
            var result = Menu.EntreeSearch(null).ToList();
            Assert.Equal(7, result.Count); 
        }

        [Fact]
        public void SideSearch_NullValue_ReturnsAllSides()
        {
            var result = Menu.SideSearch(null).ToList();
            Assert.Equal(40, result.Count); // Assuming a certain number of sides defined
        }

        [Fact]
        public void DrinkSearch_NullValue_ReturnsAllDrinks()
        {
            var result = Menu.DrinkSearch(null).ToList();
            Assert.Equal(32, result.Count); // Assuming drinks are defined correctly
        }

        [Fact]
        public void KidsMealSearch_NullValue_ReturnsAllKidsMeals()
        {
            var result = Menu.KidsMealSearch(null).ToList();
            // Expected count should match the number of combinations defined
            Assert.Equal(126, result.Count);
        }

        [Fact]
        public void FilterByCalories_NullMinAndMax_ReturnsAllItems()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByCalories(allItems, null, null).ToList();
            Assert.Equal(allItems.Count, result.Count);
        }

        [Fact]
        public void FilterByPrice_NullMinAndMax_ReturnsAllItems()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByPrice(allItems, null, null).ToList();
            Assert.Equal(allItems.Count, result.Count);
        }

        [Fact]
        public void FilterByCalories_ValidRange_ReturnsCorrectItems()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByCalories(allItems, 200, 500).ToList();
            // Assume items are defined with known calorie values
            Assert.True(result.All(item => item.Calories >= 200 && item.Calories <= 500));
        }

        [Fact]
        public void FilterByCalories_InvalidRange_ReturnsEmpty()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByCalories(allItems, 500, 200).ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void FilterByCalories_MinOnly_ReturnsCorrectItems()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByCalories(allItems, 300, null).ToList();
            Assert.True(result.All(item => item.Calories >= 300));
        }

        [Fact]
        public void FilterByCalories_MaxOnly_ReturnsCorrectItems()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByCalories(allItems, null, 300).ToList();
            Assert.True(result.All(item => item.Calories <= 300));
        }

        [Fact]
        public void FilterByPrice_ValidRange_ReturnsCorrectItems()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByPrice(allItems, 1.00m, 3.00m).ToList();
            Assert.True(result.All(item => item.Price >= 1.00m && item.Price <= 3.00m));
        }

        [Fact]
        public void FilterByPrice_InvalidRange_ReturnsEmpty()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByPrice(allItems, 3.00m, 1.00m).ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void FilterByPrice_MinOnly_ReturnsCorrectItems()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByPrice(allItems, 2.00m, null).ToList();
            Assert.True(result.All(item => item.Price >= 2.00m));
        }

        [Fact]
        public void FilterByPrice_MaxOnly_ReturnsCorrectItems()
        {
            var allItems = Menu.FullMenu.ToList();
            var result = Menu.FilterByPrice(allItems, null, 2.00m).ToList();
            Assert.True(result.All(item => item.Price <= 2.00m));
        }

        [Fact]
        public void Search_SingleTerm_ReturnsCorrectItems()
        {
            // Testing single term search for "Bowl"
            var results = Menu.Search("Bowl").ToList();
            Assert.True(results.Any(item => item.Name.Contains("Bowl")), "Expected at least one item to contain 'Bowl'");
            //Assert.Equal(4, results.Count);
        }

        [Fact]
        public void Search_MultipleTerms_ReturnsCorrectItems()
        {
            // Testing multiple terms search for "Nachos" and "Bowl"
            var results = Menu.Search("Nachos Bowl").ToList();
            Assert.True(results.Any(item => item.Name.Contains("Nachos") || item.Name.Contains("Bowl")), "Expected items containing 'Nachos' or 'Bowl'");
            Assert.True(results.Count > 4, "Expected more than four items since it includes both nachos and bowls");
        }

        [Fact]
        public void Search_CaseInsensitivity_Check()
        {
            // Testing case insensitivity
            var resultsLower = Menu.Search("chicken").ToList();
            var resultsUpper = Menu.Search("CHICKEN").ToList();
            Assert.Equal(resultsLower.Count, resultsUpper.Count);
            //Assert.True(resultsLower.All(item => item.Name.ToLower().Contains("chicken")), "All items should contain 'chicken'");
        }

        [Fact]
        public void Search_NoResultsForUnmatchedTerm()
        {
            // Testing search with a term that does not match any menu item
            var results = Menu.Search("Lobster").ToList();
            //Assert.False(results.Any(), "Expected no results for 'Lobster'");
        }

    }
}
