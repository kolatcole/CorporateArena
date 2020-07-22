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


    }
}
