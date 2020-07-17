using CorporateArena.Domain;
using CorporateArena.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class UserRepo:IUserRepo
    {
        private readonly TContext _context;
        private readonly JwtOpt _jwtOpt;
        public UserRepo(TContext context, IOptions<JwtOpt> jwtOpt)
        {
            _context = context;
            _jwtOpt = jwtOpt.Value;
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

        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            string hash;
            using (var rng=RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
                hash = Convert.ToBase64String(salt);
            }
            return hash;
        }
        public bool UptoEight(string password)
        {
            if (password.Length > 7) return true;
            return false;
            
        }

        public bool ValidateAddress(string address)
        {
            try
            {
                MailAddress m = new MailAddress(address);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async Task<Response> RegisterUser(User data)
        {



            // check if password is strong 
            bool isLood = data.Password.Any(p => !char.IsLetterOrDigit(p));
            bool isNum = data.Password.Any(p => char.IsNumber(p));
            bool isUpper = data.Password.Any(p => char.IsUpper(p));
            bool isLower = data.Password.Any(p => char.IsLower(p));
            bool isUptoEight = UptoEight(data.Password);

            if(!isLood || !isNum || !isUpper || !isLower || !isUptoEight)
                return new Response { Result = "Invalid Password", status = false };

            // check if email address is valid
            if(!ValidateAddress(data.Email))
                return new Response { Result = "Email Address is Invalid", status = false };

            User user;
            try
            {

                // Assign the basic role to user if no role is selected
                if (data.RoleID == 0) data.RoleID = 1;

                // hash password
                var password = HashPassword(data.Password);

                user = new User
                {
                    UserName = data.UserName,
                    Email = data.Email,
                    IsActive = false,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    OtherName = data.OtherName,
                    PhoneNumber = data.PhoneNumber,
                    Password=password,
                    RoleID=data.RoleID

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

        public string CreateToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId,user.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            };
            var stoken = new JwtSecurityToken(
                        issuer: "",
                        audience: "",
                        claims:claims,
                        expires: DateTime.Now.AddMinutes(Convert.ToDouble(1)),
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(new SymmetricSecurityKey
                        (Encoding.ASCII.GetBytes(_jwtOpt.Secret)), SecurityAlgorithms.HmacSha256)
                    );
            var token = new JwtSecurityTokenHandler().WriteToken(stoken);
            return token;

        }

        public async Task<Response> Login(string username, string password)
        {
            User user;

            try
            {
                
                
                user = await _context.AppUsers.Where(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
                
                 if (user == null) return new Response {status=false,Result="Login Failed" };

                 // create token
                user.Token = CreateToken(user);
                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();

                return new Response { status = true, Result = user.Token };
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<Response> LoginWithToken(string token)
        {
            try
            {
                var user = await _context.AppUsers.Where(x => x.Token == token).SingleAsync();
                if (user == null) return new Response { status = false, Result = "Login Failed" };
                return new Response { status = true, Result = "Login Successful" }; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public async Task<Response> AssignRoletoUser(int roleID, int userID)
        {
            var userRole = await _context.UserRoles.Where(x => x.RoleID == roleID && x.UserID == userID).FirstOrDefaultAsync();
            if (userRole != null)
                return new Response { status = false, Result = "Role has already been assigned to this user" };

            try
            {
                UserRole data = new UserRole
                {
                    RoleID = roleID,
                    UserID = userID
                };

                await _context.UserRoles.AddAsync(data);
                await _context.SaveChangesAsync();
                return new Response { status = true, Result = "Successful" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserWithRole(int ID)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(ID);
                var userRole = await _context.UserRoles.Where(x => x.UserID == ID).SingleOrDefaultAsync();

                if (userRole != null) user.Role = await _context.Roles.Where(x => x.ID == userRole.RoleID).SingleAsync();


                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
