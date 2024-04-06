using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BuildYourBowl.DataTests.KidsMealTests
{
    /// <summary>
    /// Class to check tests for the chicken nuggets meal class
    /// </summary>
    public class ChickenNuggetsMealUnitTests
    {
        /// <summary>
        /// Test to check if all the default values are correct
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            ChickenNuggetsMeal meal = new();
            Assert.Equal((uint)5, meal.Count);
            Assert.False((meal.DrinkChoice as Milk).Chocolate);
            Assert.False((meal.SideChoice as Fries).Curly);
            Assert.Equal(Size.Kids, meal.DrinkChoice.SizeChoice);
            Assert.Equal(Size.Kids, meal.SideChoice.SizeChoice);

        }

        /// <summary>
        /// Checking whether the default price is correct or not 
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            ChickenNuggetsMeal meal = new();
            Assert.Equal(5.99m, meal.Price);
        }

        /// <summary>
        /// Test to check if the preparation information for the meal is changing according to toppings selected
        /// </summary>
        /// <param name="count">number of nuggets in the meal</param>
        /// <param name="prepInfo">the price of the meal</param>
        [Theory]
        [InlineData(5, new string[] { })]
        [InlineData(6, new string[] { "6 Nuggets" })]
        [InlineData(7, new string[] { "7 Nuggets" })]
        [InlineData(8, new string[] { "8 Nuggets"})]

        public void checkingPreparationInfoTest(uint count, string[] prepInfo)
        {
            ChickenNuggetsMeal meal = new();
            meal.Count = count;

            foreach (string instruction in prepInfo)
            {
                Assert.Contains(instruction, meal.Instructions);
            }

            Assert.Equal(prepInfo.Length, meal.Instructions.Count());
        }


        /// <summary>
        /// Test to check if the Price for the meal is changing according to sizes selected
        /// </summary>
        /// <param name="count">number of chicken nuggets in the meal</param>
        /// <param name="side">size of the side</param>
        /// <param name="price">the price of the fries</param>
        [Theory]
        [InlineData(5, Size.Kids, Size.Kids, 5.99)]
        [InlineData(6, Size.Kids, Size.Kids, 5.99 + (0.75 * (6 - 5)))]
        [InlineData(7, Size.Kids, Size.Kids, 5.99 + (0.75 * (7 - 5)))]
        [InlineData(8, Size.Kids, Size.Kids, 5.99 + (0.75 * (8 - 5)))]
        [InlineData(5, Size.Small, Size.Kids, 5.99 + 0.50)]
        [InlineData(6, Size.Medium, Size.Kids, 5.99 + (0.75 * (6 - 5)) + 1.00)]
        [InlineData(7, Size.Large, Size.Kids, 5.99 + (0.75 * (7 - 5)) + 1.50)]

        public void checkingPriceTest(uint count, Size side, Size drink, decimal price)  
        {
            ChickenNuggetsMeal meal = new();
            meal.Count = count;
            meal.SideChoice.SizeChoice = side;
            meal.DrinkChoice.SizeChoice = drink;

            Assert.Equal(price, meal.Price);
        }

        /// <summary>
        /// Test to check if the calories for the meal is changing according to toppings selected
        /// </summary>
        /// <param name="count">number of chicken nuggets in the meal</param>
        /// <param name="side">size of the side</param>
        /// <param name="cals">the price of the fries</param>
        [Theory]
        
        [InlineData(5, Size.Kids, Size.Kids, (60 * 5) + 200 + (0.60 * 350))]
        [InlineData(6, Size.Kids, Size.Kids, (60 * 6) + 200 + (0.60 * 350))]
        [InlineData(7, Size.Kids, Size.Kids, (60 * 7) + 200 + (0.60 * 350))]
        [InlineData(8, Size.Small, Size.Kids, (60 * 8) + 200 + (0.75 * 350))]
        [InlineData(5, Size.Medium, Size.Kids, (60 * 5) + 200 + 350)]
        [InlineData(6, Size.Large, Size.Kids, (60 * 6) + 200 + (1.50 * 350))]
        
        /*
        [InlineData(5, (60 * 5) )]
        [InlineData(6,  (60 * 6) )]
        [InlineData(7,  (60 * 7) )]
        [InlineData(8, (60 * 8) )]
        */
        public void checkingCaloriesTest(uint count, Size side, Size drink, uint cals)
        {
            ChickenNuggetsMeal meal = new();
            meal.Count = count;
            meal.SideChoice.SizeChoice = side;
            meal.DrinkChoice.SizeChoice = drink;

            Assert.Equal(cals, meal.Calories);
        }

        /// <summary>
        /// Checking if the override ToString method is working properly
        /// </summary>
        [Fact]
        public void TestToString()
        {
            ChickenNuggetsMeal meal = new();
            Assert.Equal("Chicken Nuggets Kids Meal", meal.ToString());
        }

        internal class MockSide : Side, INotifyPropertyChanged
        {
            private Size _size;

            public override string Name { get; } = "Mock Side";
            public override string Description { get; } = "Mock side description";

            private decimal _price = 1.99m;
            public decimal Price
            {
                get { return _price; }
                set
                {
                    if (_price != value)
                    {
                        _price = value;
                        OnPropertyChanged(nameof(Price));
                    }
                }
            }

            private uint _calories = 100;
            public uint Calories
            {
                get { return _calories; }
                set
                {
                    if (_calories != value)
                    {
                        _calories = value;
                        OnPropertyChanged(nameof(Calories));
                    }
                }
            }

            private IEnumerable<string> _instructions = new List<string> { "Mock preparation" };
            public override IEnumerable<string> Instructions
            {
                get { return _instructions; }
            }
            public Size Size
            {
                get => _size;
                set
                {
                    if (_size != value)
                    {
                        _size = value;
                        OnPropertyChanged(nameof(Size));
                        OnPropertyChanged(nameof(Price));
                        OnPropertyChanged(nameof(Calories));
                        OnPropertyChanged(nameof(Instructions));
                    }
                }
            }

            public MockSide()
            {
                Size = Size.Small;
                OnPropertyChanged(nameof(Size));
            }

            public event PropertyChangedEventHandler? PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        internal class MockDrink : INotifyPropertyChanged
        {
            public MockDrink()
            {
                DrinkSize = Size.Small;
                OnPropertyChanged(nameof(DrinkSize));
            }
            /// <summary>
            /// Name property
            /// </summary>
            public string Name { get; }
            /// <summary>
            /// Description property
            /// </summary>
            ///
            public event PropertyChangedEventHandler? PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            public string Description { get; }
            private uint _calories = 100;
            private decimal _price = 1.99m;
            private Size _drinkSize;

            public decimal Price
            {
                get { return _price; }
                set
                {
                    if (_price != value)
                    {
                        _price = value;
                        OnPropertyChanged(nameof(Price));
                    }
                }
            }

            public uint Calories
            {
                get { return _calories; }
                set
                {
                    if (_calories != value)
                    {
                        _calories = value;
                        OnPropertyChanged(nameof(Calories));
                    }
                }
            }

            public Size DrinkSize
            {
                get => _drinkSize;
                set
                {
                    if (_drinkSize != value)
                    {
                        _drinkSize = value;
                        OnPropertyChanged(nameof(DrinkSize));
                        OnPropertyChanged(nameof(Price));
                        OnPropertyChanged(nameof(Calories));
                        OnPropertyChanged(nameof(Instructions));
                    }
                }
            }

            public IEnumerable<string> Instructions { get; } = new List<string> { "Mock preparation information" };

            public override string ToString()
            {
                return Name;
            }
        }

        [Theory]
        [InlineData(Size.Kids, "Size")]
        [InlineData(Size.Medium, "Size")]
        [InlineData(Size.Large, "Size")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Kids, "Calories")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Kids, "Instructions")]
        [InlineData(Size.Medium, "Instructions")]
        [InlineData(Size.Large, "Instructions")]
        public void NotifySizeChangeSide(Size size, string propertyName)
        {
            MockSide mockSide = new MockSide();
            Assert.PropertyChanged(mockSide, propertyName, () => {mockSide.Size = size;});
        }

        [Theory]
        [InlineData(Size.Kids, "DrinkSize")]
        [InlineData(Size.Medium, "DrinkSize")]
        [InlineData(Size.Large, "DrinkSize")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Kids, "Calories")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Kids, "Instructions")]
        [InlineData(Size.Medium, "Instructions")]
        [InlineData(Size.Large, "Instructions")]
        public void NotifySizeChangeDrink(Size size, string propertyName)
        {
            MockDrink d = new();
            Assert.PropertyChanged(d, propertyName, () => {d.DrinkSize = size;});
        }
    }
}
