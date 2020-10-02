using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // для ObservableColection !!!
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
using WpfLesson9.Models;

namespace WpfLesson9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users;
        private ObservableCollection<Administrator> administrators;
        
        private User selectedUser;
        private Administrator selectedAdministrator;

        public MainWindow()
        {
            InitializeComponent();
            //Users
            users = new ObservableCollection<User>()
            {
                new User() { Id = 0, FirstName = "Bill", LastName = "Smith", Path = "/Images/User.png" },
                new User() { Id = 1, FirstName = "James", LastName = "Blunt", Path = "/Images/User.png" },
                new User() { Id = 2, FirstName = "Martin", LastName = "Milan", Path = "/Images/User.png" },
                new User() { Id = 3, FirstName = "Mark", LastName = "Hunt", Path = "/Images/User.png" },
                new User() { Id = 0, FirstName = "Bill", LastName = "Smith", Path = "/Images/User.png" },
                new User() { Id = 1, FirstName = "James", LastName = "Blunt", Path = "/Images/User.png" },
                new User() { Id = 2, FirstName = "Martin", LastName = "Milan", Path = "/Images/User.png" },
                new User() { Id = 3, FirstName = "Mark", LastName = "Hunt", Path = "/Images/User.png" },
                new User() { Id = 0, FirstName = "Bill", LastName = "Smith", Path = "/Images/User.png" },
                new User() { Id = 1, FirstName = "James", LastName = "Blunt", Path = "/Images/User.png" },
                new User() { Id = 2, FirstName = "Martin", LastName = "Milan", Path = "/Images/User.png" },
                new User() { Id = 3, FirstName = "Mark", LastName = "Hunt", Path = "/Images/User.png" }
            };
            usersListBox.ItemsSource = users;

            //Administrators
            administrators = new ObservableCollection<Administrator>()
            {
                new Administrator() {Id = 0, FirstName = "Stan", LastName = "Barton", Path = "/Images/Administrator.png" },
                new Administrator() {Id = 0, FirstName = "Tony", LastName = "Stark", Path = "/Images/Administrator.png" }
            };
            administratorsListBox.ItemsSource = administrators;
        }

        private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = (sender as ListBox).SelectedItem as User;
            selectedAdministrator = null;
        }

        private void AdminsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAdministrator = (sender as ListBox).SelectedItem as Administrator;
            selectedUser = null;
        }

        private void Scroll_Click(object sender, RoutedEventArgs e)
        {
            usersListBox.ScrollIntoView(users.Last());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null)
            {
                EditUser editUser = new EditUser();
                editUser.User = selectedUser;
                editUser.ShowDialog();
            }
            else if (selectedAdministrator != null)
            {
                EditAdministrator editAdministrator = new EditAdministrator();
                editAdministrator.Administrator = selectedAdministrator;
                editAdministrator.ShowDialog();
            }
        }

        private void ToAdministrators_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null)
            {
                Administrator administrator = new Administrator() { Id = selectedUser.Id, FirstName = selectedUser.FirstName, LastName = selectedUser.LastName, Path = "/Images/Administrator.png" };
                administrators.Add(administrator);
                users.Remove(selectedUser);
            }
        }

        private void ToUsers_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAdministrator != null)
            {
                User user = new User() { Id = selectedAdministrator.Id, FirstName = selectedAdministrator.FirstName, LastName = selectedAdministrator.LastName, Path = "/Images/User.png" };
                users.Add(user);
                administrators.Remove(selectedAdministrator);
            }
        }

        private void MenuItem_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("View opened");
        }
    }
}
