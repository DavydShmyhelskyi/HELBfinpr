using Repos.Repositories;
using System.Linq;
using System.Windows;
using FnPrDotnet; // Підключення контексту бази даних

namespace UIwpf
{
    public partial class Login : Window
    {
        // Репозиторій користувачів
        private readonly UserRepository _userRepository;

        public Login()
        {
            InitializeComponent();

            // Ініціалізація контексту та репозиторію
            var dbContext = new LnContext();
            _userRepository = new UserRepository(dbContext);
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn signInWindow = new SignIn();
            signInWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = NameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Перевірка користувача в репозиторії
                var user = _userRepository.Get().FirstOrDefault(u => u.name == username);

                if (user == null)
                {
                    MessageBox.Show("User does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (user.password != password)
                {
                    MessageBox.Show("Incorrect password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Шлях до файлу
                    string filePath = "user_id.txt";

                    // Перевірка чи файл існує
                    if (!System.IO.File.Exists(filePath))
                    {
                        // Створення порожнього файлу
                        using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                        {
                            // Закриваємо файл одразу після створення
                            fs.Close();
                        }
                    }

                    // Очищення вмісту файлу
                    System.IO.File.WriteAllText(filePath, string.Empty);

                    // Запис id користувача в текстовий файл
                    System.IO.File.AppendAllText(filePath, user.id.ToString());

                    MainMenu mainMenuWindow = new MainMenu();
                    mainMenuWindow.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
