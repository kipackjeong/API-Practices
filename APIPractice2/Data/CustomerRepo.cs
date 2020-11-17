using System.Collections.Generic;
using System.Linq;
using APIPractice2.Model;

namespace APIPractice2.Data
{
    public class CustomerRepo : ICustomerRepo
    { 
        //PROP
        private readonly CustomerContext _context;

       

        //CTOR
        public CustomerRepo(CustomerContext context)
        {
            _context = context;
        }



        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            // No code
        }
        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer); 
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }

}