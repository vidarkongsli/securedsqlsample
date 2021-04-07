# securedsqlsample

Code for blog post Securing your ASP.NET database access with Azure SQL and Azure pipelines

## Run locally

### Prerequisites

Install the latest .NET 5 SDK.

**Windows:**

```posh
scoop install dotnet-sdk
```

**macOS:**

```
brew install --cask dotnet-sdk
```

### Start app

Migrate the database schema and start web host:

```posh
dotnet run --migrate
```

## Run Azure pipeline

* Fork this repo.
* Create an Azure ARM service connection named *SECURED_SQL_SAMPLE_ARM* to the Azure subscription you want to use
* Create an Azure pipeline based on `./azure-pipelines.yml`
* Set the following variables for the pipeline:
   1. **resourceGroupName**: the name of the resource group you want to deploy to. (Created automatically if not existing.)
   1. **aadAdminLogin**: the name of the Azure AD principal to be Azure SQL Server administrator (user or group)
   1. **aadAdminOid**: the object Id of the Azure AD principal to be Azure SQL Server administrator (user or group)
