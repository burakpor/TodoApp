# TodoApp
## Prerequisites

###### Windows
- Visual studio 2019
- Nodejs v14+
- Angular Cli v11+

###### Linux
- dotnet cli version 5.0+
- Nodejs v14+
- Angular Cli v11+

## Development

Install npm packages. Open ClientApp in command line terminal, type
```
npm install
```

Start app by open ClientApp folder in command line terminal, execute following command
```
ng serve
```
Run TodoApp with IIS Express, Open chrome type http://localhost:4200. You are good to go.

## Creating Release Package

###### Linux
```
dotnet publish -c Release -r linux-x64 --output ./PublishFolder TodoApp.csproj 
```

###### Windows
Create a folder publish profile then right click TodoApp select Publish then select publish to folder.

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



