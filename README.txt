There are default users with corresponding roles

username			password			role
========================================================================
admin				admin				Leader
ProjectManager			ProjectManager			ProjectManager
FreeProjectManager		FreeProjectManager		ProjectManager(without linked entities)
Employee			Employee			Employee
FreeEmployee			FreeEmployee			FreeEmployee(without linked entities)

___________________________________________
XUNIT TESTS
Classes with tests should be run separately 
___________________________________________


There are two DbContext's (Check your local Data source name)
ContextName		ConnectionString
=========================================================================
AppDbContext		Data Source=.;Initial Catalog=SibersApi;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;
IdentityDbContext	Data Source=.;Database=IdentityDB;Trusted_Connection=True;TrustServerCertificate=true

==========================================================================
update-database -context IdentityContext  (Default project Sibers.WebAPI)
update-database -context AppDbContex  (Default project Sibers.DAL)