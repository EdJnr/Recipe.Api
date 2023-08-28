using Microsoft.EntityFrameworkCore;
using Recipe.Domain.Commons;
using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Persistence.Contexts
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<CommentsEntity> Comments { get; set; }

        public virtual DbSet<DifficultyLevelsEntity> DifficultyLevels { get; set; }

        public virtual DbSet<IngredientsEntity> Ingredients { get; set; }

        public virtual DbSet<RecipesEntity> Recipes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IngredientsEntity>()
                .HasOne(e => e.Recipe)
                .WithMany(e => e.Ingredients)
                .HasForeignKey(e => e.RecipeId);

            modelBuilder.Entity<CommentsEntity>()
                .HasOne(e => e.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(e => e.RecipeId);

            modelBuilder.Entity<RecipesEntity>()
                .HasOne(r => r.DifficultyLevel)
                .WithMany()
                .HasForeignKey(r => r.DifficultyLevelId);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
