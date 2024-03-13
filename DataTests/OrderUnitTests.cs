using BuildYourBowl.Data;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    public class OrderUnitTests
    {
        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockMenuItem : IMenuItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public uint Calories { get; set; }
            public IEnumerable<string> PreparationInformation { get; set; }

            public IEnumerable<string> Instructions => throw new NotImplementedException();
        }

        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        [Fact]
        public void SlidersMealShouldBeAssignableToIMenuItemAndSlidersMeal()
        {
            SlidersMeal slidersMeal = new SlidersMeal();
            Assert.IsAssignableFrom<IMenuItem>(slidersMeal);
            Assert.IsAssignableFrom<SlidersMeal>(slidersMeal);
        }

        [Fact]
        public void CornDogBitesMealShouldBeAssignableToIMenuItemAndRespectiveBaseClassType()
        {
            CornDogBitesMeal c = new();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<Side>(c.SideChoice);
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<Drink>(c.DrinkChoice);
        }

        [Fact]
        public void ChickenNuggetsMealShouldBeAssignableToIMenuItemAndRespectiveBaseClassType()
        {
            ChickenNuggetsMeal c = new();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<Side>(c.SideChoice);
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<Drink>(c.DrinkChoice);
        }

        [Fact]
        public void CarnitasBowlShouldBeAssignableToIMenuItemAndRespectiveBaseClassType()
        {
            CarnitasBowl c = new();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<CarnitasBowl>(c);
            Assert.IsAssignableFrom<Bowl>(c);
        }

        [Fact]
        public void GreenChickenBowlShouldBeAssignableToIMenuItemAndRespectiveBaseClassType()
        {
            GreenChickenBowl c = new();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<GreenChickenBowl>(c);
            Assert.IsAssignableFrom<Bowl>(c);
        }

        [Fact]
        public void SpicySteakBowlShouldBeAssignableToIMenuItemAndRespectiveBaseClassType()
        {
            SpicySteakBowl c = new();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<SpicySteakBowl>(c);
            Assert.IsAssignableFrom<Bowl>(c);
        }

        [Fact]
        public void ChickenFaijtaNachosShouldBeAssignableToIMenuItemAndRespectiveBaseClassType()
        {
            ChickenFajitaNachos c = new();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<ChickenFajitaNachos>(c);
            Assert.IsAssignableFrom<Nachos>(c);
        }

        [Fact]
        public void ClassicNachosShouldBeAssignableToIMenuItemAndRespectiveBaseClassType()
        {
            ClassicNachos c = new();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<ClassicNachos>(c);
            Assert.IsAssignableFrom<Nachos>(c);
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order.ResetLastOrderNumber();
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => {
                order.TaxRate = 0.15m;
            });
        }

        [Fact]
        public void ChangingTaxShouldNotifyOfPropertyChange()
        {
            Order.ResetLastOrderNumber();
            Order order = new Order();
            Assert.PropertyChanged(order, "Tax", () => {
                order.TaxRate = 0.15m;
            });
        }

        [Fact]
        public void ChangingTaxRemoveShouldNotifyOfPropertyChange()
        {
            Order.ResetLastOrderNumber();
            Order order = new Order();
            MockMenuItem m = new();
            order.Add(m);
            Assert.PropertyChanged(order, "Tax", () => {
                order.Remove(m);
            });
        }

        [Fact]
        public void ChangingTaxAddShouldNotifyOfPropertyChange()
        {
            Order.ResetLastOrderNumber();
            Order order = new Order();
            Assert.PropertyChanged(order, "Tax", () => {
                order.Add(new MockMenuItem() { Price = 0.46m});
            });
        }

        [Fact]
        public void ChangingTaxClearShouldNotifyOfPropertyChange()
        {
            Order.ResetLastOrderNumber();
            Order order = new Order();
            Assert.PropertyChanged(order, "Tax", () => {
                order.Clear();
            });
        }

        [Fact]
        public void ChangedOrderTests()
        {
            Order.ResetLastOrderNumber();
            Order order1 = new Order();
            Assert.Equal(1, order1.Number);

            Order order2 = new Order();
            Assert.Equal(2, order2.Number);

            Order order3 = new Order();
            Assert.Equal(3, order3.Number);

            Order order4 = new Order();
            Assert.Equal(4, order4.Number);
        }

        [Fact]
        public void DateTimeTests()
        {
            Order order = new Order();
            DateTime dt = new DateTime();
            Assert.NotStrictEqual(dt, order.PlacedAt);
        }

        [Fact]
        public void DontChangeWhenRequested()
        {
            Order.ResetLastOrderNumber();
            Order order = new Order();
            TimeSpan tolerance = TimeSpan.FromDays(1);
            Assert.True(Math.Abs((DateTime.Now - order.PlacedAt).TotalDays) <= tolerance.TotalDays);
            Assert.Equal(1, order.Number);
        }

        [Fact]
        public void INotifyPropertyChangedTest()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }
    }
}