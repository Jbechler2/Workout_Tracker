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



namespace Workout_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int BUTTON_HEIGHT = 50;
        int wo_index = 4;
        int margin_index = 2;

        public MainWindow()
        {
            InitializeComponent();
            date_picker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter wo = new StreamWriter("workout1.txt", true);
            wo.WriteLine(date_picker.SelectedDate + "\n");
            wo.WriteLine(cb1.SelectedIndex.ToString() + "," + reps1.Text.ToString() + "," + weight1.Text + "\n");
            wo.WriteLine(cb2.SelectedIndex.ToString() + "," + reps2.Text.ToString() + "," + weight2.Text + "\n");
            wo.WriteLine(cb3.SelectedIndex.ToString() + "," + reps3.Text.ToString() + "," + weight3.Text + "\n");
            wo.WriteLine(cb4.SelectedIndex.ToString() + "," + reps4.Text.ToString() + "," + weight4.Text + "\n");
            wo.Close();
            cb1.SelectedIndex = -1;
            reps1.Text = "";
            cb2.SelectedIndex = -1;
            reps2.Text = "";
            cb3.SelectedIndex = -1;
            reps3.Text = "";
            cb4.SelectedIndex = -1;
            reps4.Text = "";
        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb1.SelectedIndex == 0)
            {
                weight1.Text = bw.Text;
                weight1.IsReadOnly = true;
            }
            else
            {
                weight1.Text = "";
                weight1.IsReadOnly = false;
            }
        }
        private void cb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb2.SelectedIndex == 0)
            {
                weight2.Text = bw.Text;
                weight2.IsReadOnly = true;
            }
            else
            {
                weight2.Text = "";
                weight2.IsReadOnly = false;
            }
        }
        private void cb3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb3.SelectedIndex == 0)
            {
                weight3.Text = bw.Text;
                weight3.IsReadOnly = true;
            }
            else
            {
                weight3.Text = "";
                weight3.IsReadOnly = false;
            }
        }
        private void cb4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb4.SelectedIndex == 0)
            {
                weight4.Text = bw.Text;
                weight4.IsReadOnly = true;
            }
            else
            {
                weight4.Text = "";
                weight4.IsReadOnly = false;
            }

            cb3.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ComboBox x = new ComboBox();
            TextBox y = new TextBox();
            TextBox z = new TextBox();
            x.Name = "cb" + wo_index.ToString();
            y.Name = "reps" + wo_index.ToString();
            z.Name = "weight" + wo_index.ToString();

            x.Height = reps1.Height;
            x.Width = cb3.Width;

            y.Height = reps3.Height;
            y.Width = reps3.Width;

            z.Height = weight3.Height;
            z.Width = weight3.Width;

            x.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            y.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            z.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

            x.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            y.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            z.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            x.Margin = new Thickness(cb3.Margin.Left, cb3.Margin.Top + (50 * margin_index), 0, 0);
            y.Margin = new Thickness(reps3.Margin.Left, reps3.Margin.Top + (50 * margin_index), 0, 0);
            z.Margin = new Thickness(weight3.Margin.Left, weight3.Margin.Top + (50 * margin_index) ,0, 0);

            x.Visibility = System.Windows.Visibility.Visible;

            g.Children.Add(x);
            g.Children.Add(y);
            g.Children.Add(z);

            add_wo.Margin = new Thickness(add_wo.Margin.Left, add_wo.Margin.Top + 50, 0, 0);

            margin_index++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new_workout x = new new_workout(this);
            this.Hide();
            x.Show();   
        }
    }
}
