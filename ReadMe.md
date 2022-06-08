## Web API App template

this web api app template is made to better understanding the back end enviroment and all his functionalities
using two of most common design patterns (DDD - Design Driven Development) and (MVC - Model View Controller)
going thrue all steps needed to deploy an api in a local server using docker.



## solution setup

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

the MVC strucutere can be obtained using the following command
```
dotnet new mvc -au None
```

this way dotnet will implemente the folders and file structure without any template.



## Docker configuration




