# RekorOrder
Limited order application for Rekor




Code Challenge

Customer Orders
	Objective of this technical exercise is to create a .NET solution with Web APIs in order to manage customer orders.

Consider the following tables/entities for your APIs. Feel free to create in-memory lists/data source in
the application or SQL Server to handle your data inserts/retrieval. Stage required data for your APIs.

Tables/Entities
1. Customer
	a. Customer Model
		i. CustomerId, CustomerName, AddressLine1, AddressLine2, City, State, Zip,
Country
2. Order
	a. Order Model
		i. OrderId, ProductId, CustomerId, OrderDate, Quantity, PricePaid, ShippedDate
3. Product
	a. Product Model
		i. ProductId, ProductName, PricePerItem, AverageCustomerRating

Design the following APIs to add/return the following details in JSON format:
	Api 1: Insert customer order details to the ‘Order’ table.
	Api 2: Get all the pending orders which are not yet shipped to the customers.
		• Response
			▪ CustomerId, CustomerName, OrderId, OrderDate, Quantity, PricePaid
	Api 3: Get the list of products with AverageCustomerRating in the order of highest to lowest ratings.
		• Response
			▪ ProductId, ProductName, PricePerItem, AverageCustomerRating

Design standards and expected solution:
1. Recommended technologies: .NET Core, Entity Core Framework & angular 9+.
2. Build your own appropriate UI using Angular 9+.
3. Follow the best practices.
4. Provide API paths for all the APIs along with parameters (if required)
5. Add necessary error handlers in your APIs.
6. Add supporting comments in each API.
7. Feel free to search online or use any out of the box features you would like to use.
8. Zip the final solution/project files and share it on a public drive (ex: google drive, Dropbox etc.)
or use share using personal GitHub account.
