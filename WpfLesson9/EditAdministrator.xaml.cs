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
    /// Логика взаимодействия для EditAdministrator.xaml
    /// </summary>
    public partial class EditAdministrator : Window
    {
        private Administrator administrator;

        public Administrator Administrator
        {
            get { return administrator; }
            set
            {
                administrator = value;
                FirstNameTextBox.Text = administrator.FirstName;
                LastNameTextBox.Text = administrator.LastName;
            }
        }

        public EditAdministrator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            administrator.FirstName = FirstNameTextBox.Text;
            administrator.LastName = LastNameTextBox.Text;
            Close();
        }
    }
}
