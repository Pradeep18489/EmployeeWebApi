using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeWebApi.Data;

namespace EmployeeWebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        protected EmployeeDbContext _employeeDbContext;
        public EmployeeService(EmployeeDbContext dbContext)
        {
            _employeeDbContext = dbContext;
        }

        public IList<Employee> GetEmployees()
        {        
                return _employeeDbContext.Employees.ToList();
        }

        public Employee GetSingleEmployee(int id)
        {
                return _employeeDbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public bool AddEmployee(Employee employee)
        {
            _employeeDbContext.Employees.Add(employee);
            _employeeDbContext.SaveChanges();
                return true;
        }

        public bool UpdateEmployee(int id, Employee employee, out Employee entity)
        {
                entity = this.GetSingleEmployee(id);
                if (entity == null)
                {
                    return false;
                }
                else
                {
                    entity.FirstName = employee.FirstName;
                    entity.LastName = employee.LastName;
                    entity.Email = employee.Email;
                    _employeeDbContext.SaveChanges();
                    return true;
                }
            }
        

        public bool Remove(int id)
        {
                var entity = this.GetSingleEmployee(id);
                if (entity == null)
                {
                    return false;
                }
                else
                {
                    _employeeDbContext.Employees.Remove(entity);
                    _employeeDbContext.SaveChanges();
                }

                return true;
        }
    }
}