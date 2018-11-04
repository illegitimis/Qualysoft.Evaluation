# Qualysoft.Evaluation

## tags

- `.NETCoreApp`,Version=v2.1/`netcoreapp2.1`
- `Microsoft.AspNetCore.*` version _2.1.1_
- `Microsoft.EntityFrameworkCore.*` _2.1.4_
- `Swashbuckle.AspNetCore.Swagger` version _3.0.0_
- `xunit.*` version _2.3.1_
- `NSubstitute` version _3.1.0_


## approach

- To resemble an enterprise project, I chose to use domain driven design for this sample app with an onion/clean architecture scaffolding.
- There are unit tests for each layer of the onion
- Integration tests for the api using `TestServer`
- Repository integration tests with an _in memory_ db
- Several other goodies: MVC filters, exception middleware, `swagger` description & examples, generic EF repository, clear separation of concerns, code comments.

## separate configuration based on environment

- **Development** uses an in memory database with default `Microsoft.Extensions.DependencyInjection.Abstractions` IoC
- **Production** uses a SQL Server database with an `Autofac` container
- **Staging** uses a SQLite db with no dependencies injected, so as to test status code error pages

## migrations

- couldn't get automatic incremental migrations to work with either `Simple.Migrations`, nor `Microsoft.EntityFrameworkCore`
- Relied on existing tooling with `Package Manager Console`
```cmd
Add-Migration InitialCreate
Add-Migration Seed
Add-Migration BogusFakerSeed
Update-Database -Verbose
Script-Migration
```
- Generated full migration script was saved and put to `dbup` use