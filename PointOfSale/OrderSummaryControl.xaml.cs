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
using System.Windows.Shapes;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        public event EventHandler<CustomizeItemArgs>? EditItemEvent;

        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        public void RemoveClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order && sender is Button button)
            {
                if (button.DataContext is IMenuItem menuItem)
                {
                    order.Remove(menuItem);
                    EditItemEvent?.Invoke(this, new CustomizeItemArgs(menuItem));
                }
            }
        }

        public void EditClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && DataContext is Order order)
            {
                if (button.DataContext is IMenuItem menuItem)
                {
                    EditItemEvent?.Invoke(this, new CustomizeItemArgs(menuItem));
                }
            }
        }

    }
}
