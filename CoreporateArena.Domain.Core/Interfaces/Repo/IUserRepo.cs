using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IUserRepo
    {
        Task<Response> RegisterUser(User data);

        Task<bool> ApproveUser(int ID);

        Task<List<User>> GetAllUsers();
        Task<Response> LoginAsync(string username, string password);
    }
}
