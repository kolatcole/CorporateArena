using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateArena.Infrastructure
{
    public class TContext:DbContext
    {
        public TContext(DbContextOptions<TContext> options) : base(options)
        {

        }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
    }
}
