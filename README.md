# PersonManager - Instructions

1-  Update the database connection string in appsettings.json

2-  Set PersonManager.Api as StartUp project    

2-  Create the database by running the command Update-Database in the Package Manager Console and by selecting PersonManager.Infrastructure as default project

API doc:

Create Person:
POST https://localhost:44385/api/person
{
	"name": "Person Name",
	"groupPersonId": 1
}

Get all groups:
GET https://localhost:44385/api/group

Search persons by name of group name
https://localhost:44385/api/person?keyword=name
