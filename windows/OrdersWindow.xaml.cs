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
using WpfApp1.Entity;

namespace WpfApp1.windows
{
    /// <summary>
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        List<productsView> productsViews;
        public OrdersWindow(List<productsView> productsViews)
        {
            InitializeComponent();
            this.productsViews = productsViews;
            addProductsDgv.ItemsSource = productsViews;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
            this.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

            List<orders> orders = new List<orders>();
            foreach (var item in productsViews)
            {
                orders.Add(new orders { idProduct = item.Id });
            }
        }
    }
}
