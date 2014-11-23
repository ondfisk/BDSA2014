using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Entity Framework Code-First

PM> Install-Package EntityFramework

Create Data Context
Create at least one entity
Create Console App for test + EntityFramework
Create DB using Server Explorer or SSMS (Server: (localdb)\MSSQLLocalDB)
Add connection string to Console App.config

    <add name="StuffDB" connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StuffDB;Integrated Security=True" providerName="System.Data.SqlClient" />

Compile run console app with so db code
See that database was created as expected    
Add new stuff to entity or context
Compile run see that it fails

PM> Enable-Migrations -EnableAutomaticMigrations

Fix Configuration.cs so we can compile again.

Add sample data to Seed method of Configuration.cs

Refactor-Extract interface from Context.

Create Models library
Create repository, IDisposable, construct inject IContext

Create Tests library

PM> Install-Package NUnit
PM> Install-Package NUnitTestAdapter

Create test class for repository

Install-Package EntityFrameworkTesting.Moq