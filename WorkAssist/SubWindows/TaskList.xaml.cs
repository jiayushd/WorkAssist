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
using System.Windows.Shapes;
using WorkAssist.ViewModel;

namespace WorkAssist.SubWindows
{
    /// <summary>
    /// TaskList.xaml 的交互逻辑
    /// </summary>
    public partial class TaskList : Window
    {
        public TaskList(List<TaskDetails> tds)
        {
            InitializeComponent();
            detail.ItemsSource = tds;
        }
    }
}
