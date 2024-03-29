using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        public EventHandler<RoutedEventArgs>? NewMenu;
        public PaymentControl()
        {
            InitializeComponent();
        }

        public void FinalizePaymentClick(object? sender, RoutedEventArgs e)
        {
            if (DataContext is PaymentViewModel pvm /*&& sender is Button button*/)
            {
                File.AppendAllText("Receipt.txt", pvm.Receipt);
                
                /*
                using (StreamReader input = new StreamReader("Receipt.txt"))
                {
                    using (StreamWriter output = new StreamWriter("D:\\OneDrive - Kansas State University\\Classes\\Spring 2024\\CIS 400\\build-your-bowl-aayush24rai\\MyReceipt.txt"))
                    {
                        //int count = 0;
                        while (!input.EndOfStream)
                        {
                            /*
                            // Because input is not at the end of the stream, its ReadLine
                            // method won't return null.
                            
                            string line = input.ReadLine()!;
                            count++;
                            output.Write(count);
                            output.Write('\t');   // The tab character
                            

                            output.WriteLine(pvm.Receipt);
                        }
                    }
                }*/

                MessageBox.Show("Receipt printed, click 'OK' to start a new order");

                NewMenu?.Invoke(this, new RoutedEventArgs());
                
            }

        }
    }
}
