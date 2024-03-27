using BuildYourBowl.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BuildYourBowl.Data.Sides;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for KidsMealControl.xaml
    /// </summary>
    public partial class KidsMealControl : UserControl
    {
        public KidsMealControl()
        {
            InitializeComponent();
        }

        public void FriesSideControl(object sender, RoutedEventArgs e)
        {
            if (DataContext is KidsMeal list && sender is RadioButton Rbutton)
            {
                FriesControlDisplay.DataContext = list.SideChoice;

                /*
                if (Rbutton.Name == "RB_Fries" || Rbutton.IsChecked == true)
                {
                    Fries f = new Fries();
                    FriesControlDisplay.DataContext = menuItem;
                    FriesControlDisplay.Visibility = Visibility.Visible;

                    list.Add(f);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(f));

                }
                */
            }
        }
    }
}
