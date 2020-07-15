using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IRoleRepo
    {
        Task<Response> AssignPrivilegetoRoleAsync(int roleID, int privilegeID);
        Task<int> insertAsync(Role data);
        Task<int> insertListAsync(List<Role> data);
        Task<int> deleteAsync(Role data);
        Task<int> updateAsync(Role data);
        Task<Role> getAsync(int ID);
        Task<List<Role>> getAllAsync();
    }
}
