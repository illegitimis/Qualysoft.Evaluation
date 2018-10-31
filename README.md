# Qualysoft.Evaluation

## migrations

Package Manager Console
```cmd
Add-Migration InitialCreate
Update-Database
Add-Migration Seed
Update-Database -Verbose
```

## todo

- functional test http://localhost:5000/swagger/v1/swagger.json generated json as in https://github.com/illegitimis/Tutorial/blob/master/usvc/Swagger.md
- integration test http://localhost:5000/index.html swaggerUI at base route
- split configuration
- Autofac IoC instead of `Microsoft.Extensions.DependencyInjection.Abstractions`
- faker
