using BusinessObject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class EStoreDbContext : IdentityDbContext<AspNetUsers>
    {
        public EStoreDbContext(DbContextOptions<EStoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => new { x.ProviderKey, x.LoginProvider });
            builder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x => new { x.Name, x.LoginProvider, x.UserId });
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims");

            builder.Entity<OrderDetail>().HasKey(x => new { x.OrderId, x.ProductId });

            builder.Entity<Order>().HasOne(x => x.AspNetUsers).WithMany(x => x.Orders).HasForeignKey(x => x.AspNetUsersId);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
