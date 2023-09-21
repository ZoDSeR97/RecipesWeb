# RecipesWeb
Recipes Web using Blazor WASM with Tailwindcss

## :white_check_mark: Requirements
We are using MySQL in this journey
```bash
$ node --version
v18.17.0
$ dotnet --version
7.0.401
$ dotnet tool install --global dotnet-ef # This install entity framework globally
```

## :Computer: Front-end ##
- Blazor
- Tailwindcss
- Bootstrap

## :: Back-end ##
- MySQL
- Entity Framework
- ASP.Net

## :checkered_flag: How to run ##
Go to appsetting.json edit connection to your MySQL DB
```json
{  
    "Logging": {    
        "LogLevel": {      
            "Default": "Information",      
            "Microsoft.AspNetCore": "Warning"    
        }  
    },
    "AllowedHosts": "*",    
    "ConnectionStrings":    
    {        
        "DefaultConnection": "Server=localhost;port=3306;userid={yourID};password={yourPass};database={DBName};"    
    }
}
```
Now use these commands in terminal
```bash
$ cd folder_name # cd into folder directory where .cs files are
$ dotnet restore # Restore the dependencies and tools of a project
$ dotnet run
```