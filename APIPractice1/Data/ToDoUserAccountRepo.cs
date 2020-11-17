using System;
using System.Collections.Generic;
using System.Linq;
using AppPractice1.Model;

namespace APIPractice1.Data
{
    public class ToDoUserAccountRepo : IToDoUserAccountRepo
    {
        private readonly ToDoContext _context;

        //PROP


        // CTOR
        public ToDoUserAccountRepo (ToDoContext context)
        {
            _context = context;
        }



        public IEnumerable<ToDoUserAccount> GetAllUserAccounts()
        {
            return _context.ToDoUserAccounts.ToList();
        }

        public ToDoUserAccount GetUserAccountById(int id)
        {
            return _context.ToDoUserAccounts.FirstOrDefault(e => e.Id == id);
        }
        public void CreateUserAccount(ToDoUserAccount newAccount)
        {
            if(newAccount == null)
            {
                throw new ArgumentNullException(nameof(newAccount));
            }
            _context.Add(newAccount);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUserAccount(ToDoUserAccount updatedAccount)
        {
            // No code needed
        }

        public void DeleteUserAccount(ToDoUserAccount accountToDelete)
        {
            _context.Remove(accountToDelete);
        }
    }
}