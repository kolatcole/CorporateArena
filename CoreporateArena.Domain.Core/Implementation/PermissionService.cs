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
        private readonly IRepo<Privilege> _pRepo;
        private readonly IPermissionRepo _peRepo;

        public PermissionService(IUserRepo uRepo,IRepo<Role> rRepo, IRepo<Privilege> pRepo, IPermissionRepo peRepo)
        {
            _rRepo = rRepo;
            _uRepo = uRepo;
            _pRepo = pRepo;
            _peRepo = peRepo;
        }

        public async Task<bool> AssignPrivilegetoRole(int roleID, int privilegeID)
        {
            var status = await _peRepo.AssignPrivilegetoRoleAsync(roleID, privilegeID);
            return status;
        }

        public async Task<bool> AssignRoletoUser(int roleID, int userID)
        {
            var status = await _peRepo.AssignRoletoUserAsync(roleID, userID);
            return status;
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
