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
dotnet sln add (ls -r **\*.csproj)
```
to add all folders to the solution
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

we are using the .env file to store our passwords and other senstive information (you can read more inside the docker-compose.yml
fie and inside the .env file)

to use this we need to instal the DotNetEnv package using the following command:
```
dotnet add package DotNetEnv
```

to create the database that we will use to store our data, we will utilize the Docker container system.
this way you can simulate an online database inside your computer without the need for conecting to an external server.

your data will be saved here:

///////////////////////////docker tab image


so you can connect to docker utilizing a port like we do in an external server

to create the container we need to create an docker-compose.yml file and utilize the sample that we have here to create
a basic server inside our container this way we can acess and utilize this container as an server inside our own computer

after you configure the docker-compose.yml file you can execute the following command in the terminal:
```
docker-compose up
```

this will setup and run the server inside the docker application like in the image below


////////////////////////////////docker container iamge


so now your server inside on your local machine is runing and we are ready to start filling this server with databases, tables
and everything we need.



## creating the DataBase

to create the database that we will use inside the docker container (that we did in the previous step) we will use the 
concept of "code first" and "fluent mapping" we code the database structure on visual studio and then use the entity 
framework to create the database for us using the migration files. Entity Framework is package with isntructions 
and commands made by Microsoft will translte our C# code to and SQL code and make a migration file so we can apply 
this code inside our database.

that is why the entity framework is called an object relational mapping (ORM) because make the relation between 
or C# code and the SQL database code.

to use the entity framework in our application we need to install the following packages inside our WebApiTemplate.Api folder:
```
dotnet tool install --global dotnet-ef
```
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Entity framework will check for the DbContext instruction inside our files in our project, this instruction are located in
the AppDbContext.cs file. then he will check for all the models that we are mapping inside this file.

in this case we are mapping only the UserModel.cs file but to improve the precision of entity framework and avoid any 
future problem with the database creation we add some instructions to this process using the UserMap.cs file, where
we specify to entity framework any property that we want in our coluns and tables.

before we run the command to create our migrations we need to setup the code inside our Program.cs file this way
the migrations file will have the information about the connection port and other informations related to the database

with all this finished we can execute the following command:

```
dotnet ef migrations add InitialCreation 
```

you can use any name for the first time you are creating the migration files here we used the InitialCreation name
after this if you want to make a new migration file you can use the following command:

```
dotnet ef migrations update (name of your migration)
```

if you check the migrations file inside your migrations folder you will see the instructions that Entity Framework made 
to build our database, so when we execute this code the app will build our database tables and coluns inside our docker
container.


## Migrations Auto Update

each time we start our application we need to run the command:

```
docker ef migrations update
```

this way the entity framework will check if he needs to update our database our tables inside our server. to avoid this
we will created an auto update code that is found inside our Program.cs this way each time we start the application
entity framework will update our database for us.

so if in any momento you need to make a new database, new table or add/remove coluns to your tables you need to make/change
the models, add/remove the configurations in the map file, add/remove in the AppDbContext file and execute the command to 
update the migrations files. a new migration file will be made by entity framework and then you can run the app to changes
take place in the database.

## Runing the first time

if you closed the docker application or stopped our container that we made in our previous step, you need to start it again

open the terminal navigate to our Api folder using:

```
cd WebApiTemplate.Api
```

and run the command:

```
docker-compose up
```

this way we will start our containeir inside the docker application. we need to do this step so when we start our
application we have a place to save our database.

now open a new terminal and run our app using

```
dotnet run
```

## Controllers

Controllers are the second part of our MVC design pattern, they are responsible for getting the information from our fron end
(here we are using postman to handle this front end part) and send this to our API or Database. we will make a simple CRUD 
(Create, Read, Update, Delete) in our project to understand how it works each requisition.

we need to add to our program.cs file the following code:


Since we have only one place to change that is the User database, we need to create a file inside our Controllers folder to
handle our CRUD requisitions.

