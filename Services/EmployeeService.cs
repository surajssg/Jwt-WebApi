using JwtImplementation.Context;
using JwtImplementation.Interfaces;
using JwtImplementation.Models;

namespace JwtImplementation.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JwtContext _jwtContext;    
        public EmployeeService(JwtContext jwtContext) {
            _jwtContext = jwtContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            var emp = _jwtContext.Employees.Add(employee);
            _jwtContext.SaveChanges();

            return emp.Entity;
        }

        public bool DeleteEmployee(int id)
        {
            try {
                var emp = _jwtContext.Employees.FirstOrDefault(x => x.Id == id);

                if (emp == null)
                {
                    throw new Exception("User Not Found!!");
                }
                else
                {
                    _jwtContext.Employees.Remove(emp);
                    _jwtContext.SaveChanges();
                    return true;
                }
            } catch (Exception ex) {
                return false;
            }

        }

        public List<Employee> GetEmployeeDetails() { 
            var employees = _jwtContext.Employees.ToList();
            return employees;
        }
        public Employee UpdateEmployee(Employee employee)
        {
            var updated = _jwtContext.Employees.Update(employee);
            _jwtContext.SaveChanges();

            return updated.Entity;
        }

        public Employee GetEmployee(int id)
        {
            var emp = _jwtContext.Employees.FirstOrDefault(x => x.Id == id);
            return emp;
        }


    }
}
