using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using StolyarovaDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolyarovaDemo
{
    public partial class MainWindow : Window
    {
        public List<User> users = DBHelper.context.Users.Include(x=> x.Role).ToList();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var foundUser = users.FirstOrDefault(x => x.UserLogin == LoginTextBox.Text);

            if (foundUser != null) 
            {
                var correctPassword = foundUser.UserPassword == PasswordTextBox.Text;
                if (correctPassword && foundUser.RoleId == 1)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                }
                else
                {
                    Errormessage();
                }

            }
            else
            {
                Errormessage();

            }
        }
        private async void Errormessage()
        {
            var errorBox = MessageBoxManager
                    .GetMessageBoxStandard("Ошибка", "Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные",
                    MsBox.Avalonia.Enums.ButtonEnum.Ok);

            var result = await errorBox.ShowAsync();
        }
    }
}