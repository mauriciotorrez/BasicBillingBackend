# BasicBillingBackend
 - Clone https://github.com/mauriciotorrez/BasicBillingBackend repository 
 - Pull master branch
 - Find DB files on 'DB' folder
 - Configure the correct path of database 'BasicBillingDB.db' on 'BasicBilling.API/Models/BasicBillingDBContext.cs' file
 - Configure the correct path of database 'BasicBillingDBTest.db' on 'IntegrationTest/TestBasicBillingDBContext.cs' file
 - Open cmd terminal then navigate to your clone repository 
 - Go to folder 'BasicBilling.API' where is located 'BasicBilling.API.csproj' file
 - Run on cmd: 'dotnet build BasicBilling.API.csproj' to build the API project
 - Run on cmd: 'dotnet run BasicBilling.API.csproj' to run the API
 - Navigate in cmd to  'BasicBilling.Test'
 - Run on cmd: 'dotnet test BasicBilling.Tests.csproj' to run all unit tests
 - Navigate in cmd to  'IntegrationTest'
 - Run on cmd: 'dotnet test IntegrationTest.csproj' to run all integration tests

Once you have you application running you can test API
 - Go to 'PostmanCollection' folder then import the collection to postman
 - Send Get pending to get list of pending bills by client
 - Send Get search to get list of payments by category
 - Send Post create billing (Set valid period(int) and category(string)) to create billings for that period for all registered clients
 - Send Post pay (Set valid  clientId(int), period(int), category(string)) to register a new pay and set status to 2 on bill table.

Notice 
- 'BasicBillingDB.db' has already inserted bills for periods 202101, 202102, 202103, 202104
- If you want to register a new bill should be greater or equal than 202105
- If you want to register new pay you have to find a valid pending bill for a valid client,  period and category