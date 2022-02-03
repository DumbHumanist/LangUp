using Microsoft.EntityFrameworkCore;

namespace ServerLangUp.Models
{
    public class TestContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserTest> UserTests { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role admin = new Role
            {
                RoleId = 1,
                Name = "admin"
            };
            Role moderator = new Role
            {
                RoleId = 2,
                Name = "moderator"
            };
            Role user = new Role
            {
                RoleId = 3,
                Name = "user"
            };

            User moderatorUser = new User
            {
                UserId = 2,
                Email = "moder@gmail.com",
                Login = "moderator",
                Password = "1234",
                RoleId = moderator.RoleId
            };
            User adminUser = new User
            {
                UserId = 1,
                Email = "admin@gmail.com",
                Login = "admin",
                Password = "1234",
                RoleId = admin.RoleId
            };
            modelBuilder.Entity<UserTest>()
                .HasKey(ut => new { ut.UserId, ut.TestId });
            modelBuilder.Entity<UserTest>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTests) 
                .HasForeignKey(ut => ut.UserId);
            modelBuilder.Entity<UserTest>()
                .HasOne(ut => ut.Test);

            modelBuilder.Entity<Role>().HasData(new Role[] { admin, moderator, user });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, moderatorUser });

            base.OnModelCreating(modelBuilder);
        }
    }
}
