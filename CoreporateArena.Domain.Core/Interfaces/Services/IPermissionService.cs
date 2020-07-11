using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IPermissionService
    {
        Task<bool> AssignPrivilegetoRole(int roleID, int privilegeID);
        Task<bool> AssignRoletoUser(int roleID, int userID);
        Task<bool> CopyRoletoAnotherUser(int ownerID, int recipientID, int roleID);
        Task<User> GetUserWithRole(int ID);
    }
}
