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
using System.IO;

namespace DiningRoomApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализация окна
        /// </summary>
        List<string> accounts = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            downloadAccounts();
        }
        /// <summary>
        /// Метод, отвечающий за загрузку пользователей из текстового файла
        /// </summary>
        private void downloadAccounts()
        {
            StreamReader stream = new StreamReader("../../Resources/LoginAndPassword.txt",Encoding.GetEncoding(1251));
            while (!stream.EndOfStream)
            {
                accounts.Add(stream.ReadLine());
            }

        }
        //Создание счетчика
        private int counter = 0;
        /// <summary>
        /// Кнопка "Авторизоваться
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if (counter == 3)
            {
                Ok.IsEnabled = false;
                LoginTextBox.IsEnabled = false;
                LoginTextBox.Text = "";
                PasswordBox.Password = "";
                TextBoxHiddenPassword.Text = "";
                MessageBox.Show("«Вы использовали три попытки входа в систему." +
                    "Через 15 секунд у Вас будет возможность повторить попытку входа в систему!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                await Task.Run(async () =>
                {
                    await Task.Delay(15000);
                });
                counter = 0;
                LoginTextBox.IsEnabled = true;
                Ok.IsEnabled = true;
                return;
            }

            authorize();
        }
        /// <summary>
        /// Процесс аторизации
        /// </summary>
        private void authorize()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (LoginTextBox.Text == accounts[i])
                {
                    if (PasswordBox.Password == accounts[i + 1] || TextBoxHiddenPassword.Text == accounts[i + 1])
                    {
                        MessageBox.Show("Авторизация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        if(TextBoxHiddenPassword.Text == "Менеджер" || PasswordBox.Password == "Менеджер")
                        {
                            WindowMenu windowMenu = new WindowMenu();
                            windowMenu.Show();
                            Close();
                            return;
                        }
                        else
                        {
                            WindowAdmin windowAdmin = new WindowAdmin();
                            windowAdmin.Show();
                            Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль не верен! Пожалуйста повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if (PasswordBox.Password == accounts[i] || TextBoxHiddenPassword.Text == accounts[i])
                {
                    MessageBox.Show("Логин не верен! Пожалуйста повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            MessageBox.Show("Логин и пароль не верен! Пожалуйста повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        /// <summary>
        /// Возможность просмотра пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxPassword.IsChecked == true)
            {
                TextBoxHiddenPassword.Text = PasswordBox.Password;
                TextBoxHiddenPassword.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Hidden;
            }
            else
            {
                PasswordBox.Password = TextBoxHiddenPassword.Text;
                TextBoxHiddenPassword.Visibility = Visibility.Hidden;
                PasswordBox.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Манипуляции с текстовым полем Логина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Запрет возможности вводить пароль при отсутстивии логина
            if (LoginTextBox.Text != "")
            {
                PasswordBox.IsEnabled = true;
                TextBoxHiddenPassword.IsEnabled = true;
                checkBoxPassword.IsEnabled = true;
            }
            else 
            {
                PasswordBox.Password = "";
                TextBoxHiddenPassword.Text = "";
                checkBoxPassword.IsChecked = false;
                TextBoxHiddenPassword.Visibility = Visibility.Hidden;
                PasswordBox.Visibility = Visibility.Visible;
                PasswordBox.IsEnabled = false;
                checkBoxPassword.IsEnabled = false;
            }
        }
    }
}
