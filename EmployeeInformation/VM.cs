//Author:Abhishek Sawant, Konrad Gaerdes, Rupal Pandya
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeInformation
{
    internal class VM : INotifyPropertyChanged
    {
        DB db = DB.Instance;
        List<Employee> employees;

        #region singleton
        private static VM vm;
        public static VM Instance { get { vm ??= new VM(); return vm; } }

        private VM()
        {
            employees = db.Get();
            UpdateEmployees();
        }
        #endregion

        #region properties
        public BindingList<Employee> Employees { get; set; } = new BindingList<Employee>();

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; propertyChanged(); }
        }
        #endregion

        #region Methods
        public void Edit(Employee employee)
        {
            db.Update(employee);
            employees.Remove(SelectedEmployee);
            SelectedEmployee = null;
            employees.Add(employee);
            UpdateEmployees();
        }

        private void UpdateEmployees()
        {
            employees = employees.OrderBy(e => e.EmployeeId).ToList();
            Employees.Clear();
            foreach (Employee e in employees)
                Employees.Add(e);
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
