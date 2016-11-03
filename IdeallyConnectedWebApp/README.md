https://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html

**To add new database**
Add-Migration -c BloggingContext
Add-Database -c BloggingContext

**To add/ reverse engineer existing database**
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

For setting up angularjs:
https://docs.asp.net/en/latest/client-side/angular.html
