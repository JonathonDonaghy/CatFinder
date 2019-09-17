CatFinder - AGL Code Challenge:

challenge Specification at: http://agl-developer-test.azurewebsites.net

REQUIREMENTS
Windows OS (windows 7 and 10) (probably 8 but I dont have a machine to test on)
OR Ability to run C# code and access to windows "command window"

DEPENDANCIES (for development only)
Newtonsoft.Json

DESIGN STRUCTURE
The program was designed as a simplified Model View Controller design pattern (MVC). As CatFinder takes in no input from the user, the controller aspect of the MVC is redundant. As such, there is the model that collects and retrieves the JSON body from the URL, extracts the necessary data, which is then available for the view to display. 

Design Patterns used:
Null-Object: global variables are set with a default value to avoid null-exceptions. 
Mediator: the various classes of the program don't know about each other and interact through mediator classes - In the case the Globals class and the "Main" class.


Decisions and Reasoning:



RUNTIME
Running the program will start CatFinder and use the URL �http://agl-developer-test.azurewebsites.net/people.json� to retrieve the JSON Body.
If a parameter is passed into CatFinder, this will be used as the URL to retrieve the JSON body.
