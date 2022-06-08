## Web API App template

this web api app template is made to better understanding the back end enviroment and all his functionalities
using two of most common design patterns (DDD - Design Driven Development) and (MVC - Model View Controller)
going thrue all steps needed to deploy an api in a local server using docker.

## Required Softwares

- Visual Studio or Visual Studio Code https://visualstudio.microsoft.com/pt-br/downloads/
- DotNet Runtime https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime
- Docker https://docs.docker.com/desktop/windows/install/
- Postman https://www.postman.com/downloads/



## solution setup

The domain driven design is and softaware archtecture pattern the utilize folders, called as domains,
to separate and organize the solution folders. this way we can scale our software creating new folders and files
without the need to change the previous features that we have in the softaware.

the WebApiTemplate.Api is the domain where we will handle all the coding related to the software functionality
the webApiTemplate.Domain is the domain where we will store all the software rules.
the WebApitemplate.Shared is the domain where ww will store any kind of code that can be used in other domains
like you have an ID that is used in a user profile and the same ID is used in the payment system, so you can
store this ID model in the shared domain to utilizes in more then one place.
the WebApiTemplate.Tests is the place where we will handle the tests from all the others domains that we have
or we will have in the software.


created the folders and used the following commands to implement the solution structure:

```
dotnet new sln
```
```
dotnet new classlib
```
inside domain and shared folders and
```
dotnet new mstest
```
inside the tests folder.
```
dotnet sln add {folder name} 
```
to add the folder to the solution
```
dotnet restore
```
to compile all files to the solution

and finally we need to enter in each folder to make the relations to the other folders using the command

```
dotnet add reference {folder path}
```


## Web Api Structure

the Model-View-Controller or MVC is an archtecture pattern that separates our folders in this 3 main folders
each one having the following use:

the Model folder is where we place the code that will be used to represent our database inside the software
this means that if you have a table inside your database with ID and Name columns you need to create a model
inside of this folder with the same fields so when you bring the information from the database the Web Api can
use this model to show the information that we requested from the database

the Controller folder is the place where we will store all the commands that are related to front end and database
requests. so when the user decide to change his password the code that will take this information and bring this information
to our api will be inside the controllers folder.

and the View folder is where we can place the HTML and CSS code to show to our user the interface of our Web Api.

the MVC strucutere can be obtained using the following command
```
dotnet new mvc -au None
```

this way dotnet will implemente the folders and file structure without any template.



## Database Setup

to create the database that we will use to store our data, we will utilize the Docker container system.
this way you can simulate an online database inside your computer without the need for conecting to an external server.

your data will be saved here:

docker tab image

so you can connect to docker utilizing a port like we do in an external server

to create the container we need to create an docker-compose.yml file and utilize the sample that we have here to create
a basic server inside our container this way we can acess and utilize this container as an server inside our own computer

after you configure the docker-compose.yml file you can execute the following command in the terminal:
```
docker-compose up
```

this will setup and run the server inside the docker application like in the image below

docker container iamge

so now your server inside on your local machine is runing and we are ready to start filling this server with databases, tables
and everything we need.








