using System.Collections.Generic;
using APIPractice2.Model;

namespace APIPractice2.Data
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        bool SaveChanges();
    }
}