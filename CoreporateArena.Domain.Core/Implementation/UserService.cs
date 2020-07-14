using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class UserService: IUserService
    {

        private readonly IUserRepo _uRepo;



        public UserService(IUserRepo uRepo)
        {
            _uRepo = uRepo;


        }

        public Task<bool> ApproveUserAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> AssignRoletoUserAsync(int roleID, int userID)
        {
            var response = await _uRepo.AssignRoletoUser(roleID, userID);
            return response;
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserWithRoleAsync(int ID)
        {
            var response = await _uRepo.GetUserWithRole(ID);
            return response;
        }

        public async Task<Response> LoginAsync(string username, string password)
        {
            var response = await _uRepo.Login(username, password);
            return response;
        }

        public async Task<Response> RegisterUserAsync(User data)
        {
            var response = await _uRepo.RegisterUser(data);
            return response;
        }
    }
}
