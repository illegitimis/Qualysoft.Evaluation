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
- faker [1](https://github.com/bchavez/Bogus), [2](http://jackhiston.com/2017/10/1/how-to-create-bogus-data-in-c/)
- Message: `System.MissingMethodException` : No parameterless constructor defined for this `Request` object. 
- Executing `ObjectResult`, writing value of type `Microsoft.AspNetCore.Mvc.SerializableError`.

```json
[
  {
    "ix": 1234,
    "name2": "should get added",
    "date": "2018-11-01T10:56:12.694Z"
  },
  {
    "name": "should get added",
    "date": "2018-11-01T10:56:12.694Z"
  },
  {
    "ix": 1234,
    "name": "should get added"
  },
]
```

```json
{
  "[0]": [
    "Required property 'name' not found in JSON. Path '[0]', line 6, position 3."
  ],
  "[1]": [
    "Required property 'ix' not found in JSON. Path '[1]', line 10, position 3."
  ],
  "[2]": [
    "Required property 'date' not found in JSON. Path '[2]', line 14, position 3."
  ]
}
```

```json
{
  "": [
    "Unexpected character encountered while parsing value: b. Path '', line 0, position 0."
  ]
}
```