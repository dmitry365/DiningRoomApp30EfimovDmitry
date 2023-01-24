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
    /// Логика взаимодействия для PageBreakfast.xaml
    /// </summary>
    public partial class PageBreakfast : Page
    {
        //объявление переменной, отвечающей за подсчёт суммы блюд
        public float SummaBreakfast;
        /// <summary>
        /// Инициализация окна. Считывание файлов
        /// </summary>
        public PageBreakfast()
        {
            InitializeComponent();
            using (StreamReader streamReader = new StreamReader("../../Resources/AdditionalDishesBreakfast.txt"))
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
            using (StreamReader streamReader = new StreamReader("../../Resources/PriceDishesBreakfast.txt"))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                    float number = float.Parse(str);
                    SummaBreakfast += number;
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
                SummaBreakfast += 80;
            }
            else if (SummaBreakfast != 0)
            {
                SummaBreakfast -= 80;
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
                SummaBreakfast += 50;
            }
            else if (SummaBreakfast != 0)
            {
                SummaBreakfast -= 50;
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
                SummaBreakfast += 60;
            }
            else if (SummaBreakfast != 0)
            {
                SummaBreakfast -= 60;
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
                SummaBreakfast += 120;
            }
            else if (SummaBreakfast != 0)
            {
                SummaBreakfast -= 120;
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
                SummaBreakfast += 40;
            }
            else if (SummaBreakfast != 0)
            {
                SummaBreakfast -= 40;
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
                SummaBreakfast += 30;
            }
            else if (SummaBreakfast != 0)
            {
                SummaBreakfast -= 30;
            }
            
        }
        /// <summary>
        /// Открытие окна оплаты блюд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Pay(object sender, RoutedEventArgs e)
        {
            if (SummaBreakfast != 0)
            {
                WindowPay windowPay = new WindowPay();
                windowPay.Result.Text = this.SummaBreakfast.ToString() + " рублей".ToString();
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
            SummaBreakfast = 0;
        }
    }
}
