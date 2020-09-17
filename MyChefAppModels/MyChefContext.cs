using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyChefAppModels
{
    public partial class MyChefContext : DbContext
    {
        public MyChefContext()
        {
        }

        public MyChefContext(DbContextOptions<MyChefContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountTypes> AccountTypes { get; set; }
        public virtual DbSet<CookingSkills> CookingSkills { get; set; }
        public virtual DbSet<FoodTypes> FoodTypes { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTypes>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);

                entity.Property(e => e.AccountTypeName).HasMaxLength(20);
            });

            modelBuilder.Entity<CookingSkills>(entity =>
            {
                entity.HasKey(e => e.CookingSkillId);

                entity.Property(e => e.CookingSkillName).HasMaxLength(30);
            });

            modelBuilder.Entity<FoodTypes>(entity =>
            {
                entity.HasKey(e => e.FoodTypeId);

                entity.Property(e => e.FoodTypeName).HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.UserName).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
