using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    public class ViewModelIntegrationTests
    {
        [Fact]
        public void Test()
        {
            Order o = new Order();
            //Assert.Equal(1, o.Number);
            SlidersMeal s = new SlidersMeal()

            {
                Count = 3,
                AmericanCheese = false,
                SideChoice = new RefriedBeans() { SizeChoice = Size.Medium },
                DrinkChoice = new AguaFresca() { SizeChoice = Size.Large, Ice = false, DrinkFlavor = Flavor.Tamarind },

            };

            o.Add(s);
            Bowl b = new Bowl();

            foreach (IngredientItem item in b.AdditionalIngredients.Values)
            {
                if (item.Name == "Steak" || item.Name == "Queso" || item.Name == "Sour Cream")
                {
                    item.Included = true;
                }
            }
            o.Add(b);
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            foreach (IngredientItem item in c.AdditionalIngredients.Values)
            {
                if (item.Name == "Sour Cream")
                {
                    item.Included = false;
                }
                if (item.Name == "Guacamole")
                {
                    item.Included = true;
                }
            }
            c.SalsaType = Salsa.None;
            o.Add(c);
            Assert.Equal((decimal)33.47, o.Subtotal);
            Assert.Equal((decimal)3.06, o.Tax);
            Assert.Equal((decimal)36.53, o.Total);

            PaymentViewModel p = new(o);
            p.Paid = (decimal)40.00;
            Assert.Equal((decimal)3.47, p.Change);

            Order o2 = new();
            //Assert.Equal(2, o2.Number);

            StreetCorn sC = new();
            sC.SizeChoice = Size.Large;
            
            AguaFresca aF = new();
            aF.SizeChoice = Size.Kids;
            aF.DrinkFlavor = Flavor.Tamarind;
            Nachos n = new();
            n.AdditionalIngredients.Clear();
            n.AdditionalIngredients.Add(Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans));
            n.AdditionalIngredients.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans));
            n.AdditionalIngredients.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            n.SalsaType = Salsa.Green;
            o2.Add(sC);
            o2.Add(aF);
            o2.Add(n);


            Assert.Equal((decimal)15.99, o2.Subtotal);
            Assert.Equal((decimal)1.46, o2.Tax);
            Assert.Equal((decimal)17.45, o2.Total);

            PaymentViewModel p2 = new(o2);
            Assert.Throws<ArgumentException>(() => {p2.Paid = (decimal)15.00;});
        }
    }
}
