using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SalesDAL.Models
{
    public class MyDbContext: DbContext
    {
        private string _username;
        public string Username { get { return _username; } set { _username = value; } }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Access> Access { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<AccessRole> AccessRole { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Server=127.0.0.1;Database=desa;Port=5432;User Id=migrations;Password=de$2s!3XN4;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleId = -1, RoleName = "Administrator", CreatedBy = "Admin", CreatedDate = DateTime.Now, Active = true }); 

            modelBuilder.Entity<User>().HasData(
                new User() { UserId=-1, FisrtName = "Admin", LastName = "Admin", Username = "Admin", Password = "39dc14dc1feac6be2702abb4e486f2bc755b0777c827457b24dae658f6266494", Email="admin@admin", CreatedBy = "Admin", CreatedDate = DateTime.Now, Active = true });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole() { UserRolId = -1, RoleId = -1, UserId = -1, CreatedBy = "Admin", CreatedDate = DateTime.Now, Active = true } );
        }

        /// <summary>
        /// Set the username in de DbContex from the client that call the API
        /// </summary>
        /// <param name="claims"></param>
        public void SetUsernameToContext(ClaimsIdentity claims)
        {
            Username = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
        }

    }
}
