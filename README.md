before the start 
-  you need to install docker on your local system
-  you need to have mysql user 

then you have to set your mysql password in appsettings.json

for cofig Database , run this command on package manager 
`dotnet ef  migrations add InitialCreate --project PhoneBook
dotnet ef database update --project PhoneBook
dotnet ef  migrations add InitialCreate --project PhoneBookTest
dotnet ef database update --project PhoneBookTest`

then run this commands .
`dotnet build 
dotnet test`

