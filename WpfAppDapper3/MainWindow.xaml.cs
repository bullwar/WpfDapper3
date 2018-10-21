using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfAppDapper3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<People> peoples { get; set; }     

        public MainWindow()
        {
            InitializeComponent();
            loadGridData();       
        }

        public void loadGridData()
        {
            peoples = DataService.getUsers();
            LB.ItemsSource = peoples;
        }

        private void btnAddNewUsers_Click(object sender, RoutedEventArgs e)
        {         
            DataService.insertNewUser(newUsersField.Text);
            newUsersField.Clear();
            loadGridData();
        }

        private void btnDeleteUsers_Click(object sender, RoutedEventArgs e)
        {                
           if(!DataService.deleteUser(Int32.Parse(deleteUsersField.Text)))
            {
                MessageBox.Show("нет такой записи!", "Информация");
            }
           deleteUsersField.Clear();
           loadGridData();
        }

        private void btnUpdateUsers_Click(object sender, RoutedEventArgs e)
        {
            if (!DataService.updateUser(Int32.Parse(updateGetID.Text), updateUsersField.Text))
            {
                MessageBox.Show("нет такой записи!", "Информация");
            }
            updateUsersField.Clear();
            updateGetID.Clear();
            loadGridData();
        }
    }
}
