# Race Card Viewer

This project will display basic thoroughbred horse race information using data pulled from a database. It will display a list of available dates and tracks to choose from. Once selected the user will be able to select from the race list for the day to view the contenders for a given race.

*** Note: This application is intended to be run exclusively on Windows. ***

---

## Technologies Used

The main project will be an ASP.NET MVC application. It will be written in C#, bootstrap, and javascript. Entity Framework will be used for database mapping.
 

---

## Features Implemented from List Provided by Code Louisville

*** This is a work in progress. The application currently implements the following minimum specs from Code Louisville requirements: ***
 - The database schema will contain mulitple tables - LINQ will be utilized to retrieve data from one or more tables and related entities.
 - The Maintenance menu contains a Track menu item. The list displayed as a result of choosing Track is pulled from an API within the application.
 - Data within the application is asynchronous.
 - The application runs Raw SQL commands to seed the database.

 ---

 ## Instructions to run
 
 1. After cloning or downloading the zip file, open the solution in Visual Studio 2019.
 2. Ensure the MVC project is the startup project.
 3. Open Package Manager Console
 4. Run 'Update-Database' - this will create the database and apply the seed data.
 5. Run the application.

 