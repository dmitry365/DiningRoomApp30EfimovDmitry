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
using System.IO;
using Microsoft.Win32;

namespace DiningRoomApp
{
    /// <summary>
    /// Логика взаимодействия для WindowPay.xaml
    /// </summary>
    public partial class WindowPay : Window
    {
        //инициализируем массив строк, включающий названия способа доставки и средства платежа
        string[] Delivery =
        {"В пункте выдачи",
         "Доставка на дом"        
        };
        string[] Pay =
        {"Карта",
         "Наличные"
        };
        public WindowPay()
        {
            InitializeComponent();
            int i;
            /*сгенерировать список 
            значениями из массива */
            for (i = 0; i < 2; i++)
            {
                ComboBoxDelivery.Items.Add(Delivery[i]);
                ComboBoxPay.Items.Add(Pay[i]);
            }
            
        }

        /// <summary>
        /// Вызов окна помощи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_help(object sender, RoutedEventArgs e)
        {
            WindowHelp windowHelp = new WindowHelp();
            windowHelp.ShowDialog();
            
        }
        /// <summary>
        /// Вызов окна печати
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Print(object sender, RoutedEventArgs e)
        {
            if(FIO.Text == "" || Address.Text == "" || ComboBoxDelivery.Text == "" || ComboBoxPay.Text == "" )
            {
                MessageBox.Show("Вы не заполнили все данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {               
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                StreamWriter SW;
                saveFileDialog.Filter = "txt files (*.txt) | *.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    SW = new StreamWriter(saveFileDialog.FileName);
                    SW.WriteLine("ФИО: " + FIO.Text);
                    SW.WriteLine("Адрес: " + Address.Text);
                    SW.WriteLine("Способ доставки: " + ComboBoxDelivery.Text);
                    SW.WriteLine("Способ оплаты: " + ComboBoxPay.Text);
                    SW.WriteLine("Итоговая стоимость: " + Result.Text);
                    SW.Close();
                }
                else
                {
                    MessageBox.Show("Вы не сохранили файл!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            
        }
        /// <summary>
        /// Выход из пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            foreach (Window w in App.Current.Windows)
                w.Hide();
            mainWindow.Show();
        }
    }
}
