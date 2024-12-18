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

namespace UIwpf
{
    /// <summary>
    /// Interaction logic for AddWordlist.xaml
    /// </summary>
    public partial class AddWordlist : Window
    {
        public AddWordlist()
        {
            InitializeComponent();
        }

        private void AddTerm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeTerm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveWordlist_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
    }
}
