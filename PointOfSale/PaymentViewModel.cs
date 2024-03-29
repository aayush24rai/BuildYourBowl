using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BuildYourBowl.Data;
using System.Diagnostics;

namespace BuildYourBowl.PointOfSale
{
    public class PaymentViewModel : INotifyPropertyChanged
    {
        

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void HandleItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paid)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
        }

        public PaymentViewModel(Order order)
        {
            _order = order;
            _paid = order.Total;
            order.PropertyChanged += HandleItemPropertyChanged;
        }

        public Order? _order { get; init; }

        public decimal Subtotal => _order!.Subtotal;
        public decimal Tax => _order!.Tax;
        public decimal Total => _order!.Total;

        public bool IsValid = true;
        public string IsValidS
        {
            get
            {
                if (IsValid) return "True";
                else return "False";
            }
        }

        public string InValidText
        {
            get
            {
                if (IsValid) return "";
                else return "Insufficient Funds";
            }
        }

        private decimal _paid; //HOW TO SET THIS TO TOTAL??
        public decimal Paid
        {
            get => _paid;

            set
            {
                _paid = (decimal)value;
                IsValid = true;
                OnPropertyChanged(nameof(Paid));
                OnPropertyChanged(nameof(Change));
                OnPropertyChanged(nameof(IsValidS));
                OnPropertyChanged(nameof(InValidText));

                if (value<Total)
                {
                    //_paid = Total;
                    IsValid = false;
                    OnPropertyChanged(nameof(Paid));
                    OnPropertyChanged(nameof(Change));
                    OnPropertyChanged(nameof(IsValidS));
                    OnPropertyChanged(nameof(InValidText));
                    throw new ArgumentException("Insufficient Funds");
                }
            }
        }

        public decimal Change
        {
            get
            {
                if (Paid < Total) return 0.00m;
                return Paid - Total;
            }
        }

        public string Receipt
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("Order Number: " + _order!.Number+"\n");

                sb.Append(_order!.PlacedAt + "\n");
                sb.AppendLine();

                foreach (IMenuItem item in _order)
                {
                    sb.AppendLine(item.Name + "  $" + item.Price);
                    foreach (string s in item.Instructions)
                    {
                        sb.AppendLine("\t" + s);
                    }
                    sb.AppendLine();
                }

                sb.Append("Subtotal: $" + Subtotal + "\n");

                sb.Append("Tax: $" + Tax + "\n");

                sb.Append("Total: $" + Total + "\n");
                sb.AppendLine();

                sb.Append("Paid: $" + Paid + "\n");

                sb.Append("Change: $" + Change + "\n");

                sb.Append("-----------------" + "\n");

                return sb.ToString();
            }
        }
        


    }
}
