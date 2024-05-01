using AlinaPractice.Combiners;
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
    /// Логика взаимодействия для DeliviriesPage.xaml
    /// </summary>
    public partial class DeliviriesPage : Page
    {
        public DeliviriesPage()
        {
            InitializeComponent();
        }

        private void AddDelivery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeliveryView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = IHelper.GetContext())
            {
                var orders = await db.Deliveries
                    .ToListAsync();


                var deliveries = orders.Select( x =>
                {
                    var status =  db.Statuses.Find(x.IdStatus);
                    var car =  db.Transports.Find(x.IdTranspost);
                    var tecnic =  db.Technics.Find(x.IdTechnic);
                    var staff =  db.DeliveryStaffs.Find(x.IdDeliveryStaff);

                    var driver = db.Employees.Where(x => x.IdEmployee == staff.Driver).FirstOrDefault();
                    return  new DeliveryDTO
                    {
                        Id = (int)x.IdDelivery,
                        Date = x.Date,
                        Address = x.Address,
                        Status = status.Appellation,
                        Car = car.Appellation,
                        Technic = tecnic.Appellation,
                        DeliveryStaff = $"{driver.Surname} {driver.Name} {driver.Patronymic}"
                    };  
                });
                DeliveryView.ItemsSource = deliveries;
            }
        }
    }
}
