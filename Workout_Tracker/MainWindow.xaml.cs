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
using System.Text.RegularExpressions;
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
            get_exercises();
            date_picker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter wo = new StreamWriter("workout1.txt", true);
            wo.WriteLine(date_picker.SelectedDate + "\n");
            wo.WriteLine(cb1.SelectedIndex.ToString() + "," + sets1.Text + "," + reps1.Text + "," + weight1.Text + "\n");
            wo.WriteLine(cb2.SelectedIndex.ToString() + "," + sets2.Text + "," + reps2.Text + "," + weight2.Text + "\n");
            wo.WriteLine(cb3.SelectedIndex.ToString() + "," + sets3.Text + "," + reps3.Text + "," + weight3.Text + "\n");
            wo.WriteLine(cb4.SelectedIndex.ToString() + "," + sets1.Text + "," + reps4.Text + "," + weight4.Text + "\n");
            wo.Close();
            cb1.SelectedIndex = -1;
            reps1.Text = "";
            sets1.Text = "";
            cb2.SelectedIndex = -1;
            reps2.Text = "";
            sets2.Text = "";
            cb3.SelectedIndex = -1;
            reps3.Text = "";
            sets3.Text = "";
            cb4.SelectedIndex = -1;
            reps4.Text = "";
            sets4.Text = "";
        }

        private void get_exercises()
        {
            List<string> names = new List<string>();
            names = get_exercise_names();

            string name;
            cb1.Items.Clear();
            cb2.Items.Clear();
            cb3.Items.Clear();
            cb4.Items.Clear();

            for(int i = 0; i < names.Count; i++)
            {
                name = namify(names[i]);

                cb1.Items.Add(name);
                cb2.Items.Add(name);
                cb3.Items.Add(name);
                cb4.Items.Add(name);
            }


        }

        private string namify(string name)
        {
            string new_name = "";

            dynamic words;

            new_name = name.Replace("_", " ");

            words = new_name.Split(' ');

            for(int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")
                {
                    words[i] = char.ToUpper(words[i][0]) +  words[i].Substring(1).ToLower();
                }
            }
            if (words.Length == 1)
                return words[0];
            else
            {
                return String.Join(" ", words);
            }
        }



        private List<string> get_exercise_names()
        {
            StreamReader file = new StreamReader("exercises.txt", true);
            List<string> names = new List<string>();
            string line = null;
            string name;
            while((line = file.ReadLine()) != null)
            {
                if((name = parse_names(line)) != null)
                    names.Add(name);
            }

            file.Close();

            return names;
        }

        private string parse_names(string line)
        {
            Regex name = new Regex(@"\s+[a-z_]*");

            var result = name.Match(line);

            if (result.Success)
            {
                return result.Value;
            }
            else
            {
                return null;
            }
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            update_personal new_info = new update_personal();
            new_info.Show();
        }
    }
}
