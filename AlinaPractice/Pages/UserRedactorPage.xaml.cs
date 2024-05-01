using AlinaPractice.Combiners;
using AlinaPractice.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AlinaPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserRedactorPage.xaml
    /// </summary>
    public partial class UserRedactorPage : Page
    {
        private UserDTO _user;
        public UserRedactorPage(UserDTO user)
        {
            InitializeComponent();
            _user = user;
            var db = IHelper.GetContext();
            var roles =  db.Posts.ToList();

            roles.ForEach(x =>
            {
                cb_post.Items.Add(x.Appellation);
            });
            cb_post.SelectedIndex = 0;

        }


        public bool Valid()
        {
            if (string.IsNullOrWhiteSpace(SurnameTextBox.Text) || SurnameTextBox.Text.Length >= 30 || SurnameTextBox.Text.Length < 5)
            {
                MessageBox.Show("Фамилия обязательна к заполнению");
                return false;
            }

            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || NameTextBox.Text.Length >= 30 || NameTextBox.Text.Length <= 3)
            {
                MessageBox.Show("Имя обязательно к заполнению");
                return false;
            }

            if (string.IsNullOrWhiteSpace(PatronymicTextBox.Text) || PatronymicTextBox.Text.Length >= 30 || PatronymicTextBox.Text.Length < 5)
            {
                MessageBox.Show("Отчетсво обязательно к заполнению");
                return false;
            }

            string pattern = @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)";
            if (string.IsNullOrWhiteSpace(Phone.Text) || !Regex.IsMatch(Phone.Text, pattern))
            {
                MessageBox.Show("Номер телефона обязателен к заполнению");
                return false;
            }

            if (string.IsNullOrWhiteSpace(LoginTextBox.Text) || LoginTextBox.Text.Length < 3)
            {
                MessageBox.Show("Логин обязателен к заполнению");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text) || PasswordTextBox.Text.Length < 3)
            {
                MessageBox.Show("Пароль обязательно к заполнению");
                return false;
            }

            if (string.IsNullOrWhiteSpace(PatronymicTextBox.Text) || PatronymicTextBox.Text.Length >= 30 || PatronymicTextBox.Text.Length < 5)
            {
                MessageBox.Show("Отчетсво обязательно к заполнению");
                return false;
            }
            return true;
        }

        public void Clear()
        {
            var textBoxesToRemove = infos.Children.OfType<TextBox>();
            foreach (TextBox textBox in textBoxesToRemove)
            {
                textBox.Text = string.Empty;
            }
            var datepickersToRemove = infos.Children.OfType<DatePicker>();
            foreach(DatePicker datepicker in datepickersToRemove)
            {
                datepicker.SelectedDate = DateTime.Now;
            }
        }
        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Valid())
            {
                return;
            }

            using (var db = IHelper.GetContext())
            {
                var employee = await db.Employees.FindAsync((long)_user.Id);

                employee.Birthday = DateOnly.FromDateTime(BirthdayDatePicker.SelectedDate.Value);
                employee.Surname = SurnameTextBox.Text;
                employee.Name = NameTextBox.Text;
                employee.Patronymic = PatronymicTextBox.Text;
                employee.PhoneNumber = Phone.Text;
                employee.DEmployment = DateOnly.FromDateTime(EmploymentDate.SelectedDate.Value);
                employee.Passport = Passport.Text;
                employee.IdPost = cb_post.SelectedIndex+1;

                var account = await db.Accounts.Where(x => x.IdEmployee == employee.IdEmployee).FirstOrDefaultAsync();
                if (account != null)
                {
                    account.Login = LoginTextBox.Text;
                    account.Password = PasswordTextBox.Text;
                }
                else
                {
                    var Newaccount = new Account
                    {
                        IdEmployee = employee.IdEmployee,
                        IdPost = employee.IdPost,
                        Login = LoginTextBox.Text,
                        Password = PasswordTextBox.Text,
                    };
                    await db.Accounts.AddAsync(Newaccount);
                }
                await db.SaveChangesAsync();

            }
            MessageBox.Show("Вы успешно обновили пользователя");
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Valid())
            {
                return;
            }

            var employee = new Employee
            {
                Surname = SurnameTextBox.Text,
                Name = NameTextBox.Text,
                Patronymic = PatronymicTextBox.Text,
                Birthday = DateOnly.FromDateTime(BirthdayDatePicker.SelectedDate.Value),
                Passport = Passport.Text,
                PhoneNumber = Phone.Text,
                DEmployment = DateOnly.FromDateTime(EmploymentDate.SelectedDate.Value),
                IdPost = cb_post.SelectedIndex+1
            };

            using (var db = IHelper.GetContext())
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();

                var acc = new Account
                {
                    IdPost = cb_post.SelectedIndex + 1,
                    IdEmployee = employee.IdEmployee,
                    Login = LoginTextBox.Text,
                    Password = PasswordTextBox.Text,
                };
                await db.Accounts.AddAsync(acc);
                await db.SaveChangesAsync();
                MessageBox.Show("Вы добавили нового сотрудника");
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(_user.Id == 0)
            {
                DeleteButton.IsEnabled = false; 
                return;
            }
            using (var db = IHelper.GetContext())
            {
                var user = await db.Employees.Where(x => x.IdEmployee == _user.Id).Include(x=>x.IdPostNavigation).FirstOrDefaultAsync();

                var account = await db.Accounts.Where(x => x.IdEmployee == user.IdEmployee).FirstOrDefaultAsync();

                if (user == null)
                {
                    return;
                }

                infos.DataContext = user;
                cb_post.Text = user.IdPostNavigation.Appellation;
                if (account != null)
                {
                    LoginTextBox.Text = account.Login;
                    PasswordTextBox.Text = account.Password;
                }
                BirthdayDatePicker.SelectedDate = DateTime.Parse(user.Birthday.Value.ToString());
                EmploymentDate.SelectedDate = DateTime.Parse(user.DEmployment.Value.ToString());
               

            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = IHelper.GetContext())
            {
                var acc = await db.Accounts.Where(x => x.IdEmployee == _user.Id).ExecuteDeleteAsync();
                var execute =  await db.Employees.Where(x=>x.IdEmployee == _user.Id).ExecuteDeleteAsync();
                if (execute != 0)
                {
                    Clear();
                    MessageBox.Show("Пользователь удалён");
                }
                else
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
        }
    }
}
