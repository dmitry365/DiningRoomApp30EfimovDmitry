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

namespace DiningRoomApp
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        /// <summary>
        /// Инициализация окна
        /// </summary>
        public WindowAdmin()
        {
            InitializeComponent();
            MainFrame.Navigate(new PageBreakfastAdmin());
            Manager.MainFrame = MainFrame;
        }
        /// <summary>
        /// Выход из пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
        /// <summary>
        /// Переход на страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Click_Breakfast(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageBreakfastAdmin());
        }
        /// <summary>
        /// Переход на страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Click_Lunch(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageLunchAdmin());
        }
        /// <summary>
        /// Переход на страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Click_Dinner(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageDinnerAdmin());
        }
    }
}
