# Prerequisites

1) Connection String
    ConnectionString is located in appsettings.Development.json file.

2) To create database (MSSQL) please run

    Linux:
     dotnet ef database update InitialCreateDB
  
    Windows:
     Visual Studio > Nuget Package Manager > Package Manager Console
     PM > add-migration InitialCreateDB
  
    At the program's first start, sample data will be inserted.
  
# API

1) Login:
      https://localhost:5001/api/Login?username=user&password=user
    
    This method generate a token which is used for authorization.
  
2) API Test:
      //Get Company List
      https://localhost:5001/api/Company
      
      //Get Company by Id
      https://localhost:5001/api/Company/GetCompanyById/{id}
  
     //Get Company by Isin
     https://localhost:5001/api/Company/GetCompanyByIsin/{isin}
     
     //Create Company (POST Method)
    https://localhost:5001/api/Company/CreateCompany
  
    Sample Data:
      {
      "Name": "TestCompany",
      "Exchange": "Nasdaq",
      "Ticker": "TECO",
      "Isin": "MKA1923123",
      "Website": "www.testcompany.com"
      }
      
      //Update Data (PUT Method)
      https://localhost:5001/api/Company/UpdateCompany
      
    Sample Data:
      {
      "Id": 1,
      "Name": "TestCompany",
      "Exchange": "Nasdaq",
      "Ticker": "TECO",
      "Isin": "MKA1923123",
      "Website": "www.testcompany.com"
      }

  
