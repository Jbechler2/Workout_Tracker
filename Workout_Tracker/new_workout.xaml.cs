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
using System.Text.RegularExpressions;


namespace Workout_Tracker
{
    /// <summary>
    /// Interaction logic for new_workout.xaml
    /// </summary>
    public partial class new_workout : Window
    {
        dynamic main_window;

        public new_workout(dynamic prev_window)
        {
            InitializeComponent();
            main_window = prev_window;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                no_name.Visibility = System.Windows.Visibility.Hidden;
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (log_entry())
            {
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            else
            {

            }
            
        }

        private bool log_entry()
        {
            if(new_name.Text == "" || new_name.Text == "Name")
            {
                no_name.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                StreamReader file = open_file();

                int exercise_index = get_exercise_index(file);

                file.Close();

                add_exercise(exercise_index);


                return true;
            }
        }

        private void add_exercise(int exercise_index)
        {
            string new_exercise = (++exercise_index).ToString() + " ";

            string name_format = formatted_name();

            new_exercise += name_format;

            add_to_file(new_exercise);
        }

        private void add_to_file(string new_exercise)
        { 
            StreamWriter file = new StreamWriter("exercises.txt", true);

            file.WriteLine("\n");
            file.Write(new_exercise);

            file.Close();
        }

        private string formatted_name()
        {
            string name = new_name.Text;

            name = name.ToLower();

            name = name.Replace(" ", "_");

            return name;
        }

        private int get_exercise_index(StreamReader file)
        {
            string line;
            string last_line = "";
            while((line = file.ReadLine()) != null)
            {
                last_line = line;
            }

            return get_index(last_line);
        }

        private int get_index(string line)
        {
            Regex index = new Regex(@"\d+\s");

            var result = index.Match(line);

            if (result.Success)
            {
                return Int32.Parse(result.Value);
            }
            else
            {
                return -1;
            }



        }

        private StreamReader open_file()
        {
            StreamReader exercises = new StreamReader("exercises.txt", true);

            return exercises;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            main_window.Show();
        }
    }
}
