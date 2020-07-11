using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class UserRepo:IUserRepo
    {
        private readonly TContext _context;
        public UserRepo(TContext context)
        {
            _context = context;
        }

        public async Task<bool> ApproveUser(int ID)
        {
            var user =await  _context.AppUsers.FindAsync(ID);
            try
            {
                user.IsActive = true;
                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var users = await _context.AppUsers.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // public  enum Role { SuperUser, Basic, Author }
        public async Task<int> RegisterUser(User data)
        {
            User user;
            try
            {
                user = new User
                {
                    UserName = data.UserName,
                    Email = data.Email,
                    IsActive = false,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    OtherName = data.OtherName,
                    PhoneNumber = data.PhoneNumber

                };
                await _context.AppUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                return user.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            
            }
        
        }
    }
}
