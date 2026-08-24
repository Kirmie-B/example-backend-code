# My Example Backend Code

This Git repository is being created as an example of backend code based on what I've created in the past. It has no real goal other than to show a bit of my coding ability and style. Since a try to have an emphasis on readability and separtion of concerns, I am going to fill this README.md out in a similar way to what I would do if I was writing real code with a purpose that is shared amongst one or more teams of programmers.

## Solution Structure

Below is a basic explanation of the project structure in the solution. All projects must have their own test project in the Tests folder.

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

## Running the Solution

### Docker

1. Navigate to the .devcontainer folder in the terminal.
2. Run docker compose up from inside of .devcontainer

##  Code

1. Navigate to ... in the terminal.
2. Run the command: dotnet run --launch-profile https --project Garden.Web

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
8. Foreign keys to a table's primary key shuould have the colon named as table_name_id.