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
    /// Логика взаимодействия для PageDinnerAdmin.xaml
    /// </summary>
    public partial class PageDinnerAdmin : Page
    {
        /// <summary>
        /// Инициализация окна
        /// </summary>
        public PageDinnerAdmin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка добавления блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Dish.Text == "" || Price.Text == "")
            {
                MessageBox.Show("Вы не заполнили все данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                StreamWriter SW;
                SW = new StreamWriter("../../Resources/AdditionalDishesDinner.txt");
                SW.WriteLine(Dish.Text);
                SW.Close();
                SW = new StreamWriter("../../Resources/PriceDishesDinner.txt");
                SW.WriteLine(Price.Text);
                SW.Close();
                MessageBox.Show("Вы успешно сохранили товар!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// Проверка на корректность данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkIfInputDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }
    }
}
