using System.Collections.Generic;
using AppPractice1.Model;

namespace APIPractice1.Data
{
    public interface IToDoUserAccountRepo
    {
        //METHOD
        IEnumerable<ToDoUserAccount> GetAllUserAccounts();
        ToDoUserAccount GetUserAccountById(int id);

        void CreateUserAccount(ToDoUserAccount newAccount);
        bool SaveChanges();
        void UpdateUserAccount(ToDoUserAccount updatedAccount);

        void DeleteUserAccount(ToDoUserAccount accountToDelete);

    }
}