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
using WpfLesson9.Models;

namespace WpfLesson9
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                FirstNameTextBox.Text = user.FirstName;
                LastNameTextBox.Text = user.LastName;
            }
        }

        public EditUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            Close();
        }
    }
}
