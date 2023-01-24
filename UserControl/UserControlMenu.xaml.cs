﻿using System;
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

namespace DiningRoomApp
{
    /// <summary>
    /// Логика взаимодействия для UserControlMenu.xaml
    /// </summary>
    public partial class UserControlMenu : UserControl
    {
        //создание свойства для заголовка
        public string Header { get; set; }
        /// <summary>
        /// Инициализация окна
        /// </summary>
        public UserControlMenu()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
