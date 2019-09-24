# CatFinder - AGL Code Challenge:

[challenge Specification here](http://agl-developer-test.azurewebsites.net)

## REQUIREMENTS
Windows OS (windows 7 and 10) (probably 8 but I don't have a machine to test on)
OR Ability to run .NET core C# code and access to windows "command window"


## RUNTIME
Running CatFinder.exe will start CatFinder and use the URL "http://agl-developer-test.azurewebsites.net/people.json" to retrieve the JSON Body.
If a parameter is passed into CatFinder, this will be used as the URL to retrieve the JSON body.

## Development - build and test
open the project in Visual Studio (or your prefered C# .NET compatable IDE), and choose the relevent options (run all tests, start, etc.)

to run from command line - ensure you have the dotnet [ .net SDK Download ](https://download.visualstudio.microsoft.com/download/pr/f96333a0-ed33-4ebd-9e48-8608bb62e874/525197a37079042c52003753049e443c/dotnet-sdk-2.2.402-osx-gs-x64.pkg) 
build and run project:
```
Command Prompt
dotnet run --project (Path)\CatFinder\CatFinder.csproj
```

run tests
```
Command Prompt
dotnet test (Path)\CatFinderTests\CatFinderTests.csproj
```



## DEPENDANCIES (for development only)
Newtonsoft.Json
 - This is also used for the test project, in install packages on a secondary project in Visual Studio, right click it's resources folder and select "Manage NuGet Packages".
 
Install using NuGet Package Manger
```
NuGet Package Manger Console: 
install-package Newtonsoft.Json
```

System.linq
Install using NuGet Package Manger
```
NuGet Package Manger Console: 
install-package System.linq
```



## DESIGN
The program was designed as a simplified Model View Controller design pattern (MVC). As CatFinder takes in no input from the user, the controller aspect of the MVC is redundant. As such, there is the model that collects and retrieves the JSON body from the URL, extracts the necessary data, which is then available for the view to display. 

## Design Patterns used:
Null-Object: global variables are set with a default value to avoid null-exceptions. 
Mediator: the various classes of the program don't know about each other and interact through mediator classes in this case the "Main" class.


## Design Decisions:
Newtonsoft's json and linq componets were used for the extraction and sorting of the nessassary data from the JSON provided. This was done to reduce unessassary code and streamline the processing.

The *Lock Design pattern* was investigated for CatFinder, but due to the liner nature of the program was decided to be un-necessary. In regards to future development, there would not be a significant increase in development time to add Locks when they became necessary. 

The processing portion of the program was implemented as a factory to implement Inversion of Control, to ensure that if further work was done on the project, the 'CatFinder' implementation would remain robust.



The structure of the *Cats dictionary* was used to efficiently store the needed information. With the structure the view can loop through the dictionary and print the values. The Dictionary to store the values, the Ilist of JObjects to store the cat infomation was used to simplify the conversion between the Linq data extraction and data storage.
The dictionary also has the effect that any additional gender options given will be accepted by the program and added onto the Dictionary, and later the View.

*In the event further functionality was required*, to additionally list dogs pets or owner infomation, there are two options available for extending the current design. 
If only one or two additional pet types were to be added to the display, the LINQ expression could be updated to collect and sore that infomation as well. In the event that several pet types were to be added, or unknown pet types, dynamic allocation would be preferable/required. You could wrap it up in an additional dictionary layer with the parent dictionary’s key being the pet-type, however this would result in a rather messy implementation. As such I would recommend creating a class(PetTypeDetails) to replace the current cats dictionary, with ownerGender, petType and PetNames values. This would be less efficient than using a dictionary, but would be more versatile and easier to read/understand. this could still be populated using modified versions of the existing linq statement.
