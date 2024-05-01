using AlinaPractice.Combiners;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = IHelper.GetContext())
            {
                var users = await db.Employees.Include(x => x.IdPostNavigation).ToListAsync();
                
                
            var usersDTO = users.Select(x =>
            {
                return new UserDTO
                {
                    Id = (int)x.IdEmployee,
                    Fio = $"{x.Surname} {x.Name} {x.Patronymic}",
                    Role = x.IdPostNavigation.Appellation,
                };
            });
            LViewUsers.ItemsSource = usersDTO;
            }
        }

        private void LViewUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = (sender as ListView).SelectedItem as UserDTO;
            NavigationService.Navigate(new UserRedactorPage(info));
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserRedactorPage(new UserDTO()));
        }
    }
}
