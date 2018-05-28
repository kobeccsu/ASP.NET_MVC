namespace DemoMVC.LocalDbContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LocalDb : DbContext
    {
        public LocalDb()
            : base("name=LocalDb")
        {
        }

        public virtual DbSet<Login_User> Login_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login_User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Login_User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
