using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// representing an order containing multiple customizable menu items
    /// </summary>
    public class Order : ICollection<IMenuItem>
    {
        /*
        /// <summary>
        /// Total price of all items in order
        /// </summary>
        public decimal Subtotal { get; }

        /// <summary>
        /// The % rate of sales tax as a decimal
        /// </summary>
        public decimal TaxRate { get; set; } = 0.0915m;

        /// <summary>
        /// Total tax on the order
        /// </summary>
        public decimal Tax => Subtotal * TaxRate;

        /// <summary>
        /// Total price of the order including the sales tax
        /// </summary>
        public decimal Total => Subtotal + Tax;

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(IMenuItem item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IMenuItem item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IMenuItem> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IMenuItem item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        */

        //===================
        
        
        private readonly List<IMenuItem> items = new List<IMenuItem>();

        /// <summary>
        /// Gets the subtotal of the order.
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0;

                foreach (var item in items)
                {
                    subtotal += item.Price;
                }
                return subtotal;
            }
        }

        /// <summary>
        /// Gets or sets the sales tax rate for the order.
        /// </summary>
        public decimal TaxRate { get; set; } = 0.0915m;

        /// <summary>
        /// Gets the tax for the order.
        /// </summary>
        public decimal Tax => Subtotal * TaxRate;

        /// <summary>
        /// Gets the total amount for the order (subtotal + tax).
        /// </summary>
        public decimal Total => Subtotal + Tax;

        public int Count => items.Count;

        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item to the order.
        /// </summary>
        public void Add(IMenuItem item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Removes all items from the order.
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Determines whether the order contains a specific item.
        /// </summary>
        public bool Contains(IMenuItem item)
        {
            return items.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the order to an array, starting at a particular array index.
        /// </summary>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific item from the order.
        /// </summary>
        public bool Remove(IMenuItem item)
        {
            return items.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of items in the order.
        /// </summary>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
