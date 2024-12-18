using FnPrDotnet;
using Repos.Repositories;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();

            try
            {
                // Отримуємо ID користувача
                string filePath = "user_id.txt";
                if (System.IO.File.Exists(filePath))
                {
                    int userId = int.Parse(System.IO.File.ReadAllText(filePath));

                    // Завантажуємо дані користувача
                    var user = new UserRepository(new LnContext()).Get(userId);
                    if (user != null)
                    {
                        NameTextBox.Text = user.name;
                        AgeTextBox.Text = user.age.ToString();
                        EmailTextBox.Text = user.email;
                        PasswordBox.Password = user.password;
                    }
                }
                else
                {
                    MessageBox.Show("User not found. Please log in again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the profile: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Login signInWindow = new Login();
            signInWindow.Show();
            Close();
        }

        private void ApplyChangesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Отримуємо ID користувача із текстового файлу
                string filePath = "user_id.txt";
                if (!System.IO.File.Exists(filePath))
                {
                    MessageBox.Show("User not found. Please log in again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int userId = int.Parse(System.IO.File.ReadAllText(filePath));

                // Завантажуємо користувача з бази
                var user = new UserRepository(new LnContext()).Get(userId);
                if (user == null)
                {
                    MessageBox.Show("User not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Оновлюємо дані користувача
                user.name = NameTextBox.Text;
                user.age = int.TryParse(AgeTextBox.Text, out int age) ? age : user.age; // Якщо значення некоректне, залишаємо старе
                user.email = EmailTextBox.Text;
                user.password = PasswordBox.Password;

                // Зберігаємо зміни
                var repository = new UserRepository(new LnContext());
                repository.Update(user);
                repository.SaveChanges();

                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void _Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
    }
}
