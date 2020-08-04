using CorporateArena.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CorporateArena.Infrastructure
{
    //Extenting from AuthorizeAttribute or Attribute is upto user choice.
    //You can consider using AuthorizeAttribute if you want to use the predefined properties and functions from Authorize Attribute.
    public class A1AuthorizePermission : AuthorizeAttribute,IAuthorizationFilter
    {
        public string Permissions { get; set; } //Permission string to get from controller

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Validate if any permissions are passed when using attribute at controller or action level
            if (string.IsNullOrEmpty(Permissions))
            {
                //Validation cannot take place without any permissions so returning unauthorized
                context.Result = new UnauthorizedResult();
                return;
            }


            //The below line can be used if you are reading permissions from token
            //var permissionsFromToken=context.HttpContext.User.Claims.Where(x=>x.Type=="Permissions").Select(x=>x.Value).ToList()

            //var emailFromToken = context.HttpContext.User.FindFirst("email");

            var emailFromToken = context.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var _context = context.HttpContext.RequestServices.GetRequiredService<TContext>();
            //var _context = (TContext)_con.GetService(typeof(TContext));
            var user = _context.AppUsers.Where(x => x.Email == emailFromToken).SingleOrDefault();

            
            //var userRole = await _context.UserRoles.Where(x => x.UserID == ID).SingleOrDefaultAsync();

            //if (userRole != null) user.Role = await _context.Roles.Where(x => x.ID == userRole.RoleID).SingleAsync();


            //return user;

            
            var userRole =  _context.UserRoles.Where(x => x.UserID == user.ID).SingleOrDefault();

            // this needs to be optimized
            if (userRole != null)
            {
                user.Role =  _context.Roles.Where(x => x.ID == userRole.RoleID).Single();
                var rolePrivileges = _context.RolePrivileges.Where(x => x.RoleID == user.RoleID).ToList();
                if (rolePrivileges != null)
                {
                    var privs = new List<Privilege>();
                    foreach (var rp in rolePrivileges)
                    {
                        var priv = _context.Privileges.Where(x => x.ID == rp.PrivilegeID).Single();

                        privs.Add(priv);
                    }
                    user.Role.Privileges = privs;
                    //user.Role.Privileges = await _context.Privileges.Where(x => x.ID == user.RoleID).ToListAsync();
                }
            }













            if (user.Role.Privileges != null)
            {
                foreach (var privilege in user.Role.Privileges)
                {
                    if (privilege.Name == Permissions)
                        return;
                }
            }
            context.Result = new UnauthorizedResult();
            return;


            ////Identity.Name will have windows logged in user id, in case of Windows Authentication
            ////Indentity.Name will have user name passed from token, in case of JWT Authenntication and having claim type "ClaimTypes.Name"
            //var userName = context.HttpContext.User.Identity.Name;
            //var assignedPermissionsForUser = MockData.UserPermissions.Where(x => x.Key == userName).Select(x => x.Value).ToList();



            //var requiredPermissions = Permissions.Split(","); //Multiple permissiosn can be received from controller, delimiter "," is used to get individual values
            //foreach (var x in requiredPermissions)
            //{
            //    if (assignedPermissionsForUser.Contains(x))
            //        return; //User Authorized. Wihtout setting any result value and just returning is sufficent for authorizing user
            //}

            //context.Result = new UnauthorizedResult();
            //return;
        }
    }
}



