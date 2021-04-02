# TodoApp

Start app by go to ClientApp folder, execute following command
```
ng serve
```
Run TodoApp with IIS Express, Open chrome type http://localhost:4200. You are good to go.

Deploying with docker container.
Right click TodoApp select Publish then select publish to folder. After publish complete copy Dockerfile into publish folder then open command line terminal, run command

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
