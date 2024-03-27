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
        public event EventHandler<CustomizeItemArgs>? MenuItemEvent;
        public MenuItemSelectionControl()
        {
            InitializeComponent();

        }

        // Event handler for menu item buttons
        public void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list && sender is Button button)
            {
                if (button.Name == "CustomBowl")
                {
                    Bowl b = new Bowl();
                    list.Add(b);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(b));

                }
                else if (button.Name == "CarnitasBowl")
                {
                    CarnitasBowl cb = new CarnitasBowl();
                    list.Add(cb);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(cb));

                }
                else if (button.Name == "GreenChickenBowl")
                {
                    GreenChickenBowl gb = new GreenChickenBowl();
                    list.Add(gb);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(gb));

                }
                else if (button.Name == "SpicySteakBowl")
                {
                    SpicySteakBowl sb = new SpicySteakBowl();
                    list.Add(sb);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(sb));

                }

                else if (button.Name == "CustomNachos")
                {
                    Nachos n = new Nachos();
                    list.Add(n);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(n));

                }
                else if (button.Name == "ClassicNachos")
                {
                    ClassicNachos cn = new ClassicNachos();
                    list.Add(cn);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(cn));

                }
                else if (button.Name == "ChickenFajitaNachos")
                {
                    ChickenFajitaNachos fn = new ChickenFajitaNachos();
                    list.Add(fn);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(fn));

                }
                else if (button.Name == "Fries")
                {
                    Fries f = new Fries();
                    list.Add(f);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(f));

                }
                else if (button.Name == "RefriedBeans")
                {
                    RefriedBeans rb = new RefriedBeans();
                    list.Add(rb);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(rb));
                }
                else if (button.Name == "StreetCorn")
                {
                    StreetCorn sc = new StreetCorn();
                    list.Add(sc);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(sc));
                }

                else if (button.Name == "Horchata")
                {
                    Horchata h = new Horchata();
                    list.Add(h);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(h));
                }
                else if (button.Name == "Milk")
                {
                    Milk m = new Milk();
                    list.Add(m);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(m));
                }
                else if (button.Name == "AguaFresca")
                {
                    AguaFresca af = new AguaFresca();
                    list.Add(af);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(af));
                }

                else if (button.Name == "ChickenNuggetsMeal")
                {
                    ChickenNuggetsMeal cm = new ChickenNuggetsMeal();
                    list.Add(cm);
                    MenuItemEvent?.Invoke(this, new CustomizeItemArgs(cm));

                }
                else if (button.Name == "CornDogBitesMeal") list.Add(new CornDogBitesMeal());
                else if (button.Name == "SlidersMeal") list.Add(new SlidersMeal());
            }

        }
    }
}
