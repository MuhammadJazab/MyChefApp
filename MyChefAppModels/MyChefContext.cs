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
        public virtual DbSet<FoodPreferences> FoodPreferences { get; set; }
        public virtual DbSet<FoodTypes> FoodTypes { get; set; }
        public virtual DbSet<Foods> Foods { get; set; }
        public virtual DbSet<Goals> Goals { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WeekMenu> WeekMenu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTypes>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);

                entity.Property(e => e.AccountTypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<CookingSkills>(entity =>
            {
                entity.HasKey(e => e.CookingSkillId);

                entity.Property(e => e.CookingSkillName).HasMaxLength(30);
            });

            modelBuilder.Entity<FoodPreferences>(entity =>
            {
                entity.HasKey(e => e.FoodPreferenceId);
            });

            modelBuilder.Entity<FoodTypes>(entity =>
            {
                entity.HasKey(e => e.FoodTypeId);

                entity.Property(e => e.FoodTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Goals>(entity =>
            {
                entity.HasKey(e => e.GoalId);

                entity.Property(e => e.GoalText)
                    .IsRequired()
                    .HasMaxLength(35);
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasKey(e => e.IngredientId);

                entity.Property(e => e.MenuIngredients)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasKey(e => e.MenuRecipeId);

                entity.Property(e => e.Directions).IsRequired();

                entity.Property(e => e.MenuDay)
                    .IsRequired()
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<WeekMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.Property(e => e.MenuTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WeekDay)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
