using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BuildYourBowl.Data;

namespace BuildYourBowl.PointOfSale
{
    public class CustomizeItemArgs : RoutedEventArgs
    {
        public IMenuItem Item { get; set; }
        public CustomizeItemArgs(IMenuItem menuItem)
        {
            Item = menuItem;
        }
    }
}
