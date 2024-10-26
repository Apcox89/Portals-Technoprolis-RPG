Questions: reach me at apcox89@gmail.com

Portals-Db Setup Locally:

1) Go to Sql Server Object Explorer in VS or SSMS

2) Click + Add Sql-server in your localdb instance

3) Name the server Portals

	-> the connection string should start like this: Data Source=(localdb)\MSSQLLocalDB;

		-> as prefixed in the Appsettings of the project

	-> If you name it differently, you will have to change the connection string...

4) Now, Open up a bash in the main project directory or in Visual Studio go-to Package Manager Console

	a) dotnet tool install --global dotnet-ef

		=> Run this if you haven't on your system before, or if you have you can skip

	b) dotnet restore

		=> will restore any packages necessary for the project

	c) dotnet ef database update

		=> should automatically scaffold and update the db once the 'Portals' Db is created locally