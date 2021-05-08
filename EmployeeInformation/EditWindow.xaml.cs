//Author:Abhishek Sawant, Konrad Gaerdes, Rupal Pandya
using System.Windows;

namespace EmployeeInformation
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        readonly VM vm;
        readonly Employee employee = new Employee();

        public EditWindow()
        {
            InitializeComponent();
            vm = VM.Instance;
            DataContext = employee;

            employee.EmployeeId = vm.SelectedEmployee.EmployeeId;
            employee.Name = vm.SelectedEmployee.Name;
            employee.Position = vm.SelectedEmployee.Position;
            employee.HourlyRate = vm.SelectedEmployee.HourlyRate;

            employeeNumber.IsEnabled = false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            vm.Edit(employee);
            Close();
        }
    }
}
