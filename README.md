# My Example Backend Code

This Git repository is being created as an example of backend code based on what I've created in the past. It has no real goal other than to show a bit of my coding ability and style. Since a try to have an emphasis on readability and separtion of concerns, I am going to fill this README.md out in a similar way to what I would do if I was writing real code with a purpose that is shared amongst one or more teams of programmers.

## Solution Structure

Below is a basic explanation of the project structure in the solution. All projects must have their own test project in the Tests folder.

### ExampleMain:

This project contains the essential setup of the ASP.NET solution and the controllers for the API. It is responsible for creating the endpoints, documentation, and transformation of input and output for the controller and service levels of the solution.

### ExampleMain.DataTransferObjects:

This project contains the data transfer objects (DTO's) for the input and output of the controllers in this API. The files in this project should only be used by the ExampleMain project and anynecessary data from other layers must be converted to or from these objects at that level.

### ExampleMain.Models:

This project contains the intermediary models that will contain data as it is used throughout the program.

### ExampleMain.Services:

This project contains the different service layer classes for the solution. This project cannot reference any DTO classes directly and cannot call any external things directly.

### ExampleMain.ExternalDataTransferObjects:

This project contains the various third party related DTO's for accessing external things.

### ExampleMain.Repositories:

This project holds the different repository level classes. These classes are responsible for calling external APIs and converting to and from the appropriate DTOs and models.

### ExampleMain.DataAccess:

This project holds the different DataAccessObject (DAO) classes that are responsible for interacting with internally owned data.

### ExampleMain.BusinessLogic:

This project is for shared classes that perform basic business logic.