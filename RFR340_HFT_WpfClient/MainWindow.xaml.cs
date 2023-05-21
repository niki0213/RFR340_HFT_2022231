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

namespace RFR340_HFT_WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Book_Button_Click(object sender, RoutedEventArgs e)
        {
            BookWindow bw = new BookWindow();
            bw.Show();
        }

        private void Customer_Button_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow pw = new PersonWindow();
            pw.Show();
        }

        private void Publisher_Button_Click(object sender, RoutedEventArgs e)
        {
            PublisherWindow puw = new PublisherWindow();
            puw.Show();
        }
        private void Rent_Button_Click(object sender, RoutedEventArgs e)
        {
            RentWindow rw = new RentWindow();
            rw.Show();
        }
        private void NonCrud_Button_Click(object sender, RoutedEventArgs e)
        {
            NonCrudWindow nc = new NonCrudWindow();
            nc.Show();
        }
    }
}
