using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Response> RegisterUser(User data)
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
                    PhoneNumber = data.PhoneNumber,
                    Password=data.Password

                };
                await _context.AppUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                return new Response { Result = "New User created Successfully", status = true };
            }
            catch (Exception ex)
            {
                throw ex;
            
            }
        
        }

        public async Task<Response> LoginAsync(string username, string password)
        {
            User user;

            try
            {
                user = await _context.AppUsers.Where(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
                if (user == null) return new Response {status=false,Result="Login Failed" };

                return new Response { status = true, Result = "Login Successful" };
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
