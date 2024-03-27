using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BuildYourBowl.Data;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data;



namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new Order();

            MenuItemDisplay.MenuItemEvent += HandleCustomEvent;
            OrderSummaryDisplay.EditItemEvent += HandleCustomEvent;

        }

        public void CancelOrderClick (object sender, RoutedEventArgs e)
        {
            DataContext = new Order();
        }

        public void BackToMenuClick(object sender, RoutedEventArgs e)
        {
            MenuItemDisplay.Visibility = Visibility.Visible;
            EntreeControlDisplay.Visibility = Visibility.Hidden;
            FriesControlDisplay.Visibility = Visibility.Hidden;
            RefriedBeansControlDisplay.Visibility = Visibility.Hidden;
            StreetCornControlDisplay.Visibility = Visibility.Hidden;
            HorchataControlDisplay.Visibility = Visibility.Hidden;
            MilkControlDisplay.Visibility = Visibility.Hidden;
            AguaFrescaControlDisplay.Visibility = Visibility.Hidden;


        }

        private void HandleCustomEvent(object? sender, CustomizeItemArgs? e)
        {           
            //CHECK FOR DIFFERENT IMenuItem to switch different user controls
            IMenuItem menuItem = e!.Item;

            BackToMenuClick(sender!, e);

            switch (e?.Item)
            {
                case CarnitasBowl:
                    EntreeControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    EntreeControlDisplay.Visibility = Visibility.Visible;
                    break;

                case GreenChickenBowl:
                    EntreeControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    EntreeControlDisplay.Visibility = Visibility.Visible;
                    break;

                case SpicySteakBowl:
                    EntreeControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    EntreeControlDisplay.Visibility = Visibility.Visible;
                    break;

                case Bowl:

                    EntreeControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    EntreeControlDisplay.Visibility = Visibility.Visible;
                    break;

                case ChickenFajitaNachos:
                    EntreeControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    EntreeControlDisplay.Visibility = Visibility.Visible;
                    break;

                case ClassicNachos:
                    EntreeControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    EntreeControlDisplay.Visibility = Visibility.Visible;
                    break;

                case Nachos:
                    EntreeControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    EntreeControlDisplay.Visibility = Visibility.Visible;
                    break;

                case Fries:
                    FriesControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    FriesControlDisplay.Visibility = Visibility.Visible;
                    break;

                case StreetCorn:
                    StreetCornControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    StreetCornControlDisplay.Visibility = Visibility.Visible;
                    break;

                case RefriedBeans:
                    RefriedBeansControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    RefriedBeansControlDisplay.Visibility = Visibility.Visible;
                    break;

                case Horchata:
                    HorchataControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    HorchataControlDisplay.Visibility = Visibility.Visible;
                    break;

                case Milk:
                    MilkControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    MilkControlDisplay.Visibility = Visibility.Visible;
                    break;

                case AguaFresca:
                    AguaFrescaControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    AguaFrescaControlDisplay.Visibility = Visibility.Visible;
                    break;
                
                case ChickenNuggetsMeal:
                    KidsMealControlDisplay.DataContext = menuItem;
                    MenuItemDisplay.Visibility = Visibility.Hidden;
                    KidsMealControlDisplay.Visibility = Visibility.Visible;
                    KidsMealControlDisplay.RB_Fries.IsChecked = true;
                   // KidsMealControlDisplay.FriesControlDisplay.DataContext = (menuItem as KidsMeal).SideChoice;
                    break;

                default:
                    break;
            }

            
            
        }
    }
}
