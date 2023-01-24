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
    /// Логика взаимодействия для PageDinner.xaml
    /// </summary>
    public partial class PageDinner : Page
    {
        //объявление переменной, отвечающей за подсчёт суммы блюд
        public float SummaDinner;
        /// <summary>
        /// Инициализация окна. Считывание файлов
        /// </summary>
        public PageDinner()
        {
            InitializeComponent();
            using (StreamReader streamReader = new StreamReader("../../Resources/AdditionalDishesDinner.txt"))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    ComboBoxAdditionalDishes.Items.Add(str + Environment.NewLine);
                }
            }
        }
        /// <summary>
        /// Считывание файла цены добавленного шеф блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxAdditionalDishes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (StreamReader streamReader = new StreamReader("../../Resources/PriceDishesDinner.txt"))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                    float number = float.Parse(str);
                    SummaDinner += number;
                }
            }
        }
        /// <summary>
        /// Подсчёт стоимости первого блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasketFirst_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)BasketFirst.IsChecked)
            {
                SummaDinner += 80;
            }
            else if (SummaDinner != 0)
            {
                SummaDinner -= 80;
            }
        }
        /// <summary>
        /// Подсчёт стоимости второго блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasketSecond_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)BasketSecond.IsChecked)
            {
                SummaDinner += 40;
            }
            else if (SummaDinner != 0)
            {
                SummaDinner -= 40;
            }
        }
        /// <summary>
        /// Подсчёт стоимости третьего блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasketThird_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)BasketThird.IsChecked)
            {
                SummaDinner += 50;
            }
            else if (SummaDinner != 0)
            {
                SummaDinner -= 50;
            }
        }
        /// <summary>
        /// Подсчёт стоимости четвертого блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasketFourth_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)BasketFourth.IsChecked)
            {
                SummaDinner += 90;
            }
            else if (SummaDinner != 0)
            {
                SummaDinner -= 90;
            }
        }
        /// <summary>
        /// Подсчёт стоимости пятого блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasketFifth_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)BasketFifth.IsChecked)
            {
                SummaDinner += 85;
            }
            else if (SummaDinner != 0)
            {
                SummaDinner -= 85;
            }
        }
        /// <summary>
        /// Подсчёт стоимости шестого блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasketSixth_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)BasketSixth.IsChecked)
            {
                SummaDinner += 30;
            }
            else if (SummaDinner != 0)
            {
                SummaDinner -= 30;
            }
        }
        /// <summary>
        /// Открытие окна оплаты блюд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Pay(object sender, RoutedEventArgs e)
        {           
            if (SummaDinner != 0)
            {
                WindowPay windowPay = new WindowPay();
                windowPay.Result.Text = this.SummaDinner.ToString() + " рублей".ToString();
                windowPay.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Кнопка "Очистить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            BasketFirst.IsChecked = false;
            BasketSecond.IsChecked = false;
            BasketThird.IsChecked = false;
            BasketFourth.IsChecked = false;
            BasketFifth.IsChecked = false;
            BasketSixth.IsChecked = false;
            ComboBoxAdditionalDishes.Text = "";
            SummaDinner = 0;
        }
    }
}
