# Customers CRUD with CQRS(Mediatr) and FluentValidation 
Challenge .Net

# The Problem
CRUD (Create, Read, Update and delete) customers with the follow properties

Customer:
* First name
* Last name
* Gender
* Date of birth
* Address
* Country
* Postal Code
* Email

 * The data must be saved for later consultation.

# Objetives 

* Develop a .Net Core applicaction to solve this challenge.
* Show the use of EntityFramework Core, Mediatr and FluentValidation.
* Enjoy.

# Technologies

* [.Net Core 7.0 SDK]
* [Entity Framework Core]
* [SQLite]
* [FluentValidation]
* [Mediatr]

# Notes
* The database uses on this challenge is SQLite.
* Is developed in .Net 7

# Before executed
   Before execite the application, the migrations to create the tables on DB must be executed.
   To do this, open a console and go to your startUp project folder and execute this command:
   
      ```dotnet ef database update```
	  
	* The entityframework tools need to be installed.
	
# Run the app
	Once you run the app, a swagger page would be open and you can interact with the app, calling the differents methods:
		- Get api/Customer/all => returns all customers created on DB
		- Get api/Customer => returns a customer with the given Identificator
		- Post api/Customer => create a new customer an store it on DB
		- Put api/Customer => update an already existed customer on DB
		- Delete api/Customer => remove a customer with the given Idendtificator
		
# Technical Notes
- For more entities could be an option use AutoMapper
- Use TDD
