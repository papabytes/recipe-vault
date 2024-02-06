using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Data.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasMany(r => r.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId);
        
        builder.HasMany(r => r.Steps)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId);
    }
}