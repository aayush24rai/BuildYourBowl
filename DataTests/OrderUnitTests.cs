using BuildYourBowl.Data;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Sides;
using System;
using System.Collections.Generic;
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
    }
}