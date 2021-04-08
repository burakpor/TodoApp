# TodoApp
## Prerequisites

###### Windows
- Visual studio 2019
- Nodejs v14+
- Angular Cli v11+
- MSSQL Server

###### Linux
- dotnet cli version 5.0+
- Nodejs v14+
- Angular Cli v11+
- Docker
- MSSQL Server running in docker container

## Development

To install npm packages. Open ClientApp folder in command line terminal, type
```
npm install
```
In order to start development server, execute following commands;

Open command line termine goto ClientApp folder, execute following command;
```
ng serve
```
After client app starts, open new command line termine goto TodoApp folder, launch backend api by typing
```
dotnet run TodoApp.csproj
```
You can browse site at http://localhost:5000.

If you use linux environment you need to run mssql server in docker container and set the LocalConnection variable in appsettings.development.json file.

Run following command to initilize mssql server in docker container;

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=myPass123" -p 1433:1433 --name todoDb -d mcr.microsoft.com/mssql/server:2017-latest
```

After MSSQL server starts set LocalConnection variable as

```
Data Source=localhost,1433;Initial Catalog=AppcentTodo;Persist Security Info=True;User Id=sa;Password=myPass123;MultipleActiveResultSets=True
```

Now, as you open http://localhost:5000 TodoApp Api will create database and you can start developing application.

## Creating Release Package

Open TodoApp folder in command line terminal, execute following command;
```
dotnet publish -c Release -r linux-x64 --output ./PublishFolder TodoApp.csproj 
```

## Deploying with docker container.

After publish complete copy Dockerfile into publish folder then open command line terminal, run command
```
docker build -t todo-app .
```
With this command your container will be built. You can run this container by typing 
```
docker run -it -d -p 8080:80 todo-app
```
You can reach site from
```
http://localhost:8080
```

## Running Tests

In order to run tests, open TodoApp.Test folder in command line terminal, run following command;
```
dotnet test TodoApp.Test.csproj
```



