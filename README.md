# .NetCore.Options
*Version 2.1*

This is my propostal for using Options pattern in ASP.NET Core. 
It is a combination of what I use in my work with this [Microsoft article](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.1 "Options pattern in ASP.NET Core") 
compiled into a minimal Console App solution:

1. Install the following packages (I used 2.1.1.0 version):

* Install-Package Microsoft.Extensions.Configuration -version 2.1.1.0
* Install-Package Microsoft.Extensions.Configuration.Json -version 2.1.1.0
* Install-Package Microsoft.Extensions.Configuration.EnvironmentVariables -version 2.1.1.0
* Install-Package Microsoft.Extensions.DependecyInjection -version 2.1.1.0
* Install-Package Microsoft.Extensions.DependencyInjection.Abstractions -version 2.1.1.0
* Install-Package Microsoft.Extensions.DependencyInjection -version 2.1.1.0
* Install-Package Microsoft.Extensions.Options -version 2.1.1.0
* Install-Package Microsoft.Extensions.Configuration.Binder -version 2.1.1.0

2. Generate appsettings.json and appsettings.[Environment].json

* Right click on each file and go to Properties option;
* Make in *General > Advanced > Copy to Output Directory* value *Copy always* 

3. Look for parameter prefix *wrong_code*

Something like:

```csharp
/// <wrong_code_1>
/// You can't Configure two differents sections into same Option - but otherwise...
/// </wrong_code_1>
```

4. Starts seeing the main program and enjoy it =)
