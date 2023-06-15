using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public DbSet<Access> Access { get; set; }
        public DbSet<AccessRole> AccessRole { get; set; }
        public DbSet<Address> Address { get; set; } 
        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Presentation> Presentation { get; set; }
        public DbSet<PriceType> PriceType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Telephony> Telephony { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<VendorAddress> vendorAddress { get; set; }
        public DbSet<VendorBankAccount> VendorBankAccount { get; set; }
        public DbSet<VendorPhone> VendorPhone { get; set; }




        public MyDbContext(DbContextOptions<MyDbContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Access>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Access>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<AccessRole>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<AccessRole>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<AccessRole>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Address>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Address>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Address>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Bank>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Bank>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Bank>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<BankAccount>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<BankAccount>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<BankAccount>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Brand>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Brand>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Brand>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Category>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Category>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Category>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Client>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Phone>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Phone>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Phone>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Presentation>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Presentation>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Presentation>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<PriceType>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<PriceType>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<PriceType>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Product>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Product>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Product>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<RefreshToken>().Property(s => s.Active).IsRequired();

            modelBuilder.Entity<Role>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Role>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Role>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<SubCategory>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<SubCategory>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<SubCategory>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Telephony>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Telephony>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Telephony>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<User>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<UserRole>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<UserRole>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<UserRole>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Vendor>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<Vendor>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<Vendor>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<VendorAddress>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<VendorAddress>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<VendorAddress>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<VendorBankAccount>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<VendorBankAccount>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<VendorBankAccount>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<VendorPhone>().Property(s => s.Active).IsRequired();
            modelBuilder.Entity<VendorPhone>().Property(s => s.CreatedBy).IsRequired();
            modelBuilder.Entity<VendorPhone>().Property(s => s.CreatedDate).IsRequired();

            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleId = 1, RoleName = "Administrator", CreatedBy = "Admin", CreatedDate = DateTime.Now, Active = true }); 

            modelBuilder.Entity<User>().HasData(
                new User() { UserId= 1, FisrtName = "Admin", LastName = "Admin", Username = "Admin", Password = "39dc14dc1feac6be2702abb4e486f2bc755b0777c827457b24dae658f6266494", Email="admin@admin", CreatedBy = "Admin", CreatedDate = DateTime.Now, Active = true });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole() { UserRolId = 1, RoleId = 1, UserId = 1, CreatedBy = "Admin", CreatedDate = DateTime.Now, Active = true } );
        }

        /// <summary>
        /// Set the username from the client in the dbcontext
        /// </summary>
        /// <param name="claims"></param>
        public void SetUsernameToContext(ClaimsIdentity claims)
        {
            Username = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
        }

        public void SetModifier<T>(T obj)
        {
            Type type = typeof(T);

            PropertyInfo mBy = type.GetProperty("ModifiedBy");
            PropertyInfo mDt = type.GetProperty("ModifiedDate");
            
            mBy.SetValue(obj, Username, null);
            mDt.SetValue(obj, DateTime.Now, null);
        }

        public void SetCreator<T>(T obj)
        {
            Type type = typeof(T);

            PropertyInfo cBy = type.GetProperty("CreatedBy");
            PropertyInfo cDt = type.GetProperty("CreatedDate");

            cBy.SetValue(obj, Username, null);
            cDt.SetValue(obj, DateTime.Now, null);
        }
    }
}
