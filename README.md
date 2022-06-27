# aspmvc_react_template
This is a template project for working with ASP.net MVC and React

-----------------------------------------------------------------
Running the project:

-React/css
compiling the react/css has to be done from the command line inside "./Frontend". The compilation can be done by running "yarn compile" or "yarn watch", additionally you could also type "webpack" or "webpack watch". The react will be compiled to "./wwwroot/bundle.js" 

-dotnet
The dotnet can be run using dotnet run or dontet run watch

-----------------------------------------------------------------
Database
For this project I use a postgres database. The database name can be changed in the appsettings.json. 
You can change the daabase model inside "./Models/DBContext.cs", once you have changed the model you need to run "dotnet ef migrations add {name}" and after dotnet ef database update.
