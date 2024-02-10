# Recipe Vault API

An application where users can create and share recipes

## Structure
src  
|-- backend  (.NET 6.0)  
|-- frontend (Angular)

## Migrations

Access `src/backend/Papabytes.Portfolio.RecipeVault.Infrastructure` in your terminal and type:

```bash
dotnet ef migrations add <name> -o .\Data\Migrations --context Papabytes.Portfolio.RecipeVault.Infrastructure.Data.RecipeVaultDbContext
```
