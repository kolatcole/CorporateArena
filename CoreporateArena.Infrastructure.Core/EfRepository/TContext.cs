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
        public DbSet<BrainTeaser> BrainTeasers { get; set; }
        public DbSet<BrainTeaserAnswer> BrainTeaserAnswers { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<TrafficUpdate> TrafficUpdates { get; set; }
        public DbSet<TrafficComment> TrafficComments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ArticleLike> ArticleLikes { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Privilege>().HasData(

                new Privilege
                {
                    ID=1,
                    DisplayName="Create User",
                    Name= "CreateUser",
                    Entity = "User",
                    Action= "Create"
                }, new Privilege
                {
                    ID = 2,
                    DisplayName = "Read User",
                    Name = "ReadUser",
                    Entity = "User",
                    Action = "Read"
                }, new Privilege
                {
                    ID = 3,
                    DisplayName = "Update User",
                    Name = "UpdateUser",
                    Entity = "User",
                    Action = "Update"
                },
                new Privilege
                {
                    ID = 4,
                    DisplayName = "Delete User",
                    Name = "DeleteUser",
                    Entity = "User",
                    Action = "Delete"
                }, new Privilege
                {
                    ID = 5,
                    DisplayName = "Create Role",
                    Name = "CreateRole",
                    Entity = "Role",
                    Action = "Create"
                }, new Privilege
                {
                    ID = 6,
                    DisplayName = "Read Role",
                    Name = "ReadRole",
                    Entity = "Role",
                    Action = "Read"
                }, new Privilege
                {
                    ID = 7,
                    DisplayName = "Update Role",
                    Name = "UpdateRole",
                    Entity = "Role",
                    Action = "Update"
                }, new Privilege
                {
                    ID = 8,
                    DisplayName = "Delete Role",
                    Name = "DeleteRole",
                    Entity = "Role",
                    Action = "Delete"
                }, new Privilege
                {
                    ID = 9,
                    DisplayName = "Create BrainTeaser",
                    Name = "CreateBrainTeaser",
                    Entity = "BrainTeaser",
                    Action = "Create"
                }, new Privilege
                {
                    ID = 10,
                    DisplayName = "Read BrainTeaser",
                    Name = "ReadBrainTeaser",
                    Entity = "BrainTeaser",
                    Action = "Read"
                }, new Privilege
                {
                    ID = 11,
                    DisplayName = "Update BrainTeaser",
                    Name = "UpdateBrainTeaser",
                    Entity = "BrainTeaser",
                    Action = "Update"
                }, new Privilege
                {
                    ID = 12,
                    DisplayName = "Delete BrainTeaser",
                    Name = "DeleteBrainTeaser",
                    Entity = "BrainTeaser",
                    Action = "Delete"
                }, new Privilege
                {
                    ID = 13,
                    DisplayName = "Create Vacancy",
                    Name = "CreateVacancy",
                    Entity = "Vacancy",
                    Action = "Create"
                }, new Privilege
                {
                    ID = 14,
                    DisplayName = "Read Vacancy",
                    Name = "ReadVacancy",
                    Entity = "Vacancy",
                    Action = "Read"
                }, new Privilege
                {
                    ID = 15,
                    DisplayName = "Update Vacancy",
                    Name = "UpdateVacancy",
                    Entity = "Vacancy",
                    Action = "Update"
                },
                new Privilege
                {
                    ID = 16,
                    DisplayName = "Delete Vacancy",
                    Name = "DeleteVacancy",
                    Entity = "Vacancy",
                    Action = "Delete"
                }, new Privilege
                {
                    ID = 17,
                    DisplayName = "Create Article",
                    Name = "CreateArticle",
                    Entity = "Article",
                    Action = "Create"
                }, new Privilege
                {
                    ID = 18,
                    DisplayName = "Read Article",
                    Name = "ReadArticle",
                    Entity = "Article",
                    Action = "Read"
                }, new Privilege
                {
                    ID = 19,
                    DisplayName = "Update Article",
                    Name = "UpdateArticle",
                    Entity = "Article",
                    Action = "Update"
                }, new Privilege
                {
                    ID = 20,
                    DisplayName = "Delete Article",
                    Name = "DeleteArticle",
                    Entity = "Article",
                    Action = "Delete"
                }, new Privilege
                {
                    ID = 21,
                    DisplayName = "Create TrafficUpdates",
                    Name = "CreateTrafficUpdates",
                    Entity = "TrafficUpdates",
                    Action = "Create"
                }, new Privilege
                {
                    ID = 22,
                    DisplayName = "Read TrafficUpdates",
                    Name = "ReadTrafficUpdates",
                    Entity = "TrafficUpdates",
                    Action = "Read"
                }, new Privilege
                {
                    ID = 23,
                    DisplayName = "Update TrafficUpdates",
                    Name = "UpdateTrafficUpdates",
                    Entity = "TrafficUpdates",
                    Action = "Update"
                }, new Privilege
                {
                    ID = 24,
                    DisplayName = "Delete TrafficUpdates",
                    Name = "DeleteTrafficUpdates",
                    Entity = "TrafficUpdates",
                    Action = "Delete"
                }

            );
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    ID=1,
                    DateCreated=DateTime.Now,
                    DisplayName="SuperUser",
                    Name="SuperUser",
                    UserCreated=1
                } ,
                new Role
                {
                    ID = 2,
                    DateCreated = DateTime.Now,
                    DisplayName = "Basic",
                    Name = "Basic",
                    UserCreated = 1
                }

            );

            modelBuilder.Entity<RolePrivilege>().HasData(
                new RolePrivilege
                {
                    ID = 1,
                    PrivilegeID=2,
                    RoleID=2
                }, new RolePrivilege
                {
                    ID = 2,
                    PrivilegeID = 6,
                    RoleID = 2
                }, new RolePrivilege
                {
                    ID = 3,
                    PrivilegeID = 10,
                    RoleID = 2
                }, new RolePrivilege
                {
                    ID = 4,
                    PrivilegeID = 14,
                    RoleID = 2
                },
                 new RolePrivilege
                {
                    ID = 5,
                    PrivilegeID = 18,
                    RoleID = 2
                }, new RolePrivilege
                {
                    ID = 6,
                    PrivilegeID = 22,
                    RoleID = 2
                }, new RolePrivilege
                {
                    ID = 7,
                    PrivilegeID = 1,
                    RoleID = 1
                }, new RolePrivilege
                {
                    ID = 8,
                    PrivilegeID = 2,
                    RoleID = 1
                }, new RolePrivilege
                {
                    ID = 9,
                    PrivilegeID = 3,
                    RoleID = 1
                }, new RolePrivilege
                {
                    ID = 10,
                    PrivilegeID = 4,
                    RoleID = 1
                },
                 new RolePrivilege
                 {
                     ID = 11,
                     PrivilegeID = 5,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 12,
                     PrivilegeID =6,
                     RoleID = 1
                 }


                 , new RolePrivilege
                 {
                     ID = 13,
                     PrivilegeID = 7,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 14,
                     PrivilegeID = 8,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 15,
                     PrivilegeID = 9,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 16,
                     PrivilegeID = 10,
                     RoleID = 1
                 },
                 new RolePrivilege
                 {
                     ID = 17,
                     PrivilegeID =11,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 18,
                     PrivilegeID = 12,
                     RoleID = 1
                 }



                 , new RolePrivilege
                 {
                     ID = 19,
                     PrivilegeID = 13,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 20,
                     PrivilegeID = 14,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 21,
                     PrivilegeID = 15,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 22,
                     PrivilegeID = 16,
                     RoleID = 1
                 },
                 new RolePrivilege
                 {
                     ID = 23,
                     PrivilegeID = 17,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 24,
                     PrivilegeID = 18,
                     RoleID = 1
                 }



                 , new RolePrivilege
                 {
                     ID = 25,
                     PrivilegeID = 19,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 26,
                     PrivilegeID = 20,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 27,
                     PrivilegeID = 21,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 28,
                     PrivilegeID = 22,
                     RoleID = 1
                 },
                 new RolePrivilege
                 {
                     ID = 29,
                     PrivilegeID = 23,
                     RoleID = 1
                 }, new RolePrivilege
                 {
                     ID = 30,
                     PrivilegeID = 24,
                     RoleID = 1
                 }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    DateCreated=DateTime.Now,
                    RoleID=1,
                    Email="tkolawole@Inspirecoders.com",
                    FirstName="System",
                    LastName="User",
                    UserName="System Administrator",
                    IsActive=true,
                    ID=1
                }    
                
            );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    DateCreated = DateTime.Now,
                    RoleID = 1,
                    UserID = 1,
                    ID=1
                }
            );
        }
    }
}
