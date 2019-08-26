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

namespace BuildAnApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show a message button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string name = "Beef";
            int x = 3;
            x = x * 17;
            double d = Math.PI / 2;

            myLabel.Text = "name is " + name
                + "\nx is " + x
                + "\nd is " + d;
        }

        /// <summary>
        /// If/else button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            int x = 5;
            if (x == 10)
            {
                myLabel.Text = "x must be 10.";
            }
            else
            {
                myLabel.Text = "x is not 10.";
            }
        }

        /// <summary>
        /// Another conditional test button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            int someValue = 4;
            string name = "Little Beef";
            if ((someValue == 3) && (name == "Beef"))
            {
                myLabel.Text = "x is 3 and the name is Beef.";
            }
            myLabel.Text = "This line runs no matter what.";
        }

        /// <summary>
        /// A loop button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;

            while (count < 10)
            {
                count += 1;
            }

            for (int i = 0; i < 5; i++)
            {
                count -= 1;
            }

            myLabel.Text = "The answer is: " + count;
        }
    }
}
