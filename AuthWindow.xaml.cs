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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        JewelryEntities db = new JewelryEntities();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = db.users.Where(x=>x.login==loginTb.Text && x.password == passwordTb.Password).FirstOrDefault();
            if (user != null) {
                MainWindow mw = new MainWindow();
                CurrentUser.Role = user.role;
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
    }
}
