using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IPermissionRepo
    {
        Task<bool> AssignRoletoUserAsync(int roleID, int userID);
        Task<bool> AssignPrivilegetoRoleAsync(int roleID, int privilegeID);
        Task<bool> CopyRoletoAnotherUserAsync(int ownerID,int recipientID,int roleID);
        Task<User> GetUserWithRoleAsync(int ID);
    }
}
