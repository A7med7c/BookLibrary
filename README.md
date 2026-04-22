# BookLibrary

BookLibrary is an ASP.NET Core MVC web application for browsing and purchasing books, with admin tooling for managing the catalog.

## Features
- Browse the catalog with search (title/author) and pagination
- Product details with tiered pricing (base/50/100 quantities)
- Shopping cart with quantity adjustments and session cart count
- Stripe Checkout integration and order confirmation flow
- ASP.NET Core Identity authentication with role-based access (Admin, Customer, Company, Employee)
- Google external login configuration
- Admin CRUD for categories and products, including product image uploads
- Seed data for sample categories and products

## Tech Stack
- .NET 8 / ASP.NET Core MVC
- Entity Framework Core + SQL Server
- ASP.NET Core Identity
- Stripe.net
- Bootstrap 5, DataTables, Toastr, SweetAlert2, TinyMCE
- X.PagedList for pagination

## Project Structure
- **BookLibraryWeb**: MVC app (areas: Customer, Admin, Identity)
- **BookLibrary.DataAcess**: EF Core context, migrations, repositories, unit of work
- **BookLibrary.BL**: domain models and view models
- **BookLibrary.Utility**: constants, email sender, Stripe settings

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server instance

### Configuration
Update values in `BookLibrary/appsettings.json` or user secrets:
- `ConnectionStrings:default`
- `Authentication:Google:ClientId` / `Authentication:Google:ClientSecret`
- `Stripe:SecretKey` / `Stripe:PublishableKey`

> Note: the repository includes placeholder/test keys. Replace them with your own and avoid committing real secrets.

### Database
From the repo root:

```bash
dotnet ef database update \
  --project BookLibrary.DataAcess/BookLibrary.DataAcess.csproj \
  --startup-project BookLibrary/BookLibraryWeb.csproj
```

### Run

```bash
dotnet run --project BookLibrary/BookLibraryWeb.csproj
```

## Notes
- Roles are seeded the first time the register page is loaded.
- `EmailSender` is a no-op implementation; wire up a real provider if you need outbound email.

## Scripts
- Build: `dotnet build BookLibrary.sln`
- Test: `dotnet test BookLibrary.sln`
