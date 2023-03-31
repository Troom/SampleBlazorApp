## SimpleBlazorApp

A simple API + Blazor project written for demonstration purposes only.  
Stack: C# + NET Core + EntityFramework Core + MS SQL + BlazorClient 

# What and why i use:

MediatrR -> because I like small controllers.
FluentValidation (Backend)  -> because it's super powerfull
DataAnotations (Frontend) -> it's easier.
ApplicationState -> To share data between components in Blazor app.
LocalStorage - > To reduce the number of requests to the API
Mudblazor -> because this allow me to create pretty application in short time.

# To use this project you should
Install Visual Studio 2022  
Install SQL server and fill your connection string to appsetting json.  
Type `Add-Migration DataSeed`  
Type `update-database` inside nuget console  
Run the project  

# To deploy this project you should
I do not recommend the application is still under construction.



# TODO: 
* Auth
* Make tests for app.  
* Refactor code

# Enpoints  

/Order/GetOrder/{id}  
/Order/GetOrders  
/Order/CreateOrder/Create
/Order/UpdateOrder  
/Order/DeleteOrder/{id}  