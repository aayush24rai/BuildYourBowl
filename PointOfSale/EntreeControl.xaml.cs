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
using BuildYourBowl.Data;
using BuildYourBowl.Data.Entrees;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for EntreeControl.xaml
    /// </summary>
    public partial class EntreeControl : UserControl
    {
        public EntreeControl()
        {
            InitializeComponent();
        }
        /*
        public void LoadChoices()
        {
            for (int i = itemsStack.Children.Count - 1; i >= 0; i--)
            {
                if (itemsStack.Children[i] is CheckBox)
                {
                    itemsStack.Children.RemoveAt(i);
                }
            }

            if (DataContext is Entree entree)
            {
                
                
                
                foreach(IngredientItem ingredientItem in entree.AdditionalIngredients.Values)
                {
                    CheckBox box = new CheckBox();
                    box.DataContext = ingredientItem;
                    Binding binding = new Binding();
                    binding.Source = ingredientItem;
                    binding.Path = new PropertyPath(nameof(ingredientItem.Included));
                    binding.Mode = BindingMode.TwoWay;
                    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, binding);

                    TextBlock block = new TextBlock();
                    ///block.DataContext = ingredientItem;
                    block.Text = ingredientItem.Name;
                    box.Content = block;

                    itemsStack.Children.Add(box);
                }

            }
        }
        */
    }
}
