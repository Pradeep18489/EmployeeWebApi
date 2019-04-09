using EmployeeWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebApi.Services
{
    public interface IEmployeeService
    {
        IList<Employee> GetEmployees();

        Employee GetSingleEmployee(int id);

        bool AddEmployee(Employee employee);

        bool UpdateEmployee(int id, Employee employee, out Employee entity);

        bool Remove(int id);
    }
}
