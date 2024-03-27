using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// An interface indicating a menu item
    /// </summary>
    public interface IMenuItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// Name of this menu item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Descirption of this menu item
        /// </summary>
        string Description { get; }
        
        /// <summary>
        /// Price of this menu item
        /// </summary>
        decimal Price { get; }
        
        /// <summary>
        /// Calories in this menu item
        /// </summary>
        uint Calories { get; }
        
        /// <summary>
        /// Instructions to prepare this menu item
        /// </summary>
        IEnumerable<string> Instructions { get; }

    }
}
