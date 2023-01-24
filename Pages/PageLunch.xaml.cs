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
    /// Логика взаимодействия для PageLunch.xaml
    /// </summary>
    public partial class PageLunch : Page
    {
        //объявление переменной, отвечающей за подсчёт суммы блюд
        public float SummaLunch;
        /// <summary>
        /// Инициализация окна. Считывание файлов
        /// </summary>
        public PageLunch()
        {
            InitializeComponent();
            using (StreamReader streamReader = new StreamReader("../../Resources/AdditionalDishesLunch.txt"))
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
            using (StreamReader streamReader = new StreamReader("../../Resources/PriceDishesLunch.txt"))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                    float number = float.Parse(str);
                    SummaLunch += number;
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
                SummaLunch += 140;
            }
            else if (SummaLunch != 0)
            {
                SummaLunch -= 140;
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
                SummaLunch += 100;
            }
            else if (SummaLunch != 0)
            {
                SummaLunch -= 100;
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
                SummaLunch += 120;
            }
            else if (SummaLunch != 0)
            {
                SummaLunch -= 120;
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
                SummaLunch += 50;
            }
            else if (SummaLunch != 0)
            {
                SummaLunch -= 50;
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
                SummaLunch += 20;
            }
            else if (SummaLunch != 0)
            {
                SummaLunch -= 20;
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
                SummaLunch += 80;
            }
            else if (SummaLunch != 0)
            {
                SummaLunch -= 80;
            }
        }
        /// <summary>
        /// Открытие окна оплаты блюд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Pay(object sender, RoutedEventArgs e)
        {          
            if (SummaLunch != 0)
            {
                WindowPay windowPay = new WindowPay();
                windowPay.Result.Text = this.SummaLunch.ToString() + " рублей".ToString();
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
            SummaLunch = 0;
        }
    }
}
