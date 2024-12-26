using JwtImplementation.Models;

namespace JwtImplementation.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployeeDetails();

        public Employee GetEmployee(int id);

        public Employee AddEmployee(Employee employee);

        public Employee UpdateEmployee(Employee employee);
        public bool DeleteEmployee(int id);
    }
}
