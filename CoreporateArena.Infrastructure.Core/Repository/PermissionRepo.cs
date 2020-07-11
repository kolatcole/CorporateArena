using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class PermissionRepo : IPermissionRepo
    {
        private readonly TContext _context;
        public PermissionRepo(TContext context)
        {
            _context = context;

        }
        public async Task<bool> AssignPrivilegetoRoleAsync(int roleID, int privilegeID)
        {
            bool status = false;
            try
            {
                RolePrivilege data = new RolePrivilege
                {
                    RoleID = roleID,
                    PrivilegeID = privilegeID
                };

                await _context.RolePrivileges.AddAsync(data);
                await _context.SaveChangesAsync();
                status = true;
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }

        public async Task<bool> AssignRoletoUserAsync(int roleID, int userID)
        {
            bool status = false;
            try
            {
                UserRole data = new UserRole
                {
                    RoleID = roleID,
                    UserID=userID
                };

                await _context.UserRoles.AddAsync(data);
                await _context.SaveChangesAsync();
                status = true;
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> CopyRoletoAnotherUserAsync(int ownerID, int recipientID, int roleID)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserWithRoleAsync(int ID)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(ID);
                var userRole = await _context.UserRoles.Where(x => x.UserID == ID).SingleOrDefaultAsync();

                if(userRole!=null) user.Role = await _context.Roles.SingleAsync();


                return user;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<User> GetUserWithRole(int ID)
        //{

            //    try
            //    {
            //        var user=await _context.AppUsers.FindAsync(ID);
            //        return user;
            //       // user.Role= await _context.Roles.Where(x=>x.use)
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
        }
}
