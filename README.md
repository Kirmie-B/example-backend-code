# My Example Backend Code

This Git repository is being created as an example of backend code that is based on what I've created in the past. It has no real goal other than to show a bit of my coding ability and style. Since I try to have an emphasis on readability and separtion of concerns, I am going to fill this README.md out in a similar way to what I would do if I was writing real code with a purpose that is shared amongst one or more teams of programmers. I'm also deciding what to write while I'm doing this and using Visual Studio Code exclusively for the first time, so I'm not going to be as focused on each section as I would normally be. Especially at first. I'm also doing this solo and, currently at least, without AI help, so there are bound to be a few minor mistakes here and there. Such as the inevitable spelling errors that will show up in this file since there is no spellcheck where I'm typing this. :P

## Solution Structure

Below is a basic explanation of the project structure in the solution (not currently using a solution). All projects must have their own test project in the Tests folder.

### Garden:

This project contains the essential setup of the ASP.NET solution and the controllers for the API. It is responsible for creating the endpoints, documentation, and transformation of input and output for the controller and service levels of the solution.

### Garden.DataTransferObjects:

This project contains the data transfer objects (DTO's) for the input and output of the controllers in this API. The files in this project should only be used by the Garden project and anynecessary data from other layers must be converted to or from these objects at that level.

### Garden.Models:

This project contains the intermediary models that will contain data as it is used throughout the program.

### Garden.Services:

This project contains the different service layer classes for the solution. This project cannot reference any DTO classes directly and cannot call any external things directly.

### Garden.ExternalDataTransferObjects:

This project contains the various third party related DTO's for accessing external things.

### Garden.Repositories:

This project holds the different repository level classes. These classes are responsible for calling external APIs and converting to and from the appropriate DTOs and models.

### Garden.DataAccess:

This project holds the different DataAccessObject (DAO) classes that are responsible for interacting with internally owned data.

### Garden.BusinessLogic:

This project is for shared classes that perform basic business logic.

### Tests:

This folder contains all of the test projects. Each project that has tests will have its own test project.

## Running the Solution

### Docker

1. Navigate to the .devcontainer folder in the terminal.
2. Run docker compose up from inside of .devcontainer

##  Code

1. Right-click Garden.Web.csproj in the Explorer window of Visual Studio Code.
2. Go to "Debug -> Start New Instance" to start the program with debugging or "Debug -> Start without Debugging" to start the program without debugging.

## Database

The database used by this API is PostgreSQL. It uses Flway for running and updating the schema. Flyway is setup in the docker-compose.yml file and should create the database and migrations required upon starting the Docker container locally.

Here are the general rules for the scripts:

1. All scripts must be placed in the Schema folder.
2. All scripts must use the following format for their name (note the double underscore): V#__NameOfWhatIsBeingDone.sql
3. All version numbers must be unique and the next available number must be used when a script is added.
4. Never delete a script as this can cause issues with Flyway if somebody uses a previously existing version number. This can also cause unexpected behavior if the database gets into an unexpected state due to a change having been applied that is no longer in the scripts.
5. Defensively check for the changes already having been applied inside of the SQL script. Flyway will handle migrations, but this will help protect us if the script is run again for some reason.
6. If a script only changes the data inside of tables and does not change the schema, it should end with '_DML.sql'. DML stands for Data Manipulation Language. This makes it easier to tell which scripts modify the schema itself compared to those that only update the data in case there is a need to differentiate between the two.
7. All tables must contain a generic primary key that is either an integer or a GUID/UUID that isn't necessarily related to the data itself. This makes it much easier to update the data if a unique value in the table is no longer unique.
8. Foreign keys to a table's primary key should have the colon named as table_name_id.

## Tests

All tests must be in the Tests folder in a project that begins with the name of the project that is being tested, followed by Tests.csproj. The tests will use NUnit and Moq to unit tests each area. Below are the rules to follow:

1. All mocks should be verified if possible. Ensuring the mocked function was called/not called the expected number of times can help prevent a number of issues.
2. Each class being tested should have its own test class.
3. Use regions to separate the different functions being tested. This allows collapsing the code to quickly jump between areas.
4. Use regions to surround the setup for each test. This makes it easy to jump straight to the call of the tested function and the Assert calls.
5. Each unit tests should only test one function as much as posible to limit their scope.
6. Reference type variables that are passed into the tested function cannot be used for Assert checks at the end of the test. These reference type variables can be changed by the tested code and therefore cannot be trusted to be accurate. Typically resulting in false positive results.
7. It.IsAny<T>() should be avoided whenver possible. Using that can result in bad values being considered as correct and resulting in false positive results.
8. Using Assert.Multiple(...) is great, but don't check if a variable is null inside this right before checking a bunch of that same values properties in there as well. The null check should be performed outside as all of the other checks will either fail because the value is null or result in a false positive if the specific value was supposed to be null and the ? operator was used.