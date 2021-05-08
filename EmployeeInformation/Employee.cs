//Author:Abhishek Sawant, Konrad Gaerdes, Rupal Pandya
namespace EmployeeInformation
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
    }
}
