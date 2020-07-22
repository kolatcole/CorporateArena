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

        public async Task<bool> ApproveUserAsync(int ID)
        {
            var status = await _uRepo.ApproveUser(ID);
            return status;
        }

        public async Task<Response> AssignRoletoUserAsync(int roleID, int userID)
        {
            var response = await _uRepo.AssignRoletoUser(roleID, userID);
            return response;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _uRepo.GetAllUsers();
            return users;
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

        public async Task<SaveResponse> RegisterUserAsync(User data)
        {
            var response = await _uRepo.RegisterUser(data);
            await AssignRoletoUserAsync(data.RoleID, data.ID);

            return response;
        }

        public async Task<Response> LoginWithTokenAsync(string token)
        {
            var response = await _uRepo.LoginWithToken(token);
            return response;

        }

        public async Task<bool> CheckIfUserExist(int ID)
        {
            bool Exist = false;

            var user = await _uRepo.GetUserWithRole(ID);
            if (user!= null && user.IsActive != false)
                Exist = true;

            return Exist;

        }



        public async Task<bool> CheckforPermission(int ID,string name)
        {

            bool isPermitted = false;
            var user = await GetUserWithRoleAsync(ID);

            if (user.Role.Name != "SuperAdmin")

                if(user.Role.Privileges!=null)
                {
                    foreach (var privilege in user.Role.Privileges)
                    {
                        if (privilege.Name == name)
                            isPermitted = true;
                    }
                }
                else
                {
                    isPermitted = false;

                }
                
            else
            {
                isPermitted = true;
            }
            return isPermitted;

        }
    }
}
