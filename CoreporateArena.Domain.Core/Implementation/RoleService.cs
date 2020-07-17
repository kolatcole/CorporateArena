using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class RoleService : IRoleService
    {
        
        private readonly IRepo<RolePrivilege> _rpRepo;
        private readonly IRoleRepo _rRepo;

        public RoleService(IRepo<RolePrivilege> rpRepo, IRoleRepo rRepo)
        {
            _rpRepo = rpRepo;
            _rRepo = rRepo;
        }

        public async Task<SaveResponse> SaveRoleAsync(Role data)
        {
            var result = await _rRepo.insertAsync(data);

            // Assign privileges to role if ids was selected
            if (data.PrivilegeIDs!=null)
                
                await AssignMultiplePrivileges(data);

            return result;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            var result = await _rRepo.getAllAsync();
            return result;

        }

        public async Task<Role> GetRoleByIDAsync(int ID)
        {
            var result = await _rRepo.getAsync(ID);
            return result;

        }

       
        public async Task<Response> AssignPrivilegetoRoleAsync(int roleID, int privilegeID)
        {
            var result = await _rRepo.AssignPrivilegetoRoleAsync(roleID, privilegeID);
            return result;
        }

        public async Task<bool> AssignMultiplePrivileges(Role data)
        {

            var status = false;
            List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();
            foreach(var pid in data.PrivilegeIDs)
            {
                var rp = new RolePrivilege
                {
                    RoleID=data.ID,
                    PrivilegeID=pid
                };
                rolePrivileges.Add(rp);

            }
            status = await _rpRepo.insertListAsync(rolePrivileges);


            return status;
        }



    }
}
