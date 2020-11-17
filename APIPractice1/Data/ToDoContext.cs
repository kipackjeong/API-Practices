using AppPractice1.Model;
using Microsoft.EntityFrameworkCore;


namespace APIPractice1.Data
{
    public class ToDoContext : DbContext
    { 
        //PROP
        public DbSet<ToDoUserAccount> ToDoUserAccounts { get; set;}

        //CTOR
        public ToDoContext(DbContextOptions<ToDoContext> opt) : base(opt)
        {
        }     
        //METHOD
    }
}