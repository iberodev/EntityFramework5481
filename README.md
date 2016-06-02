# EntityFramework5481

This is a Sample project created with ASP.NET Core RC2 and EF Core RC2
to show the issue with [the deadlock problem] (https://github.com/aspnet/EntityFramework/issues/5481)

# Instructions to reproduce
1. Clone this repository 
```
git clone https://github.com/iberodev/EntityFramework5481.git
```
2. Restore all the dependencies
```
cd EntityFramework5481
dotnet restore
```
3. Create the MSSQLLocalDB database by updating the database
```
dotnet ef database update
```
4. Run the application
5. Trigger the sample by sending a GET request to:
```
GET localhost: http://localhost:57092/api/people
```

The sample will show the deadlock when trying to perform a Count Async on a query that has null sub-entities
