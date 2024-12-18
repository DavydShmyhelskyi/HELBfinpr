using FnPrDotnet;
using Repos.Repositories;
using System;
using System.Windows;

namespace UIwpf
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private readonly UserRepository _userRepository;

        public SignIn()
        {
            InitializeComponent();

            // Initialize LnContext and pass it to UserRepository
            var context = new LnContext(); // Ensure your LnContext is properly configured
            _userRepository = new UserRepository(context);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Validate input fields before proceeding
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(AgeTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new User object
            var newUser = new User
            {
                name = NameTextBox.Text,
                age = int.TryParse(AgeTextBox.Text, out int age) ? age : 0,
                email = EmailTextBox.Text,
                password = PasswordBox.Password,
                userStatusId = 1
            };

            try
            {
                _userRepository.Create(newUser);
                _userRepository.SaveChanges();

                MessageBox.Show("User successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.InnerException?.Message ?? ex.Message}",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
