using Microsoft.EntityFrameworkCore;
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

namespace AlinaPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        public Auto()
        {
            InitializeComponent();
        }
        private void AutoButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Не все поля заплолнены");
                return;
            }

            

            using (var db = IHelper.GetContext())
            {
                var user = db.Accounts.Where(x => x.Login == Login.Text && x.Password == Password.Password).Include(p => p.IdPostNavigation).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }

                switch (user.IdPost)
                {
                    case 1:
                        MessageBox.Show(user.IdPostNavigation.Appellation);
                        NavigationService.Navigate(new Admin());
                        break;
                    case 2:
                        MessageBox.Show(user.IdPostNavigation.Appellation);
                        NavigationService.Navigate(new OrderPage());
                        break;
                    case 4:
                        MessageBox.Show(user.IdPostNavigation.Appellation);
                        NavigationService.Navigate(new DeliviriesPage());
                        break;
                }
            }
        }
    }
}
