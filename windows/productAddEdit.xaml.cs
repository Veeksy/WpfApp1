using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ProductAddEdit : Window
    {
        JewelryEntities db = new JewelryEntities();

        products products; 

        public ProductAddEdit(int id)
        {
            InitializeComponent();
            CategoryTb.ItemsSource = db.category.ToList();
            CategoryTb.DisplayMemberPath = "category1";
            CategoryTb.SelectedValuePath = "id";

            if (id == 0)
            {
                products = new products();
            }
            else
            {
                products = db.products.Where(x=>x.id == id).FirstOrDefault();
                nameTb.Text = products.name;

                priceTb.Text = products.Price.ToString();
                CategoryTb.SelectedValue = products.idCategory;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                products.name = nameTb.Text;
                products.Price = Convert.ToInt32(priceTb.Text);
                products.idCategory = (int)CategoryTb.SelectedValue;
                db.products.AddOrUpdate(products);
                db.SaveChanges();
                MessageBox.Show("Сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
            this.Close();
        }
    }
}
