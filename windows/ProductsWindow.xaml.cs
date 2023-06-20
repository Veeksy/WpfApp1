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
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        JewelryEntities db = new JewelryEntities();
        List<productsView> products = new List<productsView>();

        List<productsView> addedProduct = new List<productsView>();


        public ProductsWindow()
        {
            InitializeComponent();
            products = db.products.Join(db.category, x=>x.idCategory, y=>y.id, (x, y) => new productsView()
            {
                Id = x.id,
                Name = x.name,
                Category = y.category1,
                Price = x.Price,
            }).ToList();
            productsDGV.ItemsSource = products;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            ProductAddEdit addEdit = new ProductAddEdit(0);
            addEdit.Show();
            this.Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            productsView selectedPart = productsDGV.SelectedItem as productsView;
            if (selectedPart != null)
            {
                ProductAddEdit addEdit = new ProductAddEdit(selectedPart.Id);
                addEdit.Show();
                this.Close();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            productsView selectedPart = productsDGV.SelectedItem as productsView;
            if (selectedPart != null)
            {
               var _product = db.products.Where(x=>x.id == selectedPart.Id).FirstOrDefault();
                if (_product != null)
                {
                    db.products.Remove(_product);
                    db.SaveChanges();
                    products = db.products.Join(db.category, x => x.idCategory, y => y.id, (x, y) => new productsView()
                    {
                        Id = x.id,
                        Name = x.name,
                        Category = y.category1,
                        Price = x.Price,
                    }).ToList();
                    productsDGV.ItemsSource = products;
                }
            }
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            productsView selectedPart = productsDGV.SelectedItem as productsView;
            if (selectedPart != null)
            {
                addedProduct.Add(selectedPart);
            }
        }

        private void CreateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow(addedProduct);
            ordersWindow.Show();
            this.Close();
        }
    }
}
