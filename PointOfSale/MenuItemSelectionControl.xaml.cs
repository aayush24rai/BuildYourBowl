using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using BuildYourBowl.Data;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Drinks;


namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        // Event handler for menu item buttons
        public void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list && sender is Button button)
            {
                if (button.Name == "CustomBowl") list.Add(new Bowl());
                else if (button.Name == "CarnitasBowl") list.Add(new CarnitasBowl());
                else if (button.Name == "GreenChickenBowl") list.Add(new GreenChickenBowl());
                else if (button.Name == "SpicySteakBowl") list.Add(new SpicySteakBowl());

                else if (button.Name == "CustomNachos") list.Add(new Nachos());
                else if (button.Name == "ClassicNachos") list.Add(new ClassicNachos());
                else if (button.Name == "ChickenFajitaNachos") list.Add(new ChickenFajitaNachos());

                else if (button.Name == "Fries") list.Add(new Fries());
                else if (button.Name == "RefriedBeans") list.Add(new RefriedBeans());
                else if (button.Name == "StreetCorn") list.Add(new StreetCorn());

                else if (button.Name == "Horchata") list.Add(new Horchata());
                else if (button.Name == "Milk") list.Add(new Milk());
                else if (button.Name == "AguaFresca") list.Add(new AguaFresca());

                else if (button.Name == "ChickenNuggetsMeal") list.Add(new ChickenNuggetsMeal());
                else if (button.Name == "CornDogBitesMeal") list.Add(new CornDogBitesMeal());
                else if (button.Name == "SlidersMeal") list.Add(new SlidersMeal());
            }

        }        
    }
}
