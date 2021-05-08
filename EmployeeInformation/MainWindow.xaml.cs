//Author:Abhishek Sawant, Konrad Gaerdes, Rupal Pandya
using System.Windows;

namespace EmployeeInformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = VM.Instance;
            DataContext = vm;
        }
            
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedEmployee != null)
            {
                EditWindow ew = new EditWindow() { Owner = this };
                ew.ShowDialog();
            }
            else
                MessageBox.Show("Please select an employee to edit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
