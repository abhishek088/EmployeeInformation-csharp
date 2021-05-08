//Author:Abhishek Sawant, Konrad Gaerdes, Rupal Pandya
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeInformation
{
    internal class DB
    {
        const string CONNECTION_STRING = @"Server=.\SQLEXPRESS;Database=Personnel;Trusted_Connection=True;";
        const string UPDATE_COMMAND = "UPDATE Employee " +
                                      "SET name = @name, " +
                                      "position = @position, " +
                                      "hourlyRate = @hourlyRate " +
                                      "WHERE employeeID = @employeeID ";
        const string SELECT_COMMAND = "SELECT employeeId, name, position, hourlyRate FROM Employee";

        private static DB db;
        public static DB Instance { get { db ??= new DB(); return db; } }

        private SqlConnection conn;

        private DB()
        {
            conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
        }

        #region Methods
        public void Update(Employee employee)
        {
            using SqlCommand cmd = new SqlCommand(UPDATE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@EMPLOYEEID", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@NAME", employee.Name);
            cmd.Parameters.AddWithValue("@POSITION", employee.Position);
            cmd.Parameters.AddWithValue("@HOURLYRATE", employee.HourlyRate);
            cmd.ExecuteNonQuery();
        }

        public List<Employee> Get()
        {
            List<Employee> employees = new List<Employee>();

            using SqlCommand cmd = new SqlCommand(SELECT_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                employees.Add(new Employee
                {
                    EmployeeId = dr.GetInt32(dr.GetOrdinal("employeeId")),
                    Name = dr.GetString(dr.GetOrdinal("name")),
                    Position = dr.GetString(dr.GetOrdinal("position")),
                    HourlyRate = dr.GetDecimal(dr.GetOrdinal("hourlyRate"))
                });
            dr.Close();
            return employees;
        }
        #endregion
    }
}
