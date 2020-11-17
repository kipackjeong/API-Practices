using APIPractice2.Model;
using Microsoft.EntityFrameworkCore;

namespace APIPractice2.Data
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
        {
            
        }



    }
}