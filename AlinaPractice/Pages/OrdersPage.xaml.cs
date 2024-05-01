using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AlinaPractice.Combiners;
namespace AlinaPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrdersView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = IHelper.GetContext())
            {
                var orders = await db.Orders
                    .ToListAsync();


                var ordersDTOList = orders.Select(x =>
                {
                    var app = db.Applications.Find(x.IdApplications);
                    var med = db.Medicaments.Find(app.IdMedicament);
                    var del = db.Deliveries.Find(x.IdDelivery);
                    var client = db.Clients.Find(x.IdClient);
                    return new OrderDTO
                    {
                        Id = (int)x.IdOrder,
                        Application = $"{med.TradeName} {app.Quantity} {app.Cost}",
                        Delivery = $"{del.Date} {del.Address}",
                        Status = $"{x.IdStatusNavigation.Appellation}",
                        Client = $"{client.Surname} {client.Name} {client.Patronymic}"
                    };
                });
                OrdersView.ItemsSource = ordersDTOList;
            }
        }
    }
}
