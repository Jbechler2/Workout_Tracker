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
using System.IO;

namespace Workout_Tracker
{
    /// <summary>
    /// Interaction logic for update_personal.xaml
    /// </summary>
    public partial class update_personal : Window
    {
        public update_personal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            update_info();
        }

        private void update_info()
        {
            if(check_bw() && check_height())
            {
                log_info();
                MainWindow main = new MainWindow();
                this.Close();
            }
        }

        private void log_info()
        {
            StreamWriter p_info = new StreamWriter("p_info.txt");

            int weight = 0;
            int height = 0;

            weight = Int32.Parse(bw.Text);

            height = (Int32.Parse(ft.Text) * 12) + Int32.Parse(inches.Text);

            p_info.WriteLine("bw:" + weight.ToString());
            p_info.WriteLine("height:" + height.ToString());

            p_info.Close();

        }

        private bool check_bw()
        {
            for(int i = 0; i < bw.Text.Length; i++)
            {
                if(!Char.IsDigit(bw.Text, i))
                {
                    bw_warning.Visibility = System.Windows.Visibility.Visible;
                    return false;
                }
            }
            return true;
        }

        private bool check_height()
        {
            for(int i = 0; i < ft.Text.Length; i++)
            {
                if(!Char.IsDigit(ft.Text, i))
                {
                    height_warning.Visibility = System.Windows.Visibility.Visible;
                    return false;
                }
            }
            for(int i = 0; i < inches.Text.Length; i++)
            {
                if(!Char.IsDigit(inches.Text, i))
                {
                    height_warning.Visibility = System.Windows.Visibility.Visible;
                    return false;
                }
            }

            return true;
        }

        private void bw_TextChanged(object sender, TextChangedEventArgs e)
        {
            bw_warning.Visibility = System.Windows.Visibility.Hidden;
        }

        private void ft_TextChanged(object sender, TextChangedEventArgs e)
        {
            height_warning.Visibility = System.Windows.Visibility.Hidden;
        }

        private void inches_TextChanged(object sender, TextChangedEventArgs e)
        {
            height_warning.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
