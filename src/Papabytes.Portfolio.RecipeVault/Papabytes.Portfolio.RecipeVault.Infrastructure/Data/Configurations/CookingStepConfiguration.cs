using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Data.Configurations;

public class CookingStepConfiguration :  IEntityTypeConfiguration<CookingStep>
{
    public void Configure(EntityTypeBuilder<CookingStep> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => new {i.RecipeId, i.Order})
            .IsUnique();

        builder.HasOne(i => i.Recipe)
            .WithMany(r => r.Steps)
            .HasForeignKey(i => i.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}