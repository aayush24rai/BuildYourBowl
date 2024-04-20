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
    }
}
