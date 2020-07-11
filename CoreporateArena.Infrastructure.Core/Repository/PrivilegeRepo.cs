using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class PrivilegeRepo:IRepo<Privilege>
    {
        private readonly TContext _context;
        public PrivilegeRepo(TContext context)
        {
            _context = context;
        }

        public Task<int> deleteAsync(Privilege data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Privilege>> getAllAsync()
        {
            try
            {
                var privileges = await _context.Privileges.ToListAsync();
                return privileges;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Task<Privilege> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(Privilege data)
        {
            Privilege privilege;
            try
            {
                privilege = new Privilege
                {
                    DateCreated = DateTime.Now,
                    UserCreated=data.UserCreated,
                    DisplayName=data.DisplayName,
                    Name=data.Name

                };

                await _context.Privileges.AddAsync(privilege);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return privilege.ID;
        }

        public Task<int> insertListAsync(List<Privilege> data)
        {
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(Privilege data)
        {
            throw new NotImplementedException();
        }
    }
}
