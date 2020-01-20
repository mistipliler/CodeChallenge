# Prerequisites

1) Connection String
    ConnectionString is located in appsettings.Development.json file.

2) To create database please run

    Linux:
     dotnet ef database update InitialCreateDB
  
    Windows:
     Visual Studio > Nuget Package Manager > Package Manager Console
     PM > add-migration InitialCreateDB
  
    At the program's first start, sample data will be inserted.
  
3) Login:
      https://localhost:5001/api/Login?username=user&password=user
  
4) API Test:
      //Get Company List
      https://localhost:5001/api/Company
      
      //Get Company by Id
      https://localhost:5001/api/Company/GetCompanyById/{id}
  
     //Get Company by Isin
     https://localhost:5001/api/Company/GetCompanyByIsin/{isin}
  
  
