using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CorporateArena.Domain.Models;

namespace CorporateArena.Infrastructure
{
    public class PrivilegeRepo: IPrivilegeRepo
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

        public async Task<List<string>> GetActionsAsync()
        {

            var acts = new List<string>(Enum.GetNames(typeof(MyEnum)));
            return acts;
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

        public async Task<List<KeyValuePair<string, string>>> GetModelsAsync()
        {
            
            
            return Mod;
        }

        public async Task<Response> insertAsync(Privilege data)
        {

            var priv = await _context.Privileges.Where(x => x.Entity == data.Entity && x.Action == data.Action).FirstOrDefaultAsync();
            if (priv != null)
                return new Response {status=false,Result="Permission already exists" };


            Privilege privilege;
            try
            {
                privilege = new Privilege
                {
                    DateCreated = DateTime.Now,
                    UserCreated=data.UserCreated,
                    DisplayName=data.Action+" "+data.Entity,
                    Name= data.Action+data.Entity,
                    Action=data.Action,
                    Entity=data.Entity

                };

                await _context.Privileges.AddAsync(privilege);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return new Response { status = true, Result = "Permission was created successfully" };
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
