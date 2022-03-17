using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public class EmployeeService
    {
        static List<Employee> employeesList { get; }
        static int nextEmpId = 3;

        static EmployeeService()
        {
            employeesList = new List<Employee>()
            {
                new Employee{Id = 1 , Name="Mabrouki" , Title ="Developper" , Slary = 100020},
                new Employee{Id = 2, Name="Abdoulaadim" , Title ="IA" , Slary = 4503921}
            };
        }

        public static List<Employee> GetAll() => employeesList;

        public static Employee Get(int id) => employeesList.FirstOrDefault(p => p.Id == id);
        public static void Add(Employee employee)
        {
            employee.Id = nextEmpId++;
            employeesList.Add(employee);
        }

        public static void Update(Employee employee)
        {
            var index = employeesList.FindIndex(p => p.Id == employee.Id);
            if (index == -1)
                return;
            employeesList[index] = employee;
        }

        public static void Delete (int id)
        {
            var employee = Get(id);
            if (employee is null)
                return;
            employeesList.Remove(employee);
        }
    }
}
