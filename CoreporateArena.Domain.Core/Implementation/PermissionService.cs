using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class PermissionService : IPermissionService
    {
        private readonly IUserRepo _uRepo;
        private readonly IRepo<Role> _rRepo;
        private readonly IPrivilegeRepo _pRepo;
        private readonly IPermissionRepo _peRepo;

        public PermissionService(IUserRepo uRepo,IRepo<Role> rRepo, IPrivilegeRepo pRepo, IPermissionRepo peRepo)
        {
            _rRepo = rRepo;
            _uRepo = uRepo;
            _pRepo = pRepo;
            _peRepo = peRepo;
        }

        public async Task<Response> AssignPrivilegetoRole(int roleID, int privilegeID)
        {
            var response = await _peRepo.AssignPrivilegetoRoleAsync(roleID, privilegeID);
            return response;
        }

        public async Task<Response> AssignRoletoUser(int roleID, int userID)
        {
            var response = await _peRepo.AssignRoletoUserAsync(roleID, userID);
            return response;
        }

        public Task<bool> CopyRoletoAnotherUser(int ownerID, int recipientID, int roleID)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserWithRole(int ID)
        {
            var user = await _peRepo.GetUserWithRoleAsync(ID);
            return user;
        }
    }
}
