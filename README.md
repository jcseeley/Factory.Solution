# Factory Maintenance Manager

#### By Jase Seeley

#### A web application to track your engineers and the equipment they repair.

## Technologies Used
* C#
* .NET
* ASP.NET Core MVC
* Entity Core
* EF Core Migrations
* SQL
* MySQLWorkbench
* Razor
* CSHTML
* CSS
* Bootstrap

## Description

A user friendly web application for factory operators to track their engineers and equipment. Follow the provided links to add, remove, and edit engineers and machines. Navigate to an individual engineer or machine page to create new repair licenses.

## Setup/Installation Requirements

* Clone this repository to your desktop.

### Import the Database:
1. Open MySQLWorkbench and click "Local instance 3306".
2. Expand the window to uncover any hidden buttons.
3. Under the "Administration" tab, click "Data Import/Restore".
4. Select "Import from Self-Contained file".
5. To the right of the form field, click the box with ".." in it and navigate to the top level of this directory. Select the "jase_seeley.sql" file.
6. Under "Default Target Schema", click the "New..." button, enter "jase_seeley" as the schema name and click "OK". Alternatively, you may name this whatever you prefer but make sure it matches the "database" name in the "appsettings.json" file. (See below)
7. Click the "Start Import" button.
8. When the import is complete, navigate to the "Schemas" tab.
9. Right click under the list of schemas and select "Refresh All".
10. Your new schema should now appear on the list.

### Add the "appsettings.json" file:
1. Open the "Factory.Solution" folder in your code editor.
2. Right click on the "Factory" project folder and select "New File".
3. Enter "appsettings.json" in the text box and press "Enter/Return".
4. Double click the file to open it in your editor.
5. Copy and paste the code below into the file.
<pre>{  
  "ConnectionStrings": {  
    "DefaultConnection": "Server=localhost;Port=3306;database=jase_seeley;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"  
  }  
}</pre>
6. Confirm the "database" name matches the schema name from above.
7. Change the "USERNAME" and "PASSWORD" to match your MySQL information.
8. Save and close the file.

### Building and running the application:
* Make sure that "dotnet ef" is installed on your machine.
* Navigate to the "Factory" project directory in your terminal.
* Enter "dotnet restore" to install the required packages.
* Enter "dotnet build" to build the project.
* Enter "dotnet ef migrations add Initial" to create your migration file.
* Enter "dotnet ef database update" to build the database.
* To use the application, enter "dotnet run" and visit "http://localhost:5000/" in your browser.
* When finished, press "CTRL + C" in your terminal to close the application.

## Known Bugs

* No known bugs at this time.

## License

MIT

Copyright (c) 2022 Jase Seeley  